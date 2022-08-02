using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Cudafy;
using Cudafy.Host;


namespace LHON_Form
{
    public partial class Main_Form
    {
        // ============= Save Progress Image

        private void Take_Progress_Snapshot(byte[,,] dest, uint frame)
        {
            if (InvokeRequired)
                Invoke(new Action(() => Take_Progress_Snapshot(dest, frame)));
            else
            {
                gpu = CudafyHost.GetDevice(CudafyModes.Target, CudafyModes.DeviceId);

                gpu.Set(progression_image_sum_float_dev);
                gpu.Set(progress_image_num_averaged_pix_dev);
                //gpu.Launch(blocks_per_grid_pix, threads_per_block).gpu_progress_image_1(tox_dev, locked_pix_dev, progression_image_sum_float_dev, progress_image_num_averaged_pix_dev, resolution_reduction_ratio);
                //gpu.Launch(new dim3(prog_im_siz, prog_im_siz), 1).gpu_progress_image_2(tox_dev, locked_pix_dev, progression_image_sum_float_dev, progress_image_num_averaged_pix_dev, progression_image_dev, prog_im_siz);

                byte[,] progression_image = new byte[prog_im_siz, prog_im_siz];
                gpu.CopyFromDevice(progression_image_dev, progression_image);
                gpu.Synchronize();

                for (int i = 0; i < prog_im_siz; i++)
                    for (int j = 0; j < prog_im_siz; j++)
                        dest[frame, i, j] = progression_image[i, j];

                /* From Picture Box
                Rectangle bounds = picB.Bounds;
                var org = picB.PointToScreen(new Point(0, 0));

                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(org, Point.Empty, bounds.Size);
                    }
                    string pth = ProjectOutputDir + @"Recordings\" + DateTime.Now.ToString("yyyy-MM-dd @HH-mm-ss") + ".jpg";
                    bitmap.Save(pth, ImageFormat.Jpeg);
                }
                */
            }
        }

        private void Save_SIM_Table_CSV(string progression_fil_name)
        {
            float small_medium_thrs_r = 0.342F;
            float medium_large_thrs_r = 0.487F;
            int every_itr = 50;

            /* Calculate the small_medium_thrs_r and medium_large_thrs_r
            float[] Radius = new float[mdl.n_axons];
            for (int a = 0; a < mdl.n_axons; a++)
                Radius[a] = mdl.axon_coor[a][2];

            var sorted = Radius.Select((x, i) => new KeyValuePair<float, int>(x, i)).OrderBy(x => x.Key).ToList();

            List<float> RadiusSorted = sorted.Select(x => x.Key).ToList();
            List<int> SortIdx = sorted.Select(x => x.Value).ToList();

            small_medium_thrs_r = RadiusSorted[mdl.n_axons / 3];
            medium_large_thrs_r = RadiusSorted[2 * mdl.n_axons / 3];
            */

            int[] size_idx = new int[mdl.n_axons];
            int[] n_axons = new int[3];

            // Death iteration
            gpu.CopyFromDevice(axonDeathIterationVector_dev, axonDeathIterationVector);
            gpu.CopyFromDevice(rgcStateVector_dev, rgcStateVector);
            
            
            float sum_rad_alive = 0;

            for (int a = 0; a < mdl.n_axons; a++)
            {
                float radius = mdl.axon_coor[a][2];
                if (radius < small_medium_thrs_r) { size_idx[a] = 0; n_axons[0]++; }
                else if (radius > medium_large_thrs_r) { size_idx[a] = 2; n_axons[2]++; }
                else { size_idx[a] = 1; n_axons[1]++; }
                sum_rad_alive += radius;
            }

            int[,] alive = new int[iteration, 3];
            int[,] dead = new int[iteration, 3];
            float[] mean_dia_dead = new float[iteration];
            float[] mean_dia_alive = new float[iteration];

            float sum_rad_dead = 0;

            string timeStr = DateTime.Now.ToString("yyyy - MM - dd @HH - mm - ss");
            string path = ProjectOutputDir + @"Exported\" + timeStr + ".csv";

            /**
             * 
            for (int i = 1; i < iteration; i++)
            {
                for (int j = 0; j < 3; j++)
                    dead[i, j] = dead[i - 1, j];

                mean_dia_alive[i] = mean_dia_alive[i - 1];
                mean_dia_dead[i] = mean_dia_dead[i - 1];

                for (int a = 0; a < mdl.n_axons; a++)
                    if (i == axonDeathIterationVector[a])
                    {
                        int j = size_idx[a];
                        dead[i, j]++;
                        float radius = mdl.axon_coor[a][2];
                        sum_rad_alive -= radius;
                        sum_rad_dead += radius;
                        mean_dia_alive[i] = sum_rad_alive / (n_axons[j] - dead[i, j]);
                        mean_dia_dead[i] = sum_rad_dead / dead[i, j];
                    }

                for (int j = 0; j < 3; j++)
                    alive[i, j] = n_axons[j] - dead[i, j];
            }

            
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Iteration, Small_Alive, Small_Dead, Medium_Alive, Medium_Dead, Large_Alive, Large_Dead, Mean_Diameter_Alive, Mean_Diameter_Dead");

                for (int i = 1; i < iteration; i += every_itr)
                {
                    file.Write("{0}, ", i);
                    for (int j = 0; j < 3; j++)
                        file.Write("{0}, {1}, ", alive[i, j], dead[i, j]);
                    file.Write("{0}, {1}\n", mean_dia_alive[i] * 2, mean_dia_dead[i] * 2);
                }
            }
            */


            path = ProjectOutputDir + @"Exported\" + timeStr + "_axon_list" + ".csv";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Axon X, Axon Y, Axon D, Mito, Health, Time of Death (s), Current Time (s), GH, Topo");

                for (int a = 0; a < mdl.n_axons; a++)
                {
                    file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", mdl.axon_coor[a][0], mdl.axon_coor[a][1], mdl.axon_coor[a][2] * 2, mitoPercent[a] ,rgcStateVector[a], axonDeathIterationVector[a] * k_time_iter, iteration * k_time_iter, vfLabels[ghZoneMappingVector[a]], topoLabels[topoZoneMappingVector[a]]);
                }
            }


            Append_stat_ln("Model exported to " + path);
            path = ProjectOutputDir + @"Exported\" + timeStr + ".txt";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Sample Diameter = {0} um", mdl.real_diameter);
                file.WriteLine("Model Scale = {0} %",  txt_nerve_scale.Text);
                file.WriteLine("Vessel Scale = {0} %", mdl.vessel_ratio*100);
                file.WriteLine("Sample Size [XY] = {0} um, [Z] = {1} um", lbl_nerve_size.Text, txt_3d_sample_length_um.Text);
                file.WriteLine("Clearance between axons= {0} um", mdl.clearance);
                file.WriteLine("Resolution [XY] = {0}, [Z] = {1} pixels/um", setts.resolution_xy, setts.resolution_z);
                file.WriteLine("Alpha = {0}", setts.alpha);
                file.WriteLine("Model Size [XYZ] = {0} x {1} x {2}", im_size, im_size, (setts.no3dLayers > 1) ? setts.no3dLayers : 1);
                file.WriteLine("Retina = {0}", chk_retina.Checked?"Y":"N");
                
                file.WriteLine("RGC Mito Location = {0}", txt_mito_location.Text);
                file.WriteLine("RGC Mito Amount = {0} %", txt_mito_percent.Text);
                file.WriteLine("Glia Percent = {0} %", txt_glia_percent.Text);

                file.WriteLine("SOD3 = {0} % ", txt_sod_percent.Text);
                file.WriteLine("Use 3D Z Pattern? = {0}", chk_use_3d_pattern.Checked ? "Y" : "N");
                file.WriteLine("Z Spec Mult ROS = {0}", txt_3d_ros_um.Text);
                file.WriteLine("Z Spec Mult SOD = {0}", txt_3d_sod_um.Text);
                file.WriteLine("Z Spec Mult Membrane Perm = {0}", txt_3d_membrane.Text);
                file.WriteLine("Z Position Stress Point = {0}", txt_stress_z_position.Text);
                file.WriteLine("Diffusion [ROS]<H,S>[XY] = {0} um2/s [Z] = {1} um2/s", txt_diff_live_xy.Text, txt_diff_live_z.Text);
                file.WriteLine("Diffusion [ROS]<D  >[XY] = {0} um2/s [Z] = {1} um2/s", txt_diff_dead_xy.Text, txt_diff_dead_z.Text);
                file.WriteLine("Diffusion [ROS]<Int>[XY] = {0} um2/s [Z] = {1} um2/s", txt_diff_glia_xy.Text, txt_diff_glia_z.Text);
                file.WriteLine("Diffusion M [ROS]<H>[XY] = {0} um2/s <S>[XY] = {1} um2/s <D>[XY] = {2} um2/s", txt_membrane_coeff_healthy.Text, txt_membrane_coeff_stress.Text, txt_membrane_coeff_dead.Text);

                file.WriteLine("<Initial, Insult> [ROS] = <{0}> uM ", txt_initial_ros.Text);

                file.WriteLine("Kp <RGC, Glia> <H> = <{0}> uM/s ", txt_healthy_tox_prod.Text);
                file.WriteLine("Kp <RGC, Glia> <S> = <{0}> uM/s ", txt_stress_tox_prod.Text);
                file.WriteLine("Ks <S2,S1,S3> <H> = <{0}> 1/s", txt_sod_detox.Text);
                file.WriteLine("Do not adjust Kp for diam? = {0}  ", chk_fire_factor.Checked?"Y":"N" );
                file.WriteLine("Do not adjust Kp for mito? = {0}  ", noMitoScaleCheckBox.Checked ? "Y" : "N");
                file.WriteLine("Use Death DTOX S3? = {0} ", rbDDTox3.Checked?"Y":"N");
                file.WriteLine("Use Death DTOX S1? = {0} ", rbDDTox1.Checked ? "Y" : "N");
                file.WriteLine("Use Zero Death DTOX?  = {0} ", rbDDTox0.Checked ? "Y" : "N");


                file.WriteLine("H->S [ROS]<RGC,Glia> = <{0}> uM", txt_h2s_tox_thr.Text);
                file.WriteLine("S->H [ROS]<RGC,Glia> = <{0}> uM", txt_s2h_tox_thr.Text);
                file.WriteLine("S->D [ROS]<RGC,Glia> = <{0}> uM", txt_s2d_tox_thr.Text);

                file.WriteLine("Reset Timer on S->H?  = {0} ", chk_timer_reset.Checked ? "Y" : "N");
                file.WriteLine("S->D Timer<RGC,Glia> = <{0}> s ", txt_s2d_timer.Text);

                file.WriteLine("Adjust Thr for Length of axon? = {0} ", chk_length_adj.Checked ? "Y" : "N");

                file.WriteLine("New Model Info = {0}", txt_new_model_params.Text);
                file.WriteLine("Use Image for new model? = {0} ", checkBox_Back_Image.Checked ? "Y" : "N");
            }

            if (usedTimeBoxes > 1)
            {
                Append_stat_ln("Timeseries results data exported to " + path);
                path = ProjectOutputDir + @"Exported\" + timeStr + "_timeseries" + ".csv";
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine("Time, [ROS], {H}, {S}, {D}");

                    for (int i = 0; i < usedTimeBoxes; i++)
                    {
                        file.WriteLine("{0}, {1}, {2}, {3}, {4}", rosAmountVec[i], k_time_iter * iterationVec[i], aliveNumAxonsVec[i] - stressNumAxonsVec[i], stressNumAxonsVec[i], aliveNumAxonsVec[0] - aliveNumAxonsVec[i]);
                    }
                }
            }



            for (int i = 0; i < opticNerveZones; i++)
            {
                aliveZoneTotal[i] = 0;
                stressZoneTotal[i] = 0;
                deadZoneTotal[i] = 0;
            }

            bool visualField = false;

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

            Append_stat_ln("Zone loss topo data exported to " + path);
            path = ProjectOutputDir + @"Exported\" + timeStr + "_topoloss" + ".csv";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Zone, Total, Alive, Stess, Dead, Ratio");

                for (int a = 0; a < opticNerveZones; a++)
                {
                    file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", topoLabels[a], topoZoneTotal[a], aliveZoneTotal[a], stressZoneTotal[a], deadZoneTotal[a], ((float)deadZoneTotal[a])/topoZoneTotal[a]);
                }
            }

            visualField = true;

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

            Append_stat_ln("Zone loss VF data exported to " + path);
            path = ProjectOutputDir + @"Exported\" + timeStr + "_vfloss" + ".csv";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("Zone, Total, Alive, Stess, Dead, Ratio");

                for (int a = 0; a < opticNerveZones; a++)
                {
                    file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", vfLabels[a], ghZoneTotal[a], aliveZoneTotal[a], stressZoneTotal[a], deadZoneTotal[a], ((float)deadZoneTotal[a]) / ghZoneTotal[a]);
                }
            }

        }

        private void Save_Progress(string progression_fil_name)
        {
            Save_SIM_Table_CSV(progression_fil_name);
/*
            // Death iteration
            gpu.CopyFromDevice(death_itr_dev, death_itr);

            using (FileStream fileStream = new FileStream(progression_fil_name, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    // Model ID
                    Debug.WriteLine(model_id);
                    writer.Write(model_id);

                    // Setts
                    writer.Write(setts.resolution);

                    writer.Write(setts.diff_coeff_live_xy);
                    writer.Write(setts.diff_coeff_dead_xy);
                    writer.Write(setts.rate_bound_a2e);
                    writer.Write(setts.rate_extra);

                    writer.Write(setts.tox_prod);
                    writer.Write(setts.detox_intra);
                    writer.Write(setts.detox_extra);

                    writer.Write(setts.death_tox_thres);

                    writer.Write(insult_x);
                    writer.Write(insult_y);
                    writer.Write(insult_r);

                    writer.Write(setts.k_insult_tox);

                    for (int m = 0; m < mdl.n_axons; m++)
                        writer.Write(death_itr[m]);

                    writer.Flush();

                    Append_stat_ln("Sim Progress saved to " + progression_fil_name);
                }
            }
*/
        }

        // ====================== Binary reader . writer

        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite)
        {
            using (Stream stream = File.Create(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }


        // ====================== Matlab Interface

        private void Export_model() // no death info, text file
        {
            string path = ProjectOutputDir + @"Exported\" + DateTime.Now.ToString("yyyy - MM - dd @HH - mm - ss") + ".txt";
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine("{0}, {1}, {2}", mdl.nerve_scale_ratio, default_mdl_vessel_ratio, mdl_clearance);
                for (int i = 0; i < mdl.n_axons; i++)
                    file.WriteLine("{0}, {1}, {2}", mdl.axon_coor[i][0], mdl.axon_coor[i][1], mdl.axon_coor[i][2]);
            }
            Append_stat_ln("Model exported to " + path);
        }

    }
}
