using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
//using AviFile;
using System.Linq;

namespace LHON_Form
{
    public partial class Main_Form : Form
    {
        private const string ProjectOutputDir = @"..\..\Project_Output\";
        private ushort threads_per_block_1D = 1024;
        
        // ======================================================

        private BackgroundWorker alg_worker = new BackgroundWorker(), new_model_worker = new BackgroundWorker();
        //private AviManager aviManager;
        private string avi_file;
        //private VideoStream aviStream;
        private float sum_tox, max_sum_tox;
        //private float areal_progress, chron_progress;
        private float[] progress_dat = new float[3];
        private const int progress_num_frames = 20;
        private double resolution_reduction_ratio;
        private ushort prog_im_siz, prog_im_siz_default = 100;
        private byte[,] progression_image_dev;
        //private byte[,,] areal_progression_image_stack, chron_progression_image_stack;
        //private float[] areal_progress_chron_val, chron_progress_areal_val;
        //private uint areal_progression_image_stack_cnt, chron_progression_image_stack_cnt;
        private float[,] progression_image_sum_float_dev;
        private uint[,] progress_image_num_averaged_pix_dev;
        //private float areal_progress_lim;
        private bool stop_sweep_req = false, sweep_is_running = false;
        private float[] sum_tox_dev, progress_dev;
        private uint iteration = 0;
        //private float realTime;

        // float[] init_insult = new float[2] { 0, 0 };

        private enum Sim_stat_enum { None, Running, Paused, Successful, Failed, Stopped };

        private Sim_stat_enum sim_stat = Sim_stat_enum.None;

        private class AxonLabelClass
        {
            public string lbl;
            public float x;
            public float y;
        }

        private AxonLabelClass[] axon_lbl;

        public class ZStruct
        {
            public float initLen;
            public float initVal;

            public int specLen;
            public int repeat;
            public float z1Len;
            public float z1Val;
            public float z2Len;
            public float z2Val;
            public float z3Len;
            public float z3Val;
            public float z4Len;
            public float z4Val;
        }

        public class PSStruct
        {
            public float initLen;
            public float initValP;
            public float initValS;

            public int repeat;
            public float z1Len;
            public float z1ValP;
            public float z1ValS;
            public float z2Len;
            public float z2ValP;
            public float z2ValS;
        }

        public class MitoSpec
        {
            public float initMito;
            public float endMito;
            public float increment;
        }
        
        [Serializable]
        public class Setts
        {
            public float resolution_xy;
            public float resolution_z;
            public float alpha;

            public float diff_coeff_live_xy;
            public float diff_coeff_live_z;
            public float diff_coeff_dead_xy;
            public float diff_coeff_dead_z;
            public float diff_coeff_membrane;
            public float diff_coeff_glia_xy;
            public float diff_coeff_glia_z;
            
            public float tox_rgc_mito_prod;
            public float tox_glia_mito_prod;
            public bool  varToxProd;
            public float tox_rgc_mito_stress_prod;
            public float rgc_stress_to_apoptosis_ms;
            public float tox_glia_mito_stress_prod;
            public float glia_stress_to_apoptosis_ms;
            public float initial_tox_value;

            public float detox_rgc_intra;
            public float detox_rgc_extra;

            public float rgc_apoptosis_tox_threshold;
            public float glia_apoptosis_tox_threshold;
            
            public float[] insult;

            public float insult_tox;

            public int no3dLayers;

            public int toxLayerStart;

            public int sodLayerStart;

            public float mitoPercent;
            public float mitoLocation;

            public int layerToDisplay;

            public int gui_iteration_period;

            public bool use3DSpecPattern;

            public bool useFireFactor;

            public float retinaMult;

            public int startPixel;

            public int viewSize;

            public float percentGlia;

            public float percentSOD;

            public bool lengthCheck;
        
            public string ros3dString;

            public string sod3dString;

            public string mem3dString;

            public int apoptotic3DLocation;

            public bool noDetoxOnDeath;

            public float diff_coeff_membrane_dead;

            public bool useGliaDetoxOnDeath;

            public float detox_mito;

            public float diff_coeff_membrane_stress;

            public float s2h_rgc_tox_thr;
            public float s2h_glia_tox_thr;

            public float s2d_rgc_tox_thr;
            public float s2d_glia_tox_thr;

            public int timer_reset_s2h;

            public bool noMitoScaleFactor;  // true == do not use mito scale

            public float mitoRegularPercent; // "normal" percent for mitochondria; set to 4% by default; can be changed

            public float axonPixelThreshold; // set to 1 by default

            public float axonRadiusThreshold; // set to 0.5 by default; diameter distribution has a max at ~1 um diameter (ie 0.5 um radius)

            public string sodTimeSpec;

            public float tox_rgc_cyto_prod;
            public float tox_inter_cellular_prod;
            public float tox_rgc_cyto_stress_prod;
            public float tox_inter_cellular_stress_prod;
            public float model_ratio;

            public float perm_coeff_tissue;

            public float tox_tissue_prod;


        }

        private Model mdl = new Model();
        private Setts setts = new Setts();

        // ============= Main loop vars =================

        //private float progress_step, next_areal_progress_snapshot, next_chron_progress_snapshot;
        private Tictoc tt_sim = new Tictoc();
        //private float sim_time = 0;
        private uint last_itr = 1;
       // private float last_areal_prog;

        // =============== Profiling Class =============

        private class Profiler
        {
            private const int max = 100;
            private double[] T = new double[max];
            private int[] num_occur = new int[max];
            private Stopwatch sw = Stopwatch.StartNew();
            private Stopwatch sw_tot = Stopwatch.StartNew();
            public void Time(int idx) // Pass 0 start of main program to start tot_time
            {
                if (idx > 0)
                {
                    T[idx] += sw.Elapsed.TotalMilliseconds;
                    num_occur[idx]++;
                }
                else if (idx == 0)
                {
                    Array.Clear(T, 0, max);
                    Array.Clear(num_occur, 0, max);
                    sw_tot = Stopwatch.StartNew();
                }
                sw = Stopwatch.StartNew(); // Pass negative to reset only sw
            }
            public void report() // This will stop and conclude tot_time
            {
                sw_tot.Stop();
                sw.Stop();
                double tot_time = sw_tot.Elapsed.TotalMilliseconds;
                Debug.WriteLine("Total: " + (tot_time / 1000).ToString("0.000") + "s");
                for (int k = 0; k < T.Length; k++)
                    if (T[k] > 0)
                        Debug.WriteLine("{0}:\t{1}%\t{2}ms\t{3}K >> {4}ms", k, (T[k] / tot_time * 100).ToString("00.0"), T[k].ToString("000000"), (num_occur[k] / 1000).ToString("0000"), (T[k] / num_occur[k]).ToString("000.000"));
            }
        }

        private Profiler gpu_prof = new Profiler();
        private Profiler alg_prof = new Profiler();
        private Profiler prep_prof = new Profiler();


        // ======= Basic Math Functions =========

        private float Pow2(float x){return x * x;}
        private int Pow2(int x) { return x * x; }

        private float Maxf(float v1, float v2)
        {
            return (v1 > v2) ? v1 : v2;
        }
        private float Minf(float v1, float v2)
        {
            return (v1 < v2) ? v1 : v2;
        }


        public int Max(int v1, int v2)
        {
            return (v1 > v2) ? v1 : v2;
        }

        private int Min(int v1, int v2)
        {
            return (v1 < v2) ? v1 : v2;
        }

        private float Within_circle2(int x, int y, float xc, float yc, float rc)
        {
            float dx = (float)x - xc;
            float dy = (float)y - yc;
            return rc * rc - (dx * dx + dy * dy);
        }

        // ========== tic toc ==========

        private Stopwatch sw = new Stopwatch();

        private void Tic()
        {
            sw = Stopwatch.StartNew();
        }

        private float Toc()
        {
            float t = sw.ElapsedMilliseconds;
            Tic();
            return t;
        }

        private class Tictoc
        {
            private Stopwatch sw = new Stopwatch();
            public void Restart()
            {
                sw = Stopwatch.StartNew();
            }
            public float Read()
            {
                return sw.ElapsedMilliseconds;
            }
            public void Pause()
            {
                sw.Stop();
            }
            public void Start()
            {
                sw.Start();
            }
        }

        private const string CharList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Dec2B36(long value)
        {
            string result = string.Empty;
            do
            {
                int rem = (int)(value % 36);
                result = CharList[rem] + result;
                value /= 36;
            }
            while (value > 0);

            return result;
        }

        public static long B36toDec(string input)
        {
            var reversed = input.Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }
        
    }
}
