using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.IO;

using Cudafy;
using Cudafy.Host;

// Speed inside bundle: Fastest, outside bundles slower, boundaries slowest, 

namespace LHON_Form
{
    //[System.ComponentModel.DesignerCategory("Form")]
    public partial class Main_Form : Form
    {

        private void Main_Form_Load(object sender, EventArgs e)
        {
            alg_worker.DoWork += (s, ev) => SimulationEngineLoop(); alg_worker.WorkerSupportsCancellation = true;
            new_model_worker.DoWork += (s, ev) => New_model();

            Init_settings_gui();

            if (Init_gpu())
            {
                MessageBox.Show("No Nvidia GPU detected! This program requires an Nvidia GPU.", "Fatal Error");
                this.Close();
                return;
            }

            string[] fileEntries = Directory.GetFiles(ProjectOutputDir + @"Models\");
            if (fileEntries.Length > 0) Load_model(fileEntries[fileEntries.Length - 1]);

            fileEntries = Directory.GetFiles(ProjectOutputDir + @"Settings\");
            if (fileEntries.Length > 0) Load_settings(fileEntries[fileEntries.Length - 1]);

            if (mdl.n_axons > 0 && mdl.n_axons < 100000 && setts.resolution_xy > 0)
                Preprocess_model();
        }

        // =============================== SIMULATION ENGINE (MAIN LOOP)  ===============================

        private bool en_prof = false;
        //private float dt;
        private float lvl_tox_last = 0;
        private int duration_of_no_change = 0; // itr
        private int stop_sim_at_duration_of_no_change = 20000; // itr

        private bool tox_switch = false;
        private int dstl = 0;
        private int tl = 0;
        private int ml = 0;
        private int bl = 0;
        private int apoptLayer = 0;

        private int sodChangeIter;
        private int sodRepeat;
        private int sodPeriodOneIter;
        private int sodPeriodTwoIter;

        //private int gui_iteration_period = 10;

        private int Mod(int x, int m)
        {
            int temp = x % m;
            return temp < 0 ? temp + m : temp;
        }

        unsafe private void SimulationEngineLoop()
        {

           
            gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId); // should be reloaded for reliability
            alg_prof.Time(0);

            if (iteration == 0)
            {
                Load_gpu_from_cpu(gpu);
                tt_sim.Restart();
                Tic();
            }
            tt_sim.Start();
            
            headLayer = 2;
            apoptLayer = headLayer + setts.apoptotic3DLocation;
            int layerToDisplay;
            int totalPlanes = (setts.no3dLayers>1?setts.no3dLayers:0) + 2;

            simInProgress = true;

            int imsquare = im_size * im_size;

            stop_sim_at_duration_of_no_change = (int)Math.Ceiling(2.0 / k_time_iter); // run another 2 s if no change

            if (stop_at_time != 0 )
            {
                stop_at_iteration = (int) Math.Ceiling(stop_at_time / k_time_iter / 1000);
            }

            PSStruct z = ParsePSDescriptor(setts.sodTimeSpec);
            bool useSodSpec = false;

            if(setts.sodTimeSpec != null && setts.sodTimeSpec != "" )
            {
                useSodSpec = true; 
                sodChangeIter = (int)Math.Ceiling(z.initLen / k_time_iter);
                if (sodChangeIter == 0) sodChangeIter = 1; // iteration is incremented at the top of the loop
                sodRepeat = z.repeat;
                sodPeriodOneIter = (int)Math.Ceiling(z.z1Len / k_time_iter);
                sodPeriodTwoIter = (int)Math.Ceiling(z.z2Len / k_time_iter);
            }

            /**
             * [DWL] This is the main simulation loop
             *       It runs several functions on GPU
             *       and waits for their completion
             *       
             *       There are 2 versions of this loop:
             *       a) for the 2D simulation it is a single call per iteration to cuda_diffusion2D.cu
             *       b) for the 3D simulation there are N-2 calls, where N is the number of layers in the model
             *          (excluding the 2 extra planes needed for storing results)
             *          The loop is split in 3 parts: first call for the top 2 layers; second part processes 3 layers at a time 
             *                                        third part processes the bottom 2 layers.
             */

            tox_switch = false;

            int resetTimerOnStateChange = chk_timer_reset.Checked ? 1 : 0;

            int changeSodAtIter = -1;
            float currentSODMult = 1;
            float currentPRODMult = 1;
            bool toggle = false;
            if (useSodSpec)
            {
                changeSodAtIter = sodChangeIter;
                currentSODMult = z.initValS;
                currentPRODMult = z.initValP;

            }
            int sodRepeatCounter = 0;
            


            while (true)
            {

                while(sim_stat == Sim_stat_enum.Paused)
                {
                    //Append_stat_ln("Info Head: " + headLayer);
                    Thread.Sleep(100);
                }

                // [DWL] Exit the loop under these conditions

                if(sim_stat == Sim_stat_enum.None || sim_stat == Sim_stat_enum.Failed || sim_stat == Sim_stat_enum.Successful || sim_stat == Sim_stat_enum.Stopped)
                {
                    Append_stat_ln("Info: Exiting worker thread");
                    break;
                }

                iteration++;

                int local_update_period = setts.gui_iteration_period;
                bool update_gui = iteration % local_update_period == 0;
               

                alg_prof.Time(-1);

                int offset = 0;
                
                // [DWL] for debugging
                //gpu.CopyFromDevice(rate_dev, rate);
                //gpu.CopyFromDevice(axon_state_dev, axon_state);


                // [DWL] for debugging
                //gpu.CopyFromDevice(rate_dev, rate);
                //gpu.CopyFromDevice(axon_state_dev, axon_state);

                if (setts.no3dLayers <= 1)
                {
                    //[DWL] 2D SIMULATION
                    /**
                    * [DWL] At the begining of each iteration we need to check the state of the RGCs (alive, apoptotic, dead)
                    *       I modified this method to add multiple states
                    */
                    gpu.Launch(blocks_per_grid_1D_axons, threads_per_block_1D).cuda_rgc_update_live(mdl.n_axons, toxArray_dev, diffusionRateIndexArray_dev, detoxArray_dev, toxProdArray_dev, 1-k_detox_outside_rgc, h2sThrVector_dev,
                        axonsCentPixVector_dev, axonsInsidePix_dev, axonsInsidePixIndexVector_dev, axonSurrRateVector_dev, axonSurrRateIndexVector_dev,
                        rgcStateVector_dev, simulationMaskArray_dev, numAliveRGC_dev, numStressRGC_dev, axonDeathIterationVector_dev, 
                        iteration, 0, pixelNeighbourNumbers, 
                        setts.noDetoxOnDeath ? noDetox : (setts.useGliaDetoxOnDeath ? 1-k_detox_outside_rgc : 1-k_detox_intra_rgc), 
                        rgcDeathTimerVector_dev, 
                        rgc_apoptosis_iterations,
                        hProdVector_dev,
                        sProdVector_dev,
                        s2hThrVector_dev,
                        s2dThrVector_dev,
                        resetTimerOnStateChange);

                    
                    /**
                     * [DWL] If the simulation has glial cells, same check as for axons needs to be done. The cell states are the same
                     */
                    if (totalGliaCells > 0)
                    {
                        gpu.Launch(blocks_per_grid_1D_glia, threads_per_block_1D).cuda_glia_update_live(totalGliaCells, toxArray_dev, detoxArray_dev, toxProdArray_dev, k_tox_stress_glia_prod, k_tox_healthy_glia_prod, k_glia_h2s_thres, k_glia_s2d_thres, k_glia_s2h_thres,
                           gliaCenterVector_dev, gliaStateVector_dev, gliaDeathTimerVector_dev, simulationMaskArray_dev, 0, setts.noDetoxOnDeath ? noDetox : 1-k_detox_outside_rgc, glia_apoptosis_iterations, resetTimerOnStateChange);
                    }

                    if (en_prof) { gpu.Synchronize(); alg_prof.Time(1); }

                    /**
                     * [DWL] This is the 2D version of the simulation call; single call per iteration to cuda_diffusion2D
                     *       This was in the original program
                     * 
                     */
                    int index_old;
                    int index_new;
                   
                    if (tox_switch == true)
                    {
                        index_old = imsquare;
                        index_new = 0;
                        //used by display
                        headLayer = 1;
                    }
                    else
                    {
                        index_new = imsquare;
                        index_old = 0;
                        // used by display
                        headLayer = 0;
                    }
                    gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_diffusion2D(pixIndexArray_dev, pixInsideNerveCount, im_size, index_old,
                        index_new, toxArray_dev, detoxArray_dev, toxProdArray_dev, diffusionRateIndexArray_dev, diffusionRatesVector_dev);

                    tox_switch = !tox_switch;
                }

                else
                {
                    //[DWL] 3D SIMULATION

                    offset = apoptLayer * imsquare;
                    /**
                    * [DWL] At the begining of each iteration we need to check the state of the RGCs (alive, apoptotic, dead)
                    *       I modified this method to add multiple states
                    */
                    
                    gpu.Launch(blocks_per_grid_1D_axons, threads_per_block_1D).cuda_rgc_update_live(mdl.n_axons, toxArray_dev, diffusionRateIndexArray_dev, detoxArray_dev, toxProdArray_dev, 1 - k_detox_outside_rgc, h2sThrVector_dev,
                        axonsCentPixVector_dev, axonsInsidePix_dev, axonsInsidePixIndexVector_dev, axonSurrRateVector_dev, axonSurrRateIndexVector_dev,
                        rgcStateVector_dev, simulationMaskArray_dev, numAliveRGC_dev, numStressRGC_dev, axonDeathIterationVector_dev,
                        iteration, offset, pixelNeighbourNumbers,
                        setts.noDetoxOnDeath ? noDetox : (setts.useGliaDetoxOnDeath ? 1 - k_detox_outside_rgc : 1 - k_detox_intra_rgc),
                        rgcDeathTimerVector_dev,
                        rgc_apoptosis_iterations,
                        hProdVector_dev,
                        sProdVector_dev,
                        s2hThrVector_dev,
                        s2dThrVector_dev,
                        resetTimerOnStateChange);

                    /**
                     * [DWL] No glial cells in 3D
                     */


                    if (en_prof) { gpu.Synchronize(); alg_prof.Time(1); }
                    /**
                     * [DWL] This is the 3D version of the iteration. It is a for loop that processes several layers at a time
                     *       This was my addition
                     * 
                     */

                    dstl = Mod(headLayer - 2, totalPlanes)*imsquare;
                    tl = Mod(headLayer, totalPlanes)*imsquare;
                    ml = Mod(headLayer, totalPlanes)*imsquare;
                    bl = Mod(headLayer+1, totalPlanes)*imsquare;

                    bool injury = (setts.toxLayerStart == 0) || (setts.use3DSpecPattern == true);
                    bool sodLayer = (setts.sodLayerStart == 0) || (setts.use3DSpecPattern == true);
                    bool myelin = (setts.use3DSpecPattern == true) && (myelinArray[0] == 0);

                    gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_diffusion3DTop(pixIndexArray_dev, pixInsideNerveCount, im_size,
                                            toxArray_dev, detoxArray_dev, toxProdArray_dev, diffusionRateIndexArray_dev, 
                                            diffusionRatesMyelinVector_dev, 0,
                                            dstl, tl, ml, bl, injury ? randProdArray[0] : 0F, sodLayer? randSODArray[0]: 0F,
                                            assignedPixelMap_dev);

                    for (int j = 1; j < setts.no3dLayers-1; j++)
                    {
                        dstl = Mod(headLayer - 2 + j, totalPlanes)*imsquare;
                        tl   = Mod(headLayer - 1 + j, totalPlanes)*imsquare;
                        ml   = Mod(headLayer + j, totalPlanes)*imsquare;
                        bl   = Mod(headLayer + j + 1, totalPlanes)*imsquare;
                        injury = ((j >= setts.toxLayerStart) || (setts.use3DSpecPattern == true));
                        sodLayer = ((j >= setts.sodLayerStart) || (setts.use3DSpecPattern == true));
                        myelin = (setts.use3DSpecPattern == true) && (myelinArray[j] == 0);
                        gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_diffusion3D(pixIndexArray_dev, pixInsideNerveCount, im_size,
                                            toxArray_dev, detoxArray_dev, toxProdArray_dev, diffusionRateIndexArray_dev,
                                            diffusionRatesMyelinVector_dev, j,
                                            dstl, tl, ml, bl, injury ? randProdArray[j] : 0F, sodLayer ? randSODArray[j]: 0F,
                                            assignedPixelMap_dev);
                    }

                    dstl = Mod(headLayer - 2 + setts.no3dLayers - 1, totalPlanes)*imsquare;
                    tl   = Mod(headLayer - 1 + setts.no3dLayers - 1, totalPlanes)*imsquare;
                    ml   = Mod(headLayer   + setts.no3dLayers - 1, totalPlanes)*imsquare;
                    bl   = Mod(headLayer   + setts.no3dLayers - 1, totalPlanes)*imsquare;
                    injury = ((setts.no3dLayers - 1 <= setts.toxLayerStart)) || (setts.use3DSpecPattern == true);
                    sodLayer = ((setts.no3dLayers - 1 <= setts.sodLayerStart)) || (setts.use3DSpecPattern == true);
                    myelin = (setts.use3DSpecPattern == true) && (myelinArray[setts.no3dLayers-1] == 0);
                    gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_diffusion3DBottom(pixIndexArray_dev, pixInsideNerveCount, im_size,
                                            toxArray_dev, detoxArray_dev, toxProdArray_dev, diffusionRateIndexArray_dev,
                                            diffusionRatesMyelinVector_dev, setts.no3dLayers-1, 
                                            dstl, tl, ml, bl, injury ? randProdArray[setts.no3dLayers - 1] : 0F, sodLayer ? randSODArray[setts.no3dLayers - 1] : 0F,
                                            assignedPixelMap_dev);

                    headLayer = Mod(headLayer - 2, totalPlanes);
                    apoptLayer = Mod(apoptLayer - 2, totalPlanes);
                    if (setts.no3dLayers < 0)
                    {
                        Append_stat_ln("ERROR: no layers is less than zero! Simulation stopped!");
                        return;
                    }
                    if(headLayer < 0)
                    {
                        Append_stat_ln("ERROR: headLayer is less than zero! Simulation stopped!");
                        return;
                    }
                    
                }

                if (useSodSpec)
                {
                    if (iteration == changeSodAtIter)
                    {
                        // change of sod goes here
                        if (currentSODMult != 1) 
                        { 
                            gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_adjustSOD(pixIndexArray_dev, pixInsideNerveCount, detoxArray_dev, currentSODMult);
                        }

                        if(currentPRODMult != 1)
                        {
                            gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_adjustTOX(pixIndexArray_dev, pixInsideNerveCount, toxProdArray_dev, currentPRODMult);
                            gpu.Launch(blocks_per_grid_1D_axons, threads_per_block_1D).cuda_adjustPROD(mdl.n_axons, 
                                                                                                            hProdVector_dev,
                                                                                                            sProdVector_dev,
                                                                                                             currentPRODMult );
                        }


                        if (sodRepeatCounter < sodRepeat)
                        {
                            if (toggle == false)
                            {
                                changeSodAtIter += sodPeriodOneIter;
                                currentSODMult = z.z1ValS;
                                currentPRODMult = z.z1ValP;
                                toggle = true;
                            }
                            else
                            {
                                changeSodAtIter += sodPeriodTwoIter;
                                currentSODMult = z.z2ValS;
                                currentPRODMult = z.z2ValP;
                                toggle = false;
                                sodRepeatCounter++;
                            }

                        }
                    }


                }

                //gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_diffusion2(pix_idx_dev, pix_idx_num, tox_new_dev, tox_dev);

                if (en_prof) { gpu.Synchronize(); alg_prof.Time(2); }

                /**
                 * [DWL] The display is updated every "iter" iterations
                 *       The original author of the program did something really clever:
                 *            to reduce the data transfers between CPU and GPU he
                 *            processed the image on the GPU directly using data available there
                 *            and then he just passed the results to the "windows display"
                 */

                if (update_gui)
                {
                    //gpu.CopyFromDevice(axon_state_dev, axon_state); // ?
                    gpu.CopyFromDevice(numAliveRGC_dev, numAliveRGC);
                    gpu.CopyFromDevice(numStressRGC_dev, numStressRGC);


                    // Calc tox_sum for sanity check
                    gpu.Set(sum_tox_dev);
                    gpu.Set(sum_zone_tox_dev);
                    if (setts.no3dLayers > 1)
                    {
                        offset = headLayer;
                    }
                    else
                    {
                        offset = 0;
                    }

                    /**
                     * [DWL] The next function adds all the tox values in the matrix.
                     *       It was part of the original code
                     */

                    gpu.Launch(blocks_per_grid_2D_pix, threads_per_block_1D).cuda_tox_sum(pixIndexArray_dev, pixInsideNerveCount, toxArray_dev, sum_tox_dev, regionalMask_dev, sum_zone_tox_dev, offset, imsquare, setts.no3dLayers);
                    gpu.CopyFromDevice(sum_tox_dev, out sum_tox);
                    gpu.CopyFromDevice(sum_zone_tox_dev, sum_zone_tox);

                    if ((stop_at_iteration == 0) && Math.Abs(sum_tox - lvl_tox_last) < 0.001F) { 
                    
                      duration_of_no_change += local_update_period;
                      if (duration_of_no_change >= stop_sim_at_duration_of_no_change && headLayer == 2)
                      {
                        Stop_sim(Sim_stat_enum.Successful);
                      }
                        
                    }
                    else
                    {
                        lvl_tox_last = sum_tox;
                        duration_of_no_change = 0;
                    }

                    if (max_sum_tox < sum_tox)
                    {
                        max_sum_tox = sum_tox;
                    }

                    

                    if (en_prof) { gpu.Synchronize(); alg_prof.Time(3); }
                    int currentShow = showdir;
                    if (setts.no3dLayers > 1)
                    {


                        if(showdir == 0)
                        {
                            layerToDisplay = Mod(headLayer + Mod(setts.layerToDisplay, setts.no3dLayers), totalPlanes);
                        }
                        else
                        {
                            layerToDisplay = setts.layerToDisplay;
                        }
                        
                    }
                    else
                    {
                        //currentShow = 0;
                        if (showdir == 0)
                        {
                            layerToDisplay = 0;
                        }
                        else
                        {
                            layerToDisplay = setts.layerToDisplay;
                        }
                    }

                    Update_bmp_image(currentShow, layerToDisplay, imsquare);
                    Update_gui_labels();

                    if (sim_stat == Sim_stat_enum.Running && aviRecordOn == true)
                        Record_bmp_gif();

                    if (en_prof) alg_prof.Time(4);
                }
               
                if (iteration == stop_at_iteration )
                    Stop_sim(Sim_stat_enum.Successful); // >>>>>>>>>>>>>>>>>> TEMP should be Paused

                //if (main_loop_delay > 0)
                //    Thread.Sleep(main_loop_delay * 10);
            } //[DWL] end of simulation loop

            
            tt_sim.Pause();

            if (en_prof) alg_prof.report();
            else Debug.WriteLine("Sim took " + (Toc() / 1000).ToString("0.000") + " secs\n");

            Update_Chart();

            simulationDone = true;
            simInProgress = false;

        }


        // ==================== Reset State  =======================

        private void Reset_state()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Reset_state()));
            else
            {
                sum_tox = 0;
                max_sum_tox = 0;
                for (int y = 0; y < im_size; y++)
                    for (int x = 0; x < im_size; x++)
                        sum_tox += toxArray[x * im_size + y];

                iteration = 0;
                duration_of_no_change = 0;

                for (int i = 0; i < mdl.n_axons; i++) axon_lbl[i].lbl = "";

                prog_im_siz = prog_im_siz_default;
                resolution_reduction_ratio = (double)prog_im_siz / (double)im_size;
                if (resolution_reduction_ratio > 1)
                {
                    resolution_reduction_ratio = 1;
                    prog_im_siz = (ushort)im_size;
                }
                //areal_progression_image_stack = new byte[progress_num_frames, prog_im_siz, prog_im_siz];
                //chron_progression_image_stack = new byte[progress_num_frames, prog_im_siz, prog_im_siz];
                //areal_progress_chron_val = new float[progress_num_frames];
                //chron_progress_areal_val = new float[progress_num_frames];

                for (int i = 0; i < mdl.n_axons; i++)
                {
                    rgcStateVector[i] = 1;
                    rgcDeathTimerVector[i] = 0;
                }

                    usedTimeBoxes = 1;
                numStressRGC[0] = 0;
                numAliveRGC[0] = mdl.n_axons;
                aliveNumAxonsVec[0] = mdl.n_axons;
                deadPerIterationVec[0] = 0;
                healthyPerIterVec[0] = 0;
                stressNumAxonsVec[0] = 0;
                stressPerIterVec[0] = 0;
                rosAmountVec[0] = 0;
                rosChangeVec[0] = 0;
                iterationVec[0] = 0;

                for(int i=0; i<opticNerveZones; i++)
                {
                    aliveZoneTotal[i] = 0;
                    stressZoneTotal[i] = 0;
                    deadZoneTotal[i] = 0;
                }

                Load_gpu_from_cpu();

                Update_gui_labels();

                Update_init_insult();
                Update_show_opts();

                //Update_bmp_image(0,0, im_size*im_size);
                PicB_Resize(null, null);

                sim_stat = Sim_stat_enum.None;

            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void txt_on_death_tox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_tox_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }


        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_delay_ms_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }


        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void chk_var_death_Enter(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void lbl_delta_xy_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void lbl_delta_z_Click(object sender, EventArgs e)
        {

        }

        private void txt_mito_percent_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nerve_scale_TextChanged(object sender, EventArgs e)
        {

        }

        private void sox_track_bar_yz_Scroll(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_hist_logx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void chk_length_adj_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void txt_apoptosis_tox_threshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void txt_apoptosis_duration_sec_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_visual_field_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void aliveChartYLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
