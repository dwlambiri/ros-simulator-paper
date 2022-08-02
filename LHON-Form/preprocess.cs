
using System;
using System.Diagnostics;
using System.Linq;
using Cudafy;
using Cudafy.Host;
//using MathNet.Numerics.LinearAlgebra.Solvers;
using Mono.CSharp;

namespace LHON_Form
{
    public partial class Main_Form
    {

        // ========================
        //      Constants
        // ========================

        //private int process_clearance = 2;

        // ========================
        //      Parameters
        // ========================

        /* Units:
        [DWL] 

        Constant                        UI Unit                  Algorithm Unit          Conversion Factor     Comments
        k_time_iter,                     sec
        k_detox_intra_rgc,               1/s
        k_detox_outside_rgc,             1/s

        k_rate_live_axon_xy,             um^2/s
        k_rate_live_axon_z,              um^2/s
        k_rate_membrane,                 um^2/s  
        k_rate_dead_axon_xy,             um^2/s  
        k_rate_dead_axon_z,              um^2/s
        k_rate_extra_xy,                 um^2/s
        k_rate_extra_z;                  um^2/s

        k_rgc_apoptosis_thres,           uMol (zmol/um^3)
        k_glia_apoptosis_thres,          uMol (zmol/um^3)
        k_insult_tox,                    uMol (zmol/um^3)
        k_initial_ros                    uMol (zmol/um^3)

        k_tox_rgc_prod,                  uMol/s (zmol/um^3/s)
        k_tox_glia_prod,                 uMol/s (zmol/um^3/s)
        k_tox_apoptosis_rgc_prod,        uMol/s (zmol/um^3/s)
        k_tox_apoptosis_glia_prod,       uMol/s (zmol/um^3/s)
        */

        private const float noToxProd_c = -1F;
        private const float uniformRandom_c = -1F;
        private const float gaussianRandom_c = -2F;

        private float k_time_iter, k_detox_intra_rgc, k_detox_outside_rgc, k_detox_mito;
        private float k_rate_live_axon_xy, k_rate_live_axon_z, k_rate_membrane, k_rate_membrane_dead, k_rate_membrane_stress;
        private float k_rate_dead_axon_xy, k_rate_dead_axon_z, k_rate_extra_xy, k_rate_extra_z;
        private float k_rate_tissue_xy, k_rate_tissue_z;
        private float k_rgc_h2s_thres, k_glia_h2s_thres, k_rgc_s2h_thres, k_glia_s2h_thres , k_rgc_s2d_thres, k_glia_s2d_thres;  // health 2 stress threshold
        private float k_insult_tox, k_initial_ros;
        private float k_tox_healthy_rgc_prod, k_tox_stress_rgc_prod; 
        private float k_tox_healthy_glia_prod, k_tox_stress_glia_prod;
        private float k_tox_healthy_rgc_fraction, k_tox_stress_rgc_fraction;
        private float k_tox_healthy_glia_fraction, k_tox_stress_glia_fraction;
        private float k_tox_healthy_tissue_prod;


        /**
         * [DWL] volume amount of the sample
         *       this is used in  both the 2D a nd 3D cases
         */

        private float bioVolume; // in um^3


        // ====================================
        //              Variables
        // ====================================
        /**
         * [DWL] Species related data structures
         *  When adding extra species these data structures must be duplicate *per species*
         */
        private float[] toxArray, toxArray_dev; // Tox
        private byte[] diffusionRateIndexArray, diffusionRateIndexArray_dev; // [DWL] indexes into diffusionRatesVector each pixel for all pixel neighbours. they are indexes into diffusionRatesVector
        private float[] diffusionRatesVector, diffusionRatesVector_dev; //[DWL] vector of diffusion rate values. diffusionRatesVector[rate_zero_index]=0; diffusionRatesVector[rate_one_index]=1;
        private float[] diffusionRatesMyelinVector, diffusionRatesMyelinVector_dev; //[DWL] vector of diffusion rate values. diffusionRatesVector[rate_zero_index]=0; diffusionRatesVector[rate_one_index]=1;
        private float[] detoxArray, detoxArray_dev; // Detox
        private float[] toxProdArray, toxProdArray_dev; // Tox_prod
        private int[] regionalMask, regionalMask_dev; // mark the topoZone region the voxel belongs to. -1 means outside the sample. 0 to opticNerveZones-1 (7) representes the zone.

        private readonly int unAssignedPixel_c = -1;
        private readonly int gliaPixel_c = -2;
        private int[] assignedPixelMap, assignedPixelMap_dev; // [DWL] stores the index of the axon that occupies a pixel; map is used to ensure each pixel belongs to only 1 axon

        private int[] voxelProdKind, voxelProdKind_dev; // -1 unassigned, 0 tissue_prod, 1 glia_mito, 2 glia_other_prod, 3 membrane, 4 rgc_mito 5 rgc_other_prod

        private readonly int voxelNoProd_c = -1;
        private readonly int tissueProd_c = 0;
        private readonly int voxelGliaMito_c = 1;
        private readonly int voxelGliaProd_c = 2;
        private readonly int voxelMembrane_c = 3;
        private readonly int voxelRgcMito_c = 4;
        private readonly int voxelRgcProd_c = 5;
        /**
         * [DWL] RGC specific data structures. when adding new cell *types* some of these structures must be replicated
         */
        private uint[] ghZoneMappingVector; // [DWL] this vector keeps track off the Garth-Heath zone
        private uint[] topoZoneMappingVector; // [DWL] this vector keeps track off the topo zone
        private float[] randProdArray; // [DWL] random number to multiply the production in plane by
        private float[] randSODArray; // [DWL] random number to multiply the SOD in plane by
        private float[] myelinArray; // [DWL] stores random number to multiply the live diffusion rate through membrane
        private float[] h2sThrVector, h2sThrVector_dev; // [DWL] health to stress threshold for each axon
        private float[] s2hThrVector, s2hThrVector_dev; // [DWL] stress to health threshold for each axon
        private float[] s2dThrVector, s2dThrVector_dev; // [DWL] stress to death threshold for each axon
        private float[] hProdVector, hProdVector_dev; // [DWL] health prod array for each axon
        private float[] sProdVector, sProdVector_dev; // [DWL] health prod array for each axon

        private int[] pixelsInAxon; //[DWL] 
        private int[] mitoPixels; //[DWL]
        private float[] mitoPercent; //[DWL]

        private uint[] axonsCentPixVector, axonsCentPixVector_dev; // Center pixel of each axon
        private uint[] axonsInsidePixVector, axonsInsidePix_dev; // 1D array for all axons
        private uint[] axonsInsidePixIndexVector, axonsInsidePixIndexVector_dev; // indices for the above 1D array
        private uint[] axonsSurrRateVector, axonSurrRateVector_dev; // 1D indices of rate array that have the boundary rate and are outside axons
        private uint[] axonsSurrRateIndexVector, axonSurrRateIndexVector_dev; // indices for above array
        private uint[] idCenterAxonVector, idCenterAxonVector_dev; //axon id for center pixels; rest are zeros
        private uint[] axonDeathIterationVector, axonDeathIterationVector_dev; // death iteration of each axon
        private uint[] axonDiameterVector; // axon diameter in 0.1 um increments

        /**
         * [DWL] Glia related data structures
         */
        private uint[] gliaCenterVector, gliaCenterVector_dev;
        private byte[] gliaStateVector, gliaStateVector_dev;
        private uint[] gliaDeathTimerVector, gliaDeathTimerVector_dev;
        
        private float gliaFractionOfTotalTissue;
        private float sodFractionOfTotalTissue;
        private int maximumGliaCells;
        private int totalGliaCells;

        /**
         * [DWL] Display specific data structures
         */
        private byte[] simulationMaskArray, simulationMaskArray_dev;
        private uint[] imageAxonCenterVector, imageAxonCenterVector_dev;
        // Index of pixels inside the nerve (used for cuda functions)
        private int[] pixIndexArray, pixIndexArray_dev;
        private int pixInsideNerveCount; // number of pixels inside the nerve

        private uint[] imageGliaCenterVector, imageGliaCenterVector_dev; // [DWL] glia display data structures


        // [DWL] Both RGCs and glia cells are in one of the following states
        // 0 == dead
        // 1 == healthy
        // 2 == stress
        //

        private readonly byte cell_state_dead = 0;
        private readonly byte cell_state_healthy = 1;
        private readonly byte cell_state_stress = 2;

        private readonly byte rgc_display_dead = 0;
        private readonly byte rgc_display_healthy = 1;
        private readonly byte rgc_display_stress = 2;

        private readonly byte glia_display_dead = 4;
        private readonly byte glia_display_healthy = 5;
        private readonly byte glia_display_stress = 6;

        private readonly byte tissue_pixel = 127;
        private readonly byte outside_tissue_pixel = 255;

    
        private byte[] rgcStateVector, rgcStateVector_dev;
        private int[] rgcDeathTimerVector, rgcDeathTimerVector_dev;
        private int[] numAliveRGC = new int[1], numAliveRGC_dev;
        private int[] numStressRGC = new int[1], numStressRGC_dev;
        private bool[] axon_is_init_insult;
        private bool[] axon_is_large; // For display purposes


        /**
         * [DWL] number of iterations to execute during apoptosis
         *       is is calculated based on the apoptosis time
         *       and the time per iteration
         */
        private int rgc_apoptosis_iterations;
        private int glia_apoptosis_iterations;


        /**
         * [DWL] the following constants determine the 
         *       index in the diffusionRatesVector
         *       a diffusion rate is calculated as
         *       diffusionRatesVector[diffusionRateIndexArray[pixelIndex]]
         * 
         */

        private readonly byte rate_zero_index = 0;
        private readonly byte rate_live_index = 1;
        private readonly byte rate_membrane_index = 2;
        private readonly byte rate_membrane_dead_index = 3;
        private readonly byte rate_dead_index = 4;
        private readonly byte rate_extra_index = 5;
        private readonly byte rate_live_z_index = 6;
        private readonly byte rate_extra_z_index = 7;
        private readonly byte rate_dead_z_index = 8;
        private readonly byte rate_membrane_stress_index = 9;
        private readonly byte rate_tissue_index_xy = 10;
        private readonly byte rate_tissue_index_z = 11;
        private readonly byte rate_one_index = 12;
        private readonly byte rate_values_size = 13;

        private readonly uint rateUpLayerIndex = 4;
        private readonly uint rateDownLayerIndex = 5;
        private readonly int  maxArrayIndex_c= 0X7FEFFFFF;

        
        private readonly uint plane_neighbours = 4;
        private readonly uint space_neighbours = 6;

        private int pixelNeighbourNumbers;

        private ushort im_size;
        private bool preprocessDone = false;
        private bool simulationDone = false;
        private bool simInProgress = false;

        private int showdir = 0; // 0 is xy, 1 is xz, 2 is yz

        private int headLayer = 2;

        static private float fullDetox = 0F;
        static private float noDetox = 1F - fullDetox;

        private double norm_mu = 0.5;
        private double norm_sigma = 0.15;

        private float prodConv;
        private float voxelVolume; // [DWL] voxel (ie pixel) volume in um^3; this is 1/prodConv

        /*
         * [DWL] We are using an 8 zone Garway-Heath map
         * [DWL] the zones are numbered 1 to 8. 
         * [DWL] Numbering starts clockwise from left
         * [DWL] Mapping
         * 1 - (0, 40]
         * 2 - (40, 80]
         * 3 - (80, 120]
         * 4 - (120, 180]
         * 5 - (180, 230]
         * 6 - (230, 270]
         * 7 - (270, 320]
         * 8 - (320, 360]
         */

        private const int opticNerveZones = 8;

        float[] ghZoneAngles = {40, 80, 120, 180, 230, 270, 320, 360 };// {40,40,40,60,50,40,40,50 };

        float max_mdl_diam = 0;  // maximum model axon diameter in 0.1 um units!!! for um divide this value by 10


        /*
         * [Aug 2021]
         * [DWL] We are using an 8 zone topo map
         * [DWL] the zones are numbered 1 to 8. 
         * [DWL] Numbering starts clockwise from left
         * [DWL] Each zone is a sector of 45 degress
         * [DWL] Temporal zone (T) is made of 2 22.5 degree segments.
         * [DWL] Mapping
         * 
         * 1 - ST (22.5, 67.5]
         * 2 - S  (67.5, 112.5]
         * 3 - SN (112.5, 157.5]
         * 4 - N  (157.5, 202.5]
         * 5 - IN (202.5, 247.5]
         * 6 - I  (247.5, 292.5]
         * 7 - IT (292.5, 337.5]
         * 8 - T  (337.5, 360] U (0, 22.5]
         */

        
        float[] topoZoneAngles = { 22.5f, 67.5f, 112.5f, 157.5f, 202.5f, 247.5f, 292.5f, 337.5f, 360f }; // see above

        private const int liveHBoxes = 100;
        private const int maxTimeBoxes = 10000000;
        private int usedTimeBoxes = 0;

        // [DWL] maintains number of axons for each radius
        //       we use 100 boxes, as the max radius is < 10um
        //       indexing using the formula
        //       aliveHistogram[(int)(mdl.radius*10)];
        private int[] startHistogram = new int[liveHBoxes];
        private int[] aliveHistogram = new int[liveHBoxes];

        private int[,] startTopoZoneHistogram = new int[opticNerveZones, liveHBoxes];
        private int[,] aliveTopoZoneHistogram = new int[opticNerveZones, liveHBoxes];

        private int[,] startGHZoneHistogram = new int[opticNerveZones, liveHBoxes];
        private int[,] aliveGHZoneHistogram = new int[opticNerveZones, liveHBoxes];

        private int[] ghZoneTotal = new int[opticNerveZones];
        private int[] topoZoneTotal = new int[opticNerveZones];

        int[] aliveZoneTotal = new int[opticNerveZones];
        int[] stressZoneTotal = new int[opticNerveZones];
        int[] deadZoneTotal = new int[opticNerveZones];

        private int[] aliveNumAxonsVec = new int[maxTimeBoxes]; // tracks the number of alive axons at each display event (alive is health + stress)
        private int[] healthyPerIterVec = new int[maxTimeBoxes]; // change in number of healthy rgc per iteration
        private int[] deadPerIterationVec = new int[maxTimeBoxes]; // number of dead axons per display event
        private int[] stressNumAxonsVec = new int[maxTimeBoxes]; // number of stressed axons per display event
        private int[] stressPerIterVec = new int[maxTimeBoxes];
        private float[] rosAmountVec = new float[maxTimeBoxes]; // stores the ros amount
        private float[] rosChangeVec = new float[maxTimeBoxes];
        private int[] iterationVec = new int[maxTimeBoxes]; // store the iteration number for the display event

        private float[] topoZoneAnglesRadian = new float[opticNerveZones+1];
        private float[] topoZoneAnglesRadian_dev;

        private float[] ghZoneAnglesRadian = new float[opticNerveZones];

        private float[] sum_zone_tox = new float[opticNerveZones];
        private float[] sum_zone_tox_dev;


        // ====================================
        //        Model Preprocessing
        // ====================================
        private ushort Calc_im_siz()
        {
            return (ushort)((mdl_nerve_r * setts.resolution_xy + 2) * 2);
        }

       /**
        * [DWL] This is the main model preprocessing method
        *       It takes a biological model and creates
        *       the data structures needed for the simulation.
        *       
        *       This method does 
        *       1) the parameter translation from UI to computer sim units
        *       2) setup of all in cpu memory data structures
        * 
        *       Please note that this method uses the GPU to do 
        *       preprocessing. The GPU is used to bulk set constants
        *       in the data structure via cuda_prep0 function
        *       
        *       It also uses cuda_prep1.cu as a post-processing step.
        */
        private void Preprocess_model()
        {


            for(int i=0; i<liveHBoxes;i++)
            {
                for(int j=0;j<opticNerveZones;j++)
                {
                    startTopoZoneHistogram[j, i] = 0;
                    startGHZoneHistogram[j, i] = 0;
                }
            }

            Random rnd = new Random();

            if (setts.no3dLayers > 1)
                headLayer = 2;
            else
                headLayer = 0;
            // =======================================
            //              Init Parameters
            // =======================================

            sim_stat = Sim_stat_enum.None;
            ResetPlaneViewer();
            DisableButtons();

            usedTimeBoxes = 1;
            numStressRGC[0] = 0;
            max_mdl_diam = 0;

            for(int i=0; i < opticNerveZones; i++)
            {
                ghZoneTotal[i] = topoZoneTotal[i] = 0;
                sum_zone_tox[i] = 0f;
            }


            float mdl_real_radius = mdl.real_diameter / 2;

            if(setts.resolution_xy == 0)
            {
                setts.resolution_xy = 2;
                Append_stat_ln("Warning: Zero XY resolution detected. Setting to 2!");
            }

            if(setts.resolution_xy * mdl.clearance < 2)
            {
                Append_stat_ln("Warning: Spatial distance between axons is less than 2 pixels.");
                Append_stat_ln("Warning: Increase clearance or XY resolutions such that clearance*XY_res > 2.");
            }

            if(setts.resolution_z == 0)
            {
                setts.resolution_z = 1;
                Append_stat_ln("Warning: Zero Z resolution detected. Setting to 1!");
            }
#if false
            if(setts.no3dLayers > 1)
            {
                setts.percentGlia = 0;
                Update_glia_perc();
                Append_stat_ln("Warning: Glia supported only for single layer simulation. Setting to zero. ");
            }
#endif
            gliaFractionOfTotalTissue = setts.percentGlia / 100;
            sodFractionOfTotalTissue = setts.percentSOD / 100;

            mdl_nerve_r = mdl.nerve_scale_ratio * mdl.real_diameter/2 * setts.retinaMult;
            float mdl_on_r = mdl.nerve_scale_ratio * mdl.real_diameter/2;

            float pow2resxy = Pow2(setts.resolution_xy);
            float pow2rezz = Pow2(setts.resolution_z);
            //float pow2resxyToz = Pow2(setts.resolution_xy / setts.resolution_z);

            for (int q = 0; q < opticNerveZones + 1; q++)
            {
                topoZoneAnglesRadian[q] = (float)(topoZoneAngles[q] * Math.PI / 180);
            }

            for (int q = 0; q < opticNerveZones; q++)
            {
                ghZoneAnglesRadian[q] = (float)(ghZoneAngles[q] * Math.PI / 180);
            }

            float extraTerm = (setts.no3dLayers>1) ? (float)(1.0) : 0;

            int countForMax = 6;
            float[] diffSum = new float[countForMax];
            
            diffSum[0] = (2 * setts.diff_coeff_live_xy * pow2resxy + extraTerm * setts.diff_coeff_live_z * pow2rezz);
            diffSum[1] = (2 * setts.diff_coeff_dead_xy * pow2resxy + extraTerm * setts.diff_coeff_dead_z * pow2rezz);
            diffSum[2] = (2 * setts.diff_coeff_membrane / setts.resolution_xy * pow2resxy + extraTerm * setts.diff_coeff_live_z * pow2rezz);
            diffSum[3] = (2 * setts.diff_coeff_glia_xy * pow2resxy + extraTerm * setts.diff_coeff_glia_z * pow2rezz);
            diffSum[4] = (2 * setts.diff_coeff_membrane_dead  / setts.resolution_xy * pow2resxy + extraTerm * setts.diff_coeff_glia_z * pow2rezz);
            diffSum[5] = (2 * setts.diff_coeff_membrane / setts.resolution_xy * pow2resxy + extraTerm * setts.diff_coeff_glia_z * pow2rezz); // set same as membrane; simplify

            float maxDiffSum = diffSum[0];

            for(int i=0; i <countForMax; i++)
            {
                if(maxDiffSum < diffSum[i])
                {
                    maxDiffSum = diffSum[i];
                }
            }

            k_time_iter = setts.alpha / 2 / (maxDiffSum); //in seconds

           
            bioVolume = (float)(Pow2(mdl_nerve_r) * Math.PI * (setts.no3dLayers > 1? setts.no3dLayers:1) / setts.resolution_z);
            
            prodConv = Pow2(setts.resolution_xy) * setts.resolution_z ;
            voxelVolume = 1 / prodConv;
           
            // "setts" are user input with physical units

            //[DWL] ** Not sure how to scale the detox factors
            

            k_detox_intra_rgc = setts.detox_rgc_intra *k_time_iter ;
            k_detox_outside_rgc = setts.detox_rgc_extra *k_time_iter;
            k_detox_mito = setts.detox_mito * k_time_iter;

            if (k_detox_intra_rgc < 0) k_detox_intra_rgc = 0;
            if (k_detox_intra_rgc > 1) k_detox_intra_rgc = 1;

            if (k_detox_mito< 0) k_detox_mito = 0;
            if (k_detox_mito > 1) k_detox_mito = 1;

            if (k_detox_outside_rgc < 0) k_detox_outside_rgc = 0;
            if (k_detox_outside_rgc > 1) k_detox_outside_rgc = 1;

            rgc_apoptosis_iterations = (int)Math.Ceiling(setts.rgc_stress_to_apoptosis_ms / k_time_iter / 1000);
            glia_apoptosis_iterations = (int)Math.Ceiling(setts.glia_stress_to_apoptosis_ms / k_time_iter / 1000);

            //[DWL] user inputs in uMol/bioSec
            //[DWL] uMol is zmol/um^3 => user inputs are in zmol/um^3/bioSec
            //[DWL] using voxelVolume we transform onto zmol/voxel (ie pixel)
            //[DWL] multiplying by k_time_iter we transform into zmol/voxel/iter
            k_tox_healthy_rgc_prod = setts.tox_rgc_mito_prod * voxelVolume * k_time_iter;
            k_tox_healthy_glia_prod = setts.tox_glia_mito_prod * voxelVolume * k_time_iter;

            k_tox_healthy_tissue_prod = setts.tox_tissue_prod * voxelVolume * k_time_iter;
            if (setts.tox_rgc_mito_prod == 0) k_tox_healthy_rgc_fraction = 0;
            else
            {
                k_tox_healthy_rgc_fraction = setts.tox_rgc_cyto_prod / setts.tox_rgc_mito_prod;
            }

            if (setts.tox_rgc_mito_stress_prod == 0) k_tox_stress_rgc_fraction = 0;
            else
            {
                k_tox_stress_rgc_fraction = setts.tox_rgc_cyto_stress_prod / setts.tox_rgc_mito_stress_prod;
            }

            if (setts.tox_glia_mito_prod == 0) k_tox_healthy_glia_fraction = 0;
            else
            {
                k_tox_healthy_glia_fraction = setts.tox_inter_cellular_prod / setts.tox_glia_mito_prod;
            }

            if (setts.tox_glia_mito_stress_prod == 0) k_tox_stress_glia_fraction = 0;
            else
            {
                k_tox_stress_glia_fraction = setts.tox_inter_cellular_stress_prod / setts.tox_glia_mito_stress_prod;
            }


            prep_prof.Time(0);
            Tic();

            Update_bottom_stat("Preprocessing ...");

            im_size = Calc_im_siz();
            Update_image_siz_lbl();
            Update_delta_xy_lbl();
            Update_delta_z_lbl();
            Update_bio_iter_time_lbl();
            float nv = mdl.nerve_scale_ratio * mdl.real_diameter * setts.retinaMult;
            if (nv > 1000)
                lbl_nerve_size.Text = (nv / 1000F).ToString(".0") + " mm";
            else
                lbl_nerve_size.Text = (nv).ToString(".0") + " um";

            Init_bmp_write();

            int imsquare = im_size * im_size;

            ulong maxAllowableFloatIndex = gpuTotalMemoryB / 4;  // 4 bytes per float

            int maxIndex = (maxAllowableFloatIndex < (ulong)maxArrayIndex_c) ? (int)maxAllowableFloatIndex : maxArrayIndex_c;

            int maxNumPlanes = maxIndex/ imsquare;

            if((setts.no3dLayers >  1) && (maxNumPlanes < setts.no3dLayers+2))
            {
                setts.no3dLayers = maxNumPlanes-4;
                Append_stat_ln("Warning: Too many planes! Can only allocate " + setts.no3dLayers);
            }

            int numberOf3DLayers = (setts.no3dLayers > 1 ? setts.no3dLayers : 0);

            randProdArray = new float[numberOf3DLayers + 1];
            randSODArray = new  float[numberOf3DLayers + 1];
            myelinArray = new float[numberOf3DLayers + 1];

            
            aliveNumAxonsVec[0] = mdl.n_axons;
            deadPerIterationVec[0] = 0;
            healthyPerIterVec[0] = 0;
            stressNumAxonsVec[0] = 0;
            stressPerIterVec[0] = 0;
            rosAmountVec[0] = 0;
            rosChangeVec[0] = 0;
            iterationVec[0] = 0;


            /*
            for(int i = 0; i < setts.no3dLayers+1; i++)
            {
                //randProd[i] = (float) 1/(1+rnd.Next(0,4));
                if(setts.useRandProdFactor)
                    randProdArray[i] = (float) rnd.NextDouble();
                else
                    randProdArray[i] = 1;
            }
            */

            //Random aRand = new Random();
            //float singleMult = 1 + (float)aRand.NextDouble();

            if (setts.use3DSpecPattern)
            {
                ZStruct z = ParseZDescriptor(setts.ros3dString);
                int z0 = (int)(z.initLen * setts.resolution_z);
                int z1 = (int)(z.z1Len * setts.resolution_z);
                int z2 = (int)(z.z2Len * setts.resolution_z);
                int z3 = (int)(z.z3Len * setts.resolution_z);
                int z4 = (int)(z.z4Len * setts.resolution_z);



                int current = 0;
                Random toxRand = new Random();

                for (int i = 0; current < numberOf3DLayers + 1 && i < z0; i++)
                {

                    if (z.initVal < uniformRandom_c)
                    {
                        randProdArray[current++] = (float)NextZOGaussian(toxRand, norm_mu, norm_sigma);
                    }
                    else if (z.initVal < 0)
                    {
                        randProdArray[current++] = (float)toxRand.NextDouble();
                    }
                    else
                    {
                        randProdArray[current++] = z.initVal;
                    }
                }
                for (int j = 0; j < z.repeat; j++)
                {
                    if (z.specLen > 0)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z1; i++)
                        {

                            if (z.z1Val < uniformRandom_c)
                            {

                                randProdArray[current++] = (float)NextZOGaussian(toxRand, norm_mu, norm_sigma); ;
                            }
                            else if (z.z1Val < 0)
                            {
                                randProdArray[current++] = (float)toxRand.NextDouble();
                            }
                            else
                            {
                                randProdArray[current++] = z.z1Val;
                            }
                        }
                    }

                    if (z.specLen > 1)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z2; i++)
                        {

                            if (z.z2Val < uniformRandom_c)
                            {

                                randProdArray[current++] = (float)NextZOGaussian(toxRand, norm_mu, norm_sigma); ;
                            }
                            else if (z.z2Val < 0)
                            {
                                randProdArray[current++] = (float)toxRand.NextDouble();
                            }
                            else
                            {
                                randProdArray[current++] = z.z2Val;
                            }
                        }
                    }
                    if (z.specLen > 2)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z3; i++)
                        {

                            if (z.z3Val < uniformRandom_c)
                            {

                                randProdArray[current++] = (float)NextZOGaussian(toxRand, norm_mu, norm_sigma); ;
                            }
                            else if (z.z3Val < 0)
                            {
                                randProdArray[current++] = (float)toxRand.NextDouble();
                            }
                            else
                            {
                                randProdArray[current++] = z.z3Val;
                            }
                        }
                    }
                    if (z.specLen > 3)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z4; i++)
                        {

                            if (z.z4Val < uniformRandom_c)
                            {

                                randProdArray[current++] = (float)NextZOGaussian(toxRand, norm_mu, norm_sigma); ;
                            }
                            else if (z.z4Val < 0)
                            {
                                randProdArray[current++] = (float)toxRand.NextDouble();
                            }
                            else
                            {
                                randProdArray[current++] = z.z4Val;
                            }
                        }
                    }

                    if (current >= numberOf3DLayers + 1) break;
                }
            }
            else
            {
                for (int i = 0; i < numberOf3DLayers + 1; i++)
                {
                    randProdArray[i] = 1;
                }
            }

            if (setts.use3DSpecPattern)
            {
                ZStruct z = ParseZDescriptor(setts.sod3dString);
                int z0 = (int)(z.initLen * setts.resolution_z);
                int z1 = (int)(z.z1Len * setts.resolution_z);
                int z2 = (int)(z.z2Len * setts.resolution_z);
                int z3 = (int)(z.z3Len * setts.resolution_z);
                int z4 = (int)(z.z4Len * setts.resolution_z);

                int current = 0;
                Random sodRand = new Random();
                for (int i = 0; current < numberOf3DLayers + 1 && i < z0; i++)
                {

                    if (z.initVal < uniformRandom_c)
                    {

                        randSODArray[current++] = (float)NextZOGaussian(sodRand, norm_mu, norm_sigma);
                    }
                    else if (z.initVal < 0)
                    {
                        randSODArray[current++] = (float)sodRand.NextDouble();
                    }
                    else
                    {
                        randSODArray[current++] = z.initVal;
                    }
                }
                for (int j = 0; j < z.repeat; j++)
                {
                    if (z.specLen > 0)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z1; i++)
                        {

                            if (z.z1Val < uniformRandom_c)
                            {

                                randSODArray[current++] = (float)NextZOGaussian(sodRand, norm_mu, norm_sigma);
                            }
                            else if (z.z1Val < 0)
                            {
                                randSODArray[current++] = (float)sodRand.NextDouble();
                            }
                            else
                            {
                                randSODArray[current++] = z.z1Val;
                            }
                        }
                    }

                    if (z.specLen > 1)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z2; i++)
                        {
                            if (z.z2Val < uniformRandom_c)
                            {

                                randSODArray[current++] = (float)NextZOGaussian(sodRand, norm_mu, norm_sigma);
                            }
                            else if (z.z2Val < 0)
                            {
                                randSODArray[current++] = (float)sodRand.NextDouble();
                            }
                            else
                            {
                                randSODArray[current++] = z.z2Val;
                            }
                        }
                    }

                    if (z.specLen > 2)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z3; i++)
                        {
                            if (z.z3Val < uniformRandom_c)
                            {

                                randSODArray[current++] = (float)NextZOGaussian(sodRand, norm_mu, norm_sigma);
                            }
                            else if (z.z3Val < 0)
                            {
                                randSODArray[current++] = (float)sodRand.NextDouble();
                            }
                            else
                            {
                                randSODArray[current++] = z.z3Val;
                            }
                        }
                    }

                    if (z.specLen > 3)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z4; i++)
                        {
                            if (z.z4Val < uniformRandom_c)
                            {

                                randSODArray[current++] = (float)NextZOGaussian(sodRand, norm_mu, norm_sigma);
                            }
                            else if (z.z4Val < 0)
                            {
                                randSODArray[current++] = (float)sodRand.NextDouble();
                            }
                            else
                            {
                                randSODArray[current++] = z.z4Val;
                            }
                        }
                    }

                    if (current >= numberOf3DLayers + 1) break;
                }
            }
            else
            {
                for (int i = 0; i < numberOf3DLayers + 1; i++)
                {
                    randSODArray[i] = 1;
                }
            }

            //[DWL] we can do diffusion multipliers for membrane ONLY

            if (setts.use3DSpecPattern)
            {
                ZStruct z = ParseZDescriptor(setts.mem3dString);
                int z0 = (int)(z.initLen * setts.resolution_z);
                int z1 = (int)(z.z1Len * setts.resolution_z);
                int z2 = (int)(z.z2Len * setts.resolution_z);
                int z3 = (int)(z.z3Len * setts.resolution_z);
                int z4 = (int)(z.z4Len * setts.resolution_z);

                int current = 0;
                Random permRand = new Random();

                for (int i = 0; current < numberOf3DLayers + 1 && i < z0; i++)
                {

                    if (z.initVal < uniformRandom_c)
                    {
                        myelinArray[current++] = (float)NextZOGaussian(permRand, norm_mu, norm_sigma);
                    }
                    else if (z.initVal < 0)
                    {
                        myelinArray[current++] = (float)permRand.NextDouble();
                    }
                    else
                    {
                        myelinArray[current++] = z.initVal;
                    }
                }
                for (int j = 0; j < z.repeat; j++)
                {
                    if (z.specLen > 0)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z1; i++)
                        {

                            if (z.z1Val < uniformRandom_c)
                            {
                                myelinArray[current++] = (float)NextZOGaussian(permRand, norm_mu, norm_sigma);
                            }
                            else if (z.z1Val < 0)
                            {
                                myelinArray[current++] = (float)permRand.NextDouble();
                            }
                            else
                            {
                                myelinArray[current++] = z.z1Val;
                            }
                        }
                    }

                    if (z.specLen > 1)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z2; i++)
                        {
                            if (z.z2Val < uniformRandom_c)
                            {
                                myelinArray[current++] = (float)NextZOGaussian(permRand, norm_mu, norm_sigma);
                            }
                            else if (z.z2Val < 0)
                            {
                                myelinArray[current++] = (float)permRand.NextDouble();
                            }
                            else
                            {
                                myelinArray[current++] = z.z2Val;
                            }
                        }
                    }

                    if (z.specLen > 2)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z3; i++)
                        {
                            if (z.z3Val < uniformRandom_c)
                            {
                                myelinArray[current++] = (float)NextZOGaussian(permRand, norm_mu, norm_sigma);
                            }
                            else if (z.z3Val < 0)
                            {
                                myelinArray[current++] = (float)permRand.NextDouble();
                            }
                            else
                            {
                                myelinArray[current++] = z.z3Val;
                            }
                        }
                    }

                    if (z.specLen > 3)
                    {
                        for (int i = 0; current < numberOf3DLayers + 1 && i < z4; i++)
                        {
                            if (z.z4Val < uniformRandom_c)
                            {
                                myelinArray[current++] = (float)NextZOGaussian(permRand, norm_mu, norm_sigma);
                            }
                            else if (z.z4Val < 0)
                            {
                                myelinArray[current++] = (float)permRand.NextDouble();
                            }
                            else
                            {
                                myelinArray[current++] = z.z4Val;
                            }
                        }
                    }

                    if (current >= numberOf3DLayers + 1) break;
                }
            }
            else
            {
                for (int i = 0; i < numberOf3DLayers + 1; i++)
                {
                    myelinArray[i] = 1;
                }
            }


            //int max_pixels_in_nerve = (int)(Pow2(mdl_nerve_r * setts.resolution_xy) * (1 - Pow2(mdl_vessel_ratio)) * Math.PI);
            float mult = 1;
#if false
            if(setts.resolution_xy < 2)
            {
                mult = 5F;
            }
            else if(setts.resolution_xy < 5)
            {
                mult = 1.5F;
            }
            else if(setts.resolution_xy < 10)
            {
                mult = 1.2F;
            }
            else
            {
                mult = 1F;
            }
#endif
            int max_pixels_in_nerve = (int)Math.Ceiling(Pow2(mult*mdl_nerve_r * setts.resolution_xy)  * 4);

            pixelNeighbourNumbers = setts.no3dLayers >1 ? (int)space_neighbours : (int)plane_neighbours;

            if ( maxIndex / max_pixels_in_nerve < pixelNeighbourNumbers)
            {
                Append_stat_ln("Fatal Error: Model too large. Aborting preprocess... ");
                EnableButtons();
                return;
            }

            //float neighbourPlus1 = pixelNeighbourNumbers+1;
            //float limitDiff = 1 / neighbourPlus1;

            // [DWL] User setts diffusion coefficients in um^2/s
            // [DWL] We need to transform into dimensionless diffusion rates
            k_rate_live_axon_xy = setts.diff_coeff_live_xy *pow2resxy *k_time_iter;
            k_rate_live_axon_z = setts.diff_coeff_live_z*pow2rezz *k_time_iter;

            k_rate_membrane = setts.diff_coeff_membrane / setts.resolution_xy * pow2resxy *k_time_iter;
            k_rate_membrane_dead = setts.diff_coeff_membrane_dead / setts.resolution_xy * pow2resxy *k_time_iter;
            k_rate_membrane_stress = setts.diff_coeff_membrane / setts.resolution_xy * pow2resxy * k_time_iter; // set same as membrane; simplify

            k_rate_tissue_xy = setts.perm_coeff_tissue / setts.resolution_xy * pow2resxy * k_time_iter;
            k_rate_tissue_z = setts.perm_coeff_tissue / setts.resolution_xy * pow2rezz * k_time_iter;

            k_rate_dead_axon_xy = setts.diff_coeff_dead_xy *pow2resxy *k_time_iter;
            k_rate_dead_axon_z = setts.diff_coeff_dead_z *pow2rezz *k_time_iter;

            k_rate_extra_xy = setts.diff_coeff_glia_xy *pow2resxy *k_time_iter;
            k_rate_extra_z = setts.diff_coeff_glia_z *pow2rezz *k_time_iter;

            /**
             * [DWL] the following variables are in zmol/point
             *       user inputs in uMol; this is same as zmol/um^3
             *       using voxelVolume we can transform into per point
             */

            k_rgc_h2s_thres = setts.rgc_apoptosis_tox_threshold *voxelVolume;
            k_glia_h2s_thres = setts.glia_apoptosis_tox_threshold *voxelVolume;
            k_rgc_s2h_thres = setts.s2h_rgc_tox_thr * voxelVolume;
            k_glia_s2h_thres = setts.s2h_glia_tox_thr * voxelVolume;
            k_rgc_s2d_thres = setts.s2d_rgc_tox_thr * voxelVolume;
            k_glia_s2d_thres = setts.s2d_glia_tox_thr * voxelVolume;

            k_insult_tox = setts.insult_tox *voxelVolume;

            k_initial_ros = setts.initial_tox_value *voxelVolume;

            // [DWL] 
            k_tox_stress_rgc_prod = setts.tox_rgc_mito_stress_prod * voxelVolume * k_time_iter;
            k_tox_stress_glia_prod = setts.tox_glia_mito_stress_prod * voxelVolume * k_time_iter;

            // ======== diffusionRatesArray initialization =========

            diffusionRateIndexArray = new byte[imsquare * pixelNeighbourNumbers];


            diffusionRatesVector = new float[rate_values_size];

            
            diffusionRatesVector[ rate_zero_index] = 0;
            diffusionRatesVector[rate_live_index] = k_rate_live_axon_xy;
            diffusionRatesVector[rate_membrane_index] = k_rate_membrane;
            diffusionRatesVector[rate_membrane_dead_index] = k_rate_membrane_dead;
            diffusionRatesVector[rate_dead_index] = k_rate_dead_axon_xy;
            diffusionRatesVector[rate_extra_index] = k_rate_extra_xy;
            diffusionRatesVector[rate_live_z_index] = k_rate_live_axon_z;
            diffusionRatesVector[rate_extra_z_index] = k_rate_extra_z;
            diffusionRatesVector[rate_dead_z_index] = k_rate_dead_axon_z;
            diffusionRatesVector[rate_membrane_stress_index] = k_rate_membrane_stress;
            diffusionRatesVector[rate_tissue_index_xy] = k_rate_tissue_xy;
            diffusionRatesVector[rate_tissue_index_z] = k_rate_tissue_z;
            diffusionRatesVector[rate_one_index] = 1;


            diffusionRatesMyelinVector = new float[rate_values_size * (numberOf3DLayers + 1)];

            for (int i = 0; i < numberOf3DLayers + 1; i++)
            {

                diffusionRatesMyelinVector[i * rate_values_size + rate_zero_index] = 0;
                diffusionRatesMyelinVector[i * rate_values_size + rate_live_index] = k_rate_live_axon_xy;
                diffusionRatesMyelinVector[i * rate_values_size + rate_membrane_index] = k_rate_membrane * myelinArray[i];
                diffusionRatesMyelinVector[i * rate_values_size + rate_membrane_dead_index] = k_rate_membrane_dead;
                diffusionRatesMyelinVector[i * rate_values_size + rate_dead_index] = k_rate_dead_axon_xy;
                diffusionRatesMyelinVector[i * rate_values_size + rate_extra_index] = k_rate_extra_xy;
                diffusionRatesMyelinVector[i * rate_values_size + rate_live_z_index] = k_rate_live_axon_z;
                diffusionRatesMyelinVector[i * rate_values_size + rate_extra_z_index] = k_rate_extra_z;
                diffusionRatesMyelinVector[i * rate_values_size + rate_dead_z_index] = k_rate_dead_axon_z;
                diffusionRatesMyelinVector[i * rate_values_size + rate_membrane_stress_index] = k_rate_membrane_stress;
                diffusionRatesMyelinVector[i * rate_values_size + rate_tissue_index_xy] = k_rate_tissue_xy;
                diffusionRatesMyelinVector[i * rate_values_size + rate_tissue_index_z] = k_rate_tissue_z;
                diffusionRatesMyelinVector[i * rate_values_size + rate_one_index] = 1;
            }


            Append_stat_ln("Membrane " + k_rate_membrane );

            detoxArray = new float[imsquare];
            toxArray = new float[imsquare];
            toxProdArray = new float[imsquare];

            idCenterAxonVector = new uint[imsquare];

            simulationMaskArray = new byte[imsquare]; // for display. if 1: axon is live, if 2: axon is dead, otherwise 0.
            pixIndexArray = new int[imsquare]; // linear index of pixels within nerve

            regionalMask = new int[imsquare];

            imageAxonCenterVector = Enumerable.Repeat((uint)0, bmp_im_size*bmp_im_size).ToArray();
            imageGliaCenterVector = Enumerable.Repeat((uint)0, bmp_im_size * bmp_im_size).ToArray();

            maximumGliaCells = (int)Math.Ceiling(1.1F * imsquare * gliaFractionOfTotalTissue);

            gliaCenterVector = new uint[maximumGliaCells];
            gliaDeathTimerVector = Enumerable.Repeat((uint)0, maximumGliaCells).ToArray();
            gliaStateVector = Enumerable.Repeat((byte)0, maximumGliaCells).ToArray(); // init to true

            assignedPixelMap = Enumerable.Repeat(unAssignedPixel_c, imsquare).ToArray();

            // ======== Axon Properties =========

            axonsCentPixVector = new uint[mdl.n_axons];
            h2sThrVector = new float[mdl.n_axons];
            s2hThrVector = new float[mdl.n_axons];
            s2dThrVector = new float[mdl.n_axons];
            hProdVector = new float[mdl.n_axons];
            sProdVector = new float[mdl.n_axons];

            pixelsInAxon = new int[mdl.n_axons];
            mitoPixels = new int[mdl.n_axons];
            mitoPercent = new float[mdl.n_axons];

            ghZoneMappingVector = new uint[mdl.n_axons];
            topoZoneMappingVector = new uint[mdl.n_axons];

            rgcStateVector = Enumerable.Repeat((byte)1, mdl.n_axons).ToArray(); // init to true
            rgcDeathTimerVector = Enumerable.Repeat(0, mdl.n_axons).ToArray();
            // temp variable 

            //Append_stat_ln("Info: imsize is" + im_size + "  mdl*res " + (mdl_nerve_r * res));

            axonsInsidePixVector = new uint[max_pixels_in_nerve];
            axonsInsidePixIndexVector = new uint[mdl.n_axons + 1];
            axonsInsidePixIndexVector[0] = 0;

            axonsSurrRateVector = new uint[max_pixels_in_nerve*pixelNeighbourNumbers];
            axonsSurrRateIndexVector = new uint[mdl.n_axons + 1];
            axonsSurrRateIndexVector[0] = 0;

            axon_is_init_insult = new bool[mdl.n_axons];

            axon_is_large = new bool[mdl.n_axons]; // For display purposes

            axonDeathIterationVector = new uint[mdl.n_axons];

            axon_lbl = new AxonLabelClass[mdl.n_axons]; // for GUI

            axonDiameterVector = new uint[mdl.n_axons];

            // ======== Local Constants =========
            int nerve_cent_pix = im_size / 2;
            int nerve_r_pix = (int)(mdl_nerve_r * setts.resolution_xy);
            int vein_r_pix = (int)(mdl.vessel_ratio * mdl_nerve_r * setts.resolution_xy);

            if(setts.retinaMult > 1)
            {
                vein_r_pix = (int)(Math.Sqrt(mdl.vessel_ratio * mdl_nerve_r) * setts.resolution_xy);
            }

            int nerve_r_pix_2 = Pow2(nerve_r_pix);
            int vein_r_pix_2 = Pow2(vein_r_pix);

            // GPU init for prep0 and prep1
            GPGPU preprocessGPUVar = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            preprocessGPUVar.FreeAll(); 
            preprocessGPUVar.Synchronize();

            pixInsideNerveCount = 0;
            diffusionRateIndexArray_dev = preprocessGPUVar.Allocate<byte>(imsquare * pixelNeighbourNumbers);
            
            detoxArray_dev = preprocessGPUVar.Allocate<float>(imsquare);
            pixIndexArray_dev = preprocessGPUVar.Allocate<int>(imsquare);
            toxProdArray_dev = preprocessGPUVar.Allocate<float>(imsquare);
            toxArray_dev = preprocessGPUVar.Allocate<float>(imsquare);
            simulationMaskArray_dev = preprocessGPUVar.Allocate<byte>(imsquare); 
            regionalMask_dev = preprocessGPUVar.Allocate<int>(imsquare);
            topoZoneAnglesRadian_dev = preprocessGPUVar.Allocate<float>(opticNerveZones+1);


            preprocessGPUVar.CopyToDevice(topoZoneAnglesRadian, topoZoneAnglesRadian_dev);

            byte[] pix_out_of_nerve_dev = preprocessGPUVar.Allocate<byte>(imsquare);
            byte[] pix_out_of_nerve = new byte[imsquare];

            int prep_siz = 32;
            dim3 block_siz_prep = new dim3(prep_siz, prep_siz);
            int tmp = (int)Math.Ceiling((double)im_size / (double)prep_siz);
            dim3 grid_siz_prep = new dim3(tmp, tmp);

            //preprocessGPUVar.CopyToDevice(rate_values, rate_values_dev);

            preprocessGPUVar.Launch(grid_siz_prep, block_siz_prep).cuda_prep0(im_size, nerve_cent_pix, nerve_r_pix_2, vein_r_pix_2,1-k_detox_outside_rgc,
                pix_out_of_nerve_dev, diffusionRateIndexArray_dev, detoxArray_dev, pixelNeighbourNumbers, toxProdArray_dev, fullDetox, toxArray_dev, k_initial_ros, simulationMaskArray_dev, regionalMask_dev, topoZoneAnglesRadian_dev, k_tox_healthy_tissue_prod, noToxProd_c);

            preprocessGPUVar.Synchronize();

            preprocessGPUVar.CopyFromDevice(pix_out_of_nerve_dev, pix_out_of_nerve);
            preprocessGPUVar.CopyFromDevice(diffusionRateIndexArray_dev, diffusionRateIndexArray);
            preprocessGPUVar.CopyFromDevice(detoxArray_dev, detoxArray);
            preprocessGPUVar.CopyFromDevice(toxProdArray_dev, toxProdArray);
            preprocessGPUVar.CopyFromDevice(toxArray_dev, toxArray);
            preprocessGPUVar.CopyFromDevice(simulationMaskArray_dev, simulationMaskArray);
            preprocessGPUVar.CopyFromDevice(regionalMask_dev, regionalMask);

            prep_prof.Time(1);
            
            float[,] AxCorPix = new float[mdl.n_axons, 3]; // axon coordinate in pixels

            // ======== Individual Axon Properties Initialization =========

            int[] box_y_min = new int[mdl.n_axons],
                box_y_max = new int[mdl.n_axons],
                box_x_min = new int[mdl.n_axons],
                box_x_max = new int[mdl.n_axons],
                box_siz_x = new int[mdl.n_axons],
                box_siz_y = new int[mdl.n_axons];


            Func<int, int, uint> xy_to_lin_idx = (x, y) => (uint)x * (uint)im_size + (uint)y;
            Func<uint, uint, uint> xy_to_lin_idx_u = (x, y) => (uint)x * (uint)im_size + (uint)y;

            float minX = 10000;
            float maxX = -10000;

            float a = -(retinaMultiplier_c / 21 - 1) / 0.9f;
            float b0 =  (1 - a);
            float a0 = a / mdl.nerve_scale_ratio / mdl_real_radius; 

            for (int i = 0; i < mdl.n_axons; i++)
            {
               
                axon_is_large[i] = mdl.axon_coor[i][2] > axon_max_r_mean;
                if(mdl.axon_coor[i][0] < minX)
                {
                    minX = mdl.axon_coor[i][0];
                }

                if (mdl.axon_coor[i][0] > maxX)
                {
                    maxX= mdl.axon_coor[i][0];
                }

                double theta = 0;
                if(mdl.axon_coor[i][0] == 0)
                {
                    if (mdl.axon_coor[i][1] >= 0)
                        theta = Math.PI / 2;
                    else
                        theta = Math.PI * 3 / 4;

                }else
                {

                    if(mdl.axon_coor[i][0] < 0)
                    {
                        if (mdl.axon_coor[i][1] >= 0)
                            theta = Math.Atan((double)(-1F)*mdl.axon_coor[i][1] / mdl.axon_coor[i][0]);
                        else
                            theta = 2*Math.PI - Math.Atan((double)mdl.axon_coor[i][1] / mdl.axon_coor[i][0]);
                    }
                    else
                    {
                        if (mdl.axon_coor[i][1] >= 0)
                            theta = Math.PI - Math.Atan((double) mdl.axon_coor[i][1] / mdl.axon_coor[i][0]);
                        else
                            theta = Math.PI + Math.Atan((double)(-1F)* mdl.axon_coor[i][1] / mdl.axon_coor[i][0]);
                    }
                }

                for(int q=0; q< opticNerveZones; q++)
                {
                    if(theta < ghZoneAnglesRadian[q])
                    {
                        ghZoneMappingVector[i] = (uint)q;
                        break;
                    }
                }

                for (int q = 0; q < opticNerveZones+1; q++)
                {
                    if (theta < topoZoneAnglesRadian[q])
                    {
                        topoZoneMappingVector[i] = (uint)((q+7)% opticNerveZones);
                        break;
                    }
                }

                axon_is_init_insult[i] = Pow2(insult_r - mdl.axon_coor[i][2]) > Pow2(insult_x - mdl.axon_coor[i][0]) + Pow2(insult_y - mdl.axon_coor[i][1]);

                // Change coordinates from um to pixels
                // [DWL] Using Round function instead of simple typecast
                float xPos =  mdl.axon_coor[i][0] * setts.resolution_xy * setts.retinaMult;
                float yPos =  mdl.axon_coor[i][1] * setts.resolution_xy * setts.retinaMult;
                float f = 1.0F;
                float rdist = (float)Math.Sqrt(Pow2(mdl.axon_coor[i][0]) + Pow2(mdl.axon_coor[i][1])); //rdist in um

                float neuronLocationFactor = (float)Math.Sqrt(rdist / mdl_on_r);

                if (setts.retinaMult > 1)
                {

                    f = neuronLocationFactor;
                }
                   
                xPos *= f;
                yPos *= f;
                

                float xCenter = (float) Math.Round(nerve_cent_pix + xPos , 0);
                float yCenter = (float) Math.Round(nerve_cent_pix + yPos, 0);

                float radiusCircle;

                int diameterP1 = (int) Math.Ceiling((mdl.axon_coor[i][2] * 20));  // 10 for 0.1 um x 2 for diameter = 20
                startHistogram[diameterP1]++;
                startGHZoneHistogram[ghZoneMappingVector[i],diameterP1]++;
                startTopoZoneHistogram[topoZoneMappingVector[i], diameterP1]++;
                ghZoneTotal[ghZoneMappingVector[i]]++;
                topoZoneTotal[topoZoneMappingVector[i]]++;
                axonDiameterVector[i] = (uint)(diameterP1);

                if (max_mdl_diam < diameterP1) max_mdl_diam = diameterP1; 
                

                if (setts.retinaMult == 1)
                    radiusCircle = mdl.axon_coor[i][2] * setts.resolution_xy;
                else
                {
                    /**
                     * [DWL] scale the axon diameter to the soma diameter
                     *       somas diameters are in the [14..24] um range
                     *       from Topography of ganglion cells in human retina
                     *       C Curcio and K Allen
                     *       Journal of Comp Neurology 1990
                     *       page 11
                     *       
                     *       See also 
                     *       [2] Nuclear Atrophy of Retinal Ganglion Cells Precedes the Bax-Dependent Stage of Apoptosis | IOVS | ARVO Journals (2013)
                     *       [2] suggests a radius ratio between axons and soma of 16
                     *       we will use this factor
                     *       
                     */
                    float q = mdl.axon_coor[i][2] * 16;
                    //if (q < 7) q = 7;
                    //else if (q > 12) q = 12;
                    radiusCircle = q * setts.resolution_xy;
                }
                AxCorPix[i, 0] = xCenter; AxCorPix[i, 1] = yCenter; AxCorPix[i, 2] = radiusCircle;
                axonDeathIterationVector[i] = 0;
                axonsCentPixVector[i] = xy_to_lin_idx_u((uint)xCenter, (uint)yCenter);
                idCenterAxonVector[axonsCentPixVector[i]] = (uint) i;
                axon_lbl[i] = new AxonLabelClass { lbl = "", x = xCenter, y = yCenter };

                int xpoint = (int)(xCenter / bmp_im_size);
                int ypoint = (int) (yCenter / bmp_im_size);
                imageAxonCenterVector[xpoint * bmp_im_size + ypoint] = (uint)axonsCentPixVector[i];

                //float rc_1 = radiusCircle + process_clearance;
                //[DWL] Changed cast from float to int to use floor ceiling
                float rc_1 = radiusCircle + 1;
                box_y_min[i] = Max((int)Math.Floor(yCenter - rc_1), 0);
                box_y_max[i] = Min((int)Math.Ceiling(yCenter + rc_1), im_size - 1);
                box_x_min[i] = Max((int)Math.Floor(xCenter - rc_1), 0);
                box_x_max[i] = Min((int)Math.Ceiling(xCenter + rc_1), im_size - 1);
                box_siz_x[i] = box_x_max[i] - box_x_min[i] + 2;
                box_siz_y[i] = box_y_max[i] - box_y_min[i] + 2;

                if(box_y_min[i] +1 == box_y_max[i] || box_x_min[i] +1 == box_x_max[i])
                {
                    Append_stat_ln("Warning: Zero sized box " + i + " " + box_x_min[i] + " " + box_y_min[i]);
                }

                if (setts.retinaMult > 1)
                {
                    h2sThrVector[i] = k_rgc_h2s_thres;
                    s2hThrVector[i] = k_rgc_s2h_thres;
                    s2dThrVector[i] = k_rgc_s2d_thres;
                }
                else
                {
                    /**
                    if (xCenter > im_size / 2)
                        deathThrArray[i] = k_rgc_apoptosis_thres * neuronLocationFactor * (xCenter + 1) / (im_size/2 + 1);
                    else
                        deathThrArray[i] = k_rgc_apoptosis_thres * neuronLocationFactor;
                    */
                    if (setts.lengthCheck == true && setts.retinaMult == 1)
                    {

                        h2sThrVector[i] = k_rgc_h2s_thres *  (a0 * rdist + b0);
                        s2hThrVector[i] = k_rgc_s2h_thres *  (a0 * rdist + b0); 
                        s2dThrVector[i] = k_rgc_s2d_thres *  (a0 * rdist + b0);
                        
                    }
                    else
                    {
                        h2sThrVector[i] = k_rgc_h2s_thres;
                        s2hThrVector[i] = k_rgc_s2h_thres;
                        s2dThrVector[i] = k_rgc_s2d_thres;
                    }
                    
                }
                //else
                //{
                //    death_thr_array[i] = death_tox_thres * (1 + death_var_thr * xCenter / im_size);
                //}

            }
            prep_prof.Time(3);

            //Append_stat_ln("MinX = " + minX.ToString());
            //Append_stat_ln("MaxX = " + maxX.ToString());

            float mitoZone = setts.mitoPercent;

            if(mitoZone == 0 )
            {
                Append_stat_ln("\n\n Warning: Axons have no mitochondria!!\n\n\n");
            }

            float aFactor = setts.mitoLocation;
            float aFactor2 = aFactor * aFactor;
            bool mitoInCenter = false;
            bool mitoRandom = false;
            bool randReset = false;
            if (aFactor < 0) mitoRandom = true;
            if (aFactor < -1) randReset = true;
            if (aFactor == 0) mitoInCenter = true;
            float bFactor = aFactor2 + mitoZone;

            Random mitornd = new Random();
            Random seedRnd = new Random();

            //const float mitoPercentCalibration = 0.04f;  // [DWL] calibrating for 10% mitochondria content
            float mitoDivider = (setts.mitoPercent > 0 ? ((float)(setts.mitoPercent/setts.mitoRegularPercent)) : 1);
            if (setts.noMitoScaleFactor == true) mitoDivider = 1;

            for (int i = 0; i < mdl.n_axons; i++)
            {

                bool[,] is_inside_this_axon = new bool[box_siz_x[i], box_siz_y[i]];
                axonsInsidePixIndexVector[i + 1] = axonsInsidePixIndexVector[i];
                axonsSurrRateIndexVector[i + 1] = axonsSurrRateIndexVector[i]; //

                // From "How the Optic Nerve Allocates Space, Energy Capacity and Info" by Perge et all 
                // 2009 J Neuroscience
                // Fig 6b
                //float firingRateFactor = 1;

                if (setts.useFireFactor == true)
                {
                    hProdVector[i] = k_tox_healthy_rgc_prod / mitoDivider;
                    sProdVector[i] = k_tox_stress_rgc_prod / mitoDivider;
                }
                else
                {
                    hProdVector[i] =  k_tox_healthy_rgc_prod *setts.axonRadiusThreshold / mdl.axon_coor[i][2] / mitoDivider;
                    sProdVector[i] =  k_tox_stress_rgc_prod * setts.axonRadiusThreshold / mdl.axon_coor[i][2] / mitoDivider;
                }
               

                if(randReset) mitornd = new Random(seedRnd.Next());

                for (int y = box_y_min[i]; y <= box_y_max[i]; y++) 
                {
                    for (int x = box_x_min[i]; x <= box_x_max[i]; x++)
                    {
                        float dx = (float)x - AxCorPix[i, 0];
                        float dy = (float)y - AxCorPix[i, 1];
                        float r2 = AxCorPix[i, 2] * AxCorPix[i, 2];
                        float pdist = (dx * dx + dy * dy);
                        bool inside = r2 - pdist > 0;
                        bool inMito = false ;

                       
                        if (inside)
                        { // inside axon

                            uint lin_idx = xy_to_lin_idx(x, y);
                            if (assignedPixelMap[lin_idx] < 0)
                            {
                                assignedPixelMap[lin_idx] = i;
                            }
                            else
                            {
                                // skip this pixel as it is already assigned
                                continue;
                            }

                            pixelsInAxon[i]++;

                            if (mitoRandom == true)
                            {
                               
                                if(pdist==0)
                                {
                                    if (AxCorPix[i, 2] * setts.resolution_xy > 3)
                                        inMito = false; // do not put mito in center pixel for most axons
                                    else
                                        inMito = true;
                                }
                                else
                                {
                                    inMito = ((float)mitornd.NextDouble() < mitoZone);
                                }
                            }
                            else
                            {
                                if (mitoInCenter == false)
                                {
                                    //inMito = r2 * Math.Sqrt(1 - mitoZone) - pdist < 0;

                                    inMito = (r2 * aFactor2 - pdist <= 0) && (r2 * bFactor - pdist >= 0);

                                }
                                else
                                {
                                    inMito = r2 * mitoZone - pdist > 0;
                                }
                            }
                            //[DWL] place mitochondria in the setts.mitoPercent*radius of the axon

                            

                            is_inside_this_axon[x - box_x_min[i], y - box_y_min[i]] = true;
                            simulationMaskArray[lin_idx] = rgc_display_healthy; // alive
                            axonsInsidePixVector[axonsInsidePixIndexVector[i + 1]++] = lin_idx;
                            
                           
                            if (inMito)
                            {
                                // [DWL] Make tox production per pixel inverse proportional with
                                //       *reaL* axon circumference (2*pi*r) => r is radius in um *not* pixels
                                if(setts.useFireFactor == true)
                                {
                                    toxProdArray[lin_idx] = k_tox_healthy_rgc_prod  / mitoDivider;
                                }
                                else
                                {
                                    toxProdArray[lin_idx] = k_tox_healthy_rgc_prod * setts.axonRadiusThreshold / mdl.axon_coor[i][2] / mitoDivider;
                                }
                                
                                detoxArray[lin_idx] = 1-k_detox_mito;
                                mitoPixels[i]++;

                            }
                            else
                            {
                                toxProdArray[lin_idx] = noToxProd_c;
                                detoxArray[lin_idx] = 1-k_detox_intra_rgc;
                                
                            }
                            // AxonInsult = i_pix*pi*pix^2= i_t/res^2*pi*pix^2=i_t/res^2*pi*(r*res)^2
                            //            = i_t*pi*r^2
                            // k_insult_tox has been resized before the assignment
                            if (axon_is_init_insult[i])
                                toxArray[lin_idx] += k_insult_tox;
                        }
                    }
                }
                prep_prof.Time(4);

                int expectedMitoPixels = (int) Math.Ceiling(mitoZone * pixelsInAxon[i]);

                
                if(mitoZone > 0 && mitoPixels[i] == 0 && pixelsInAxon[i] >= setts.axonPixelThreshold)
                {
                    for (int y = box_y_min[i]; y <= box_y_max[i]; y++)
                    {
                        for (int x = box_x_min[i]; x <= box_x_max[i]; x++)
                        {
                            float dx = (float)x - AxCorPix[i, 0];
                            float dy = (float)y - AxCorPix[i, 1];
                            float r2 = AxCorPix[i, 2] * AxCorPix[i, 2];
                            float pdist = (dx * dx + dy * dy);
                            bool inside = r2 - pdist > 0;
                           

                            if (inside)
                            { // inside axon

                                uint lin_idx = xy_to_lin_idx(x, y);
                                if (assignedPixelMap[lin_idx] != i)
                                {
                                    // skip this pixel as it is assigned to another axon
                                    continue;
                                }

                                if (expectedMitoPixels == 0) break;

                                
                                expectedMitoPixels--;


                                // [DWL] Make tox production per pixel inverse proportional with
                                //       *reaL* axon circumference (2*pi*r) => r is radius in um *not* pixels
                                if (setts.useFireFactor == true)
                                {
                                    toxProdArray[lin_idx] = k_tox_healthy_rgc_prod  / mitoDivider;
                                }
                                else
                                {
                                    toxProdArray[lin_idx] = k_tox_healthy_rgc_prod * setts.axonRadiusThreshold / mdl.axon_coor[i][2] / mitoDivider;
                                }

                                detoxArray[lin_idx] = 1 - k_detox_mito;
                                mitoPixels[i]++;

                                
                            }
                        }
                    }
                }

                int cnt1 = 0, cnt2 = 0;

                for (int y = box_y_min[i] + 1; y < box_y_max[i]; y++)
                {
                    for (int x = box_x_min[i] + 1; x < box_x_max[i]; x++)
                    {
                        /*
                        int bmin = box_x_min[i];
                        int bmax = box_x_max[i];
                        int bym = box_y_min[i];
                        int bymax = box_y_max[i];
                        int bxs = box_siz_x[i];
                        int bys = box_siz_y[i];
                        */
                        int x_rel = x - box_x_min[i];
                        int y_rel = y - box_y_min[i];
                        //[DWL] This must be in the same order as used in 
                        //      the diffusion files!!
                        int[] neighbors_x = new int[] { x_rel + 1, x_rel - 1, x_rel, x_rel };
                        int[] neighbors_y = new int[] { y_rel, y_rel, y_rel + 1, y_rel - 1 };

                        bool xy_inside = is_inside_this_axon[x_rel, y_rel];
                        uint base2base = xy_to_lin_idx(x, y);
                        uint lin_idx_base = xy_to_lin_idx(x, y) * (uint) pixelNeighbourNumbers;
                        //bool membrane = false;
                        // [DWL] Fixed the rate setting for boundary
                        if(xy_inside)
                        {
                            if (assignedPixelMap[base2base] != i)
                            {
                                // this pixel does not belong to the current axon
                                continue;
                            }

                            for (uint k = 0; k < plane_neighbours; k++)
                            {
                                bool neigh_k_inside = is_inside_this_axon[neighbors_x[k], neighbors_y[k]];

                                uint lin_idx = lin_idx_base + k;

                                if (!neigh_k_inside)
                                {
                                   diffusionRateIndexArray[lin_idx] = rate_membrane_index;
                                }
                                else
                                {
                                    diffusionRateIndexArray[lin_idx] = rate_live_index;
                                }
                                axonsSurrRateVector[axonsSurrRateIndexVector[i + 1]++] = lin_idx;
                            }
                            if (setts.no3dLayers > 1)
                            {
                                byte pixelRate = rate_live_z_index;

                                diffusionRateIndexArray[lin_idx_base + rateDownLayerIndex] = pixelRate;
                                axonsSurrRateVector[axonsSurrRateIndexVector[i + 1]++] = lin_idx_base + rateDownLayerIndex;
                                diffusionRateIndexArray[lin_idx_base + rateUpLayerIndex] = pixelRate;
                                axonsSurrRateVector[axonsSurrRateIndexVector[i + 1]++] = lin_idx_base + rateUpLayerIndex;
                            }
                        }
                        else
                        {
                            for (uint k = 0; k < plane_neighbours; k++)
                            {
                                bool neigh_k_inside = is_inside_this_axon[neighbors_x[k], neighbors_y[k]];

                                uint lin_idx = lin_idx_base + k;

                                if (neigh_k_inside)
                                {
                                    diffusionRateIndexArray[lin_idx] = rate_membrane_index;
                                    uint localIndex = axonsSurrRateIndexVector[i + 1]++;
                                    axonsSurrRateVector[localIndex] = lin_idx;
                                }
                                else
                                {
                                    uint localIndex = axonsSurrRateIndexVector[i + 1]++;
                                    axonsSurrRateVector[localIndex] = 0;
                                }
                            }
                            if (setts.no3dLayers > 1)
                            {
                                /**
                                if (assignedPixelMap[base2base] != unAssignedPixel_c)
                                {
                                    // this pixel does not belong to the current axon
                                    continue;
                                }
                                */

                                byte pixelRate = rate_extra_z_index;

                                diffusionRateIndexArray[lin_idx_base + rateDownLayerIndex] = pixelRate;
                                axonsSurrRateVector[axonsSurrRateIndexVector[i + 1]++] = lin_idx_base + rateDownLayerIndex;
                                diffusionRateIndexArray[lin_idx_base + rateUpLayerIndex] = pixelRate;
                                axonsSurrRateVector[axonsSurrRateIndexVector[i + 1]++] = lin_idx_base + rateUpLayerIndex;
                            }

                        }
                    }
                }

                if (cnt1 / 2 != cnt2)
                    Debug.WriteLine("Please increase clearance!");
                prep_prof.Time(5);
                // Verify radius
                // Debug.WriteLine("{0} vs {1}", (Math.Pow(mdl.axon_coor[i][2] * res, 2) * Math.PI).ToString("0.0"), axons_inside_pix_idx[i + 1] - axons_inside_pix_idx[i]);
            }


            for(int i =0; i < mdl.n_axons; i++)
            {
                mitoPercent[i] = ((float)mitoPixels[i]) / pixelsInAxon[i];
            }

            Random random = new Random();
            totalGliaCells = 0;
            //float bmpDivImg = 1.0F / bmp_image_compression_ratio;
            for (int idx = 0; idx < imsquare; idx++)
            {
                if (pix_out_of_nerve[idx] == 0 || pix_out_of_nerve[idx] == 2)
                {
                    // Only these pixels will be run through cuda_diffusion_*
                    pixIndexArray[pixInsideNerveCount++] = idx;
                }
                if (simulationMaskArray[idx] != outside_tissue_pixel)
                {
                    double tmp01 = random.NextDouble();
                    if (tmp01 < gliaFractionOfTotalTissue)
                    {
                        if (simulationMaskArray[idx] == tissue_pixel)
                        {
                            if (totalGliaCells < maximumGliaCells)
                            {
                                //detox[idx] = 0;
                                toxProdArray[idx] = k_tox_healthy_glia_prod;
                                detoxArray[idx] = 1 - k_detox_mito;
                                gliaStateVector[totalGliaCells] = 1;
                                gliaCenterVector[totalGliaCells++] = (uint)idx;
                                int x = idx / im_size;
                                int y = idx % im_size;
                                int xpoint = x / bmp_im_size;
                                int ypoint = y / bmp_im_size;
                                imageGliaCenterVector[xpoint * bmp_im_size + ypoint] = (uint)idx;
                                simulationMaskArray[idx] = glia_display_healthy;
                            }
                        }
                    }
                    
                    if (tmp01 > sodFractionOfTotalTissue)
                    {
                        if (simulationMaskArray[idx] == tissue_pixel)
                        {
                            detoxArray[idx] = noDetox;
                        }
                    }
                }
            }
            prep_prof.Time(2);

            rebuildTimeMap = true;

            preprocessGPUVar.CopyToDevice(diffusionRateIndexArray, diffusionRateIndexArray_dev);
            preprocessGPUVar.Launch(grid_siz_prep, block_siz_prep).cuda_prep1(im_size, pix_out_of_nerve_dev, diffusionRateIndexArray_dev, pixelNeighbourNumbers);
            preprocessGPUVar.CopyFromDevice(diffusionRateIndexArray_dev, diffusionRateIndexArray);
            preprocessGPUVar.FreeAll();

            prep_prof.Time(6);

            // Keep backup of inital state 

            //tox_init = null; tox_init = (float[,])tox.Clone();
            //rate_init = null; rate_init = (float[,,])rate.Clone();
            //detox_init = null; detox_init = (float[,])detox.Clone();
            //tox_init = null; tox_init = null; tox_prod_init = (float[,])tox_prod.Clone();
            //axon_mask_init = null; axon_mask_init = (byte[,])simulation_mask.Clone();
            //axon_state_init = null; axon_state_init = (bool[])axon_state.Clone();

            preprocessDone = true;
            simulationDone = false;

            Reset_state();

            // variable size study
            //((rate.Length + tox.Length + detox.Length + tox_prod.Length + simulation_mask.Length + axon_state.Length)*4)/1024/1024 // MB

            //Load_gpu_from_cpu();

            Update_bottom_stat("Preprocess Done! (" + (Toc() / 1000).ToString("0.0") + " secs)");
            // Debug.WriteLine("inside: {0} vs allocated {1}", axons_inside_pix_idx[mdl.n_axons - 1], axons_inside_pix.Length);

            lbl_x_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
            lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";

            EnableButtons();

            prep_prof.report();
        }

        public double NextGaussian(Random r, double mu = 0, double sigma = 1)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }

        public double NextZOGaussian(Random rnd, double mu = 0, double sigma = 1)
        {
            double r = NextGaussian(rnd, mu, sigma);
            if (r < 0) r = 0;
            if (r > 1) r = 1;
            return r;
        }

    }

}
