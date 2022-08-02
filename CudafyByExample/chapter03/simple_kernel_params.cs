/* 
 * This software is based upon the book CUDA By Example by Sanders and Kandrot
 * and source code provided by NVIDIA Corporation.
 * It is a good idea to read the book while studying the examples!
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cudafy;
using Cudafy.Host;
using Cudafy.Translator;
namespace CudafyByExample
{
    public class simple_kernel_params
    {
        public static void Execute()
        {
            CudafyModule km = CudafyTranslator.Cudafy(eArchitecture.sm_70);

            GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);
            gpu.LoadModule(km);

            int oneB = 1300000000;
            float[] l = new float[oneB];

            float[] f = gpu.Allocate<float>(oneB);

            int c = 0;
            int[] dev_c = gpu.Allocate<int>(); // cudaMalloc one Int32
            gpu.Launch().add(2, 7, dev_c); // or gpu.Launch(1, 1, "add", 2, 7, dev_c);
            gpu.CopyFromDevice(dev_c, out c);

            Console.WriteLine("2 + 7 = {0}", c);
            gpu.Launch().sub(2, 7, dev_c);
            gpu.CopyFromDevice(dev_c, out c);

            for(int i = 0; i < 100000; i++)
                Console.WriteLine("2 - 7 = {0}", c);



            gpu.Free(dev_c);

            gpu.Free(f);
        }

        [Cudafy]
        public static void add(int a, int b, int[] c)
        {
            c[0] = a + b;
        }

        [Cudafy]
        public static void sub(int a, int b, int[] c)
        {
            c[0] = a - b;
        }
    }
}
