using System;
using System.Diagnostics;
using System.Windows.Forms;

using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;

namespace LHON_Form
{
    public partial class Main_Form : Form
    {
        private volatile GPGPU gpu;
        private readonly bool recompile_cuda = true;

        ulong gpuTotalMemoryB = 0;

       // const int max_resident_blocks = 16;
       // const int max_resident_threads = 2048;
       // const int warp_size = 32;

        public bool Init_gpu()
        {
            try { gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId); }
            catch { return true; }

            int deviceCount = CudafyHost.GetDeviceCount(CudafyModes.Target);
            if (deviceCount == 0) return true;

            string gpu_name = gpu.GetDeviceProperties(false).Name;

            gpuTotalMemoryB = gpu.TotalMemory ;

            //if (gpu is CudaGPU && gpu.GetDeviceProperties().Capability < new Version(1, 2))
            //{
            //    Debug.WriteLine("Compute capability 1.2 or higher required for atomics.");
            //    append_stat_ln(gpu_name + " not supported.");
            //    return true;
            //}

            Append_stat_ln("Running on " + gpu_name);

            CudafyModule km = CudafyModule.TryDeserialize();
            if (recompile_cuda && (km == null || !km.TryVerifyChecksums()))
            {
                // eArchitecture arch = gpu.GetArchitecture();
                km = CudafyTranslator.Cudafy(arch: eArchitecture.sm_70);
                km.TrySerialize();
            }
            gpu.LoadModule(km);

            return false;
        }

        // ==================================================================
        //                 Copy from GPU to CPU and vice-versa 
        // ==================================================================

        private dim3 blocks_per_grid_2D_pix;
        private int blocks_per_grid_1D_axons;
        private int blocks_per_grid_1D_glia;


        /**
         * [DWL] Next two methods load data from CPU to GPU for the simulation engine
         *       GPGPU is the Cudafy.net object that creates the bridge to the gpu
         *       All variables of this type create gpu environments and open interfaces on CPU for their access.
         *       This is a 2 step process: 
         *          a) allocate a data structure on GPU using gpuLocal.Allocate
         *          b) copy the CPU data to GPU using gpuLocal.CopyToDevice
         *          
         *       In CUDA "speak" Device is GPU and Host is CPU. 
         *       Thus "CopyToDevice" is "copy to GPU from cpu" while "CopyFromDevice" is "copy to cpu from gpu)
         *       
         *       VERY IMPORTANT:
         *       To be able to use cuda functions we need to add their definition in this file using
         *       [CudafyDummy] keyword. See bottom of this file.
         *       
         *       Cudafy will copy all files that contain the functions declared with [CudafyDummy] to
         *       a single file called CUDAFYSOURCETEMP.cu place in the bin directory. On my laptop this file is located in
         *       gpu-reaction-diffusion\LHON-Form\bin\x64\Debug
         *       This file has the following contents at the time of writing this comment:
         *       #include "cuda_rgc_update_live.cu"
         *       #include "cuda_glia_update_live.cu"
         *       #include "cuda_diffusion2D.cu"
         *       #include "cuda_diffusion3D.cu"
         *       #include "cuda_update_image.cu"
         *       #include "cuda_tox_sum.cu"
         *       #include "cuda_prep0.cu"
         *       #include "cuda_prep1.cu"
         *       #include "cuda_update_init_insult.cu"
         */

        private void Load_gpu_from_cpu()
        {
            GPGPU gpuLocal = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            Load_gpu_from_cpu(gpuLocal);
                    
        }


        private void Load_gpu_from_cpu(GPGPU gpuLocal)
        {
            gpuLocal.FreeAll(); gpuLocal.Synchronize();

            int imsq = im_size * im_size;

            toxArray_dev = gpuLocal.Allocate<float>((2 + (setts.no3dLayers>1?setts.no3dLayers:0)) * imsq); 
            //float[] t1 = new float[(2 + setts.no3dLayers) * imsq];
            //tox_dev = gpuLocal.Allocate<float>(t1);
            gpuLocal.Set(toxArray_dev);
            if (setts.no3dLayers > 1)
            {
                for(int i=0; i < setts.no3dLayers+2;i++)
                    gpuLocal.CopyToDevice(toxArray, 0, toxArray_dev, i * imsq , toxArray.Length);
            }
            else
            {
                gpuLocal.CopyToDevice(toxArray, 0, toxArray_dev, 0, toxArray.Length);
                gpuLocal.CopyToDevice(toxArray, 0, toxArray_dev, imsq, toxArray.Length);
            }
            //tox_new_dev = gpuLocal.Allocate<float>(im_size * im_size); gpuLocal.Set(tox_new_dev);

            diffusionRateIndexArray_dev = gpuLocal.Allocate(diffusionRateIndexArray); gpuLocal.CopyToDevice(diffusionRateIndexArray, diffusionRateIndexArray_dev);

            //[DWL] added next group of arrays
            diffusionRatesVector_dev = gpu.Allocate(diffusionRatesVector); gpu.CopyToDevice(diffusionRatesVector, diffusionRatesVector_dev);
            
            diffusionRatesMyelinVector_dev = gpu.Allocate(diffusionRatesMyelinVector); gpu.CopyToDevice(diffusionRatesMyelinVector, diffusionRatesMyelinVector_dev);
            
            detoxArray_dev = gpuLocal.Allocate(detoxArray); gpuLocal.CopyToDevice(detoxArray, detoxArray_dev);
            toxProdArray_dev = gpuLocal.Allocate(toxProdArray); gpuLocal.CopyToDevice(toxProdArray, toxProdArray_dev);

            axonsCentPixVector_dev = gpuLocal.Allocate(axonsCentPixVector); gpuLocal.CopyToDevice(axonsCentPixVector, axonsCentPixVector_dev);
            idCenterAxonVector_dev = gpuLocal.Allocate(idCenterAxonVector); gpuLocal.CopyToDevice(idCenterAxonVector, idCenterAxonVector_dev);
            rgcStateVector_dev = gpuLocal.Allocate(rgcStateVector); gpuLocal.CopyToDevice(rgcStateVector, rgcStateVector_dev);
            //[DWL] added this
            h2sThrVector_dev = gpuLocal.Allocate(h2sThrVector); gpuLocal.CopyToDevice(h2sThrVector, h2sThrVector_dev);
            s2hThrVector_dev = gpuLocal.Allocate(s2hThrVector); gpuLocal.CopyToDevice(s2hThrVector, s2hThrVector_dev);
            s2dThrVector_dev = gpuLocal.Allocate(s2dThrVector); gpuLocal.CopyToDevice(s2dThrVector, s2dThrVector_dev);

            hProdVector_dev = gpuLocal.Allocate(hProdVector); gpuLocal.CopyToDevice(hProdVector, hProdVector_dev);
            sProdVector_dev = gpuLocal.Allocate(sProdVector); gpuLocal.CopyToDevice(sProdVector, sProdVector_dev);

            //[DWL] added this
            rgcDeathTimerVector_dev = gpuLocal.Allocate(rgcDeathTimerVector); gpuLocal.CopyToDevice(rgcDeathTimerVector, rgcDeathTimerVector_dev);

            pixIndexArray_dev = gpuLocal.Allocate(pixIndexArray); gpuLocal.CopyToDevice(pixIndexArray, pixIndexArray_dev);

            numAliveRGC_dev = gpuLocal.Allocate<int>(1); gpuLocal.CopyToDevice(numAliveRGC, numAliveRGC_dev);
            numStressRGC_dev = gpuLocal.Allocate<int>(1); gpuLocal.CopyToDevice(numStressRGC, numStressRGC_dev);
            axonDeathIterationVector_dev = gpuLocal.Allocate(axonDeathIterationVector); gpuLocal.CopyToDevice(axonDeathIterationVector, axonDeathIterationVector_dev);
            bmp_bytes_dev = gpuLocal.Allocate(bmp_bytes); gpuLocal.CopyToDevice(bmp_bytes, bmp_bytes_dev);

            //[DWL] added this
            if (totalGliaCells > 0)
            {
                gliaCenterVector_dev = gpuLocal.Allocate(gliaCenterVector); gpuLocal.CopyToDevice(gliaCenterVector, gliaCenterVector_dev);
                gliaDeathTimerVector_dev = gpuLocal.Allocate(gliaDeathTimerVector); gpuLocal.CopyToDevice(gliaDeathTimerVector, gliaDeathTimerVector_dev);
                gliaStateVector_dev = gpuLocal.Allocate(gliaStateVector); gpuLocal.CopyToDevice(gliaStateVector, gliaStateVector_dev);
            }

            imageGliaCenterVector_dev = gpuLocal.Allocate(imageGliaCenterVector); gpuLocal.CopyToDevice(imageGliaCenterVector, imageGliaCenterVector_dev);
            imageAxonCenterVector_dev = gpuLocal.Allocate(imageAxonCenterVector); gpuLocal.CopyToDevice(imageAxonCenterVector, imageAxonCenterVector_dev);

            //[DWL] Added array to retrieve the pixel tox values
            // Useful for debugging
            bmp_tox_dev = gpuLocal.Allocate(bmp_tox); gpuLocal.CopyToDevice(bmp_tox, bmp_tox_dev);
            init_insult_mask_dev = gpuLocal.Allocate<byte>(bmp_im_size, bmp_im_size);

            sum_tox_dev = gpuLocal.Allocate<float>(1);
            progress_dev = gpuLocal.Allocate<float>(3);

            sum_zone_tox_dev = gpuLocal.Allocate<float>(opticNerveZones);
            regionalMask_dev = gpuLocal.Allocate<int>(imsq);
            gpuLocal.CopyToDevice(regionalMask, regionalMask_dev);

            assignedPixelMap_dev = gpuLocal.Allocate<int>(imsq);
            gpuLocal.CopyToDevice(assignedPixelMap, assignedPixelMap_dev);


            progression_image_sum_float_dev = gpuLocal.Allocate<float>(prog_im_siz, prog_im_siz);
            progress_image_num_averaged_pix_dev = gpuLocal.Allocate<uint>(prog_im_siz, prog_im_siz);
            progression_image_dev = gpuLocal.Allocate<byte>(prog_im_siz, prog_im_siz);

            // ==================== Constants

            int tmp = (int)Math.Ceiling(Math.Sqrt((double)pixInsideNerveCount / (double)threads_per_block_1D));
            blocks_per_grid_2D_pix = new dim3(tmp, tmp);
            blocks_per_grid_1D_axons = mdl.n_axons / threads_per_block_1D + 1;
            blocks_per_grid_1D_glia = totalGliaCells / threads_per_block_1D + 1;

            show_opts_dev = gpuLocal.Allocate(show_opts); gpuLocal.CopyToDevice(show_opts, show_opts_dev);

            axonsInsidePix_dev = gpuLocal.Allocate(axonsInsidePixVector); gpuLocal.CopyToDevice(axonsInsidePixVector, axonsInsidePix_dev);
            axonsInsidePixIndexVector_dev = gpuLocal.Allocate(axonsInsidePixIndexVector); gpuLocal.CopyToDevice(axonsInsidePixIndexVector, axonsInsidePixIndexVector_dev);

            axonSurrRateVector_dev = gpuLocal.Allocate(axonsSurrRateVector); gpuLocal.CopyToDevice(axonsSurrRateVector, axonSurrRateVector_dev);
            axonSurrRateIndexVector_dev = gpuLocal.Allocate(axonsSurrRateIndexVector); gpuLocal.CopyToDevice(axonsSurrRateIndexVector, axonSurrRateIndexVector_dev);

            simulationMaskArray_dev = gpuLocal.Allocate(simulationMaskArray); gpuLocal.CopyToDevice(simulationMaskArray, simulationMaskArray_dev);

            gpuLocal.Synchronize();
            Append_stat_ln("GPU total memory: " + ((double)gpuLocal.TotalMemory/ 1048576).ToString("0.0") + " MB\n");
            Append_stat_ln("GPU free memory: " + ((double)gpuLocal.FreeMemory / 1048576).ToString("0.0") + " MB\n");
            Append_stat_ln("GPU perc used memory: " + (100.0 * (1 - (double)gpuLocal.FreeMemory / (double)gpuLocal.TotalMemory)).ToString("0.0") + " %\n");

        }

        /*
        private void load_cpu_from_gpu()
        {
            //GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);

            gpu.CopyFromDevice(tox_dev, tox);
            gpu.CopyFromDevice(rate_dev, rate);
            gpu.CopyFromDevice(detox_dev, detox);
            gpu.CopyFromDevice(tox_prod_dev, tox_prod);

            gpu.CopyFromDevice(axon_state_dev, axon_state);
            gpu.CopyFromDevice(death_itr_dev, death_itr);
        }
        */

        // ==================================================================
        //         Dummy functions (defined in native cuda @ cuda/...)
        // ==================================================================

        [CudafyDummy]
        public static void cuda_rgc_update_live() { }
        [CudafyDummy]
        public static void cuda_glia_update_live() { }
        [CudafyDummy]
        public static void cuda_diffusion2D() { }
        [CudafyDummy]
        public static void cuda_diffusion3D() { }
        [CudafyDummy]
        public static void cuda_update_image() { }
        [CudafyDummy]
        public static void cuda_tox_sum() { }
        [CudafyDummy]
        public static void cuda_prep0() { }
        [CudafyDummy]
        public static void cuda_prep1() { }
        [CudafyDummy]
        public static void cuda_update_init_insult() { }

        [CudafyDummy]
        public static void cuda_diffusion3DTop() { }

        [CudafyDummy]
        public static void cuda_diffusion3DBottom() { }

        [CudafyDummy]
        public static void cuda_adjustSOD() { }

        [CudafyDummy]
        public static void cuda_adjustPROD() { }

        [CudafyDummy]
        public static void cuda_adjustTOX() { }

    }
}

