using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Forms.DataVisualization.Charting;

using System.Threading.Tasks;


namespace LHON_Form
{
    public partial class Main_Form : Form
    {
        private GifBitmapEncoder gifEnc = new GifBitmapEncoder();

        private bool rebuildTimeMap = true;
        Series q;
        Series hSeries;
        Series sSeries;
        Series dSeries;
        Series tSeries;

        readonly float retinaMultiplier_c = 26f;
        private MitoSpec mitoSpec = new MitoSpec();


        /*
        bool mouse_r_pressed;
        int mouse_r_press_x, mouse_r_press_y;
        picB.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    mouse_r_pressed = true;
                    mouse_r_press_x = e.X;
                    mouse_r_press_y = e.Y;
                }
        };
        picB.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    mouse_r_pressed = false;
                }
            };
        picB.MouseMove += (s, e) => if (mouse_r_pressed) ...
        */

        private int stop_at_iteration = 0;
        private float stop_at_time = 0;
        private int main_loop_delay = 0;

        //[DWL] if set to 1 display sox using RGB, if 0 use red only
        private int showRGBSox = 1;
        private int displayAtTop = 1;

        private bool aviRecordOn = false;

       

        public Main_Form()
        {

            
            InitializeComponent();
            this.CenterToScreen();
            DoubleBuffered = true;

            Init_sweep();

            Append_stat_ln("Optic Nerve ROS 3D simulation software. (c) McGill University 2022.\n");


            chk_show_live_axons.CheckedChanged += (o, e) => Update_show_opts();
            chk_show_dead_axons.CheckedChanged += (o, e) => Update_show_opts();
            chk_show_stress.CheckedChanged += (o, e) => Update_show_opts();
            checkBox_show_rgc.CheckedChanged += (o, e) => Update_show_opts();
            checkBox_show_glia.CheckedChanged += (o, e) => Update_show_opts();

            checkBox_chart_healthy.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
            checkBox_chart_dead.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
            checkBox_chart_stress.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
            checkBox_chart_legend.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
            checkDisplayLineHist.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
            checkPercentHist.CheckedChanged += (o, e) => Update_Chart();
            checkBoxRatio.CheckedChanged += (o, e) => Update_Chart();

            checkBox_chart_3d.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };

            checkBox_chart_add_zones.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };

            chk_chart_add_states.CheckedChanged += (o, e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };


            checkBox_showSumOfHSD.CheckedChanged += (o,e) =>
            {
                rebuildTimeMap = true;
                Update_Chart();
            };
        

            checkBox_visual_field.CheckedChanged += (o, e) =>
            {
                if (checkBox_visual_field.Checked)
                {
                    UseVisualField();
                }
                else
                {
                    UseTopo();
                }
                rebuildTimeMap = true;
                Update_Chart();

            };

            checkBoxZ1.CheckedChanged += (o, e) =>
            {
                if(radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                
                Update_Chart();
            };
            checkBoxZ2.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ3.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ4.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ5.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ6.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ7.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };
            checkBoxZ8.CheckedChanged += (o, e) =>
            {
                if (radio_button_coronal.Checked)
                {
                    if (checkBox_visual_field.Checked)
                    {
                        ShowVisualFieldLabels();
                    }
                    else
                    {
                        TopoView();
                    }
                }
                Update_Chart();
            };

            radioButtonHistogram.CheckedChanged += (o, e) =>
            {

                liveHistGroupBox.Enabled = true;
                Update_Chart();
            };

            
            radioButtonCount.CheckedChanged += (o, e) =>
            {

                liveHistGroupBox.Enabled = false;
                rebuildTimeMap = true;
                Update_Chart();
            };

            radioButtonROS.CheckedChanged += (o, e) =>
            {

                //liveHistGroupBox.Enabled = false;
                rebuildTimeMap = true;
                Update_Chart();
            };

            radioButtonLoss.CheckedChanged += (o, e) =>
            {

                liveHistGroupBox.Enabled = true;
                rebuildTimeMap = true;
                Update_Chart();
            };

            radioButton_ros_v_h.CheckedChanged += (o, e) =>
            {

                liveHistGroupBox.Enabled = true;
                rebuildTimeMap = true;
                Update_Chart();
            };

            checkBoxDiff.CheckedChanged += (o, e) =>
            {

                rebuildTimeMap = true;
                Update_Chart();

            };

            chk_length_adj.CheckedChanged += (o, e) =>
            {
                if(chk_length_adj.Checked == true)
                {
                    setts.lengthCheck = true;
                }
                else
                {
                    setts.lengthCheck = false;
                }
                // [DWL]forces you to press preprocess so that the parameters take hold in GPU
                SimParamsChanged();
            };

            chk_retina.CheckedChanged += (o, e) =>
            {
                //[DWL] Accordying to Forrester et all, The Eye, Saunders Ltd 2015
                //      page 40, the retina is approx 1250 mm^2 in surface
                //      and has a thickness of 230um near optic nerve head
                //      and 100 um towards periphery (nasal and temporal)
                //  If we model the retina as a circular surface 
                //      (it is actually a part of a sphere so the 2D mapping
                //       is a series of leafs) 
                //      the radius of the circle is sqrt(1250/pi) ~ 20 mm
                //      As the optic nerve is 1.5mm in diam, ie 0.75 mm radius
                //      the "multiplier" is 20/0.75 ~26.
                if (chk_retina.Checked == true)
                {
                    setts.retinaMult = retinaMultiplier_c;
                    setts.resolution_xy = 1;
                    setts.resolution_z = 1;
                    txt_xy_resolution.Text = setts.resolution_xy.ToString() + "," + setts.resolution_z.ToString();
                    lbl_sample_type.Text = "Retina";
                }
                else
                {
                    setts.retinaMult = 1;
                    lbl_sample_type.Text = "Optic Nerve";
                }

                SimParamsChanged();
            };

            rbDDTox0.CheckedChanged += (o, e) =>
            {
                setts.noDetoxOnDeath = rbDDTox0.Checked;

                SimParamsChanged();

            };

            rbDDTox3.CheckedChanged += (o, e) =>
            {
                setts.useGliaDetoxOnDeath = rbDDTox3.Checked;

                SimParamsChanged();

            };

            rbDDTox1.CheckedChanged += (o, e) =>
            {
                setts.noDetoxOnDeath = false;
                setts.useGliaDetoxOnDeath = false;

                SimParamsChanged();

            };

            chk_fire_factor.CheckedChanged += (o, e) =>
            {
                if (chk_fire_factor.Checked == true)
                {
                    setts.useFireFactor = true;
                }
                else
                {
                    setts.useFireFactor = false;
                }
                SimParamsChanged();
            };

            noMitoScaleCheckBox.CheckedChanged += (o, e) =>
            {
                if (noMitoScaleCheckBox.Checked == true)
                {
                    setts.noMitoScaleFactor = true;
                }
                else
                {
                    setts.noMitoScaleFactor = false;
                }
                SimParamsChanged();
            };

            chk_timer_reset.CheckedChanged += (o, e) =>
            {
                setts.timer_reset_s2h = chk_timer_reset.Checked ? 1 : 0;
                SimParamsChanged();
            };

            chk_show_tox.CheckedChanged += (o, e) =>
            {
                    if (chk_show_tox.Checked == true)
                    {
                        direction_group_box.Enabled = true;
                        chk_rgb_box.Enabled = true;
                        if (radio_button_coronal.Checked) sox_track_bar_coronal.Enabled = true;
                        if (radio_button_sagittal.Checked) sox_track_bar_sagittal.Enabled = true;
                        if (radio_button_transversal.Checked) sox_track_bar_transversal.Enabled = true;
                    }
                    else
                    {
                        direction_group_box.Enabled = false;
                        sox_track_bar_transversal.Enabled = false;
                        sox_track_bar_coronal.Enabled = false;
                        sox_track_bar_sagittal.Enabled = false;
                        chk_rgb_box.Enabled = false;
                        
                    }

                Update_show_opts();

            };

            chk_rgb_box.CheckedChanged += (o, e) =>
            {
                if (chk_rgb_box.Checked == true)
                {
                    showRGBSox = 1;
                }
                else
                {
                    showRGBSox = 0;
                }

                Update_show_opts();

            };


            txt_stop_itr.TextChanged += (s, e) =>
            {
                stop_at_iteration = Read_int(s);
            };
            txt_stop_time.TextChanged += (s, e) =>
            {
                stop_at_time = 1000*Read_float(s); //[DWL] input is in bio seconds, data is stored in bio ms
                stop_at_iteration = 0;
                txt_stop_itr.Text = "0";
            };
            txt_img_size.TextChanged += (s, e) =>
            {
                bmp_im_size = (ushort)Read_int(s);

                SimParamsChanged();
            };

            /**
            txt_view_info.TextChanged += (s, e) =>
            {
                string[] values = txt_view_info.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if(values.Length > 0 ) setts.startPixel = int.Parse(values[0]);
                if(values.Length > 1) setts.viewSize = int.Parse(values[1]);
            };
            */

            //txt_block_siz.TextChanged += (s, e) => threads_per_block_1D = (ushort)Read_int(s);

            btn_reset.Click += (s, e) =>
            {
                if (diffusionRateIndexArray == null)
                {
                    Append_stat_ln("Info: Calling preprocess.....");
                    Preprocess_model();
                    Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true;
                    Append_stat_ln("Info: Preprocessing complete.");
                    return;
                }
                if (sim_stat == Sim_stat_enum.Running)
                {
                    Append_stat_ln("Warning: You must stop the simulation before resetting the states.");
                    return;
                }
                Reset_state(); Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true;
                Update_bottom_stat("Simulation state was reset!");
            };

            btn_start.Click += (s, e) =>
            {
                if (sim_stat == Sim_stat_enum.None || sim_stat == Sim_stat_enum.Paused)
                {
                    /*
                    Append_stat_ln("D(um)        Initial Num");
                    for(int i =0; i< aliveHBoxes; i++)
                    {
                        if(startHistogram[i] != 0)
                            Append_stat_ln(((float)i/10) + "      " + startHistogram[i]);
                    }
                    */
                    int noLoop = Read_int(textBox_no_iterations);
                    Update_Chart();
                    if (noLoop <= 1)
                        Start_sim();
                    else
                    {
                        TestLoop(noLoop, checkBox_gen_model.Checked);
                    }
                }
                else if (sim_stat == Sim_stat_enum.Running)
                {
                    Stop_sim(Sim_stat_enum.Paused);
                    Update_Chart();
                }
            };

            btn_generate_model.Click += (s, e) => { // [DWL] Generate Model Button
                GenerateNewModel();
            };

            
            btn_preprocess.Click += (s, e) =>
            {
                if (sim_stat == Sim_stat_enum.Running)
                {
                    Append_stat_ln("Warning: You must stop the simulation before preprogress.");
                    return;
                }
                Append_stat_ln("Info: Preprocessing model.");
                Preprocess_model();
                Append_stat_ln("Info: Preprocessing done.");
                Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true; btn_reset.Enabled = true;
            };

            btn_clr.Click += (s, e) => txt_status.Text = "";

            
            btn_record_avi.Click += (s, e) =>
            {
                if (btn_record_avi.Enabled)
                {
                    if (aviRecordOn == false)
                    {
                        aviRecordOn = true;
                        btn_record_avi.Text = "Recording";
                        btn_record_avi.BackColor = System.Drawing.Color.DarkRed;

#if false
                    avi_file = ProjectOutputDir + @"Recordings\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + '(' + (im_size * im_size / 1e6).ToString("0.0") + "Mpix).avi";
                    aviManager = new AviManager(avi_file, false);
                    Avi.AVICOMPRESSOPTIONS options = new Avi.AVICOMPRESSOPTIONS();
                    options.fccType = (uint)Avi.mmioStringToFOURCC("vids", 5);
                    options.fccHandler = (uint)Avi.mmioStringToFOURCC("CVID", 5);
                    options.dwQuality = 1;
                    aviStream = aviManager.AddVideoStream(options, 10, bmp); 
#endif
                    }
                    else
                    {
                        btn_record_avi.Text = "Saving";
                        btn_record_avi.BackColor = System.Drawing.Color.LightGray;
                        btn_record_avi.Enabled = false;
#if false
                    aviManager.Close();
                    Process.Start(avi_file);
#endif
                        Save_bmp_gif();
                    }
                }
            };

            
            btn_save_state_as_list.Click += (s, e) =>
            {
                Set_btn_save_list_txt("Saving..", System.Drawing.Color.Red); btn_save_state_as_list.Enabled = false;
                Save_Progress(ProjectOutputDir + @"Progression\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".prgim");
                Set_btn_save_list_txt("Save List", System.Drawing.Color.LightGray); btn_save_state_as_list.Enabled = true;
            };

            btn_img_snapshot.Click += (s, e) =>
            {
                string adr = ProjectOutputDir + @"Snapshots\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".jpg";
                Append_stat_ln("Snapshot saved to: " + adr);
                if(bmp != null) bmp.Save(adr);
            };

            //txt_block_siz.Text = threads_per_block_1D.ToString("0");

            picB.MouseWheel += (s, e) =>
            {
                if (simInProgress == false) {
                    float[] um = get_mouse_click_um(e);
                    float dx = insult_x - um[0], dy = insult_y - um[1];
                    float dist = dx * dx + dy * dy;
                    if (insult_r * insult_r - dist > 0 || dist < 100)
                    {
                        insult_r += (float)e.Delta / 100;
                        if (insult_r < 0) insult_r = 0;
                        Update_init_insult();
                        Update_bmp_image(0, 0, im_size * im_size);
                        //Debug.WriteLine(insult_r);
                    }
                }
            };
            
            picB.Click += (s, e) => {

                mouse_click(e as MouseEventArgs);

                int[] um = get_mouse_location(e as MouseEventArgs);

                if (bmp_tox != null)
                {
                    tox_image_value.Show(((bmp_tox[um[0] + um[1] * bmp_im_size])*1000).ToString("0.00")+" nM", picB, um[2], um[3], 10000);
                }


            };
            
            /**
             * [DWL] comments above and uncomment this 
             * for injury placement
             * the above code displays the tox at point
             * 
            picB.Click += (s, e) => mouse_click(e as MouseEventArgs);
            */
        }

        private void Update_show_opts()
        {

            if(preprocessDone == false)
            {
                return;
            }
            show_opts[0] = chk_show_live_axons.Checked;
            show_opts[1] = chk_show_dead_axons.Checked;
            show_opts[2] = chk_show_stress.Checked;
            show_opts[3] = chk_show_tox.Checked;
            show_opts[4] = checkBox_show_rgc.Checked;
            show_opts[5] = checkBox_show_glia.Checked;
            

            //setts.layerToDisplay = Read_int(txt_layer_to_display);

            gpu.CopyToDevice(show_opts, show_opts_dev);
            int layerToDisplay = 0;
            int currentShow = showdir;
            if (setts.no3dLayers > 1)
            {
                if (showdir == 0)
                {
                    layerToDisplay = Mod(headLayer + Mod(setts.layerToDisplay, setts.no3dLayers), setts.no3dLayers +2);
                }
                else
                {
                    layerToDisplay = setts.layerToDisplay;
                }
            }
            else
            {
                if (showdir == 0)
                {
                    layerToDisplay = 0;
                }
                else
                {
                    layerToDisplay = setts.layerToDisplay;
                }
            }
            if(sim_stat != Sim_stat_enum.Running)
                Update_bmp_image(currentShow, layerToDisplay, im_size* im_size);
            //Update_bmp_image(0);
        }

        // ====================================================================
        //                       Start / Stop Simulation
        // ====================================================================
        private void Start_sim()
        {
            if (diffusionRateIndexArray == null)
            {
                Append_stat_ln("Warning: You must preprocess the model before running simulation.\n");
                return;
            }
            if (sim_stat == Sim_stat_enum.None || sim_stat == Sim_stat_enum.Stopped || sim_stat == Sim_stat_enum.Successful || sim_stat == Sim_stat_enum.Failed)
            {
                DisableButtons();

                sim_stat = Sim_stat_enum.Running;
                alg_worker.RunWorkerAsync();
                Set_btn_start_txt("&Pause", System.Drawing.Color.DarkRed);
                Update_bottom_stat("Simulation is Running");
            } else if(sim_stat == Sim_stat_enum.Paused)
            {
                DisableButtons();

                sim_stat = Sim_stat_enum.Running;
                Set_btn_start_txt("&Pause",  System.Drawing.Color.DarkRed);
                Update_bottom_stat("Simulation is Running");
            }
        }

        private void Stop_sim(Sim_stat_enum stat)
        {
            if (InvokeRequired)
                Invoke(new Action(() => Stop_sim(stat)));
            else
            {
                if (sim_stat == Sim_stat_enum.Running)
                {
                    sim_stat = stat;
                    if (sim_stat == Sim_stat_enum.Paused)
                    {
                        Set_btn_start_txt("&Continue", System.Drawing.Color.Green);
                    }
                    else
                    {
                        if(aviRecordOn == true)
                        {
                            btn_record_avi.Text = "Saving";
                            btn_record_avi.BackColor = System.Drawing.Color.LightGray;
                            btn_record_avi.Enabled = false;
                            Save_bmp_gif();
                        }
                        Set_btn_start_txt("&Start", System.Drawing.Color.Gray);
                        btn_start.Enabled = false;
                    }
                    Update_bottom_stat("Simulation is " + sim_stat.ToString());
                }
                else if (sim_stat == Sim_stat_enum.Paused)
                {
                    sim_stat = stat;
                    Set_btn_start_txt("&Start", System.Drawing.Color.Green);
                    Update_bottom_stat("Simulation is " + sim_stat.ToString());
                }
                EnableButtons();
            }
        }
        // ====================================================================
        //                           Low level GUI
        // ====================================================================

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            sim_stat = Sim_stat_enum.Paused;
            Thread.Sleep(10);
        }

        private void Set_btn_start_txt(string s, System.Drawing.Color color)
        {
            if (InvokeRequired) Invoke(new Action(() => { btn_start.Text = s; btn_start.BackColor = color; }));
            else
            {
                btn_start.Text = s;
                btn_start.BackColor = color;
            }
        }

        private void Set_btn_save_list_txt(string s, System.Drawing.Color color)
        {
            if (InvokeRequired) Invoke(new Action(() => { btn_save_state_as_list.Text = s; btn_save_state_as_list.BackColor = color; }));
            else
            {
                btn_save_state_as_list.Text = s;
                btn_save_state_as_list.BackColor = color;
            }
        }

        private void Update_num_axons_lbl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Update_num_axons_lbl()));
            else
                lbl_num_axons.Text = mdl.n_axons.ToString() + " Expected: " +
                    (Math.Pow(mdl.nerve_scale_ratio, 2) * mdl_real_num_axons).ToString("0");
        }

        private void Update_glia_perc()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Update_glia_perc()));
            else
                txt_glia_percent.Text = setts.percentGlia.ToString();
        }

        private void Update_mdl_prog(float prog)
        {
            Update_bottom_stat("Generating Model ... " + (prog * 100).ToString("0.0") + " %");
        }

        private void Update_image_siz_lbl()
        {
            string s = string.Format("{0} x {0} x {1}", im_size, (setts.no3dLayers>1)?setts.no3dLayers:1);
            if (InvokeRequired) Invoke(new Action(() => lbl_image_size.Text = s));
            else lbl_image_size.Text = s;
        }

        private void Update_delta_xy_lbl()
        {
            string s = string.Format("{0} nm", 1000/setts.resolution_xy);
            if (InvokeRequired) Invoke(new Action(() => lbl_delta_xy.Text = s));
            else lbl_delta_xy.Text = s;
        }

        private void Update_delta_z_lbl()
        {
            string s = string.Format("{0} nm", 1000/(float)setts.resolution_z);
            if (InvokeRequired) Invoke(new Action(() => lbl_delta_z.Text = s));
            else lbl_delta_z.Text = s;
        }

        private void Update_bio_iter_time_lbl()
        {
            string s = string.Format("{0} s", k_time_iter);
            if (InvokeRequired) Invoke(new Action(() => lbl_bioIterTime.Text = s));
            else lbl_bioIterTime.Text = s;
        }

        private void Update_bottom_stat(string s)
        {
            //statlbl.Text = s;
            if (InvokeRequired) Invoke(new Action(() => statlbl.Text = s));
            else statlbl.Text = s;
        }

        private void update_stat_sw_lbl(string s)
        {
            if (InvokeRequired) Invoke(new Action(() => statlbl_sweep.Text = s));
            else statlbl_sweep.Text = s;
        }

        private void Append_stat(string s)
        {
            if (InvokeRequired) Invoke(new Action(() => Append_stat(s)));
            else txt_status.AppendText(s.Replace("\n", Environment.NewLine));
        }

        private void Append_stat_ln(string s) { Append_stat(s + Environment.NewLine); }

        private uint prev_itr = 0;
        private float prev_itr_t = 0;

        private void Update_gui_labels()
        {
            Invoke(new Action(() =>
            {
                float now = tt_sim.Read();
                lbl_itr.Text = iteration.ToString("0");
                if(sum_tox < 0.1)
                {
                    lbl_tox.Text = (sum_tox*1000).ToString("0.000") + " ymol";
                }             
                else if(sum_tox < 100)
                {
                    lbl_tox.Text = sum_tox.ToString("0.000") + " zmol";
                }
                else if (sum_tox < 10000)
                {
                    lbl_tox.Text = (sum_tox / 1000).ToString("0.000") + " amol";
                }
                else 
                {
                    lbl_tox.Text = (sum_tox / 1000000).ToString("0.000") + " fmol";
                }

                
               lbl_stress_percent.Text = ((float)(numStressRGC[0]) * 100 / mdl.n_axons).ToString("0.0") + "%";


                // [DWL] yMol/area/height yM/V
                // OXYGEN: 5L of molecular oxygen in body
                //         5L / 0.1 m^3 = 50L / m^3
                //         1 mol ~ 22.4 L => 1L ~ 1/22.4 mol
                //         5/22.4 mol of oxygen in body
                //         density = 5/22.5 mol/100L = 2.23 mM
                //  [DWL] Nov 26: Accordying to "How mitocondria produce reactive oxygen species" M. Murphy 2009
                //        "the [O2] in air-saturated aquerous buffer at 37C is approx 200uM".
                //        "plausible estimated for mitocondrian [O2] in vivo are in the range of 3-30 uM"
                //        "tentative estimates of[O2-] within mitochondrial matrix is in range of 10-200 pM"
                //
                //  [DWL] => needs some review in light of above


                lbl_density.Text = (sum_tox  / bioVolume * 1000).ToString("0.000") + "nM"; 
                lbl_healthy_percent.Text = ((float)(numAliveRGC[0] - numStressRGC[0]) * 100 / mdl.n_axons).ToString("0.0") + "%";
                var span = TimeSpan.FromSeconds(now / 1000);
                lbl_sim_time.Text = string.Format("{0:00}:{1:00}:{2:00}", span.Minutes, span.Seconds, span.Milliseconds);

                float itr_p_s = 0;
                if (sim_stat == Sim_stat_enum.Running)
                {
                    if (iteration < prev_itr || now < prev_itr_t)
                        itr_p_s = iteration / now * 1000;
                    else
                        itr_p_s = (iteration - prev_itr) / (now - prev_itr_t) * 1000;

                    prev_itr_t = now;
                    prev_itr = iteration;
                }

                float btime = iteration * k_time_iter;

                if(btime < 1)
                    lbl_bio_time.Text = string.Format("{0:0000.00} ms", btime*1000);  
                else
                    lbl_bio_time.Text = string.Format("{0:000.000} s", btime);

                lbl_itr_s.Text = itr_p_s.ToString("0.0"); ;

                float x = (float)iteration / last_itr;
                float rat = 0.3F;
                float m = itr_p_s / (1 - x * rat);
                float estimated_total_itr_s = (m + (m * rat) * (1F - x)) / 2;

                if (!float.IsInfinity(estimated_total_itr_s) && !float.IsNaN(estimated_total_itr_s) && estimated_total_itr_s > 0)
                {
                    span = TimeSpan.FromSeconds((last_itr - iteration) / estimated_total_itr_s);
                    //lbl_density.Text = string.Format("{0}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
                }
     
            }));
        }

        // ====================================================================
        //                               Settings
        // ====================================================================

        private bool model_is_saved = false;
        private long model_id = 0;

        private void Init_settings_gui()
        {

            chk_use_3d_pattern.CheckedChanged += (s, e) =>
            {

                if (sim_stat != Sim_stat_enum.Running)
                {
                    setts.use3DSpecPattern = chk_use_3d_pattern.Checked;
                    SimParamsChanged();
                }

            };

            // Model parameters
            txt_nerve_scale.TextChanged += (s, e) =>
            {

                if (sim_stat != Sim_stat_enum.Running)
                {
                    preprocessDone = false;
                    sim_stat = Sim_stat_enum.None;

                    mdl.nerve_scale_ratio = Read_float(s) / 100F;
                    float nv = mdl.nerve_scale_ratio * mdl.real_diameter * setts.retinaMult;
                    setts.model_ratio = mdl.nerve_scale_ratio;
                    if(nv > 1000)
                        lbl_nerve_size.Text = (nv/1000F).ToString(".0") + " mm";
                    else
                        lbl_nerve_size.Text = (nv).ToString(".0") + " um";
                    SimParamsChanged();
                }
            };

            // Preprocess parameters

            txt_xy_resolution.TextChanged += (s, e) =>
            {
                

                if (sim_stat != Sim_stat_enum.Running)
                {
                    preprocessDone = false;
                    sim_stat = Sim_stat_enum.None;
                    string[] values = txt_xy_resolution.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        if (values.Length > 0) setts.resolution_xy = (int) Math.Ceiling((float) float.Parse(values[0]));
                    }
                    catch (ArgumentNullException)
                    {
                        setts.resolution_z = setts.resolution_xy = 1;
                    }
                    catch (FormatException)
                    {
                        setts.resolution_z = setts.resolution_xy = 1;
                    }
                    catch (OverflowException)
                    {
                        setts.resolution_z = setts.resolution_xy = 1;
                    }
                    try
                    {
                        if (values.Length > 1) setts.resolution_z = float.Parse(values[1]);
                        else setts.resolution_z = 1;
                    }
                    catch (ArgumentNullException)
                    {
                        setts.resolution_z = 1;
                    }
                    catch (FormatException)
                    {
                        setts.resolution_z = 1;
                    }
                    catch (OverflowException)
                    {
                        setts.resolution_z = 1;
                    }
                    
                    setts.no3dLayers = (int) (setts.resolution_z * Read_float(txt_3d_sample_length_um));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_ros_um));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_sod_um));
                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;
                    
                    
                    ReadMitoPercent();
                    ReadMitoLocation();
                    SimParamsChanged();
                }

            };

            txt_rec_interval.TextChanged += (s, e) => {

                int tmp = Read_int(txt_rec_interval);
                if(tmp <= 0 )
                {
                    tmp = 1;
                    txt_rec_interval.Text = "1"; // minimum value!!
                }
                setts.gui_iteration_period = tmp;
            };

            
            txt_sod_detox.TextChanged += (s, e) =>
            {

                string[] values = txt_sod_detox.Text.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if(values.Length < 1)
                {

                    setts.detox_mito  = setts.detox_rgc_intra = setts.detox_rgc_extra = 0;
                    return;
                }


                // [DWL] SOD2 is intra-mito
                setts.detox_mito = 0;
                try
                {
                    if (values.Length > 0) setts.detox_mito = float.Parse(values[0]);
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                   
                }
                

                if (values.Length < 2)
                {
                    setts.detox_rgc_intra = setts.detox_rgc_extra = 0;
                    return;
                }

                // [DWL] SOD1 is cytoplasmatic
                setts.detox_rgc_intra = 0;
                try
                {
                    if (values.Length > 1) setts.detox_rgc_intra = float.Parse(values[1]);
                }
                catch (Exception ev) when (MyFilter(ev))
                {

                }



                if (values.Length < 3)
                {
                    setts.detox_rgc_extra = 0;
                    return;
                }

                // [DWL] SOD3 is extra-cellular
                setts.detox_rgc_extra = 0;
                try
                {
                    if (values.Length > 2) setts.detox_rgc_extra = float.Parse(values[2]);
                }
                catch (Exception ev) when (MyFilter(ev))
                {

                }


                SimParamsChanged();
            };

            txt_alpha.TextChanged += (s, e) =>
            {
                setts.alpha = Read_float(s);
                if(setts.alpha<=0 || setts.alpha >=1)
                {
                    setts.alpha = (float)0.99;
                    txt_alpha.Text = setts.alpha.ToString();
                    //Append_stat_ln("Error: Alpha must be set to a value between (0..1). Setting to: "+setts.alpha);
                }
                SimParamsChanged();
            };

            txt_tissue_permeability.TextChanged += (s, e) =>
            {
                setts.perm_coeff_tissue = Read_float(s);
                SimParamsChanged();
            };

            txt_membrane_coeff_healthy.TextChanged += (s, e) =>
            {
                setts.diff_coeff_membrane = Read_float(s);
                SimParamsChanged();
            };

            txt_membrane_coeff_stress.TextChanged += (s, e) =>
            {
                setts.diff_coeff_membrane_stress = Read_float(s);
                SimParamsChanged();
            };

            txt_membrane_coeff_dead.TextChanged += (s, e) =>
            {
                setts.diff_coeff_membrane_dead = Read_float(s);
                SimParamsChanged();
            };

            txt_diff_dead_xy.TextChanged += (s, e) =>
            {
                setts.diff_coeff_dead_xy = Read_float(s);
                SimParamsChanged();
            };

            txt_diff_dead_z.TextChanged += (s, e) =>
            {
                setts.diff_coeff_dead_z = Read_float(s);
                SimParamsChanged();
            };

            txt_diff_glia_xy.TextChanged += (s, e) =>
            {
                setts.diff_coeff_glia_xy = Read_float(s);
                SimParamsChanged();
            };
            txt_diff_glia_z.TextChanged += (s, e) =>
            {
                setts.diff_coeff_glia_z = Read_float(s);
                SimParamsChanged();
            };
            txt_diff_live_xy.TextChanged += (s, e) =>
            {
                setts.diff_coeff_live_xy = Read_float(s);
                SimParamsChanged();
            };
            txt_diff_live_z.TextChanged += (s, e) =>
            {
                setts.diff_coeff_live_z = Read_float(s);
                SimParamsChanged();
            };

            txt_healthy_tox_prod.TextChanged += (s, e) =>
            {
                string[] values = txt_healthy_tox_prod.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                setts.tox_glia_mito_prod = setts.tox_rgc_mito_prod = 0;
                setts.tox_rgc_cyto_prod = setts.tox_inter_cellular_prod = setts.tox_tissue_prod = 0;
                bool error = false;

                try
                {
                    if (values.Length > 0) setts.tox_rgc_mito_prod = float.Parse(values[0]);
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                    error = true;
                }

                try
                {
                    if (values.Length > 1) setts.tox_glia_mito_prod = float.Parse(values[1]);
                    else setts.tox_glia_mito_prod = setts.tox_rgc_mito_prod;
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                    error = true;
                }



                try
                {
                    if (values.Length > 2) setts.tox_rgc_cyto_prod = float.Parse(values[2]);
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                    error = true;
                }

                try
                {
                    if (values.Length > 3) setts.tox_inter_cellular_prod = float.Parse(values[3]);
                    else setts.tox_inter_cellular_prod = setts.tox_rgc_cyto_prod;
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                    error = true;
                }

                try
                {
                    if (values.Length > 4) setts.tox_tissue_prod = float.Parse(values[4]);
                    else setts.tox_tissue_prod = 0;
                }
                catch (Exception ev) when (MyFilter(ev))
                {
                    error = true;
                }

                SimParamsChanged();
            };

            
            txt_glia_percent.TextChanged += (s, e) =>
            {
                setts.percentGlia = Read_float(s);
                SimParamsChanged();
            };

            txt_sod_percent.TextChanged += (s, e) =>
            {
                setts.percentSOD = Read_float(s);
                SimParamsChanged();
            };

            txt_h2s_tox_thr.TextChanged += (s, e) =>
            {
                string[] values = txt_h2s_tox_thr.Text.Split(new char[] { ',' , ' '}, StringSplitOptions.RemoveEmptyEntries);
                setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold = 0;
                
                try
                {
                    if (values.Length > 0) setts.rgc_apoptosis_tox_threshold = float.Parse(values[0]);
                }
                catch (ArgumentNullException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold = 0;
                }
                catch (FormatException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold = 0;
                }
                catch (OverflowException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold = 0;
                }
                try
                {
                    if (values.Length > 1) setts.glia_apoptosis_tox_threshold = float.Parse(values[1]);
                    else setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold;
                }
                catch(ArgumentNullException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold;
                }
                catch(FormatException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold;
                }
                catch (OverflowException)
                {
                    setts.glia_apoptosis_tox_threshold = setts.rgc_apoptosis_tox_threshold;
                }

                SimParamsChanged();
            };


            txt_s2h_tox_thr.TextChanged += (s, e) =>
            {
                string[] values = txt_s2h_tox_thr.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (values.Length > 0) setts.s2h_rgc_tox_thr = float.Parse(values[0]);
                }
                catch (ArgumentNullException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr = 0;
                }
                catch (FormatException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr = 0;
                }
                catch (OverflowException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr = 0;
                }
                try
                {
                    if (values.Length > 1) setts.s2h_glia_tox_thr = float.Parse(values[1]);
                    else setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr;
                }
                catch (ArgumentNullException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr;
                }
                catch (FormatException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr;
                }
                catch (OverflowException)
                {
                    setts.s2h_glia_tox_thr = setts.s2h_rgc_tox_thr;
                }

                SimParamsChanged();
            };

            txt_s2d_tox_thr.TextChanged += (s, e) =>
            {
                string[] values = txt_s2d_tox_thr.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (values.Length > 0) setts.s2d_rgc_tox_thr = float.Parse(values[0]);
                }
                catch (ArgumentNullException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr = 0;
                }
                catch (FormatException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr = 0;
                }
                catch (OverflowException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr = 0;
                }
                try
                {
                    if (values.Length > 1) setts.s2d_glia_tox_thr = float.Parse(values[1]);
                    else setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr;
                }
                catch (ArgumentNullException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr;
                }
                catch (FormatException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr;
                }
                catch (OverflowException)
                {
                    setts.s2d_glia_tox_thr = setts.s2d_rgc_tox_thr;
                }

                SimParamsChanged();
            };

            txt_initial_ros.TextChanged += (s, e) =>
            {
                //setts.initial_tox_value = Read_float(s);

                string[] values = txt_initial_ros.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (values.Length > 0) setts.initial_tox_value = float.Parse(values[0]);
                }
                catch (ArgumentNullException)
                {
                    setts.insult_tox = setts.initial_tox_value = 0;
                }
                catch (FormatException)
                {
                    setts.insult_tox = setts.initial_tox_value = 0;
                }
                catch (OverflowException)
                {
                    setts.insult_tox = setts.initial_tox_value = 0;
                }
                try
                {
                    if (values.Length > 1) setts.insult_tox = float.Parse(values[1]);
                    else setts.insult_tox = setts.initial_tox_value;
                }
                catch (ArgumentNullException)
                {
                    setts.insult_tox = setts.initial_tox_value;
                }
                catch (FormatException)
                {
                    setts.insult_tox = setts.initial_tox_value;
                }
                catch (OverflowException)
                {
                    setts.insult_tox = setts.initial_tox_value;
                }


                SimParamsChanged();
            };

            txt_other_initial.TextChanged += (s, e) =>
            {
                
                //SimParamsChanged();
            };
            txt_stress_tox_prod.TextChanged += (s, e) =>
            {
                string[] values = txt_stress_tox_prod.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                setts.tox_glia_mito_stress_prod = setts.tox_rgc_mito_stress_prod = 0;
                setts.tox_inter_cellular_stress_prod = setts.tox_rgc_cyto_stress_prod = 0;

                try
                {
                   if (values.Length > 0) setts.tox_rgc_mito_stress_prod = float.Parse(values[0]);
                }
                catch (Exception esc) when (MyFilter(esc))
                {
                   
                }

                try
                {
                    if (values.Length > 1) setts.tox_glia_mito_stress_prod = float.Parse(values[1]);
                    else setts.tox_glia_mito_stress_prod = setts.tox_rgc_mito_stress_prod;
                }
                catch (Exception esc) when (MyFilter(esc))
                {
                    setts.tox_glia_mito_stress_prod = setts.tox_rgc_mito_stress_prod;
                }



                try
                {
                    if (values.Length > 2) setts.tox_rgc_cyto_stress_prod = float.Parse(values[2]);
                }
                catch (Exception esc) when (MyFilter(esc))
                {

                }


                try
                {
                    if (values.Length > 3) setts.tox_inter_cellular_stress_prod = float.Parse(values[3]);
                    else setts.tox_inter_cellular_stress_prod = setts.tox_rgc_cyto_stress_prod;
                }
                catch (Exception esc) when (MyFilter(esc))
                {
                    setts.tox_inter_cellular_stress_prod = setts.tox_rgc_cyto_stress_prod;
                }

                SimParamsChanged();
            };

            txt_s2d_timer.TextChanged += (s, e) =>
            {
                // [DWL] the split method chops the text into substrings using the list of characters provided at delimiters
                //       we can use comas and spaces as separators between numbers
                string[] values = txt_s2d_timer.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (values.Length > 0) setts.rgc_stress_to_apoptosis_ms = (int) Math.Ceiling(1000F*float.Parse(values[0]));
                }
                catch (Exception esc) when (MyFilter(esc))
                {
                    setts.glia_stress_to_apoptosis_ms = setts.rgc_stress_to_apoptosis_ms = 0;
                }
                

                try
                {
                    if (values.Length > 1) setts.glia_stress_to_apoptosis_ms = (int)Math.Ceiling(1000F * float.Parse(values[1]));
                    else setts.glia_stress_to_apoptosis_ms = setts.rgc_stress_to_apoptosis_ms;
                }
                catch (Exception esc) when (MyFilter(esc))
                {
                    setts.glia_stress_to_apoptosis_ms = setts.rgc_stress_to_apoptosis_ms;
                }

                SimParamsChanged();
            };

            txt_new_model_params.TextChanged += (s, e) =>
            {
               
                string[] values = txt_new_model_params.Text.Split(new char[] { ';' , ',' ,' '}, StringSplitOptions.RemoveEmptyEntries);


                if (values.Length > 0)
                {
                    mdl_real_nerve_r = float.Parse(values[0])/2;
                }
                if (values.Length > 1)
                {
                    mdl_vessel_ratio = float.Parse(values[1]);
                }
                if (values.Length > 2)
                {
                    mdl_clearance = float.Parse(values[2]);
                }
                if (values.Length > 3)
                {
                    axon_bmp_file = fileDirPrefix + values[3];
                }
                else
                {
                    axon_bmp_file = fileDirPrefix + default_bmp_file;
                }
            };

            txt_mito_percent.TextChanged += (s, e) =>
            {
                ReadMitoPercent();
                SimParamsChanged();
            };

            txt_mito_location.TextChanged += (s, e) =>
            {
                ReadMitoLocation();
                SimParamsChanged();
            };

            txt_3d_sample_length_um.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {
                    Stop_sim(Sim_stat_enum.Stopped);
                    
                    setts.no3dLayers = (int)(setts.resolution_z * Read_float(s));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_ros_um));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_sod_um));
                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;
                    setts.apoptotic3DLocation = (int)(setts.resolution_z * Read_float(txt_stress_z_position));
                    if (setts.no3dLayers > 1)
                        setts.apoptotic3DLocation %= setts.no3dLayers;


                    ReadMitoPercent();
                    ReadMitoLocation();
                    
                    radio_button_coronal.Enabled = true;
                    radio_button_transversal.Enabled = true;
                    radio_button_sagittal.Enabled = true;
                    txt_diff_glia_z.Enabled = true;
                    txt_diff_live_z.Enabled = true;
                    txt_diff_dead_z.Enabled = true;
                    
                    //Append_stat_ln("Info: Number of layers changed. Call preprocess next.....");
                    //Preprocess_model();
                    //Append_stat_ln("Info: Preprocessing complete.");
                    Set_btn_start_txt("&Start", System.Drawing.Color.Gray); btn_start.Enabled = false;
                }
                else
                {
                    Append_stat_ln("Warning: Cannot change the number of layers while the sim is running.");
                }

            };

            txt_3d_ros_um.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {

                    setts.no3dLayers = (int)(setts.resolution_z * Read_float(txt_3d_sample_length_um));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(s));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_sod_um));

                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;
                    SimParamsChanged();
                }
            };

            txt_prod_sod_timechange.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {
                    setts.sodTimeSpec = txt_prod_sod_timechange.Text;
                    SimParamsChanged();
                }

            };

            txt_stress_z_position.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {

                    setts.no3dLayers = (int)(setts.resolution_z * Read_float(txt_3d_sample_length_um));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_ros_um));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_sod_um));

                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;

                    setts.apoptotic3DLocation = (int)(setts.resolution_z * Read_float(s));
                    if(setts.no3dLayers > 1 ) 
                        setts.apoptotic3DLocation %= setts.no3dLayers;

                    SimParamsChanged();
                }
            };

            txt_3d_sod_um.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {
                    setts.no3dLayers = (int)(setts.resolution_z * Read_float(txt_3d_sample_length_um));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_ros_um));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(s));

                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;
                    SimParamsChanged();
                }
            };

            txt_3d_membrane.TextChanged += (s, e) =>
            {
                if (sim_stat != Sim_stat_enum.Running)
                {
                    setts.no3dLayers = (int)(setts.resolution_z * Read_float(txt_3d_sample_length_um));
                    setts.toxLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_ros_um));
                    setts.sodLayerStart = (int)(setts.resolution_z * Read_float(txt_3d_sod_um));

                    setts.sod3dString = txt_3d_sod_um.Text;
                    setts.ros3dString = txt_3d_ros_um.Text;
                    setts.mem3dString = txt_3d_membrane.Text;
                    SimParamsChanged();
                }
            };

            //txt_layer_to_display.TextChanged += (s, e) => setts.layerToDisplay = Read_int(s);

            radio_button_coronal.CheckedChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_coronal.Checked)
                {
                    sox_track_bar_coronal.Visible = true;
                    sox_track_bar_coronal.Enabled = true;
                    TopoView();
                    lbl_coronal_dist.Visible = true;
                    lbl_coronal_prox.Visible = true;

                    chk_show_dead_axons.Enabled = true;
                    chk_show_live_axons.Enabled = true;
                    chk_show_stress.Enabled = true;
                    showdir = 0;

                    lbl_body_plane.Text = "Coronal";

                    int layerToDisplay = sox_track_bar_coronal.Value;
                    if(setts.no3dLayers <= 1)
                    {
                        layerToDisplay = 0;
                    }
                    else 
                    {
                        layerToDisplay = Mod(layerToDisplay, setts.no3dLayers);
                    }

                    setts.layerToDisplay = layerToDisplay;
                    sox_track_bar_coronal.Value = setts.layerToDisplay;
                    
                    lbl_display_view.Text = "Proximal Delta= " + ((float)setts.layerToDisplay / setts.resolution_z) + " um";
                    lbl_x_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    // Append_stat_ln("Info: XY " + setts.layerToDisplay);
                    if (preprocessDone)
                    {
                        Update_show_opts();
                    }

                }
                else
                {
                    sox_track_bar_coronal.Visible = false;
                    HideVisualFieldLabels();
                    lbl_coronal_dist.Visible = false;
                    lbl_coronal_prox.Visible = false;
                }
            };

            radio_button_transversal.CheckedChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_transversal.Checked)
                {
                    sox_track_bar_transversal.Visible = true;
                    sox_track_bar_transversal.Enabled = true;
                    TopoView();
                    lbl_transversal_inf.Visible = true;
                    lbl_transversal_superior.Visible = true;

                    chk_show_dead_axons.Enabled = false;
                    chk_show_live_axons.Enabled = false;
                    chk_show_stress.Enabled = false;
                    showdir = 1;

                    lbl_body_plane.Text = "Transversal";

                    int layerToDisplay = bmp_im_size - sox_track_bar_transversal.Value;
                    if(layerToDisplay < 0)
                    {
                        layerToDisplay = 0;
                    }
                    if (layerToDisplay >= bmp_im_size)
                    {
                        layerToDisplay = bmp_im_size;
                    }
                    setts.layerToDisplay = layerToDisplay;
                    lbl_display_view.Text = "Superior Delta= " + ((float)setts.layerToDisplay/  (float)bmp_im_size * mdl_nerve_r *2).ToString("0.00") + " um";
                    lbl_y_dim.Text = ((setts.no3dLayers > 1?setts.no3dLayers :1) / setts.resolution_z).ToString() + " um";
                    lbl_x_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    //Append_stat_ln("Info: XZ " + setts.layerToDisplay);
                    if (preprocessDone)
                    {
                       Update_show_opts();
                    }
                }
                else
                {
                    sox_track_bar_transversal.Visible = false;
                    lbl_transversal_inf.Visible = false;
                    lbl_transversal_superior.Visible = false;
                }
            };

            radio_button_sagittal.CheckedChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_sagittal.Checked)
                {

                    sox_track_bar_sagittal.Visible = true;
                    sox_track_bar_sagittal.Enabled = true;

                    lbl_sagittal_nasal.Visible = true;
                    lbl_sagittal_temp.Visible = true;

                    TopoView();

                    chk_show_dead_axons.Enabled = false;
                    chk_show_live_axons.Enabled = false;
                    chk_show_stress.Enabled = false;
                    
                    showdir = 2;

                    lbl_body_plane.Text = "Sagittal";

                    setts.layerToDisplay = sox_track_bar_sagittal.Value;
                    if (setts.layerToDisplay >= bmp_im_size)
                    {
                        setts.layerToDisplay = bmp_im_size;
                    }
                    //Append_stat_ln("Info: YZ " + setts.layerToDisplay);
                    lbl_display_view.Text = "Temporal Delta= " + ((float)setts.layerToDisplay / (float)bmp_im_size * mdl_nerve_r *2).ToString("0.00") + " um";
                    lbl_x_dim.Text = ((setts.no3dLayers>1?setts.no3dLayers:1)/setts.resolution_z).ToString() + " um";
                    lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    if (preprocessDone)
                    {
                        Update_show_opts();
                    }
                }
                else
                {
                    sox_track_bar_sagittal.Visible = false;
                    lbl_sagittal_nasal.Visible = false;
                    lbl_sagittal_temp.Visible = false;
                }
            };

            sox_track_bar_transversal.ValueChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_transversal.Checked)
                {
                    int layerToDisplay = bmp_im_size - sox_track_bar_transversal.Value;
                    if (layerToDisplay < 0)
                    {
                        layerToDisplay = 0;
                    }
                    if(layerToDisplay >= bmp_im_size)
                    {
                        layerToDisplay = bmp_im_size;
                    }
                    setts.layerToDisplay = layerToDisplay;
                    lbl_display_view.Text = "Superior Delta= " + ((float)setts.layerToDisplay / (float)bmp_im_size * mdl_nerve_r * 2).ToString("0.00") + " um";
                    lbl_y_dim.Text = ((setts.no3dLayers>1?setts.no3dLayers:1) / setts.resolution_z).ToString() + " um";
                    lbl_x_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    //Append_stat_ln("Info: XZ " + setts.layerToDisplay);
                    if (preprocessDone)
                    {
                        Update_show_opts();
                    }
                }
                else
                {
                    sox_track_bar_transversal.Enabled = false;
                }
            };

            sox_track_bar_sagittal.ValueChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_sagittal.Checked)
                {
                    setts.layerToDisplay = sox_track_bar_sagittal.Value;
                    if (setts.layerToDisplay >= bmp_im_size)
                    {
                        setts.layerToDisplay = bmp_im_size;
                    }
                    //Append_stat_ln("Info: YZ " + setts.layerToDisplay);
                    lbl_display_view.Text = "Temporal Delta= " + ((float)setts.layerToDisplay / (float)bmp_im_size * mdl_nerve_r * 2).ToString("0.00") + " um";
                    lbl_x_dim.Text = ((setts.no3dLayers>1?setts.layerToDisplay:1) / setts.resolution_z).ToString() + " um";
                    lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    lbl_x_dim.Text = ((setts.no3dLayers>1?setts.no3dLayers :1) / setts.resolution_z).ToString() + " um";
                    lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    if (preprocessDone)
                    {
                        Update_show_opts();
                    }
                }
                else
                {
                    sox_track_bar_sagittal.Enabled = false;
                }
            };

            sox_track_bar_coronal.ValueChanged += (s, e) =>
            {
                if (direction_group_box.Enabled && radio_button_coronal.Checked)
                {
                    int layerToDisplay = sox_track_bar_coronal.Value;
                    if(setts.no3dLayers <= 1 )
                    {
                        layerToDisplay = 0;
                    }
                    else 
                    {
                        layerToDisplay = Mod(layerToDisplay, setts.no3dLayers);
                    }

                    setts.layerToDisplay = layerToDisplay;
                    sox_track_bar_coronal.Value = setts.layerToDisplay;
                    
                    //Append_stat_ln("Info: XY " + setts.layerToDisplay);
                    lbl_display_view.Text = "Proximal Delta= " + (setts.layerToDisplay * setts.resolution_z) + " um";
                    lbl_x_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    lbl_y_dim.Text = (mdl_nerve_r * 2).ToString() + " um";
                    if (preprocessDone)
                    {
                        Update_show_opts();
                    }
                }
                else {
                    sox_track_bar_coronal.Enabled = false;
                }
            };

            // The Maximum property sets the value of the track bar when
            // the slider is all the way to the right.
            //sox_track_bar.Minimum = 0;
            //sox_track_bar.Maximum = setts.no3dLayers;

            // The TickFrequency property establishes how many positions
            // are between each tick-mark.
            //sox_track_bar.TickFrequency = 1;

            // The LargeChange property sets how many positions to move
            // if the bar is clicked on either side of the slider.
            //sox_track_bar.LargeChange = 1;

            // The SmallChange property sets how many positions to move
            // if the keyboard arrows are used to move the slider.
            //sox_track_bar.SmallChange = 1;

            btn_save_model.Click += (s, e) =>
            {
                if (model_is_saved) { Append_stat_ln("Model is already saved."); return; }
                if (model_id == 0) { Append_stat_ln("Model is not yet generated."); return; }
                Debug.WriteLine(model_id);
                var fil_name = ProjectOutputDir + @"Models\" + Dec2B36(model_id) + " " + (mdl.nerve_scale_ratio * 100).ToString("0") + "%" + ".mdat";
                Save_mdl(fil_name);
                Append_stat_ln("Model saved to " + fil_name);
                model_is_saved = true;                
            };

            btn_load_model.Click += (s, e) =>
            {
                var FD = new OpenFileDialog()
                {
                    InitialDirectory = ProjectOutputDir + @"Models\",
                    Title = "Load Model",
                    Filter = "Model Data files (*.mdat) | *.mdat",
                    RestoreDirectory = true,
                    AutoUpgradeEnabled = false
                };
                if (FD.ShowDialog() != DialogResult.OK) return;
                Load_model(FD.FileName);
                Append_stat_ln("Info: Loaded " + FD.FileName + " model");
                Append_stat_ln("Info: Processing Model ....");
                Preprocess_model();
                Append_stat_ln("Info: Processing Model Done.");
                Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true;
            };

            btn_save_setts.Click += (s, e) =>
            {
                var fil_name = ProjectOutputDir + @"Settings\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".sdat";
                setts.insult = new float[] { insult_x, insult_y, insult_r };
                WriteToBinaryFile(fil_name, setts);
                Append_stat_ln("Settings saved to " + fil_name);
            };

            btn_load_setts.Click += (s, e) =>
            {
                var FD = new OpenFileDialog()
                {
                    InitialDirectory = ProjectOutputDir + @"Settings\",
                    Title = "Load Settings",
                    Filter = "Setting files (*.sdat) | *.sdat",
                    RestoreDirectory = true,
                    AutoUpgradeEnabled = false
                };
                if (FD.ShowDialog() != DialogResult.OK) return;
                Load_settings(FD.FileName);
                Append_stat_ln("Info: Loaded " + FD.FileName + " settings.");
            };
        }


        private bool MyFilter(Exception e)
        {
            return e is ArgumentNullException || e is FormatException || e is OverflowException;
        }


        /**
         * [DWL] The structure of the line is as follows:
         *       initLen, initVal ; repeat*(z1, v1 | z2, v2)
         * 
         */

        private ZStruct ParseZDescriptor(string s)
        {
            ZStruct tmp = new ZStruct();
            if (s == null) return tmp; ;
            string[] values = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            tmp.specLen = 0;
            bool error = false;

            if (values.Length > 0)
            {
                string[] init = values[0].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (init.Length > 0) tmp.initLen = float.Parse(init[0]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                try
                {
                    if (init.Length > 1) tmp.initVal = float.Parse(init[1]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

            }

            if (error == true) return tmp;

            if (values.Length > 1)
            {
                string[] rest = values[1].Split(new char[] { '*', '(', ')', '|', '&', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (rest.Length > 0) tmp.repeat = (int)Math.Ceiling((float)float.Parse(rest[0]));
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                try
                {
                    if (rest.Length > 1) tmp.z1Len = float.Parse(rest[1]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                try
                {
                    if (rest.Length > 2) tmp.z1Val = float.Parse(rest[2]);
                    tmp.specLen++;
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                if (error == true) return tmp;

                try
                {
                    if (rest.Length > 3) tmp.z2Len = float.Parse(rest[3]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                try
                {
                    if (rest.Length > 4) tmp.z2Val = float.Parse(rest[4]);
                    tmp.specLen++;
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }
                
                if (error == true) return tmp;

                try
                {
                    if (rest.Length > 5) tmp.z3Len = float.Parse(rest[5]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                try
                {
                    if (rest.Length > 6) tmp.z3Val = float.Parse(rest[6]);
                    tmp.specLen++;
                }
                catch (Exception e) when (MyFilter(e))
                {
                    error = true;
                }

                if (error == true) return tmp;

                try
                {
                    if (rest.Length > 7) tmp.z4Len = float.Parse(rest[7]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                    // error = true;
                }

                try
                {
                    if (rest.Length > 8) tmp.z4Val = float.Parse(rest[8]);
                    tmp.specLen++;
                }
                catch (Exception e) when (MyFilter(e))
                {
                   // error = true;
                }

            }
            

            return tmp;
        }

        private PSStruct ParsePSDescriptor(string s)
        {
            PSStruct tmp = new PSStruct();
            if (s == null) return tmp; ;
            string[] values = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


            if (values.Length > 0)
            {
                string[] init = values[0].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (init.Length > 0) tmp.initLen = float.Parse(init[0]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (init.Length > 1) tmp.initValP = float.Parse(init[1]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (init.Length > 2) tmp.initValS = float.Parse(init[2]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

            }

            if (values.Length > 1)
            {
                string[] rest = values[1].Split(new char[] { '*', '(', ')', '|', '&', ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (rest.Length > 0) tmp.repeat = (int)Math.Ceiling((float)float.Parse(rest[0]));
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 1) tmp.z1Len = float.Parse(rest[1]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 2) tmp.z1ValP = float.Parse(rest[2]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 3) tmp.z1ValS = float.Parse(rest[3]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 4) tmp.z2Len = float.Parse(rest[4]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 5) tmp.z2ValP = float.Parse(rest[5]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

                try
                {
                    if (rest.Length > 6) tmp.z2ValS = float.Parse(rest[6]);
                }
                catch (Exception e) when (MyFilter(e))
                {
                }

            }


            return tmp;
        }

        private void ReadMitoPercent()
        {
            mitoSpec.initMito = mitoSpec.endMito = mitoSpec.increment = 0;
            string[] rest = txt_mito_percent.Text.Split(new char[] {  '|', ';', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (rest.Length > 0)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[0])) / 100;
                    if (f > 1) f = 1;
                    else if (f < 0) f = 0;
                    mitoSpec.initMito = mitoSpec.endMito = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            try
            {
                if (rest.Length > 1)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[1])) / 100;
                    if (f > 1) f = 1;
                    else if (f < 0) f = 0;
                    mitoSpec.endMito = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            try
            {
                if (rest.Length > 2)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[2])) / 100;
                    if (f > 1) f = 1;
                    else if (f < 0) f = 0;
                    mitoSpec.increment = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            
            // we need this number in [0 ..1] range
            // transform from %
            setts.mitoPercent = mitoSpec.initMito;
            
            
        }

        private void ReadMitoLocation()
        {
            string[] rest = txt_mito_location.Text.Split(new char[] { '|', ';', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            setts.mitoLocation = -1;
            setts.mitoRegularPercent = 0.10f;
            setts.axonPixelThreshold = 1;
            setts.axonRadiusThreshold = 0.5f;
            try
            {
                if (rest.Length > 0)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[0])) ;
                    setts.mitoLocation = f;
                    

                    if (setts.mitoLocation >= 0)
                    {
                        if (setts.mitoLocation + setts.mitoPercent > 1)
                        {
                            setts.mitoLocation = 1 - setts.mitoPercent;
                        }
                        if (setts.mitoLocation > 1) setts.mitoLocation = 1;
                        if (setts.mitoLocation < 0) setts.mitoLocation = 0;
                    }

                    
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            try
            {
                if (rest.Length > 1)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[1])) / 100;
                    if (f > 1) f = 1;
                    else if (f <= 0) f = 0.04f; // if less or equal to zero default to 4%
                    setts.mitoRegularPercent = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            catch (Exception e) when (MyFilter(e))
            {
            }

            try
            {
                if (rest.Length > 2)
                {
                    int f = (int)Math.Ceiling((float)float.Parse(rest[2]));
                    if (f > 20) f = 20;
                    else if (f <= 1) f = 1; 
                    setts.axonPixelThreshold = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

            try
            {
                if (rest.Length > 3)
                {
                    float f = (float)Math.Ceiling((float)float.Parse(rest[3]));
                    if (f > 20) f = 20;
                    else if (f <= 0) f = 0.1f;
                    setts.axonRadiusThreshold = f;
                }
            }
            catch (Exception e) when (MyFilter(e))
            {
            }

        }

        private void ResetPlaneViewer()
        {
            if (InvokeRequired)
                Invoke(new Action(() => ResetPlaneViewer()));
            else
            {
                sox_track_bar_coronal.Maximum = (setts.no3dLayers>1?setts.no3dLayers-1:0);
                setts.layerToDisplay = 0;
                sox_track_bar_coronal.Value = setts.layerToDisplay;
               
            }
        }


        private void DisableButtons()
        {
            if (InvokeRequired)
                Invoke(new Action(() => DisableButtons()));
            else
            {
                groupBoxInitialStates.Enabled = false;
                groupBoxDiffusion.Enabled = false;
                samplingParameter.Enabled = false;
                groupBox1.Enabled = false;
                groupBoxInitialStates.Enabled = false;
                groupBoxReactionRates.Enabled = false;
                groupBoxSegmentStateTransitions.Enabled = false;
                groupBoxCellStateTransitions.Enabled = false;

                
                btn_preprocess.Enabled = false;
                btn_preprocess.BackColor = System.Drawing.Color.LightGray;
                btn_reset.Enabled = false;
                btn_load_setts.Enabled = false;
                btn_load_setts.BackColor = System.Drawing.Color.LightGray;
                btn_load_model.Enabled = false;
                btn_load_model.BackColor = System.Drawing.Color.LightGray;
                btn_save_model.Enabled = false;
                btn_generate_model.Enabled = false;
                
              
                txt_stop_itr.Enabled = false;
                txt_stop_time.Enabled = false;
                txt_img_size.Enabled = false;
                //txt_block_siz.Enabled = false;
                
                
            }
        }

        private void EnableButtons()
        {
            if (InvokeRequired)
                Invoke(new Action(() => EnableButtons()));
            else
            {

                groupBoxInitialStates.Enabled = true;
                groupBoxDiffusion.Enabled = true;
                samplingParameter.Enabled = true;
                groupBox1.Enabled = true;
                groupBoxInitialStates.Enabled = true;
                groupBoxReactionRates.Enabled = true;
                groupBoxSegmentStateTransitions.Enabled = true;
                groupBoxCellStateTransitions.Enabled = true;

                btn_preprocess.Enabled = true;
                btn_record_avi.Enabled = true;
                btn_record_avi.BackColor = System.Drawing.Color.Green;
                btn_img_snapshot.Enabled = true;
                btn_img_snapshot.BackColor = System.Drawing.Color.Green;

                btn_preprocess.BackColor = System.Drawing.Color.Green;
                btn_reset.Enabled = true;
                btn_load_setts.Enabled = true;
                btn_load_setts.BackColor = System.Drawing.Color.Green;
                btn_load_model.Enabled = true;
                btn_load_model.BackColor = System.Drawing.Color.Green;
                btn_save_model.Enabled = true;
                btn_generate_model.Enabled = true;

                txt_stop_itr.Enabled = true;
                txt_stop_time.Enabled = true;
                txt_img_size.Enabled = true;
                //txt_block_siz.Enabled = true;

            }
        }

        private void SimParamsChanged()
        {
            if (InvokeRequired)
                Invoke(new Action(() => SimParamsChanged()));
            else
            {
                Stop_sim(Sim_stat_enum.Stopped);
                Set_btn_start_txt("&Start", System.Drawing.Color.Gray); btn_start.Enabled = false; btn_reset.Enabled = false;
                //Append_stat_ln("Info: Simulation parameter changed. Call preprocess next.....");
            }
        }

        private void Load_model(string path)
        {
            if (!File.Exists(path)) return;
            Load_mdl(path);
            Update_mdl_and_setts_ui();
            Append_stat_ln("Model Successfully Loaded.");
            Update_bottom_stat("Model Successfully Loaded.");
            model_is_saved = true;
        }

        private void Load_settings(string path)
        {
            if (!File.Exists(path)) return;
            setts = ReadFromBinaryFile<Setts>(path);
            insult_x = setts.insult[0];
            insult_y = setts.insult[1];
            insult_r = setts.insult[2];
            Update_mdl_and_setts_ui();
        }

        private void Update_mdl_and_setts_ui()
        {

            txt_mito_percent.Text = (setts.mitoPercent*100).ToString();
            txt_mito_location.Text = setts.mitoLocation.ToString();

            String a = setts.ros3dString;
            String b = setts.sod3dString;
            String c = setts.mem3dString;
            int z = setts.apoptotic3DLocation;

            txt_3d_sample_length_um.Text = (((float)(setts.no3dLayers>1?setts.no3dLayers:1)) / setts.resolution_z).ToString();

            txt_3d_ros_um.Text = a;
            txt_3d_sod_um.Text = b;
            txt_3d_membrane.Text = c;
            txt_stress_z_position.Text = z.ToString();

            txt_prod_sod_timechange.Text = setts.sodTimeSpec;

            setts.ros3dString = a;
            setts.sod3dString = b;
            setts.mem3dString = c;
            setts.apoptotic3DLocation = z;

            if (setts.retinaMult == 0)
            {
                setts.retinaMult = 1;
                chk_retina.Checked = false;
                lbl_sample_type.Text = "Optic Nerve";
            }
            else if (setts.retinaMult == 1)
            {
                chk_retina.Checked = false;
                lbl_sample_type.Text = "Optic Nerve";
            }
            else
            {
                setts.resolution_xy = 1;
                setts.resolution_z = 1;
                txt_xy_resolution.Text = setts.resolution_xy.ToString() + "," + setts.resolution_z.ToString();
                chk_retina.Checked = true;
                lbl_sample_type.Text = "Retina";

            }

            if (setts.no3dLayers <= 0)
            {
                setts.no3dLayers = 1;
            }

            txt_3d_sample_length_um.Text = (((float)(setts.no3dLayers>1?setts.no3dLayers:1)) / setts.resolution_z).ToString();

            if(setts.model_ratio == 0)
            {
                setts.model_ratio = mdl.nerve_scale_ratio = 0.01f;
            }
            else
            {
                mdl.nerve_scale_ratio = setts.model_ratio;
            }

            txt_nerve_scale.Text = (setts.model_ratio * 100F).ToString();
            

            txt_xy_resolution.Text = setts.resolution_xy.ToString() + "," + setts.resolution_z.ToString();
            txt_alpha.Text = setts.alpha.ToString();

            txt_sod_detox.Text = setts.detox_mito.ToString() + "," + setts.detox_rgc_intra.ToString() + "," + setts.detox_rgc_extra.ToString();

            txt_membrane_coeff_healthy.Text = setts.diff_coeff_membrane.ToString();
            txt_membrane_coeff_stress.Text = setts.diff_coeff_membrane_stress.ToString();
            txt_membrane_coeff_dead.Text = setts.diff_coeff_membrane_dead.ToString();
            txt_diff_dead_xy.Text = setts.diff_coeff_dead_xy.ToString();
            txt_diff_dead_z.Text = setts.diff_coeff_dead_z.ToString();
            txt_diff_glia_xy.Text = setts.diff_coeff_glia_xy.ToString();
            txt_diff_glia_z.Text = setts.diff_coeff_glia_z.ToString();
            txt_diff_live_xy.Text = setts.diff_coeff_live_xy.ToString();
            txt_diff_live_z.Text = setts.diff_coeff_live_z.ToString();

            txt_healthy_tox_prod.Text = setts.tox_rgc_mito_prod.ToString() + "," + setts.tox_glia_mito_prod.ToString() + "," + setts.tox_rgc_cyto_prod + "," + setts.tox_inter_cellular_prod + "," + setts.tox_tissue_prod;
            txt_h2s_tox_thr.Text = setts.rgc_apoptosis_tox_threshold.ToString() + "," + setts.glia_apoptosis_tox_threshold.ToString();
            txt_s2h_tox_thr.Text = setts.s2h_rgc_tox_thr.ToString() + "," + setts.s2h_glia_tox_thr.ToString();
            txt_s2d_tox_thr.Text = setts.s2d_rgc_tox_thr.ToString() + "," + setts.s2d_glia_tox_thr.ToString();

            txt_stress_tox_prod.Text = setts.tox_rgc_mito_stress_prod.ToString() + "," + setts.tox_glia_mito_stress_prod.ToString() + "," + setts.tox_rgc_cyto_stress_prod + "," +  setts.tox_inter_cellular_stress_prod;
            txt_s2d_timer.Text = (setts.rgc_stress_to_apoptosis_ms / 1000).ToString() + "," + (setts.glia_stress_to_apoptosis_ms/1000).ToString();
            txt_initial_ros.Text = setts.initial_tox_value.ToString() + "," + setts.insult_tox.ToString(); 
            txt_glia_percent.Text = setts.percentGlia.ToString();
            txt_sod_percent.Text = setts.percentSOD.ToString();

            txt_tissue_permeability.Text = setts.perm_coeff_tissue.ToString();

            //txt_3d_layers.Text = setts.no3dLayers.ToString();
            //txt_3d_tox_start.Text = setts.toxLayerStart.ToString();
            //txt_3d_tox_stop.Text = setts.toxLayerStop.ToString();
           
            
            txt_new_model_params.Text = (mdl.real_diameter).ToString() + "," + mdl.vessel_ratio.ToString() +"," + mdl.clearance.ToString();

            txt_rec_interval.Text = setts.gui_iteration_period.ToString();

            chk_use_3d_pattern.Checked = setts.use3DSpecPattern;

            chk_fire_factor.Checked = setts.useFireFactor;

            noMitoScaleCheckBox.Checked = setts.noMitoScaleFactor;

           

            chk_length_adj.Checked = setts.lengthCheck;

            float nv = mdl.nerve_scale_ratio * mdl.real_diameter  * setts.retinaMult;
            if (nv > 1000)
                lbl_nerve_size.Text = (nv / 1000F).ToString(".0") + " mm";
            else
                lbl_nerve_size.Text = (nv).ToString(".0") + " um";

            if (setts.useGliaDetoxOnDeath == true) rbDDTox3.Checked = true;
            else if (setts.noDetoxOnDeath == true) rbDDTox0.Checked = true;
            else rbDDTox1.Checked = true;

            Update_num_axons_lbl();
        }

        private float Read_float(object o)
        {
            TextBox txtB = (TextBox)o;
            float num;
            if (!float.TryParse(txtB.Text, out num)) return 0;
            return num;
        }

        private int Read_int(object o)
        {
            TextBox txtB = (TextBox)o;
            int num;
            if (!int.TryParse(txtB.Text, out num))
            {
                //txtB.Text = "0";
                //txtB.SelectionStart = 0;
                //txtB.SelectionLength = txtB.Text.Length;
                return 0;
            }
            return num;
        }


        private async void GenerateNewModel()
        {
            if (sim_stat != Sim_stat_enum.Running && !new_model_worker.IsBusy)
            {
                Append_stat_ln("Info: Generating new model. Please wait!");
                Stop_sim(Sim_stat_enum.Stopped);
                SimParamsChanged();
                new_model_worker.RunWorkerAsync();
                while(new_model_worker.IsBusy)
                    await Task.Delay(200);
                Append_stat_ln("Info: Generating new model. Done!");

                Append_stat_ln("Info: Preprocessing model.");
                Preprocess_model();
                Append_stat_ln("Info: Preprocessing done.");
                Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true; btn_reset.Enabled = true;
            }
            else {
                return;
            }
            
            
        }

        private async void TestLoop(int iter, bool new_model)
        {
            int delay_ms = 2000;
            int failures = 0;

            //Append_stat_ln("Test Loop");
            //Append_stat_ln("[ROS]        {H}");
            int mitoIter = 1;
            if (mitoSpec.initMito < mitoSpec.endMito)
            {
                if (mitoSpec.initMito > 0)
                {
                    mitoIter = (int)((mitoSpec.endMito - mitoSpec.initMito) / mitoSpec.increment);
                }
            }

            int totalIter = iter * mitoIter;
            
            float[] ros = new float[totalIter];
            int[] no = new int[totalIter];
            int[] h = new int[totalIter];
            int[] s = new int[totalIter];
            int[] d = new int[totalIter];
            float[] mito = new float[totalIter];
            float[,] topoZoneStats = new float[totalIter, opticNerveZones];
            float[,] topoZoneROS = new float[totalIter, opticNerveZones];
            
           
            for(int j =0; j < mitoIter; j++)
            {
                setts.mitoPercent = mitoSpec.initMito + (mitoSpec.increment) * j;
                for (int i = 0; i < iter; i++)
                {
                    if (sim_stat != Sim_stat_enum.Running && sim_stat != Sim_stat_enum.Paused && !new_model_worker.IsBusy)
                    {
                        if (new_model)
                        {
                            //Append_stat_ln("Info: Generating new model. Please wait!");
                            Stop_sim(Sim_stat_enum.Stopped);
                            SimParamsChanged();
                            new_model_worker.RunWorkerAsync();
                            while (new_model_worker.IsBusy)
                                await Task.Delay(delay_ms / 10);
                            //Append_stat_ln("Info: Generating new model. Done!");
                        }


                        //Append_stat_ln("Info: Preprocessing model.");
                        Preprocess_model();
                        //Append_stat_ln("Info: Preprocessing done.");
                        Set_btn_start_txt("&Start", System.Drawing.Color.Green); btn_start.Enabled = true; btn_reset.Enabled = true;
                    }
                    else if (sim_stat == Sim_stat_enum.Paused)
                    {
                        //nothing to do??
                    }
                    else
                    {
                        return;
                    }
                    label_test_no.Text = "[" + (j).ToString() + "," + (i).ToString() + "]";
                    Start_sim();
                    //Debug.WriteLine("simulation should've been started" + sim_stat);
                    while (sim_stat != Sim_stat_enum.Successful && sim_stat != Sim_stat_enum.Failed)
                    {
                        await Task.Delay(delay_ms);
                        if (stop_sweep_req) { stop_sweep_req = false; sweep_is_running = false; return; }
                    }
                    await Task.Delay(delay_ms / 5);

                    if (sim_stat == Sim_stat_enum.Failed)
                    {
                        failures++;
                    }
                    else
                    {
                        Save_Progress(ProjectOutputDir + @"Progression\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".prgim");
                        string adr = ProjectOutputDir + @"Snapshots\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".jpg";

                        if (bmp != null)
                        {
                            bmp.Save(adr);
                            Append_stat_ln("Snapshot saved to: " + adr);
                        }
                        ros[j*iter+i] = sum_tox / bioVolume;
                        no[j * iter + i] = mdl.n_axons;
                        h[j * iter + i] = numAliveRGC[0] - numStressRGC[0];
                        s[j * iter + i] = numStressRGC[0];
                        d[j * iter + i] = mdl.n_axons - numAliveRGC[0];
                        mito[j * iter + i] = setts.mitoPercent * 100;
                        //Append_stat((sum_tox / bioVolume).ToString("0.000") + "      ");
                        //Append_stat_ln(((float)(numAliveRGC[0] - numStressRGC[0]) * 100 / mdl.n_axons).ToString("0.0"));

                        for (int ii = 0; ii < opticNerveZones; ii++)
                        {
                            aliveZoneTotal[ii] = 0;
                            stressZoneTotal[ii] = 0;
                            deadZoneTotal[ii] = 0;
                        }

                        for (int ii = 0; ii < mdl.n_axons; ii++)
                        {
                            uint currentZone = topoZoneMappingVector[ii];
                            

                            if (rgcStateVector[ii] == cell_state_healthy)
                            {
                                aliveZoneTotal[currentZone]++;
                            }
                            if (rgcStateVector[ii] == cell_state_stress)
                            {
                                stressZoneTotal[currentZone]++;
                            }
                            if (rgcStateVector[ii] == cell_state_dead)
                            {
                                deadZoneTotal[currentZone]++;
                            }

                        }

                        for (int ii = 0; ii < opticNerveZones; ii++)
                        {
                            topoZoneStats[j * iter + i, ii] = (float)(deadZoneTotal[ii]) / (float)topoZoneTotal[ii];
                            topoZoneROS[j * iter + i, ii] = sum_zone_tox[ii] * 1000* 8 / bioVolume;
                        }

                        string timeStr = DateTime.Now.ToString("yyyy - MM - dd @HH - mm - ss");
                        string path = ProjectOutputDir + @"Exported\" + timeStr + "_loop_results.csv";
                        using (StreamWriter file = new StreamWriter(path, true))
                        {
                            // all [ROS] is printed in nM
                            file.WriteLine("Mito (%), [ROS], {T} , {H}, {S}, {D}, {D}/{T}," + topoLabels[0] + "," + topoLabels[1] + "," + topoLabels[2] + "," + topoLabels[3] + "," + topoLabels[4] + "," + topoLabels[5] + "," + topoLabels[6] + "," + topoLabels[7] + ", [" + topoLabels[0] + "], [" + topoLabels[1] + "], [" + topoLabels[2] + "], [" + topoLabels[3] + "], [" + topoLabels[4] + "], [" + topoLabels[5] + "], [" + topoLabels[6] + "], [" + topoLabels[7] +"]");

                            for (int k = 0; k <= (j * iter + i); k++)
                            {
                                file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6} , {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}", mito[k], ros[k] *  1000, no[k], h[k], s[k], d[k], ((float)d[k]) / ((float)no[k]),
                                    topoZoneStats[k, 0],
                                    topoZoneStats[k, 1],
                                    topoZoneStats[k, 2],
                                    topoZoneStats[k, 3],
                                    topoZoneStats[k, 4],
                                    topoZoneStats[k, 5],
                                    topoZoneStats[k, 6],
                                    topoZoneStats[k, 7], 
                                    topoZoneROS[k, 0],
                                    topoZoneROS[k, 1],
                                    topoZoneROS[k, 2],
                                    topoZoneROS[k, 3],
                                    topoZoneROS[k, 4],
                                    topoZoneROS[k, 5],
                                    topoZoneROS[k, 6],
                                    topoZoneROS[k, 7]);
                            }
                        }

                    }
                }
            }
            
 /*           
            string timeStr = DateTime.Now.ToString("yyyy - MM - dd @HH - mm - ss");
            string path = ProjectOutputDir + @"Exported\" + timeStr + "_loop_results.csv";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Mito (%), [ROS], {T} , {H}, {S}, {D}, {D}/{T}");

                for (int k = 0; k < totalIter; k++)
                {
                    file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", mito[k], ros[k],no[k],h[k],s[k],d[k], ((float)d[k])/((float)no[k]));
                }
            }
 */
            Append_stat_ln("Test Loop Complete");
            label_test_no.Text = "[0]";
        }

        private void HideVisualFieldLabels()
        {
            labelZ1.Visible = false;
            labelZ2.Visible = false;
            labelZ3.Visible = false;
            labelZ4.Visible = false;
            labelZ5.Visible = false;
            labelZ6.Visible = false;
            labelZ7.Visible = false;
            labelZ8.Visible = false;

        }


        private void ShowVisualFieldLabels()
        {
            labelZ1.Visible = checkBoxZ1.Checked;
            labelZ2.Visible = checkBoxZ2.Checked;
            labelZ3.Visible = checkBoxZ3.Checked;
            labelZ4.Visible = checkBoxZ4.Checked;
            labelZ5.Visible = checkBoxZ5.Checked;
            labelZ6.Visible = checkBoxZ6.Checked;
            labelZ7.Visible = checkBoxZ7.Checked;
            labelZ8.Visible = checkBoxZ8.Checked;

        }

        private void ShowCoronalTopoLabels()
        {
            lbl_topo_st.Visible = checkBoxZ1.Checked;
            lbl_topo_s.Visible = checkBoxZ2.Checked;
            lbl_topo_sn.Visible = checkBoxZ3.Checked;
            lbl_topo_n.Visible = checkBoxZ4.Checked;
            lbl_topo_in.Visible = checkBoxZ5.Checked;
            lbl_topo_i.Visible = checkBoxZ6.Checked;
            lbl_topo_it.Visible = checkBoxZ7.Checked;
            lbl_topo_t.Visible = checkBoxZ8.Checked;

        }

        private void ShowSagittalTopoLabels()
        {
            lbl_topo_st.Visible = false;
            lbl_topo_s.Visible = true;
            lbl_topo_sn.Visible = false;
            lbl_topo_n.Visible = true;
            lbl_topo_in.Visible = false;
            lbl_topo_i.Visible = true;
            lbl_topo_it.Visible = false;
            lbl_topo_t.Visible = true;

        }

        private void ShowTransversalTopoLabels()
        {
            lbl_topo_st.Visible = false;
            lbl_topo_s.Visible = true;
            lbl_topo_sn.Visible = false;
            lbl_topo_n.Visible = true;
            lbl_topo_in.Visible = false;
            lbl_topo_i.Visible = true;
            lbl_topo_it.Visible = false;
            lbl_topo_t.Visible = true;

        }


        private void HideTopoLabels()
        {
            lbl_topo_st.Visible = false;
            lbl_topo_s.Visible = false;
            lbl_topo_sn.Visible = false;
            lbl_topo_n.Visible = false;
            lbl_topo_in.Visible = false;
            lbl_topo_i.Visible = false;
            lbl_topo_it.Visible = false;
            lbl_topo_t.Visible = false;


        }

        private void VisualFieldCheckLabels()
        {

            
            checkBoxZ1.Text = vfLabels[0];
            checkBoxZ2.Text = vfLabels[1];
            checkBoxZ3.Text = vfLabels[2];
            checkBoxZ4.Text = vfLabels[3];
            checkBoxZ5.Text = vfLabels[4];
            checkBoxZ6.Text = vfLabels[5];
            checkBoxZ7.Text = vfLabels[6];
            checkBoxZ8.Text = vfLabels[7];

        }

        private void TopoCheckLabels()
        {

            checkBoxZ1.Text = topoLabels[0];
            checkBoxZ2.Text = topoLabels[1];
            checkBoxZ3.Text = topoLabels[2];
            checkBoxZ4.Text = topoLabels[3];
            checkBoxZ5.Text = topoLabels[4];
            checkBoxZ6.Text = topoLabels[5];
            checkBoxZ7.Text = topoLabels[6];
            checkBoxZ8.Text = topoLabels[7];


        }


        private readonly String[] vfLabels = { "ML", "IN", "I", "TL", "TH", "S", "SN", "MH" };
        private readonly String[] topoLabels = { "ST", "S", "SN", "N", "IN", "I", "IT", "T"};

        private void UseVisualField()
        {
            
            VisualFieldCheckLabels();
            if(radio_button_coronal.Checked)
            {
                HideTopoLabels();
                ShowVisualFieldLabels();
            }
            else
            {
                TopoView();
            }
            
        }


        private void UseTopo()
        {
            HideVisualFieldLabels();
            TopoCheckLabels();
            TopoView();

        }

        private void TopoLabelsCoronal()
        {

            lbl_topo_s.Text = "S"; //superior
            lbl_topo_t.Text = "T"; //temporal
            lbl_topo_n.Text = "N"; //nasal
            lbl_topo_i.Text = "I"; //inferior
        }

        private void TopoLabelsSagittal()
        {

            lbl_topo_s.Text = "S"; //superior
            lbl_topo_t.Text = "Prox"; //proximal; closer to face
            lbl_topo_n.Text = "Dist"; //distal; closer to brain
            lbl_topo_i.Text = "I"; //inferior
        }

        private void TopoLabelsTransversal()
        {

            lbl_topo_s.Text = "Prox"; //proximal; closer to face
            lbl_topo_t.Text = "T"; //termporal
            lbl_topo_n.Text = "N"; //nasal
            lbl_topo_i.Text = "Dist"; // distal; closer to brain
        }


        private void TopoCoronalView()
        {
            TopoLabelsCoronal();
            ShowCoronalTopoLabels();
        }

        private void TopoSagittalView()
        {
            TopoLabelsSagittal();
            ShowSagittalTopoLabels();
        }

        private void TopoTransversalView()
        {
            TopoLabelsTransversal();
            ShowTransversalTopoLabels();
        }

        private void TopoView()
        {
            if(radio_button_coronal.Checked)
            {
                TopoCoronalView();
                return;
            }
            if(radio_button_sagittal.Checked)
            {
                TopoSagittalView();
                return;
            }
            if(radio_button_transversal.Checked)
            {
                TopoTransversalView();
                return;
            }
        }

        private void Update_Chart()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Update_Chart()));
            else {

                if (startHistogram == null) return;
                
                bool displayLineHist = checkDisplayLineHist.Checked;
                bool perc = checkPercentHist.Checked;
                bool healthy = checkBox_chart_healthy.Checked;
                bool stress = checkBox_chart_stress.Checked;
                bool dead = checkBox_chart_dead.Checked;
                bool ratio = checkBoxRatio.Checked;
                bool diff = checkBoxDiff.Checked;
                bool enable3D = checkBox_chart_3d.Checked;
                bool visualField = checkBox_visual_field.Checked;
                bool addZonesTogether = checkBox_chart_add_zones.Checked;
                bool showAll = checkBox_showSumOfHSD.Checked;
                bool addStates = chk_chart_add_states.Checked;
                const String biotime = "Biotime";
                System.Drawing.Color hColor = System.Drawing.Color.MediumSeaGreen;
                System.Drawing.Color sColor = System.Drawing.Color.DarkOrange;
                System.Drawing.Color dColor = System.Drawing.Color.Blue;
                System.Drawing.Color rColor = System.Drawing.Color.DarkRed;


                bool[] z = new bool[opticNerveZones];
                z[0] = checkBoxZ1.Checked;
                z[1] = checkBoxZ2.Checked;
                z[2] = checkBoxZ3.Checked;
                z[3] = checkBoxZ4.Checked;
                z[4] = checkBoxZ5.Checked;
                z[5] = checkBoxZ6.Checked;
                z[6] = checkBoxZ7.Checked;
                z[7] = checkBoxZ8.Checked;

                bool noNewData = false;

                if (usedTimeBoxes == 0) return;

                if (iterationVec[usedTimeBoxes - 1] != iteration)
                {

                    iterationVec[usedTimeBoxes] = (int)iteration;
                    aliveNumAxonsVec[usedTimeBoxes] = numAliveRGC[0];
                    stressNumAxonsVec[usedTimeBoxes] = numStressRGC[0];
                    rosAmountVec[usedTimeBoxes] = sum_tox / bioVolume;
                    deadPerIterationVec[usedTimeBoxes] = aliveNumAxonsVec[usedTimeBoxes - 1] - aliveNumAxonsVec[usedTimeBoxes];
                    stressPerIterVec[usedTimeBoxes] = stressNumAxonsVec[usedTimeBoxes] - stressNumAxonsVec[usedTimeBoxes - 1];
                    rosChangeVec[usedTimeBoxes] = rosAmountVec[usedTimeBoxes] - rosAmountVec[usedTimeBoxes - 1];
                    healthyPerIterVec[usedTimeBoxes] = (aliveNumAxonsVec[usedTimeBoxes ] - stressNumAxonsVec[usedTimeBoxes]) - (aliveNumAxonsVec[usedTimeBoxes-1] - stressNumAxonsVec[usedTimeBoxes-1]);
                    usedTimeBoxes++;
                }
                else
                {
                    noNewData = true;
                }

                if(radioButtonCount.Checked)
                {

                    bool over1Sec = false;
                    float iterTime = iteration * k_time_iter;
                   

                    if((iterTime - setts.gui_iteration_period * k_time_iter) < 1 && iterTime > 1)
                    {
                        rebuildTimeMap = true;
                    }

                    if(iterTime > 1 )
                    {
                        over1Sec = true;
                    }

                    

                    if(rebuildTimeMap)
                    {
                        labelChartY.Visible = true;
                        labelChartX.Visible = true;

                        if (over1Sec == true)
                        {
                            labelChartX.Text = biotime+ " (s)";
                        }
                        else
                        {
                            labelChartX.Text = biotime + " (ms)";
                        }
                        labelChartY.Text = "Axons\n#";

                        rebuildTimeMap = false;
                        liveChart.Series.Clear();
                        liveChart.Titles.Clear();
                        liveChart.Legends.Clear();
                        liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                        liveChart.ChartAreas[0].AxisY.Minimum = -double.NaN;
                        liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        liveChart.ChartAreas[0].AxisX.Minimum = 0;
                        liveChart.ChartAreas[0].AxisX.Maximum = double.NaN;


                        //liveChart.Titles.Add("RGC Timeseries");

                        if (healthy)
                        {
                            hSeries = liveChart.Series.Add("H");
                            hSeries.LegendText = "H";
                            hSeries.Color = hColor;
                            if(checkBox_chart_legend.Checked) {
                                liveChart.Legends.Add(hSeries.Legend);
                            }
                            if(displayLineHist)
                                hSeries.ChartType = SeriesChartType.Line;
                            else
                                hSeries.ChartType = SeriesChartType.Point;

                            for (int i = 0; i < usedTimeBoxes; i++)
                            {
                                float bioT = iterationVec[i] * k_time_iter;

                                if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio seconds

                                if (diff)
                                    hSeries.Points.AddXY((decimal)bioT, healthyPerIterVec[i]);
                                else
                                    hSeries.Points.AddXY((decimal)bioT, aliveNumAxonsVec[i] - stressNumAxonsVec[i]);
                            }
                        }
                        if (stress)
                        {
                            sSeries = liveChart.Series.Add("S");
                            sSeries.LegendText = "S";
                            sSeries.Color = sColor;

                            if (displayLineHist)
                                sSeries.ChartType = SeriesChartType.Line;
                            else
                                sSeries.ChartType = SeriesChartType.Point;

                            for (int i = 0; i < usedTimeBoxes; i++)
                            {
                                float bioT = iterationVec[i] * k_time_iter;

                                if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio seconds

                                if (diff)
                                    sSeries.Points.AddXY((decimal)bioT, stressPerIterVec[i]);
                                else
                                    sSeries.Points.AddXY((decimal)bioT, stressNumAxonsVec[i]);
                            }
                        }
                        if (dead)
                        {
                            
                            dSeries = liveChart.Series.Add("D");
                            dSeries.LegendText = "D";
                            dSeries.Color = dColor;
                            if (displayLineHist)
                                dSeries.ChartType = SeriesChartType.Line;
                            else
                                dSeries.ChartType = SeriesChartType.Point;

                            for (int i = 0; i < usedTimeBoxes; i++)
                            {
                                float bioT = iterationVec[i] * k_time_iter;

                                if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio seconds
                                
                                if (diff)
                                    dSeries.Points.AddXY((decimal)bioT, deadPerIterationVec[i]);
                                else
                                    dSeries.Points.AddXY((decimal)bioT, mdl.n_axons - aliveNumAxonsVec[i]);
                            }
                        }
                        
                    }
                    else
                    {

                        if(noNewData)
                        {
                            return;

                        }

                        int i = usedTimeBoxes - 1;

                        float bioT = iterationVec[i] * k_time_iter;

                        if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio second

                        if (healthy)
                        {
                            if (diff==false)
                                hSeries.Points.AddXY((decimal)bioT, aliveNumAxonsVec[i]- stressNumAxonsVec[i]);
                            else
                                hSeries.Points.AddXY((decimal)bioT, healthyPerIterVec[i]);
                        }

                        if(stress)
                        {
                            if (diff)
                                sSeries.Points.AddXY((decimal)bioT, stressPerIterVec[i]);
                            else
                                sSeries.Points.AddXY((decimal)bioT, stressNumAxonsVec[i]);
                        }
                        if(dead)
                        {
                            if (diff)
                                dSeries.Points.AddXY((decimal)bioT, deadPerIterationVec[i]);
                            else
                                dSeries.Points.AddXY((decimal)bioT, mdl.n_axons - aliveNumAxonsVec[i]);
                        }
                        
                    }

                    return;
                    
                }


                

                if (radioButtonROS.Checked)
                {
                    if(diff == true )
                    {
                        labelChartY.Visible = true;
                        labelChartX.Visible = true;
                        labelChartX.Text = "Zones";

                        rebuildTimeMap = false;
                        liveChart.Series.Clear();
                        liveChart.Titles.Clear();
                        liveChart.Legends.Clear();
                        liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                        liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        liveChart.ChartAreas[0].AxisY.Minimum = -double.NaN;
                        liveChart.ChartAreas[0].AxisX.Minimum = -double.NaN;
                        liveChart.ChartAreas[0].AxisX.Maximum = double.NaN;

                        
                        labelChartY.Visible = true;
                        
                        labelChartY.Text = "[ROS]\nnM";

                        q = liveChart.Series.Add("");
                        q.ChartType = SeriesChartType.Column;
                        double maxros = 0;
                        for (int i = 0; i < opticNerveZones; i++)
                        {
                            int j = (i + 6) % opticNerveZones;
                            double ros = ((double)sum_zone_tox[j] * 1000 * 8 / bioVolume);
                            if (maxros < ros) maxros = ros;
                            q.Points.AddXY(topoLabels[j], ros);

                        }

                        liveChart.ChartAreas[0].AxisY.Maximum = 1.25*maxros;

                    }
                    else
                    {
                        bool over1Sec = false;
                        float iterTime = iteration * k_time_iter;

                        if ((iterTime - setts.gui_iteration_period * k_time_iter) < 1 && iterTime > 1)
                        {
                            rebuildTimeMap = true;
                        }

                        if (iterTime > 1)
                        {
                            over1Sec = true;
                        }



                        if (rebuildTimeMap)
                        {

                            labelChartY.Visible = true;
                            labelChartY.Text = "[ROS]\nnM";
                            labelChartX.Visible = true;

                            if (over1Sec == true)
                            {
                                labelChartX.Text = biotime + " (s)";
                            }
                            else
                            {
                                labelChartX.Text = biotime + " (ms)";
                            }

                            rebuildTimeMap = false;
                            liveChart.Series.Clear();
                            liveChart.Titles.Clear();
                            liveChart.Legends.Clear();
                            liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                            liveChart.ChartAreas[0].AxisY.Minimum = -double.NaN;
                            liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                            liveChart.ChartAreas[0].AxisX.Minimum = 0;
                            liveChart.ChartAreas[0].AxisX.Maximum = double.NaN;

                            //liveChart.Titles.Add("[ROS] Timeseries");
                            q = liveChart.Series.Add("");
                            if (displayLineHist)
                                q.ChartType = SeriesChartType.Line;
                            else
                                q.ChartType = SeriesChartType.Point;

                            for (int i = 2; i < usedTimeBoxes; i++)
                            {
                                float bioT = iterationVec[i] * k_time_iter;

                                if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio seconds

                                if (diff)
                                    q.Points.AddXY((decimal)bioT, 1000 * rosChangeVec[i]);
                                else
                                    q.Points.AddXY((decimal)bioT, 1000 * rosAmountVec[i]);
                            }
                        }
                        else
                        {
                            if (noNewData)
                            {
                                return;

                            }

                            int i = usedTimeBoxes - 1;

                            float bioT = iterationVec[i] * k_time_iter;

                            if (over1Sec == false) bioT *= 1000;  // [DWL] display in bio ms otherwise display in bio second

                            if (diff)
                                q.Points.AddXY((decimal)bioT, 1000 * rosChangeVec[i]);
                            else
                                q.Points.AddXY((decimal)bioT, 1000 * rosAmountVec[i]);
                        }


                        
                    }
                    return;

                }



                if (radioButtonLoss.Checked)
                {


                    labelChartY.Visible = true;
                    labelChartX.Visible = true;
                    labelChartX.Text = "Zones";



                    for (int i = 0; i < opticNerveZones; i++)
                    {
                        aliveZoneTotal[i] = 0;
                        stressZoneTotal[i] = 0;
                        deadZoneTotal[i] = 0;
                    }

                    for (int i = 0; i < mdl.n_axons; i++)
                    {
                        uint currentZone;
                        if (visualField)
                        {
                            currentZone = ghZoneMappingVector[i];
                        }
                        else
                        {
                            currentZone = topoZoneMappingVector[i];
                        }

                        if (rgcStateVector[i] == cell_state_healthy)
                        {
                            aliveZoneTotal[currentZone]++;
                        }
                        if (rgcStateVector[i] == cell_state_stress)
                        {
                            stressZoneTotal[currentZone]++;
                        }
                        if (rgcStateVector[i] == cell_state_dead)
                        {
                            deadZoneTotal[currentZone]++;
                        }

                    }

                    rebuildTimeMap = false;
                    liveChart.Series.Clear();
                    liveChart.Titles.Clear();
                    liveChart.Legends.Clear();
                    liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                    liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                    liveChart.ChartAreas[0].AxisY.Minimum = -double.NaN;
                    liveChart.ChartAreas[0].AxisX.Minimum = -double.NaN;
                    liveChart.ChartAreas[0].AxisX.Maximum = double.NaN;
                    



                    if (perc == false)
                    {

                        
                        Series h = liveChart.Series.Add("");
                        Series s = liveChart.Series.Add("");
                        Series d = liveChart.Series.Add("");
                        s.Color = sColor;
                        h.Color = hColor;
                        d.Color = dColor;
                        labelChartY.Visible = true;

                        if (ratio)
                        {
                            //liveChart.Titles.Add("Zonal RGC Ratios");
                            h.ChartType = SeriesChartType.StackedColumn100;
                            s.ChartType = SeriesChartType.StackedColumn100;
                            d.ChartType = SeriesChartType.StackedColumn100;
                            labelChartY.Text = "Axons\n%";
                        }
                        else
                        {
                            //liveChart.Titles.Add("Zonal RGC Numbers");
                            h.ChartType = SeriesChartType.StackedColumn;
                            s.ChartType = SeriesChartType.StackedColumn;
                            d.ChartType = SeriesChartType.StackedColumn;
                            labelChartY.Text = "Axons\n#";
                        }
                        

                        h.CustomProperties = "StackedGroupName = {*}";
                        s.CustomProperties = "StackedGroupName = {*}";
                        d.CustomProperties = "StackedGroupName = {*}";

                        for (int i = 0; i < opticNerveZones; i++)
                        {
                            String sl;
                            int j = (i + 6) % opticNerveZones;
                            if(visualField) j = (i + 7) % opticNerveZones;
                            if (visualField) sl = vfLabels[j];
                            else sl = topoLabels[j];
                            h.Points.AddXY(sl, aliveZoneTotal[j]);
                            s.Points.AddXY(sl, stressZoneTotal[j]);
                            d.Points.AddXY(sl, deadZoneTotal[j]);

                        }


                        if (checkBox_chart_legend.Checked)
                        {
                            s.LegendText = "S"; 
                            d.LegendText = "D"; 
                            h.LegendText = "H";
                            //liveChart.Legends.Add(h.Legend);
                            liveChart.Legends.Add(s.Legend);
                            //liveChart.Legends.Add(d.Legend);
                        }
                    }
                    else
                    {
                        if(ratio == false)
                            liveChart.ChartAreas[0].AxisY.Maximum = 0;
                        else
                            liveChart.ChartAreas[0].AxisY.Maximum = 1;

                        //liveChart.Titles.Add("Zonal RGC Loss (dB)");
                        labelChartY.Visible = true;
                        if (ratio == false)
                            labelChartY.Text = "     dB";
                        else
                            labelChartY.Text = "Survive\nRatio";

                        q = liveChart.Series.Add("");
                        q.ChartType = SeriesChartType.Column;
                        double min = 0;
                        for (int i = 0; i < opticNerveZones; i++)
                        {
                            int j = (i + 6) % opticNerveZones;
                            if(visualField) j = (i + 7) % opticNerveZones;
                            int az = aliveZoneTotal[j] + stressZoneTotal[j];


                            if (visualField == true)
                            {
                                int zt = ghZoneTotal[j];
                                double v = 10 * Math.Log10(((double)az) / zt);
                                
                                if (v < -100) v = -100;
                                if (min > v) min = v;
                                if(ratio == false)
                                    q.Points.AddXY(vfLabels[j], v);
                                else
                                    q.Points.AddXY(vfLabels[j], ((double)az) / zt);
                            }
                            else
                            {
                                int zt = topoZoneTotal[j];
                                double v = 10 * Math.Log10(((double)az) / zt);

                                if (v < -100) v = -100;
                                if (min > v) min = v;
                                if(ratio == false)
                                    q.Points.AddXY(topoLabels[j], v);
                                else
                                    q.Points.AddXY(topoLabels[j], ((double)az) / zt);
                            }

                        }

                        if(ratio == false)
                        {
                            min = min - 1;

                            if (min < -101) min = -101;

                            liveChart.ChartAreas[0].AxisY.Minimum = Math.Floor(min);
                        }
                        else
                        {
                            liveChart.ChartAreas[0].AxisY.Minimum = 0;
                        }
                        

                        if (checkBox_chart_legend.Checked)
                        {
                            q.LegendText = "D";
                            liveChart.Legends.Add(q.Legend);
                        }

                    }

                    



                    return;
                }


                if (radioButton_ros_v_h.Checked)
                {

                    if (rebuildTimeMap)
                    {
                        labelChartY.Visible = true;
                        labelChartX.Visible = true;

                    
                       
                        labelChartY.Text = "[ROS]\nnM";


                        rebuildTimeMap = false;
                        liveChart.Series.Clear();
                        liveChart.Titles.Clear();
                        liveChart.Legends.Clear();
                        liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                        liveChart.ChartAreas[0].AxisX.Minimum = 0;
                        liveChart.ChartAreas[0].AxisX.Maximum = 1;
                        liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        liveChart.ChartAreas[0].AxisY.Minimum = 0;

                        //liveChart.Titles.Add("[ROS] vs {H,S,D}");
                        q = liveChart.Series.Add("");
                        if (displayLineHist)
                            q.ChartType = SeriesChartType.Line;
                        else
                            q.ChartType = SeriesChartType.Point;

                        labelChartX.Text = "Ratio  (";
                        if (healthy)
                        {
                            labelChartX.Text += "H";
                            if(stress || dead) labelChartX.Text += "+";

                        }
                        if (stress)
                        {
                            labelChartX.Text += "S";
                            if(dead) labelChartX.Text += "+";
                        }
                        if(dead) labelChartX.Text += "D";
                        labelChartX.Text += ")/(H+S+D)";

                        for (int i = 2; i < usedTimeBoxes; i++)
                        {
                            float f = 0;
                            if (healthy) f = aliveNumAxonsVec[i] - stressNumAxonsVec[i];
                            if (stress) f += stressNumAxonsVec[i];
                            if (dead) f += aliveNumAxonsVec[0] - aliveNumAxonsVec[i];
                            q.Points.AddXY((f/aliveNumAxonsVec[0]), 1000*rosAmountVec[i]);
                        }
                    }
                    else
                    {
                        if (noNewData)
                        {
                            return;

                        }

                        int i = usedTimeBoxes - 1;
                        float f = 0;
                        if (healthy) f = aliveNumAxonsVec[i] - stressNumAxonsVec[i];
                        if (stress) f += stressNumAxonsVec[i];
                        if (dead) f += aliveNumAxonsVec[0] - aliveNumAxonsVec[i];
                        q.Points.AddXY((f / aliveNumAxonsVec[0]), 1000*rosAmountVec[i]);
                    }


                return;
            }



                bool none = true;

                for(int i = 0; i< opticNerveZones; i++)
                {
                    if(z[i] == true)
                    {
                        none = false;
                        break;
                    }
                }

                if (none == true) return;

                liveChart.Series.Clear();
                liveChart.Titles.Clear();
                liveChart.Legends.Clear();
             
                liveChart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                liveChart.ChartAreas[0].AxisY.Minimum = -double.NaN;
                liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                liveChart.ChartAreas[0].AxisX.Minimum = -double.NaN;
                liveChart.ChartAreas[0].AxisX.Maximum = double.NaN;
                labelChartY.Visible = true;

                if (ratio == false)
                {
                    if(perc)
                    {
                        if (diff)
                        {
                            liveChart.ChartAreas[0].AxisY.Maximum = 0.15;
                            labelChartY.Text = "Bin/Total";
                        }
                        else
                        {
                            liveChart.ChartAreas[0].AxisY.Maximum = 1;
                            labelChartY.Text = "Sum/Total";
                        }
                    }
                    else
                    {
                        liveChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                        labelChartY.Text = "Axons\n#";
                    }
                    
                }
                else
                {
                    liveChart.ChartAreas[0].AxisY.Maximum = 100;
                    labelChartY.Text = "State\n%";
                }
                

                if(enable3D)
                {
                    //liveChart.ChartAreas[0].Area3DStyle.Rotation = 45;
                    //liveChart.ChartAreas[0].Area3DStyle.Inclination = 45;
                }
                //liveChart.ChartAreas[0].AxisX.Minimum = 0;
                //liveChart.ChartAreas[0].AxisX.Maximum = 70;
                //liveChart.ChartAreas[0].AxisX.Interval = 0.1;

                //liveChart.Titles.Add("RGC Histograms");
               
                
                labelChartX.Visible = true;
                labelChartX.Text = "Axon Diameter (um)";

                int zones = 1;

                if (addZonesTogether == false) zones = opticNerveZones;


                int[,] liveHistogram = new int[zones,liveHBoxes];
                int[,] healthyHistogram = new int[zones,liveHBoxes];
                int[,] stressHistogram = new int[zones,liveHBoxes];
                int[,] deadHistogram = new int[zones,liveHBoxes];

                int[] totalCount = new int[zones];
                for (int i = 0; i < mdl.n_axons; i++)
                {
                    uint currentZone;
                    if (visualField)
                    {
                        currentZone = ghZoneMappingVector[i];
                        if (z[ghZoneMappingVector[i]] == false)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        currentZone = topoZoneMappingVector[i];
                        if (z[topoZoneMappingVector[i]] == false)
                        {
                            continue;
                        }
                    }

                    if (addZonesTogether == true) currentZone = 0;

                    if (healthy && rgcStateVector[i] == cell_state_healthy)
                    {
                        liveHistogram[currentZone,axonDiameterVector[i]]++;
                        healthyHistogram[currentZone,axonDiameterVector[i]]++;
                        totalCount[currentZone]++;
                    }
                    if (stress && rgcStateVector[i] == cell_state_stress)
                    {
                        liveHistogram[currentZone, axonDiameterVector[i]]++;
                        stressHistogram[currentZone,axonDiameterVector[i]]++;
                        totalCount[currentZone]++;
                    }
                    if (dead && rgcStateVector[i] == cell_state_dead)
                    {
                        liveHistogram[currentZone,axonDiameterVector[i]]++;
                        deadHistogram[currentZone,axonDiameterVector[i]]++;
                        totalCount[currentZone]++;
                    }
                }
                /*
                                Append_stat_ln("D(um)        Current Alive Num");
                                for (int i = 0; i < aliveHBoxes; i++)
                                {
                                    if (aliveHistogram[i] != 0)
                                        Append_stat_ln(((float)i) / 10 + "   " + aliveHistogram[i]);
                                }
                */

                int[] totalHistogram = new int[liveHBoxes];
                int numAxons = 0;

                for(int i = 0; i < opticNerveZones; i++)
                {
                    if (z[i] == false) continue;
                    for (int j = 0; j < liveHBoxes; j++)
                    {
                        if(visualField)
                        {
                            totalHistogram[j] += startGHZoneHistogram[i, j];
                            numAxons += startGHZoneHistogram[i, j];
                        }
                        else
                        {
                            totalHistogram[j] += startTopoZoneHistogram[i, j];
                            numAxons += startTopoZoneHistogram[i, j];
                        }
                        
                    }
                }

                bool addedToLegend = false;

                

                for (int j=0; j < zones; j++)
                {
                    if (addZonesTogether == false && z[j] == false) continue;
                    if (ratio == false)
                    {

                        Series h = null;
                        Series s= null;
                        Series d = null;
                        
                        
                        
                        if (addStates == true || healthy)
                        {
                            h = liveChart.Series.Add("");
                            h.Color = hColor;
                        }
                        if (stress)
                        {
                            s = liveChart.Series.Add("");
                            s.Color = sColor;
                        }
                        if (dead)
                        {
                            d = liveChart.Series.Add("");
                            d.Color = dColor;
                        }

                        if(displayLineHist)
                        {
                            if(addStates == true || healthy) h.ChartType = SeriesChartType.Line;
                            if(stress) s.ChartType = SeriesChartType.Line;
                            if(dead) d.ChartType = SeriesChartType.Line;
                        }
                        else
                        {
                            if(addStates == true || healthy) h.ChartType = SeriesChartType.StackedColumn;
                            if(stress) s.ChartType = SeriesChartType.StackedColumn;
                            if(dead) d.ChartType = SeriesChartType.StackedColumn;

                            if(addZonesTogether == true)
                            {
                                if (addStates == true || healthy) h.CustomProperties = "StackedGroupName = {*}";
                                if (stress) s.CustomProperties = "StackedGroupName = {*}";
                                if (dead) d.CustomProperties = "StackedGroupName = {*}";
                            }
                            else
                            {
                                if (addStates == true || healthy) h.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                                if (stress) s.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                                if (dead) d.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                            }
                            
                        }
                        
                       
                        if (stress) s.LegendText = "S";
                        if (dead) d.LegendText = "D";
                        if (healthy) h.LegendText = "H";
                       
                        

                        if (checkBox_chart_legend.Checked && addedToLegend == false)
                        {
                            if(healthy) liveChart.Legends.Add(h.Legend);
                            else if (stress) liveChart.Legends.Add(s.Legend);
                            else if (dead) liveChart.Legends.Add(d.Legend);
                            addedToLegend = true;
                        }


                        float ht = 0;
                        float st = 0;
                        float dt = 0;

                        for (int i = 0; i < liveHBoxes; i++)
                        {
                            if (liveHistogram[j,i] != 0)
                            {
                                ht += (float)healthyHistogram[j, i];
                                st += (float)stressHistogram[j, i];
                                dt += (float)deadHistogram[j, i];

                                if(diff)
                                {
                                    if(addStates == false)
                                    {

                                        if (healthy) h.Points.AddXY((((float)i) / 10).ToString(), (float)healthyHistogram[j, i] / (perc ? totalCount[j] : 1));
                                        if (stress) s.Points.AddXY((((float)i) / 10).ToString(), (float)stressHistogram[j, i] / (perc ? totalCount[j] : 1));
                                        if (dead) d.Points.AddXY((((float)i) / 10).ToString(), (float)deadHistogram[j, i] / (perc ? totalCount[j] : 1));
                                    }
                                    else
                                    {
                                        float tt = 0;

                                        if (healthy) tt += healthyHistogram[j, i] ;
                                        if (stress) tt += stressHistogram[j, i];
                                        if (dead) tt += deadHistogram[j, i];

                                       
                                        if (healthy || stress || dead) h.Points.AddXY((((float)i) / 10).ToString(), (float)tt / (perc ? totalCount[j] : 1));
                                       
                                    }
                                    

                                }
                                else
                                {
                                    if(addStates == false)
                                    {
                                        if (healthy) h.Points.AddXY((((float)i) / 10).ToString(), ht / (perc ? totalCount[j] : 1));
                                        if (stress) s.Points.AddXY((((float)i) / 10).ToString(), st / (perc ? totalCount[j] : 1));
                                        if (dead) d.Points.AddXY((((float)i) / 10).ToString(), dt / (perc ? totalCount[j] : 1));
                                    }
                                    else
                                    {
                                        float tt = 0;

                                        if (healthy) tt += ht;
                                        if (stress) tt += st;
                                        if (dead) tt += dt;

                                        if (healthy || stress || dead) h.Points.AddXY((((float)i) / 10).ToString(), tt / (perc ? totalCount[j] : 1));

                                    }

                                }
                                

                            }

                        }

                    }
                    else
                    {
                        Series h = liveChart.Series.Add("");
                        Series s = liveChart.Series.Add("");
                        Series d = liveChart.Series.Add("");
                        h.ChartType = SeriesChartType.StackedColumn100;
                        s.ChartType = SeriesChartType.StackedColumn100;
                        d.ChartType = SeriesChartType.StackedColumn100;
                        h.Color = hColor;
                        s.Color = sColor;
                        d.Color = dColor;
                        if(addZonesTogether == true)
                        {
                            h.CustomProperties = "StackedGroupName = {*}";
                            s.CustomProperties = "StackedGroupName = {*}";
                            d.CustomProperties = "StackedGroupName = {*}";
                        }
                        else
                        {
                            h.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                            s.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                            d.CustomProperties = "StackedGroupName = {" + (visualField ? vfLabels[j] : topoLabels[j]) + "}";
                        }

                        
                        if(stress) s.LegendText = "S";
                        if(dead) d.LegendText = "D";
                        if(healthy) h.LegendText = "H";

                        //labelChartY.Visible = true;
                        //labelChartY.Text = "State\n%";

                        if (checkBox_chart_legend.Checked && addedToLegend == false)
                        {
                            liveChart.Legends.Add(s.Legend);
                            addedToLegend = true;
                        }


                        for (int i = 0; i < liveHBoxes; i++)
                        {
                            if (totalHistogram[i] != 0)
                            {
                                h.Points.AddXY((((float)i) / 10).ToString(), ((float)healthyHistogram[j,i]));
                                s.Points.AddXY((((float)i) / 10).ToString(), ((float)stressHistogram[j,i]));
                                d.Points.AddXY((((float)i) / 10).ToString(), ((float)deadHistogram[j,i]));
                            }

                        }
                    }
                }

                if (showAll && ratio == false)
                {
                    Series v = liveChart.Series.Add("");
                    v.ChartType = SeriesChartType.Line;
                    v.LegendText = "T";
                    v.Color = rColor;

                    float tt = 0;

                    for (int i = 0; i < liveHBoxes; i++)
                    {
                        if (totalHistogram[i] != 0)
                        {
                            tt += (float)totalHistogram[i];
                            if (diff)
                                v.Points.AddXY((((float)i) / 10).ToString(), (float)totalHistogram[i] / (perc ? numAxons : 1));
                            else
                                v.Points.AddXY((((float)i) / 10).ToString(), tt / (perc ? numAxons : 1));
                        }


                    }

                }


            }
        }
    }
}
