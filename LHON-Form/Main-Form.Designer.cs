using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CustomControls;

namespace LHON_Form
{
    partial class Main_Form
    {
        const bool first_compile = true;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_save_model = new System.Windows.Forms.Button();
            this.btn_load_model = new System.Windows.Forms.Button();
            this.btn_generate_model = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_num_axons = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.checkBox_Back_Image = new System.Windows.Forms.CheckBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txt_stress_z_position = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.txt_3d_membrane = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.chk_retina = new System.Windows.Forms.CheckBox();
            this.txt_mito_location = new System.Windows.Forms.TextBox();
            this.txt_new_model_params = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_mito_percent = new System.Windows.Forms.TextBox();
            this.chk_use_3d_pattern = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txt_sod_percent = new System.Windows.Forms.TextBox();
            this.txt_glia_percent = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txt_3d_sod_um = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txt_3d_ros_um = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txt_3d_sample_length_um = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.lbl_nerve_size = new System.Windows.Forms.Label();
            this.txt_nerve_scale = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxInitialStates = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_initial_ros = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txt_other_initial = new System.Windows.Forms.TextBox();
            this.chk_length_adj = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txt_h2s_tox_thr = new System.Windows.Forms.TextBox();
            this.groupBoxReactionRates = new System.Windows.Forms.GroupBox();
            this.txt_prod_sod_timechange = new System.Windows.Forms.TextBox();
            this.noMitoScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupDDtox = new System.Windows.Forms.GroupBox();
            this.rbDDTox0 = new System.Windows.Forms.RadioButton();
            this.rbDDTox3 = new System.Windows.Forms.RadioButton();
            this.rbDDTox1 = new System.Windows.Forms.RadioButton();
            this.label68 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txt_sod_detox = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_healthy_tox_prod = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.chk_fire_factor = new System.Windows.Forms.CheckBox();
            this.txt_stress_tox_prod = new System.Windows.Forms.TextBox();
            this.txt_s2d_timer = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.btn_load_setts = new System.Windows.Forms.Button();
            this.btn_save_setts = new System.Windows.Forms.Button();
            this.groupBoxDiffusion = new System.Windows.Forms.GroupBox();
            this.label79 = new System.Windows.Forms.Label();
            this.txt_tissue_permeability = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.txt_membrane_coeff_stress = new System.Windows.Forms.TextBox();
            this.txt_diff_glia_z = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.txt_diff_glia_xy = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_membrane_coeff_dead = new System.Windows.Forms.TextBox();
            this.txt_diff_live_xy = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_diff_live_z = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txt_diff_dead_xy = new System.Windows.Forms.TextBox();
            this.txt_diff_dead_z = new System.Windows.Forms.TextBox();
            this.txt_membrane_coeff_healthy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_xy_resolution = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_image_size = new System.Windows.Forms.Label();
            this.btn_preprocess = new System.Windows.Forms.Button();
            this.simGroupBox = new System.Windows.Forms.GroupBox();
            this.label_test_no = new System.Windows.Forms.Label();
            this.checkBox_gen_model = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox_no_iterations = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_stop_time = new System.Windows.Forms.TextBox();
            this.txt_stop_itr = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_save_state_as_list = new System.Windows.Forms.Button();
            this.btn_img_snapshot = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_img_size = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statlbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statlbl_sweep = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxSegmentStateTransitions = new System.Windows.Forms.GroupBox();
            this.chk_timer_reset = new System.Windows.Forms.CheckBox();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.txt_s2d_tox_thr = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.txt_s2h_tox_thr = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txt_cell_ch2ca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.btn_clr = new System.Windows.Forms.Button();
            this.chk_show_tox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chk_show_live_axons = new System.Windows.Forms.CheckBox();
            this.txt_rec_interval = new System.Windows.Forms.TextBox();
            this.lbl_display_view = new System.Windows.Forms.Label();
            this.chk_show_dead_axons = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_show_glia = new System.Windows.Forms.CheckBox();
            this.checkBox_show_rgc = new System.Windows.Forms.CheckBox();
            this.lbl_coronal_dist = new System.Windows.Forms.Label();
            this.lbl_coronal_prox = new System.Windows.Forms.Label();
            this.btn_record_avi = new System.Windows.Forms.Button();
            this.chk_show_stress = new System.Windows.Forms.CheckBox();
            this.chk_rgb_box = new System.Windows.Forms.CheckBox();
            this.sox_track_bar_coronal = new System.Windows.Forms.TrackBar();
            this.direction_group_box = new System.Windows.Forms.GroupBox();
            this.radio_button_sagittal = new System.Windows.Forms.RadioButton();
            this.radio_button_transversal = new System.Windows.Forms.RadioButton();
            this.radio_button_coronal = new System.Windows.Forms.RadioButton();
            this.lbl_topo_n = new System.Windows.Forms.Label();
            this.sox_track_bar_sagittal = new System.Windows.Forms.TrackBar();
            this.sox_track_bar_transversal = new System.Windows.Forms.TrackBar();
            this.tox_image_value = new System.Windows.Forms.ToolTip(this.components);
            this.samplingParameter = new System.Windows.Forms.GroupBox();
            this.lbl_bioIterTime = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.txt_alpha = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.lbl_delta_z = new System.Windows.Forms.Label();
            this.lbl_delta_xy = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lbl_topo_t = new System.Windows.Forms.Label();
            this.lbl_topo_s = new System.Windows.Forms.Label();
            this.lbl_topo_i = new System.Windows.Forms.Label();
            this.lbl_y_dim = new System.Windows.Forms.Label();
            this.lbl_x_dim = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lbl_sample_type = new System.Windows.Forms.Label();
            this.liveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkDisplayLineHist = new System.Windows.Forms.CheckBox();
            this.checkPercentHist = new System.Windows.Forms.CheckBox();
            this.liveHistGroupBox = new System.Windows.Forms.GroupBox();
            this.chk_chart_add_states = new System.Windows.Forms.CheckBox();
            this.checkBox_showSumOfHSD = new System.Windows.Forms.CheckBox();
            this.checkBox_chart_add_zones = new System.Windows.Forms.CheckBox();
            this.checkBox_visual_field = new System.Windows.Forms.CheckBox();
            this.checkBoxZ8 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ2 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ1 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ3 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ4 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ5 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ6 = new System.Windows.Forms.CheckBox();
            this.checkBoxZ7 = new System.Windows.Forms.CheckBox();
            this.checkBoxRatio = new System.Windows.Forms.CheckBox();
            this.checkBox_chart_dead = new System.Windows.Forms.CheckBox();
            this.checkBox_chart_stress = new System.Windows.Forms.CheckBox();
            this.checkBox_chart_healthy = new System.Windows.Forms.CheckBox();
            this.checkBox_chart_legend = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.lbl_stress_percent = new System.Windows.Forms.Label();
            this.lbl_density = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_tox = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_healthy_percent = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_itr_s = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_itr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_bio_time = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_sim_time = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDiff = new System.Windows.Forms.CheckBox();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.labelZ8 = new System.Windows.Forms.Label();
            this.labelZ2 = new System.Windows.Forms.Label();
            this.labelZ3 = new System.Windows.Forms.Label();
            this.labelZ4 = new System.Windows.Forms.Label();
            this.labelZ5 = new System.Windows.Forms.Label();
            this.labelZ6 = new System.Windows.Forms.Label();
            this.labelZ7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_ros_v_h = new System.Windows.Forms.RadioButton();
            this.radioButtonLoss = new System.Windows.Forms.RadioButton();
            this.radioButtonROS = new System.Windows.Forms.RadioButton();
            this.radioButtonCount = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogram = new System.Windows.Forms.RadioButton();
            this.labelChartY = new System.Windows.Forms.Label();
            this.labelChartX = new System.Windows.Forms.Label();
            this.lbl_body_plane = new System.Windows.Forms.Label();
            this.lbl_transversal_superior = new System.Windows.Forms.Label();
            this.lbl_transversal_inf = new System.Windows.Forms.Label();
            this.lbl_sagittal_temp = new System.Windows.Forms.Label();
            this.lbl_sagittal_nasal = new System.Windows.Forms.Label();
            this.lbl_topo_it = new System.Windows.Forms.Label();
            this.lbl_topo_in = new System.Windows.Forms.Label();
            this.lbl_topo_st = new System.Windows.Forms.Label();
            this.lbl_topo_sn = new System.Windows.Forms.Label();
            this.checkBox_chart_3d = new System.Windows.Forms.CheckBox();
            this.groupBoxCellStateTransitions = new System.Windows.Forms.GroupBox();
            this.txt_cell_ca2cd = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.picB = new CustomControls.PictureBoxWithInterpolationMode();
            this.groupBox1.SuspendLayout();
            this.groupBoxInitialStates.SuspendLayout();
            this.groupBoxReactionRates.SuspendLayout();
            this.groupDDtox.SuspendLayout();
            this.groupBoxDiffusion.SuspendLayout();
            this.simGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxSegmentStateTransitions.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_coronal)).BeginInit();
            this.direction_group_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_sagittal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_transversal)).BeginInit();
            this.samplingParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveChart)).BeginInit();
            this.liveHistGroupBox.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxCellStateTransitions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start.Enabled = false;
            this.btn_start.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_start.Location = new System.Drawing.Point(241, 53);
            this.btn_start.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(216, 50);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "&Start";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_save_model
            // 
            this.btn_save_model.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save_model.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_save_model.Location = new System.Drawing.Point(276, 482);
            this.btn_save_model.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_save_model.Name = "btn_save_model";
            this.btn_save_model.Size = new System.Drawing.Size(177, 70);
            this.btn_save_model.TabIndex = 9;
            this.btn_save_model.Text = "Save Map";
            this.btn_save_model.UseVisualStyleBackColor = false;
            // 
            // btn_load_model
            // 
            this.btn_load_model.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_load_model.BackColor = System.Drawing.Color.Green;
            this.btn_load_model.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_load_model.Location = new System.Drawing.Point(43, 484);
            this.btn_load_model.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_load_model.Name = "btn_load_model";
            this.btn_load_model.Size = new System.Drawing.Size(166, 70);
            this.btn_load_model.TabIndex = 10;
            this.btn_load_model.Text = "Load Map";
            this.btn_load_model.UseVisualStyleBackColor = false;
            // 
            // btn_generate_model
            // 
            this.btn_generate_model.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_generate_model.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_generate_model.Location = new System.Drawing.Point(514, 480);
            this.btn_generate_model.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_generate_model.Name = "btn_generate_model";
            this.btn_generate_model.Size = new System.Drawing.Size(178, 70);
            this.btn_generate_model.TabIndex = 11;
            this.btn_generate_model.Text = "New Map";
            this.btn_generate_model.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GrayText;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(29, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 32);
            this.label4.TabIndex = 19;
            this.label4.Text = "RGC Number";
            // 
            // lbl_num_axons
            // 
            this.lbl_num_axons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_num_axons.AutoSize = true;
            this.lbl_num_axons.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_num_axons.Location = new System.Drawing.Point(418, 44);
            this.lbl_num_axons.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_num_axons.Name = "lbl_num_axons";
            this.lbl_num_axons.Size = new System.Drawing.Size(79, 32);
            this.lbl_num_axons.TabIndex = 18;
            this.lbl_num_axons.Text = "8000";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label76);
            this.groupBox1.Controls.Add(this.label75);
            this.groupBox1.Controls.Add(this.checkBox_Back_Image);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.txt_stress_z_position);
            this.groupBox1.Controls.Add(this.label60);
            this.groupBox1.Controls.Add(this.txt_3d_membrane);
            this.groupBox1.Controls.Add(this.label57);
            this.groupBox1.Controls.Add(this.chk_retina);
            this.groupBox1.Controls.Add(this.txt_mito_location);
            this.groupBox1.Controls.Add(this.txt_new_model_params);
            this.groupBox1.Controls.Add(this.lbl_num_axons);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txt_mito_percent);
            this.groupBox1.Controls.Add(this.chk_use_3d_pattern);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label59);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.txt_sod_percent);
            this.groupBox1.Controls.Add(this.txt_glia_percent);
            this.groupBox1.Controls.Add(this.label58);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txt_3d_sod_um);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.txt_3d_ros_um);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.txt_3d_sample_length_um);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lbl_nerve_size);
            this.groupBox1.Controls.Add(this.txt_nerve_scale);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btn_generate_model);
            this.groupBox1.Controls.Add(this.btn_save_model);
            this.groupBox1.Controls.Add(this.btn_load_model);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2215, 254);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Size = new System.Drawing.Size(746, 566);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Topology Control";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.SystemColors.GrayText;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label76.Location = new System.Drawing.Point(117, 321);
            this.label76.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(79, 32);
            this.label76.TabIndex = 76;
            this.label76.Text = "ROS";
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.SystemColors.Highlight;
            this.label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.White;
            this.label75.Location = new System.Drawing.Point(424, 134);
            this.label75.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(53, 32);
            this.label75.TabIndex = 75;
            this.label75.Text = "{Z}";
            // 
            // checkBox_Back_Image
            // 
            this.checkBox_Back_Image.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox_Back_Image.AutoSize = true;
            this.checkBox_Back_Image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkBox_Back_Image.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Back_Image.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_Back_Image.Location = new System.Drawing.Point(598, 429);
            this.checkBox_Back_Image.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_Back_Image.Name = "checkBox_Back_Image";
            this.checkBox_Back_Image.Size = new System.Drawing.Size(136, 36);
            this.checkBox_Back_Image.TabIndex = 74;
            this.checkBox_Back_Image.Text = "Image";
            this.checkBox_Back_Image.UseVisualStyleBackColor = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(692, 133);
            this.label40.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 32);
            this.label40.TabIndex = 72;
            this.label40.Text = "um";
            // 
            // txt_stress_z_position
            // 
            this.txt_stress_z_position.Location = new System.Drawing.Point(231, 376);
            this.txt_stress_z_position.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_stress_z_position.Name = "txt_stress_z_position";
            this.txt_stress_z_position.Size = new System.Drawing.Size(191, 38);
            this.txt_stress_z_position.TabIndex = 70;
            this.txt_stress_z_position.Text = "0";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.BackColor = System.Drawing.SystemColors.GrayText;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label60.Location = new System.Drawing.Point(118, 382);
            this.label60.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(101, 32);
            this.label60.TabIndex = 69;
            this.label60.Text = "Stress";
            // 
            // txt_3d_membrane
            // 
            this.txt_3d_membrane.Location = new System.Drawing.Point(513, 376);
            this.txt_3d_membrane.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_3d_membrane.Name = "txt_3d_membrane";
            this.txt_3d_membrane.Size = new System.Drawing.Size(225, 38);
            this.txt_3d_membrane.TabIndex = 68;
            this.txt_3d_membrane.Text = "0";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.SystemColors.GrayText;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label57.Location = new System.Drawing.Point(424, 379);
            this.label57.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(86, 32);
            this.label57.TabIndex = 67;
            this.label57.Text = "Perm";
            // 
            // chk_retina
            // 
            this.chk_retina.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chk_retina.AutoSize = true;
            this.chk_retina.BackColor = System.Drawing.SystemColors.GrayText;
            this.chk_retina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_retina.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chk_retina.Location = new System.Drawing.Point(423, 84);
            this.chk_retina.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_retina.Name = "chk_retina";
            this.chk_retina.Size = new System.Drawing.Size(142, 36);
            this.chk_retina.TabIndex = 46;
            this.chk_retina.Text = "Retina";
            this.chk_retina.UseVisualStyleBackColor = false;
            // 
            // txt_mito_location
            // 
            this.txt_mito_location.Location = new System.Drawing.Point(234, 176);
            this.txt_mito_location.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_mito_location.Name = "txt_mito_location";
            this.txt_mito_location.Size = new System.Drawing.Size(86, 38);
            this.txt_mito_location.TabIndex = 66;
            this.txt_mito_location.Text = "0.1";
            // 
            // txt_new_model_params
            // 
            this.txt_new_model_params.Location = new System.Drawing.Point(231, 427);
            this.txt_new_model_params.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_new_model_params.Name = "txt_new_model_params";
            this.txt_new_model_params.Size = new System.Drawing.Size(345, 38);
            this.txt_new_model_params.TabIndex = 43;
            this.txt_new_model_params.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 429);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 32);
            this.label15.TabIndex = 44;
            this.label15.Text = "New RGC Topo";
            // 
            // txt_mito_percent
            // 
            this.txt_mito_percent.Location = new System.Drawing.Point(603, 170);
            this.txt_mito_percent.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_mito_percent.Name = "txt_mito_percent";
            this.txt_mito_percent.Size = new System.Drawing.Size(83, 38);
            this.txt_mito_percent.TabIndex = 63;
            this.txt_mito_percent.Text = "10";
            this.txt_mito_percent.TextChanged += new System.EventHandler(this.txt_mito_percent_TextChanged);
            // 
            // chk_use_3d_pattern
            // 
            this.chk_use_3d_pattern.AutoSize = true;
            this.chk_use_3d_pattern.BackColor = System.Drawing.SystemColors.GrayText;
            this.chk_use_3d_pattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_use_3d_pattern.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chk_use_3d_pattern.Location = new System.Drawing.Point(29, 274);
            this.chk_use_3d_pattern.Name = "chk_use_3d_pattern";
            this.chk_use_3d_pattern.Size = new System.Drawing.Size(383, 36);
            this.chk_use_3d_pattern.TabIndex = 49;
            this.chk_use_3d_pattern.Text = "3D Pattern Specification";
            this.chk_use_3d_pattern.UseVisualStyleBackColor = false;
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.SystemColors.Highlight;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label59.Location = new System.Drawing.Point(424, 225);
            this.label59.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(140, 32);
            this.label59.TabIndex = 50;
            this.label59.Text = "Sod3 (%)";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.SystemColors.Highlight;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label53.Location = new System.Drawing.Point(426, 175);
            this.label53.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(200, 32);
            this.label53.TabIndex = 62;
            this.label53.Text = "RGC Mito (%)";
            this.label53.Click += new System.EventHandler(this.label53_Click);
            // 
            // txt_sod_percent
            // 
            this.txt_sod_percent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_sod_percent.Location = new System.Drawing.Point(603, 219);
            this.txt_sod_percent.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_sod_percent.Name = "txt_sod_percent";
            this.txt_sod_percent.Size = new System.Drawing.Size(85, 38);
            this.txt_sod_percent.TabIndex = 49;
            this.txt_sod_percent.Text = "50";
            // 
            // txt_glia_percent
            // 
            this.txt_glia_percent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_glia_percent.Location = new System.Drawing.Point(234, 225);
            this.txt_glia_percent.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_glia_percent.Name = "txt_glia_percent";
            this.txt_glia_percent.Size = new System.Drawing.Size(88, 38);
            this.txt_glia_percent.TabIndex = 48;
            this.txt_glia_percent.Text = "10";
            // 
            // label58
            // 
            this.label58.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.SystemColors.Highlight;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label58.Location = new System.Drawing.Point(34, 230);
            this.label58.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(191, 32);
            this.label58.TabIndex = 47;
            this.label58.Text = "Glia Mito (%)";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.SystemColors.Highlight;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label54.Location = new System.Drawing.Point(33, 180);
            this.label54.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(206, 32);
            this.label54.TabIndex = 65;
            this.label54.Text = "RGC Mito Pos";
            // 
            // txt_3d_sod_um
            // 
            this.txt_3d_sod_um.Location = new System.Drawing.Point(508, 321);
            this.txt_3d_sod_um.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_3d_sod_um.Name = "txt_3d_sod_um";
            this.txt_3d_sod_um.Size = new System.Drawing.Size(230, 38);
            this.txt_3d_sod_um.TabIndex = 52;
            this.txt_3d_sod_um.Text = "0";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.SystemColors.GrayText;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label39.Location = new System.Drawing.Point(424, 321);
            this.label39.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(79, 32);
            this.label39.TabIndex = 50;
            this.label39.Text = "SOD";
            // 
            // txt_3d_ros_um
            // 
            this.txt_3d_ros_um.Location = new System.Drawing.Point(232, 318);
            this.txt_3d_ros_um.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_3d_ros_um.Name = "txt_3d_ros_um";
            this.txt_3d_ros_um.Size = new System.Drawing.Size(188, 38);
            this.txt_3d_ros_um.TabIndex = 51;
            this.txt_3d_ros_um.Text = "0";
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.SystemColors.Highlight;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(154, 135);
            this.label45.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(75, 32);
            this.label45.TabIndex = 45;
            this.label45.Text = "{XY}";
            this.label45.Click += new System.EventHandler(this.label45_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.SystemColors.GrayText;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label38.Location = new System.Drawing.Point(421, 274);
            this.label38.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(239, 32);
            this.label38.TabIndex = 49;
            this.label38.Text = "Z spec only (um)";
            // 
            // txt_3d_sample_length_um
            // 
            this.txt_3d_sample_length_um.Location = new System.Drawing.Point(604, 127);
            this.txt_3d_sample_length_um.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_3d_sample_length_um.Name = "txt_3d_sample_length_um";
            this.txt_3d_sample_length_um.Size = new System.Drawing.Size(84, 38);
            this.txt_3d_sample_length_um.TabIndex = 44;
            this.txt_3d_sample_length_um.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.Highlight;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label23.Location = new System.Drawing.Point(32, 134);
            this.label23.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 32);
            this.label23.TabIndex = 43;
            this.label23.Text = "Sample";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // lbl_nerve_size
            // 
            this.lbl_nerve_size.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_nerve_size.AutoSize = true;
            this.lbl_nerve_size.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_nerve_size.Location = new System.Drawing.Point(228, 133);
            this.lbl_nerve_size.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_nerve_size.Name = "lbl_nerve_size";
            this.lbl_nerve_size.Size = new System.Drawing.Size(109, 32);
            this.lbl_nerve_size.TabIndex = 37;
            this.lbl_nerve_size.Text = "150 um";
            // 
            // txt_nerve_scale
            // 
            this.txt_nerve_scale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_nerve_scale.Location = new System.Drawing.Point(232, 84);
            this.txt_nerve_scale.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_nerve_scale.Name = "txt_nerve_scale";
            this.txt_nerve_scale.Size = new System.Drawing.Size(88, 38);
            this.txt_nerve_scale.TabIndex = 39;
            this.txt_nerve_scale.Text = "10";
            this.txt_nerve_scale.TextChanged += new System.EventHandler(this.txt_nerve_scale_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Highlight;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(31, 88);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 32);
            this.label11.TabIndex = 38;
            this.label11.Text = "Diameter (%)";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // groupBoxInitialStates
            // 
            this.groupBoxInitialStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInitialStates.Controls.Add(this.label28);
            this.groupBoxInitialStates.Controls.Add(this.label65);
            this.groupBoxInitialStates.Controls.Add(this.label64);
            this.groupBoxInitialStates.Controls.Add(this.label21);
            this.groupBoxInitialStates.Controls.Add(this.label20);
            this.groupBoxInitialStates.Controls.Add(this.txt_initial_ros);
            this.groupBoxInitialStates.Controls.Add(this.label41);
            this.groupBoxInitialStates.Controls.Add(this.txt_other_initial);
            this.groupBoxInitialStates.Location = new System.Drawing.Point(2213, 1187);
            this.groupBoxInitialStates.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxInitialStates.Name = "groupBoxInitialStates";
            this.groupBoxInitialStates.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxInitialStates.Size = new System.Drawing.Size(746, 90);
            this.groupBoxInitialStates.TabIndex = 26;
            this.groupBoxInitialStates.TabStop = false;
            this.groupBoxInitialStates.Text = "Initial Conditions";
            this.groupBoxInitialStates.Enter += new System.EventHandler(this.chk_var_death_Enter);
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(120, 46);
            this.label28.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(184, 32);
            this.label28.TabIndex = 71;
            this.label28.Text = "{Initial, Insult}";
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(483, 79);
            this.label65.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(54, 32);
            this.label65.TabIndex = 70;
            this.label65.Text = "uM";
            this.label65.Visible = false;
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(483, 42);
            this.label64.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(54, 32);
            this.label64.TabIndex = 69;
            this.label64.Text = "uM";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(483, -88);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 32);
            this.label21.TabIndex = 66;
            this.label21.Text = "uMol";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(483, -137);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 32);
            this.label20.TabIndex = 65;
            this.label20.Text = "uMol";
            // 
            // txt_initial_ros
            // 
            this.txt_initial_ros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_initial_ros.Location = new System.Drawing.Point(309, 42);
            this.txt_initial_ros.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_initial_ros.Name = "txt_initial_ros";
            this.txt_initial_ros.Size = new System.Drawing.Size(155, 38);
            this.txt_initial_ros.TabIndex = 52;
            this.txt_initial_ros.Text = "5";
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(38, 43);
            this.label41.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(92, 32);
            this.label41.TabIndex = 51;
            this.label41.Text = "[ROS]";
            // 
            // txt_other_initial
            // 
            this.txt_other_initial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_other_initial.Enabled = false;
            this.txt_other_initial.Location = new System.Drawing.Point(309, 88);
            this.txt_other_initial.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_other_initial.Name = "txt_other_initial";
            this.txt_other_initial.Size = new System.Drawing.Size(155, 38);
            this.txt_other_initial.TabIndex = 44;
            this.txt_other_initial.Text = "0";
            this.txt_other_initial.Visible = false;
            // 
            // chk_length_adj
            // 
            this.chk_length_adj.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_length_adj.AutoSize = true;
            this.chk_length_adj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_length_adj.ForeColor = System.Drawing.Color.Black;
            this.chk_length_adj.Location = new System.Drawing.Point(444, 60);
            this.chk_length_adj.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_length_adj.Name = "chk_length_adj";
            this.chk_length_adj.Size = new System.Drawing.Size(190, 36);
            this.chk_length_adj.TabIndex = 65;
            this.chk_length_adj.Text = "Length Adj";
            this.chk_length_adj.UseVisualStyleBackColor = true;
            this.chk_length_adj.CheckedChanged += new System.EventHandler(this.chk_length_adj_CheckedChanged);
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(3, 42);
            this.label36.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(231, 32);
            this.label36.TabIndex = 39;
            this.label36.Text = "{H}->{S}[ROS] >=";
            this.label36.Click += new System.EventHandler(this.label36_Click);
            // 
            // txt_h2s_tox_thr
            // 
            this.txt_h2s_tox_thr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_h2s_tox_thr.Location = new System.Drawing.Point(237, 41);
            this.txt_h2s_tox_thr.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_h2s_tox_thr.Name = "txt_h2s_tox_thr";
            this.txt_h2s_tox_thr.Size = new System.Drawing.Size(135, 38);
            this.txt_h2s_tox_thr.TabIndex = 40;
            this.txt_h2s_tox_thr.Text = "0,0";
            this.txt_h2s_tox_thr.TextChanged += new System.EventHandler(this.txt_apoptosis_tox_threshold_TextChanged);
            // 
            // groupBoxReactionRates
            // 
            this.groupBoxReactionRates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReactionRates.Controls.Add(this.txt_prod_sod_timechange);
            this.groupBoxReactionRates.Controls.Add(this.noMitoScaleCheckBox);
            this.groupBoxReactionRates.Controls.Add(this.label69);
            this.groupBoxReactionRates.Controls.Add(this.label10);
            this.groupBoxReactionRates.Controls.Add(this.groupDDtox);
            this.groupBoxReactionRates.Controls.Add(this.label68);
            this.groupBoxReactionRates.Controls.Add(this.label63);
            this.groupBoxReactionRates.Controls.Add(this.label56);
            this.groupBoxReactionRates.Controls.Add(this.txt_sod_detox);
            this.groupBoxReactionRates.Controls.Add(this.label34);
            this.groupBoxReactionRates.Controls.Add(this.label27);
            this.groupBoxReactionRates.Controls.Add(this.txt_healthy_tox_prod);
            this.groupBoxReactionRates.Controls.Add(this.label29);
            this.groupBoxReactionRates.Controls.Add(this.chk_fire_factor);
            this.groupBoxReactionRates.Controls.Add(this.txt_stress_tox_prod);
            this.groupBoxReactionRates.Location = new System.Drawing.Point(2210, 1280);
            this.groupBoxReactionRates.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxReactionRates.Name = "groupBoxReactionRates";
            this.groupBoxReactionRates.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxReactionRates.Size = new System.Drawing.Size(749, 252);
            this.groupBoxReactionRates.TabIndex = 32;
            this.groupBoxReactionRates.TabStop = false;
            this.groupBoxReactionRates.Text = "Reaction Factors";
            this.groupBoxReactionRates.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // txt_prod_sod_timechange
            // 
            this.txt_prod_sod_timechange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_prod_sod_timechange.Location = new System.Drawing.Point(215, 150);
            this.txt_prod_sod_timechange.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_prod_sod_timechange.Name = "txt_prod_sod_timechange";
            this.txt_prod_sod_timechange.Size = new System.Drawing.Size(347, 38);
            this.txt_prod_sod_timechange.TabIndex = 78;
            this.txt_prod_sod_timechange.Text = "0.01";
            // 
            // noMitoScaleCheckBox
            // 
            this.noMitoScaleCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.noMitoScaleCheckBox.AutoSize = true;
            this.noMitoScaleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noMitoScaleCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noMitoScaleCheckBox.Location = new System.Drawing.Point(386, 198);
            this.noMitoScaleCheckBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.noMitoScaleCheckBox.Name = "noMitoScaleCheckBox";
            this.noMitoScaleCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.noMitoScaleCheckBox.Size = new System.Drawing.Size(177, 36);
            this.noMitoScaleCheckBox.TabIndex = 77;
            this.noMitoScaleCheckBox.Text = "RP !~Mito";
            this.noMitoScaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(391, 56);
            this.label69.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(52, 32);
            this.label69.TabIndex = 75;
            this.label69.Text = "{S}";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 151);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 32);
            this.label10.TabIndex = 74;
            this.label10.Text = "Time {RP, RS}";
            // 
            // groupDDtox
            // 
            this.groupDDtox.Controls.Add(this.rbDDTox0);
            this.groupDDtox.Controls.Add(this.rbDDTox3);
            this.groupDDtox.Controls.Add(this.rbDDTox1);
            this.groupDDtox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupDDtox.Location = new System.Drawing.Point(625, 50);
            this.groupDDtox.Name = "groupDDtox";
            this.groupDDtox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupDDtox.Size = new System.Drawing.Size(115, 170);
            this.groupDDtox.TabIndex = 56;
            this.groupDDtox.TabStop = false;
            this.groupDDtox.Text = "RS{D}";
            // 
            // rbDDTox0
            // 
            this.rbDDTox0.AutoSize = true;
            this.rbDDTox0.ForeColor = System.Drawing.Color.Black;
            this.rbDDTox0.Location = new System.Drawing.Point(11, 121);
            this.rbDDTox0.Name = "rbDDTox0";
            this.rbDDTox0.Size = new System.Drawing.Size(68, 36);
            this.rbDDTox0.TabIndex = 54;
            this.rbDDTox0.Text = "0";
            this.rbDDTox0.UseVisualStyleBackColor = true;
            // 
            // rbDDTox3
            // 
            this.rbDDTox3.AutoSize = true;
            this.rbDDTox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rbDDTox3.Location = new System.Drawing.Point(10, 80);
            this.rbDDTox3.Name = "rbDDTox3";
            this.rbDDTox3.Size = new System.Drawing.Size(87, 36);
            this.rbDDTox3.TabIndex = 53;
            this.rbDDTox3.Text = "S3";
            this.rbDDTox3.UseVisualStyleBackColor = true;
            // 
            // rbDDTox1
            // 
            this.rbDDTox1.AutoSize = true;
            this.rbDDTox1.Checked = true;
            this.rbDDTox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDDTox1.ForeColor = System.Drawing.Color.Black;
            this.rbDDTox1.Location = new System.Drawing.Point(10, 40);
            this.rbDDTox1.Name = "rbDDTox1";
            this.rbDDTox1.Size = new System.Drawing.Size(87, 36);
            this.rbDDTox1.TabIndex = 52;
            this.rbDDTox1.TabStop = true;
            this.rbDDTox1.Text = "S1";
            this.rbDDTox1.UseVisualStyleBackColor = true;
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(161, 57);
            this.label68.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(53, 32);
            this.label68.TabIndex = 71;
            this.label68.Text = "{H}";
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(561, 101);
            this.label63.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(53, 32);
            this.label63.TabIndex = 68;
            this.label63.Text = "1/s";
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(558, 58);
            this.label56.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(76, 32);
            this.label56.TabIndex = 67;
            this.label56.Text = "uM/s";
            // 
            // txt_sod_detox
            // 
            this.txt_sod_detox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_sod_detox.Location = new System.Drawing.Point(217, 102);
            this.txt_sod_detox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_sod_detox.Name = "txt_sod_detox";
            this.txt_sod_detox.Size = new System.Drawing.Size(345, 38);
            this.txt_sod_detox.TabIndex = 21;
            this.txt_sod_detox.Text = "0.01";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(571, 148);
            this.label34.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 32);
            this.label34.TabIndex = 36;
            this.label34.Text = "s";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 105);
            this.label27.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(193, 32);
            this.label27.TabIndex = 20;
            this.label27.Text = "RS{S2,S1,S3}";
            this.label27.Click += new System.EventHandler(this.label27_Click);
            // 
            // txt_healthy_tox_prod
            // 
            this.txt_healthy_tox_prod.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_healthy_tox_prod.Location = new System.Drawing.Point(217, 55);
            this.txt_healthy_tox_prod.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_healthy_tox_prod.Name = "txt_healthy_tox_prod";
            this.txt_healthy_tox_prod.Size = new System.Drawing.Size(171, 38);
            this.txt_healthy_tox_prod.TabIndex = 42;
            this.txt_healthy_tox_prod.Text = "0.003";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 57);
            this.label29.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(165, 32);
            this.label29.TabIndex = 41;
            this.label29.Text = "RP{a,g,c,i,t}";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // chk_fire_factor
            // 
            this.chk_fire_factor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_fire_factor.AutoSize = true;
            this.chk_fire_factor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_fire_factor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chk_fire_factor.Location = new System.Drawing.Point(9, 197);
            this.chk_fire_factor.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_fire_factor.Name = "chk_fire_factor";
            this.chk_fire_factor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk_fire_factor.Size = new System.Drawing.Size(249, 36);
            this.chk_fire_factor.TabIndex = 64;
            this.chk_fire_factor.Text = "RP{H,S} freq~R";
            this.chk_fire_factor.UseVisualStyleBackColor = true;
            // 
            // txt_stress_tox_prod
            // 
            this.txt_stress_tox_prod.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_stress_tox_prod.Location = new System.Drawing.Point(441, 55);
            this.txt_stress_tox_prod.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_stress_tox_prod.Name = "txt_stress_tox_prod";
            this.txt_stress_tox_prod.Size = new System.Drawing.Size(121, 38);
            this.txt_stress_tox_prod.TabIndex = 46;
            this.txt_stress_tox_prod.Text = "5";
            this.txt_stress_tox_prod.TextChanged += new System.EventHandler(this.txt_on_death_tox_TextChanged);
            // 
            // txt_s2d_timer
            // 
            this.txt_s2d_timer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_s2d_timer.Location = new System.Drawing.Point(522, 130);
            this.txt_s2d_timer.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_s2d_timer.Name = "txt_s2d_timer";
            this.txt_s2d_timer.Size = new System.Drawing.Size(106, 38);
            this.txt_s2d_timer.TabIndex = 52;
            this.txt_s2d_timer.Text = "5";
            this.txt_s2d_timer.TextChanged += new System.EventHandler(this.txt_apoptosis_duration_sec_TextChanged);
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(433, 133);
            this.label55.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(87, 32);
            this.label55.TabIndex = 51;
            this.label55.Text = "Timer";
            this.label55.Click += new System.EventHandler(this.label55_Click);
            // 
            // btn_load_setts
            // 
            this.btn_load_setts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_load_setts.BackColor = System.Drawing.Color.Green;
            this.btn_load_setts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_load_setts.Location = new System.Drawing.Point(2253, 1554);
            this.btn_load_setts.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_load_setts.Name = "btn_load_setts";
            this.btn_load_setts.Size = new System.Drawing.Size(210, 70);
            this.btn_load_setts.TabIndex = 29;
            this.btn_load_setts.Text = "Load Settings";
            this.btn_load_setts.UseVisualStyleBackColor = false;
            // 
            // btn_save_setts
            // 
            this.btn_save_setts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save_setts.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_save_setts.Location = new System.Drawing.Point(2714, 1554);
            this.btn_save_setts.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_save_setts.Name = "btn_save_setts";
            this.btn_save_setts.Size = new System.Drawing.Size(210, 70);
            this.btn_save_setts.TabIndex = 20;
            this.btn_save_setts.Text = "Save Settings ";
            this.btn_save_setts.UseVisualStyleBackColor = false;
            // 
            // groupBoxDiffusion
            // 
            this.groupBoxDiffusion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDiffusion.Controls.Add(this.label79);
            this.groupBoxDiffusion.Controls.Add(this.txt_tissue_permeability);
            this.groupBoxDiffusion.Controls.Add(this.label83);
            this.groupBoxDiffusion.Controls.Add(this.label82);
            this.groupBoxDiffusion.Controls.Add(this.txt_membrane_coeff_stress);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_glia_z);
            this.groupBoxDiffusion.Controls.Add(this.label25);
            this.groupBoxDiffusion.Controls.Add(this.label78);
            this.groupBoxDiffusion.Controls.Add(this.label30);
            this.groupBoxDiffusion.Controls.Add(this.label33);
            this.groupBoxDiffusion.Controls.Add(this.label77);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_glia_xy);
            this.groupBoxDiffusion.Controls.Add(this.label26);
            this.groupBoxDiffusion.Controls.Add(this.txt_membrane_coeff_dead);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_live_xy);
            this.groupBoxDiffusion.Controls.Add(this.label62);
            this.groupBoxDiffusion.Controls.Add(this.label48);
            this.groupBoxDiffusion.Controls.Add(this.label49);
            this.groupBoxDiffusion.Controls.Add(this.label61);
            this.groupBoxDiffusion.Controls.Add(this.label31);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_live_z);
            this.groupBoxDiffusion.Controls.Add(this.label7);
            this.groupBoxDiffusion.Controls.Add(this.label32);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_dead_xy);
            this.groupBoxDiffusion.Controls.Add(this.txt_diff_dead_z);
            this.groupBoxDiffusion.Controls.Add(this.txt_membrane_coeff_healthy);
            this.groupBoxDiffusion.Controls.Add(this.label8);
            this.groupBoxDiffusion.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBoxDiffusion.Location = new System.Drawing.Point(2210, 828);
            this.groupBoxDiffusion.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxDiffusion.Name = "groupBoxDiffusion";
            this.groupBoxDiffusion.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxDiffusion.Size = new System.Drawing.Size(751, 387);
            this.groupBoxDiffusion.TabIndex = 35;
            this.groupBoxDiffusion.TabStop = false;
            this.groupBoxDiffusion.Text = "Diffusion Coefficients (um^2/s) ";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(162, 322);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(117, 32);
            this.label79.TabIndex = 69;
            this.label79.Text = "{*}{XYZ}";
            // 
            // txt_tissue_permeability
            // 
            this.txt_tissue_permeability.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_tissue_permeability.Location = new System.Drawing.Point(300, 322);
            this.txt_tissue_permeability.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_tissue_permeability.Name = "txt_tissue_permeability";
            this.txt_tissue_permeability.Size = new System.Drawing.Size(158, 38);
            this.txt_tissue_permeability.TabIndex = 68;
            this.txt_tissue_permeability.Text = "0.05";
            // 
            // label83
            // 
            this.label83.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(44, 322);
            this.label83.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(99, 32);
            this.label83.TabIndex = 67;
            this.label83.Text = "Tissue";
            // 
            // label82
            // 
            this.label82.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(1, 185);
            this.label82.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(401, 32);
            this.label82.TabIndex = 66;
            this.label82.Text = "Membrane Permeability (um/s)";
            // 
            // txt_membrane_coeff_stress
            // 
            this.txt_membrane_coeff_stress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_membrane_coeff_stress.Location = new System.Drawing.Point(570, 236);
            this.txt_membrane_coeff_stress.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_membrane_coeff_stress.Name = "txt_membrane_coeff_stress";
            this.txt_membrane_coeff_stress.Size = new System.Drawing.Size(158, 38);
            this.txt_membrane_coeff_stress.TabIndex = 65;
            this.txt_membrane_coeff_stress.Text = "0.0";
            this.txt_membrane_coeff_stress.Visible = false;
            // 
            // txt_diff_glia_z
            // 
            this.txt_diff_glia_z.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_glia_z.Location = new System.Drawing.Point(566, 141);
            this.txt_diff_glia_z.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_glia_z.Name = "txt_diff_glia_z";
            this.txt_diff_glia_z.Size = new System.Drawing.Size(159, 38);
            this.txt_diff_glia_z.TabIndex = 37;
            this.txt_diff_glia_z.Text = "0.5";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(42, 56);
            this.label25.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(142, 32);
            this.label25.TabIndex = 29;
            this.label25.Text = "RGC{H,S}";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(470, 238);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(108, 32);
            this.label78.TabIndex = 64;
            this.label78.Text = "{S}{XY}";
            this.label78.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(512, 141);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 32);
            this.label30.TabIndex = 13;
            this.label30.Text = "{Z}";
            this.label30.Click += new System.EventHandler(this.label30_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(226, 52);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(71, 32);
            this.label33.TabIndex = 16;
            this.label33.Text = "{XY}";
            // 
            // label77
            // 
            this.label77.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(46, 284);
            this.label77.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(80, 32);
            this.label77.TabIndex = 63;
            this.label77.Text = "Axon";
            // 
            // txt_diff_glia_xy
            // 
            this.txt_diff_glia_xy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_glia_xy.Location = new System.Drawing.Point(301, 141);
            this.txt_diff_glia_xy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_glia_xy.Name = "txt_diff_glia_xy";
            this.txt_diff_glia_xy.Size = new System.Drawing.Size(159, 38);
            this.txt_diff_glia_xy.TabIndex = 34;
            this.txt_diff_glia_xy.Text = "0.5";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(45, 139);
            this.label26.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(164, 32);
            this.label26.TabIndex = 33;
            this.label26.Text = "Inter{H,S,D}";
            // 
            // txt_membrane_coeff_dead
            // 
            this.txt_membrane_coeff_dead.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_membrane_coeff_dead.Location = new System.Drawing.Point(302, 278);
            this.txt_membrane_coeff_dead.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_membrane_coeff_dead.Name = "txt_membrane_coeff_dead";
            this.txt_membrane_coeff_dead.Size = new System.Drawing.Size(158, 38);
            this.txt_membrane_coeff_dead.TabIndex = 62;
            this.txt_membrane_coeff_dead.Text = "0.05";
            // 
            // txt_diff_live_xy
            // 
            this.txt_diff_live_xy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_live_xy.Location = new System.Drawing.Point(300, 51);
            this.txt_diff_live_xy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_live_xy.Name = "txt_diff_live_xy";
            this.txt_diff_live_xy.Size = new System.Drawing.Size(159, 38);
            this.txt_diff_live_xy.TabIndex = 32;
            this.txt_diff_live_xy.Text = "0.5";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(162, 279);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(109, 32);
            this.label62.TabIndex = 61;
            this.label62.Text = "{D}{XY}";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(227, 144);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 32);
            this.label48.TabIndex = 38;
            this.label48.Text = "{XY}";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(509, 96);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(50, 32);
            this.label49.TabIndex = 59;
            this.label49.Text = "{Z}";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(163, 237);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(136, 32);
            this.label61.TabIndex = 60;
            this.label61.Text = "{H,S}{XY}";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(509, 51);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 32);
            this.label31.TabIndex = 14;
            this.label31.Text = "{Z}";
            // 
            // txt_diff_live_z
            // 
            this.txt_diff_live_z.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_live_z.Location = new System.Drawing.Point(568, 51);
            this.txt_diff_live_z.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_live_z.Name = "txt_diff_live_z";
            this.txt_diff_live_z.Size = new System.Drawing.Size(159, 38);
            this.txt_diff_live_z.TabIndex = 36;
            this.txt_diff_live_z.Text = "0.5";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 98);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 32);
            this.label7.TabIndex = 39;
            this.label7.Text = "RGC{D}";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(226, 95);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(71, 32);
            this.label32.TabIndex = 59;
            this.label32.Text = "{XY}";
            // 
            // txt_diff_dead_xy
            // 
            this.txt_diff_dead_xy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_dead_xy.Location = new System.Drawing.Point(301, 96);
            this.txt_diff_dead_xy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_dead_xy.Name = "txt_diff_dead_xy";
            this.txt_diff_dead_xy.Size = new System.Drawing.Size(158, 38);
            this.txt_diff_dead_xy.TabIndex = 21;
            this.txt_diff_dead_xy.Text = "0.5";
            // 
            // txt_diff_dead_z
            // 
            this.txt_diff_dead_z.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_diff_dead_z.Location = new System.Drawing.Point(568, 96);
            this.txt_diff_dead_z.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_diff_dead_z.Name = "txt_diff_dead_z";
            this.txt_diff_dead_z.Size = new System.Drawing.Size(157, 38);
            this.txt_diff_dead_z.TabIndex = 35;
            this.txt_diff_dead_z.Text = "0.05";
            // 
            // txt_membrane_coeff_healthy
            // 
            this.txt_membrane_coeff_healthy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt_membrane_coeff_healthy.Location = new System.Drawing.Point(302, 232);
            this.txt_membrane_coeff_healthy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_membrane_coeff_healthy.Name = "txt_membrane_coeff_healthy";
            this.txt_membrane_coeff_healthy.Size = new System.Drawing.Size(158, 38);
            this.txt_membrane_coeff_healthy.TabIndex = 27;
            this.txt_membrane_coeff_healthy.Text = "0.05";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 243);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 32);
            this.label8.TabIndex = 26;
            this.label8.Text = "Axon";
            // 
            // txt_xy_resolution
            // 
            this.txt_xy_resolution.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_xy_resolution.Location = new System.Drawing.Point(382, 43);
            this.txt_xy_resolution.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_xy_resolution.Name = "txt_xy_resolution";
            this.txt_xy_resolution.Size = new System.Drawing.Size(139, 38);
            this.txt_xy_resolution.TabIndex = 34;
            this.txt_xy_resolution.Text = "5,1";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Highlight;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(27, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 32);
            this.label9.TabIndex = 33;
            this.label9.Text = "Res (pix/um) {XY, Z}";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.GrayText;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label12.Location = new System.Drawing.Point(27, 176);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(340, 32);
            this.label12.TabIndex = 31;
            this.label12.Text = "Model Size (XYZ pixels)";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lbl_image_size
            // 
            this.lbl_image_size.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_image_size.AutoSize = true;
            this.lbl_image_size.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_image_size.Location = new System.Drawing.Point(383, 178);
            this.lbl_image_size.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_image_size.Name = "lbl_image_size";
            this.lbl_image_size.Size = new System.Drawing.Size(187, 32);
            this.lbl_image_size.TabIndex = 30;
            this.lbl_image_size.Text = "1500x1500x1";
            // 
            // btn_preprocess
            // 
            this.btn_preprocess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_preprocess.BackColor = System.Drawing.Color.Green;
            this.btn_preprocess.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_preprocess.Location = new System.Drawing.Point(12, 51);
            this.btn_preprocess.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_preprocess.Name = "btn_preprocess";
            this.btn_preprocess.Size = new System.Drawing.Size(210, 52);
            this.btn_preprocess.TabIndex = 29;
            this.btn_preprocess.Text = "&Preprocess";
            this.btn_preprocess.UseVisualStyleBackColor = false;
            // 
            // simGroupBox
            // 
            this.simGroupBox.Controls.Add(this.label_test_no);
            this.simGroupBox.Controls.Add(this.checkBox_gen_model);
            this.simGroupBox.Controls.Add(this.label70);
            this.simGroupBox.Controls.Add(this.textBox_no_iterations);
            this.simGroupBox.Controls.Add(this.label52);
            this.simGroupBox.Controls.Add(this.label24);
            this.simGroupBox.Controls.Add(this.btn_reset);
            this.simGroupBox.Controls.Add(this.btn_start);
            this.simGroupBox.Controls.Add(this.txt_stop_time);
            this.simGroupBox.Controls.Add(this.txt_stop_itr);
            this.simGroupBox.Controls.Add(this.label16);
            this.simGroupBox.Controls.Add(this.label5);
            this.simGroupBox.Controls.Add(this.btn_preprocess);
            this.simGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.simGroupBox.Location = new System.Drawing.Point(32, 14);
            this.simGroupBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.simGroupBox.Name = "simGroupBox";
            this.simGroupBox.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.simGroupBox.Size = new System.Drawing.Size(709, 215);
            this.simGroupBox.TabIndex = 27;
            this.simGroupBox.TabStop = false;
            this.simGroupBox.Text = "Sim Engine Control";
            this.simGroupBox.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label_test_no
            // 
            this.label_test_no.AutoSize = true;
            this.label_test_no.BackColor = System.Drawing.SystemColors.GrayText;
            this.label_test_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_test_no.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_test_no.Location = new System.Drawing.Point(400, 179);
            this.label_test_no.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_test_no.Name = "label_test_no";
            this.label_test_no.Size = new System.Drawing.Size(76, 32);
            this.label_test_no.TabIndex = 99;
            this.label_test_no.Text = "[0,0]";
            // 
            // checkBox_gen_model
            // 
            this.checkBox_gen_model.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_gen_model.AutoSize = true;
            this.checkBox_gen_model.Location = new System.Drawing.Point(545, 179);
            this.checkBox_gen_model.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_gen_model.Name = "checkBox_gen_model";
            this.checkBox_gen_model.Size = new System.Drawing.Size(169, 36);
            this.checkBox_gen_model.TabIndex = 98;
            this.checkBox_gen_model.Text = "Gen Map";
            this.checkBox_gen_model.UseVisualStyleBackColor = true;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.SystemColors.Highlight;
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label70.Location = new System.Drawing.Point(13, 179);
            this.label70.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(150, 32);
            this.label70.TabIndex = 79;
            this.label70.Text = "Test Loop";
            // 
            // textBox_no_iterations
            // 
            this.textBox_no_iterations.Location = new System.Drawing.Point(241, 177);
            this.textBox_no_iterations.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.textBox_no_iterations.Name = "textBox_no_iterations";
            this.textBox_no_iterations.Size = new System.Drawing.Size(147, 38);
            this.textBox_no_iterations.TabIndex = 78;
            this.textBox_no_iterations.Text = "0";
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(396, 135);
            this.label52.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(29, 32);
            this.label52.TabIndex = 77;
            this.label52.Text = "s";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.SystemColors.Highlight;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Location = new System.Drawing.Point(94, 133);
            this.label24.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(144, 32);
            this.label24.TabIndex = 43;
            this.label24.Text = "@Bio sec";
            // 
            // btn_reset
            // 
            this.btn_reset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(481, 51);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(210, 52);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "&Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // txt_stop_time
            // 
            this.txt_stop_time.Location = new System.Drawing.Point(243, 131);
            this.txt_stop_time.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_stop_time.Name = "txt_stop_time";
            this.txt_stop_time.Size = new System.Drawing.Size(147, 38);
            this.txt_stop_time.TabIndex = 41;
            this.txt_stop_time.Text = "0";
            // 
            // txt_stop_itr
            // 
            this.txt_stop_itr.Location = new System.Drawing.Point(545, 132);
            this.txt_stop_itr.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_stop_itr.Name = "txt_stop_itr";
            this.txt_stop_itr.Size = new System.Drawing.Size(147, 38);
            this.txt_stop_itr.TabIndex = 38;
            this.txt_stop_itr.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.GrayText;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(451, 134);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 32);
            this.label16.TabIndex = 37;
            this.label16.Text = "@Iter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Highlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 32);
            this.label5.TabIndex = 42;
            this.label5.Text = "Stop";
            // 
            // btn_save_state_as_list
            // 
            this.btn_save_state_as_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save_state_as_list.Location = new System.Drawing.Point(598, 145);
            this.btn_save_state_as_list.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_save_state_as_list.Name = "btn_save_state_as_list";
            this.btn_save_state_as_list.Size = new System.Drawing.Size(158, 43);
            this.btn_save_state_as_list.TabIndex = 43;
            this.btn_save_state_as_list.Text = "Save &List";
            this.btn_save_state_as_list.UseVisualStyleBackColor = true;
            // 
            // btn_img_snapshot
            // 
            this.btn_img_snapshot.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_img_snapshot.Enabled = false;
            this.btn_img_snapshot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_img_snapshot.Location = new System.Drawing.Point(598, 36);
            this.btn_img_snapshot.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_img_snapshot.Name = "btn_img_snapshot";
            this.btn_img_snapshot.Size = new System.Drawing.Size(158, 43);
            this.btn_img_snapshot.TabIndex = 36;
            this.btn_img_snapshot.Text = "S&napshot";
            this.btn_img_snapshot.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(340, 43);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 32);
            this.label13.TabIndex = 34;
            this.label13.Text = "Img Size";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txt_img_size
            // 
            this.txt_img_size.Location = new System.Drawing.Point(477, 39);
            this.txt_img_size.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_img_size.Name = "txt_img_size";
            this.txt_img_size.Size = new System.Drawing.Size(100, 38);
            this.txt_img_size.TabIndex = 35;
            this.txt_img_size.Text = "1024";
            this.txt_img_size.TextChanged += new System.EventHandler(this.txt_delay_ms_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statlbl,
            this.toolStripStatusLabel3,
            this.statlbl_sweep,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2974, 54);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statlbl
            // 
            this.statlbl.Name = "statlbl";
            this.statlbl.Size = new System.Drawing.Size(146, 41);
            this.statlbl.Text = "                ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(234, 41);
            this.toolStripStatusLabel3.Text = "                           ";
            // 
            // statlbl_sweep
            // 
            this.statlbl_sweep.Name = "statlbl_sweep";
            this.statlbl_sweep.Size = new System.Drawing.Size(210, 41);
            this.statlbl_sweep.Text = "                        ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(2114, 41);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(138, 41);
            this.toolStripStatusLabel2.Text = "               ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 38);
            // 
            // groupBoxSegmentStateTransitions
            // 
            this.groupBoxSegmentStateTransitions.Controls.Add(this.chk_timer_reset);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label73);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label74);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.txt_s2d_tox_thr);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label71);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label72);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.txt_s2h_tox_thr);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label67);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label66);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.txt_s2d_timer);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label55);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.label36);
            this.groupBoxSegmentStateTransitions.Controls.Add(this.txt_h2s_tox_thr);
            this.groupBoxSegmentStateTransitions.Location = new System.Drawing.Point(1549, 27);
            this.groupBoxSegmentStateTransitions.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxSegmentStateTransitions.Name = "groupBoxSegmentStateTransitions";
            this.groupBoxSegmentStateTransitions.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxSegmentStateTransitions.Size = new System.Drawing.Size(649, 184);
            this.groupBoxSegmentStateTransitions.TabIndex = 33;
            this.groupBoxSegmentStateTransitions.TabStop = false;
            this.groupBoxSegmentStateTransitions.Text = "Segment Transitions {rgc, glia}";
            this.groupBoxSegmentStateTransitions.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // chk_timer_reset
            // 
            this.chk_timer_reset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_timer_reset.AutoSize = true;
            this.chk_timer_reset.Checked = true;
            this.chk_timer_reset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_timer_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_timer_reset.ForeColor = System.Drawing.Color.Black;
            this.chk_timer_reset.Location = new System.Drawing.Point(442, 87);
            this.chk_timer_reset.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_timer_reset.Name = "chk_timer_reset";
            this.chk_timer_reset.Size = new System.Drawing.Size(206, 36);
            this.chk_timer_reset.TabIndex = 77;
            this.chk_timer_reset.Text = "Reset Timer";
            this.chk_timer_reset.UseVisualStyleBackColor = true;
            // 
            // label73
            // 
            this.label73.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(383, 133);
            this.label73.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(54, 32);
            this.label73.TabIndex = 73;
            this.label73.Text = "uM";
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(3, 126);
            this.label74.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(231, 32);
            this.label74.TabIndex = 71;
            this.label74.Text = "{S}->{D}[ROS] >=";
            // 
            // txt_s2d_tox_thr
            // 
            this.txt_s2d_tox_thr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_s2d_tox_thr.Location = new System.Drawing.Point(239, 127);
            this.txt_s2d_tox_thr.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_s2d_tox_thr.Name = "txt_s2d_tox_thr";
            this.txt_s2d_tox_thr.Size = new System.Drawing.Size(135, 38);
            this.txt_s2d_tox_thr.TabIndex = 72;
            this.txt_s2d_tox_thr.Text = "0,0";
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(380, 90);
            this.label71.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(54, 32);
            this.label71.TabIndex = 70;
            this.label71.Text = "uM";
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(3, 83);
            this.label72.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(231, 32);
            this.label72.TabIndex = 68;
            this.label72.Text = "{S}->{H}[ROS] <=";
            // 
            // txt_s2h_tox_thr
            // 
            this.txt_s2h_tox_thr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_s2h_tox_thr.Location = new System.Drawing.Point(238, 84);
            this.txt_s2h_tox_thr.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_s2h_tox_thr.Name = "txt_s2h_tox_thr";
            this.txt_s2h_tox_thr.Size = new System.Drawing.Size(135, 38);
            this.txt_s2h_tox_thr.TabIndex = 69;
            this.txt_s2h_tox_thr.Text = "0,0";
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(383, 47);
            this.label67.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(54, 32);
            this.label67.TabIndex = 67;
            this.label67.Text = "uM";
            this.label67.Click += new System.EventHandler(this.label67_Click);
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(629, 133);
            this.label66.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(29, 32);
            this.label66.TabIndex = 66;
            this.label66.Text = "s";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(390, 96);
            this.label35.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 32);
            this.label35.TabIndex = 76;
            this.label35.Text = "s";
            this.label35.Visible = false;
            // 
            // txt_cell_ch2ca
            // 
            this.txt_cell_ch2ca.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_cell_ch2ca.Enabled = false;
            this.txt_cell_ch2ca.Location = new System.Drawing.Point(241, 39);
            this.txt_cell_ch2ca.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_cell_ch2ca.Name = "txt_cell_ch2ca";
            this.txt_cell_ch2ca.Size = new System.Drawing.Size(135, 38);
            this.txt_cell_ch2ca.TabIndex = 75;
            this.txt_cell_ch2ca.Text = "0";
            this.txt_cell_ch2ca.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 32);
            this.label6.TabIndex = 74;
            this.label6.Text = "{CH}->{CA} >=";
            this.label6.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.txt_status);
            this.groupBox8.Controls.Add(this.btn_clr);
            this.groupBox8.Location = new System.Drawing.Point(1312, 362);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox8.Size = new System.Drawing.Size(886, 288);
            this.groupBox8.TabIndex = 38;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Output";
            // 
            // txt_status
            // 
            this.txt_status.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_status.Location = new System.Drawing.Point(0, 52);
            this.txt_status.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_status.Multiline = true;
            this.txt_status.Name = "txt_status";
            this.txt_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_status.Size = new System.Drawing.Size(889, 228);
            this.txt_status.TabIndex = 33;
            // 
            // btn_clr
            // 
            this.btn_clr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clr.Location = new System.Drawing.Point(800, -8);
            this.btn_clr.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_clr.Name = "btn_clr";
            this.btn_clr.Size = new System.Drawing.Size(86, 52);
            this.btn_clr.TabIndex = 34;
            this.btn_clr.Text = "clr";
            this.btn_clr.UseVisualStyleBackColor = true;
            // 
            // chk_show_tox
            // 
            this.chk_show_tox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_show_tox.AutoSize = true;
            this.chk_show_tox.Checked = true;
            this.chk_show_tox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_show_tox.Location = new System.Drawing.Point(12, 152);
            this.chk_show_tox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_show_tox.Name = "chk_show_tox";
            this.chk_show_tox.Size = new System.Drawing.Size(130, 36);
            this.chk_show_tox.TabIndex = 27;
            this.chk_show_tox.Text = "[ROS]";
            this.chk_show_tox.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 46);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(170, 32);
            this.label17.TabIndex = 44;
            this.label17.Text = "Update [Iter]";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // chk_show_live_axons
            // 
            this.chk_show_live_axons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_show_live_axons.AutoSize = true;
            this.chk_show_live_axons.Checked = true;
            this.chk_show_live_axons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_show_live_axons.Location = new System.Drawing.Point(12, 94);
            this.chk_show_live_axons.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_show_live_axons.Name = "chk_show_live_axons";
            this.chk_show_live_axons.Size = new System.Drawing.Size(91, 36);
            this.chk_show_live_axons.TabIndex = 26;
            this.chk_show_live_axons.Text = "{H}";
            this.chk_show_live_axons.UseVisualStyleBackColor = true;
            // 
            // txt_rec_interval
            // 
            this.txt_rec_interval.Location = new System.Drawing.Point(198, 43);
            this.txt_rec_interval.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_rec_interval.Name = "txt_rec_interval";
            this.txt_rec_interval.Size = new System.Drawing.Size(100, 38);
            this.txt_rec_interval.TabIndex = 45;
            this.txt_rec_interval.Text = "200";
            // 
            // lbl_display_view
            // 
            this.lbl_display_view.AutoSize = true;
            this.lbl_display_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_display_view.ForeColor = System.Drawing.Color.White;
            this.lbl_display_view.Location = new System.Drawing.Point(73, 319);
            this.lbl_display_view.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_display_view.Name = "lbl_display_view";
            this.lbl_display_view.Size = new System.Drawing.Size(285, 32);
            this.lbl_display_view.TabIndex = 49;
            this.lbl_display_view.Text = "Proximal Delta= 0 um";
            this.lbl_display_view.Click += new System.EventHandler(this.label40_Click);
            // 
            // chk_show_dead_axons
            // 
            this.chk_show_dead_axons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_show_dead_axons.AutoSize = true;
            this.chk_show_dead_axons.Checked = true;
            this.chk_show_dead_axons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_show_dead_axons.Location = new System.Drawing.Point(200, 96);
            this.chk_show_dead_axons.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_show_dead_axons.Name = "chk_show_dead_axons";
            this.chk_show_dead_axons.Size = new System.Drawing.Size(91, 36);
            this.chk_show_dead_axons.TabIndex = 51;
            this.chk_show_dead_axons.Text = "{D}";
            this.chk_show_dead_axons.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_show_glia);
            this.groupBox4.Controls.Add(this.checkBox_show_rgc);
            this.groupBox4.Controls.Add(this.btn_save_state_as_list);
            this.groupBox4.Controls.Add(this.lbl_coronal_dist);
            this.groupBox4.Controls.Add(this.lbl_coronal_prox);
            this.groupBox4.Controls.Add(this.btn_record_avi);
            this.groupBox4.Controls.Add(this.chk_show_stress);
            this.groupBox4.Controls.Add(this.chk_rgb_box);
            this.groupBox4.Controls.Add(this.btn_img_snapshot);
            this.groupBox4.Controls.Add(this.sox_track_bar_coronal);
            this.groupBox4.Controls.Add(this.chk_show_dead_axons);
            this.groupBox4.Controls.Add(this.direction_group_box);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txt_img_size);
            this.groupBox4.Controls.Add(this.txt_rec_interval);
            this.groupBox4.Controls.Add(this.chk_show_live_axons);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.chk_show_tox);
            this.groupBox4.Location = new System.Drawing.Point(753, 23);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox4.Size = new System.Drawing.Size(784, 331);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Visualization Control";
            // 
            // checkBox_show_glia
            // 
            this.checkBox_show_glia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_show_glia.AutoSize = true;
            this.checkBox_show_glia.Checked = true;
            this.checkBox_show_glia.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_show_glia.Location = new System.Drawing.Point(482, 100);
            this.checkBox_show_glia.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_show_glia.Name = "checkBox_show_glia";
            this.checkBox_show_glia.Size = new System.Drawing.Size(105, 36);
            this.checkBox_show_glia.TabIndex = 97;
            this.checkBox_show_glia.Text = "Glia";
            this.checkBox_show_glia.UseVisualStyleBackColor = true;
            // 
            // checkBox_show_rgc
            // 
            this.checkBox_show_rgc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_show_rgc.AutoSize = true;
            this.checkBox_show_rgc.Checked = true;
            this.checkBox_show_rgc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_show_rgc.Location = new System.Drawing.Point(372, 99);
            this.checkBox_show_rgc.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_show_rgc.Name = "checkBox_show_rgc";
            this.checkBox_show_rgc.Size = new System.Drawing.Size(115, 36);
            this.checkBox_show_rgc.TabIndex = 96;
            this.checkBox_show_rgc.Text = "RGC";
            this.checkBox_show_rgc.UseVisualStyleBackColor = true;
            // 
            // lbl_coronal_dist
            // 
            this.lbl_coronal_dist.AutoSize = true;
            this.lbl_coronal_dist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_coronal_dist.ForeColor = System.Drawing.Color.White;
            this.lbl_coronal_dist.Location = new System.Drawing.Point(292, 242);
            this.lbl_coronal_dist.Name = "lbl_coronal_dist";
            this.lbl_coronal_dist.Size = new System.Drawing.Size(35, 32);
            this.lbl_coronal_dist.TabIndex = 94;
            this.lbl_coronal_dist.Text = "D";
            // 
            // lbl_coronal_prox
            // 
            this.lbl_coronal_prox.AutoSize = true;
            this.lbl_coronal_prox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_coronal_prox.ForeColor = System.Drawing.Color.White;
            this.lbl_coronal_prox.Location = new System.Drawing.Point(3, 243);
            this.lbl_coronal_prox.Name = "lbl_coronal_prox";
            this.lbl_coronal_prox.Size = new System.Drawing.Size(34, 32);
            this.lbl_coronal_prox.TabIndex = 93;
            this.lbl_coronal_prox.Text = "P";
            // 
            // btn_record_avi
            // 
            this.btn_record_avi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_record_avi.Enabled = false;
            this.btn_record_avi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_record_avi.Location = new System.Drawing.Point(598, 91);
            this.btn_record_avi.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btn_record_avi.Name = "btn_record_avi";
            this.btn_record_avi.Size = new System.Drawing.Size(158, 43);
            this.btn_record_avi.TabIndex = 56;
            this.btn_record_avi.Text = "R&ecord";
            this.btn_record_avi.UseVisualStyleBackColor = false;
            // 
            // chk_show_stress
            // 
            this.chk_show_stress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_show_stress.AutoSize = true;
            this.chk_show_stress.Checked = true;
            this.chk_show_stress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_show_stress.Location = new System.Drawing.Point(103, 95);
            this.chk_show_stress.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_show_stress.Name = "chk_show_stress";
            this.chk_show_stress.Size = new System.Drawing.Size(90, 36);
            this.chk_show_stress.TabIndex = 55;
            this.chk_show_stress.Text = "{S}";
            this.chk_show_stress.UseVisualStyleBackColor = true;
            // 
            // chk_rgb_box
            // 
            this.chk_rgb_box.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_rgb_box.AutoSize = true;
            this.chk_rgb_box.Checked = true;
            this.chk_rgb_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_rgb_box.Location = new System.Drawing.Point(148, 154);
            this.chk_rgb_box.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_rgb_box.Name = "chk_rgb_box";
            this.chk_rgb_box.Size = new System.Drawing.Size(180, 36);
            this.chk_rgb_box.TabIndex = 53;
            this.chk_rgb_box.Text = "[ROS] HM";
            this.chk_rgb_box.UseVisualStyleBackColor = true;
            // 
            // sox_track_bar_coronal
            // 
            this.sox_track_bar_coronal.Location = new System.Drawing.Point(13, 204);
            this.sox_track_bar_coronal.Maximum = 100;
            this.sox_track_bar_coronal.Name = "sox_track_bar_coronal";
            this.sox_track_bar_coronal.Size = new System.Drawing.Size(308, 114);
            this.sox_track_bar_coronal.TabIndex = 52;
            // 
            // direction_group_box
            // 
            this.direction_group_box.Controls.Add(this.radio_button_sagittal);
            this.direction_group_box.Controls.Add(this.radio_button_transversal);
            this.direction_group_box.Controls.Add(this.radio_button_coronal);
            this.direction_group_box.Location = new System.Drawing.Point(359, 151);
            this.direction_group_box.Name = "direction_group_box";
            this.direction_group_box.Size = new System.Drawing.Size(225, 169);
            this.direction_group_box.TabIndex = 53;
            this.direction_group_box.TabStop = false;
            this.direction_group_box.Text = "Body Plane";
            // 
            // radio_button_sagittal
            // 
            this.radio_button_sagittal.AutoSize = true;
            this.radio_button_sagittal.ForeColor = System.Drawing.Color.Black;
            this.radio_button_sagittal.Location = new System.Drawing.Point(11, 121);
            this.radio_button_sagittal.Name = "radio_button_sagittal";
            this.radio_button_sagittal.Size = new System.Drawing.Size(149, 36);
            this.radio_button_sagittal.TabIndex = 54;
            this.radio_button_sagittal.Text = "Sagittal";
            this.radio_button_sagittal.UseVisualStyleBackColor = true;
            // 
            // radio_button_transversal
            // 
            this.radio_button_transversal.AutoSize = true;
            this.radio_button_transversal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radio_button_transversal.Location = new System.Drawing.Point(10, 80);
            this.radio_button_transversal.Name = "radio_button_transversal";
            this.radio_button_transversal.Size = new System.Drawing.Size(200, 36);
            this.radio_button_transversal.TabIndex = 53;
            this.radio_button_transversal.Text = "Transversal";
            this.radio_button_transversal.UseVisualStyleBackColor = true;
            // 
            // radio_button_coronal
            // 
            this.radio_button_coronal.AutoSize = true;
            this.radio_button_coronal.Checked = true;
            this.radio_button_coronal.ForeColor = System.Drawing.Color.Black;
            this.radio_button_coronal.Location = new System.Drawing.Point(10, 40);
            this.radio_button_coronal.Name = "radio_button_coronal";
            this.radio_button_coronal.Size = new System.Drawing.Size(152, 36);
            this.radio_button_coronal.TabIndex = 52;
            this.radio_button_coronal.TabStop = true;
            this.radio_button_coronal.Text = "Coronal";
            this.radio_button_coronal.UseVisualStyleBackColor = true;
            // 
            // lbl_topo_n
            // 
            this.lbl_topo_n.AutoSize = true;
            this.lbl_topo_n.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_n.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_n.Location = new System.Drawing.Point(1154, 927);
            this.lbl_topo_n.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_n.Name = "lbl_topo_n";
            this.lbl_topo_n.Size = new System.Drawing.Size(35, 32);
            this.lbl_topo_n.TabIndex = 58;
            this.lbl_topo_n.Text = "N";
            // 
            // sox_track_bar_sagittal
            // 
            this.sox_track_bar_sagittal.Enabled = false;
            this.sox_track_bar_sagittal.Location = new System.Drawing.Point(55, 352);
            this.sox_track_bar_sagittal.Maximum = 1024;
            this.sox_track_bar_sagittal.Name = "sox_track_bar_sagittal";
            this.sox_track_bar_sagittal.Size = new System.Drawing.Size(1105, 114);
            this.sox_track_bar_sagittal.TabIndex = 50;
            this.sox_track_bar_sagittal.Value = 512;
            this.sox_track_bar_sagittal.Visible = false;
            this.sox_track_bar_sagittal.Scroll += new System.EventHandler(this.sox_track_bar_yz_Scroll);
            // 
            // sox_track_bar_transversal
            // 
            this.sox_track_bar_transversal.Enabled = false;
            this.sox_track_bar_transversal.Location = new System.Drawing.Point(1247, 374);
            this.sox_track_bar_transversal.Maximum = 1024;
            this.sox_track_bar_transversal.Name = "sox_track_bar_transversal";
            this.sox_track_bar_transversal.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sox_track_bar_transversal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sox_track_bar_transversal.RightToLeftLayout = true;
            this.sox_track_bar_transversal.Size = new System.Drawing.Size(114, 1138);
            this.sox_track_bar_transversal.TabIndex = 51;
            this.sox_track_bar_transversal.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sox_track_bar_transversal.Value = 512;
            this.sox_track_bar_transversal.Visible = false;
            // 
            // samplingParameter
            // 
            this.samplingParameter.Controls.Add(this.lbl_bioIterTime);
            this.samplingParameter.Controls.Add(this.label51);
            this.samplingParameter.Controls.Add(this.txt_alpha);
            this.samplingParameter.Controls.Add(this.label50);
            this.samplingParameter.Controls.Add(this.lbl_delta_z);
            this.samplingParameter.Controls.Add(this.lbl_delta_xy);
            this.samplingParameter.Controls.Add(this.label47);
            this.samplingParameter.Controls.Add(this.label46);
            this.samplingParameter.Controls.Add(this.label9);
            this.samplingParameter.Controls.Add(this.txt_xy_resolution);
            this.samplingParameter.Controls.Add(this.lbl_image_size);
            this.samplingParameter.Controls.Add(this.label12);
            this.samplingParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.samplingParameter.Location = new System.Drawing.Point(2217, 27);
            this.samplingParameter.Name = "samplingParameter";
            this.samplingParameter.Size = new System.Drawing.Size(752, 223);
            this.samplingParameter.TabIndex = 57;
            this.samplingParameter.TabStop = false;
            this.samplingParameter.Text = "Mesh Parameters";
            // 
            // lbl_bioIterTime
            // 
            this.lbl_bioIterTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_bioIterTime.AutoSize = true;
            this.lbl_bioIterTime.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_bioIterTime.Location = new System.Drawing.Point(389, 133);
            this.lbl_bioIterTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_bioIterTime.Name = "lbl_bioIterTime";
            this.lbl_bioIterTime.Size = new System.Drawing.Size(93, 32);
            this.lbl_bioIterTime.TabIndex = 61;
            this.lbl_bioIterTime.Text = "5e-4 s";
            // 
            // label51
            // 
            this.label51.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.SystemColors.GrayText;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label51.Location = new System.Drawing.Point(27, 131);
            this.label51.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(247, 32);
            this.label51.TabIndex = 60;
            this.label51.Text = "Iteration BioTime";
            // 
            // txt_alpha
            // 
            this.txt_alpha.Location = new System.Drawing.Point(647, 44);
            this.txt_alpha.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_alpha.Name = "txt_alpha";
            this.txt_alpha.Size = new System.Drawing.Size(84, 38);
            this.txt_alpha.TabIndex = 59;
            this.txt_alpha.Text = "0.9";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.SystemColors.GrayText;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label50.Location = new System.Drawing.Point(541, 47);
            this.label50.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(94, 32);
            this.label50.TabIndex = 58;
            this.label50.Text = "Alpha";
            this.label50.Click += new System.EventHandler(this.label50_Click);
            // 
            // lbl_delta_z
            // 
            this.lbl_delta_z.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_delta_z.AutoSize = true;
            this.lbl_delta_z.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_delta_z.Location = new System.Drawing.Point(529, 91);
            this.lbl_delta_z.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_delta_z.Name = "lbl_delta_z";
            this.lbl_delta_z.Size = new System.Drawing.Size(70, 32);
            this.lbl_delta_z.TabIndex = 58;
            this.lbl_delta_z.Text = "1um";
            this.lbl_delta_z.Click += new System.EventHandler(this.lbl_delta_z_Click);
            // 
            // lbl_delta_xy
            // 
            this.lbl_delta_xy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_delta_xy.AutoSize = true;
            this.lbl_delta_xy.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_delta_xy.Location = new System.Drawing.Point(189, 89);
            this.lbl_delta_xy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_delta_xy.Name = "lbl_delta_xy";
            this.lbl_delta_xy.Size = new System.Drawing.Size(94, 32);
            this.lbl_delta_xy.TabIndex = 57;
            this.lbl_delta_xy.Text = "0.2um";
            this.lbl_delta_xy.Click += new System.EventHandler(this.lbl_delta_xy_Click);
            // 
            // label47
            // 
            this.label47.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.SystemColors.GrayText;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label47.Location = new System.Drawing.Point(385, 89);
            this.label47.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(136, 32);
            this.label47.TabIndex = 56;
            this.label47.Text = "Dz (1pix)";
            this.label47.Click += new System.EventHandler(this.label47_Click);
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.SystemColors.GrayText;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.White;
            this.label46.Location = new System.Drawing.Point(27, 89);
            this.label46.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(151, 32);
            this.label46.TabIndex = 55;
            this.label46.Text = "Dxy (1pix)";
            this.label46.Click += new System.EventHandler(this.label46_Click);
            // 
            // lbl_topo_t
            // 
            this.lbl_topo_t.AutoSize = true;
            this.lbl_topo_t.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_t.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_t.Location = new System.Drawing.Point(19, 927);
            this.lbl_topo_t.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_t.Name = "lbl_topo_t";
            this.lbl_topo_t.Size = new System.Drawing.Size(32, 32);
            this.lbl_topo_t.TabIndex = 57;
            this.lbl_topo_t.Text = "T";
            // 
            // lbl_topo_s
            // 
            this.lbl_topo_s.AutoSize = true;
            this.lbl_topo_s.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_s.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_s.Location = new System.Drawing.Point(587, 408);
            this.lbl_topo_s.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_s.Name = "lbl_topo_s";
            this.lbl_topo_s.Size = new System.Drawing.Size(34, 32);
            this.lbl_topo_s.TabIndex = 59;
            this.lbl_topo_s.Text = "S";
            // 
            // lbl_topo_i
            // 
            this.lbl_topo_i.AutoSize = true;
            this.lbl_topo_i.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_i.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_i.Location = new System.Drawing.Point(599, 1486);
            this.lbl_topo_i.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_i.Name = "lbl_topo_i";
            this.lbl_topo_i.Size = new System.Drawing.Size(22, 32);
            this.lbl_topo_i.TabIndex = 60;
            this.lbl_topo_i.Text = "I";
            // 
            // lbl_y_dim
            // 
            this.lbl_y_dim.AutoSize = true;
            this.lbl_y_dim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_y_dim.ForeColor = System.Drawing.Color.White;
            this.lbl_y_dim.Location = new System.Drawing.Point(1144, 1443);
            this.lbl_y_dim.Name = "lbl_y_dim";
            this.lbl_y_dim.Size = new System.Drawing.Size(77, 32);
            this.lbl_y_dim.TabIndex = 61;
            this.lbl_y_dim.Text = "0 um";
            // 
            // lbl_x_dim
            // 
            this.lbl_x_dim.AutoSize = true;
            this.lbl_x_dim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_x_dim.ForeColor = System.Drawing.Color.White;
            this.lbl_x_dim.Location = new System.Drawing.Point(1050, 1483);
            this.lbl_x_dim.Name = "lbl_x_dim";
            this.lbl_x_dim.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_x_dim.Size = new System.Drawing.Size(77, 32);
            this.lbl_x_dim.TabIndex = 62;
            this.lbl_x_dim.Text = "0 um";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(85, 1486);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(77, 32);
            this.label42.TabIndex = 63;
            this.label42.Text = "0 um";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(1144, 447);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 32);
            this.label43.TabIndex = 64;
            this.label43.Text = "0 um";
            // 
            // lbl_sample_type
            // 
            this.lbl_sample_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_sample_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sample_type.ForeColor = System.Drawing.Color.White;
            this.lbl_sample_type.Location = new System.Drawing.Point(519, 265);
            this.lbl_sample_type.Name = "lbl_sample_type";
            this.lbl_sample_type.Size = new System.Drawing.Size(208, 43);
            this.lbl_sample_type.TabIndex = 65;
            this.lbl_sample_type.Text = "Optic Nerve";
            this.lbl_sample_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // liveChart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.liveChart.ChartAreas.Add(chartArea1);
            this.liveChart.Location = new System.Drawing.Point(1312, 657);
            this.liveChart.Name = "liveChart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.liveChart.Series.Add(series1);
            this.liveChart.Size = new System.Drawing.Size(889, 798);
            this.liveChart.TabIndex = 66;
            this.liveChart.Text = "chart1";
            // 
            // checkDisplayLineHist
            // 
            this.checkDisplayLineHist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkDisplayLineHist.AutoSize = true;
            this.checkDisplayLineHist.Location = new System.Drawing.Point(1665, 1588);
            this.checkDisplayLineHist.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkDisplayLineHist.Name = "checkDisplayLineHist";
            this.checkDisplayLineHist.Size = new System.Drawing.Size(69, 36);
            this.checkDisplayLineHist.TabIndex = 67;
            this.checkDisplayLineHist.Text = "L";
            this.checkDisplayLineHist.UseVisualStyleBackColor = true;
            // 
            // checkPercentHist
            // 
            this.checkPercentHist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkPercentHist.AutoSize = true;
            this.checkPercentHist.Checked = true;
            this.checkPercentHist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPercentHist.Location = new System.Drawing.Point(198, 85);
            this.checkPercentHist.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkPercentHist.Name = "checkPercentHist";
            this.checkPercentHist.Size = new System.Drawing.Size(78, 36);
            this.checkPercentHist.TabIndex = 68;
            this.checkPercentHist.Text = "%";
            this.checkPercentHist.UseVisualStyleBackColor = true;
            // 
            // liveHistGroupBox
            // 
            this.liveHistGroupBox.Controls.Add(this.chk_chart_add_states);
            this.liveHistGroupBox.Controls.Add(this.checkBox_showSumOfHSD);
            this.liveHistGroupBox.Controls.Add(this.checkBox_chart_add_zones);
            this.liveHistGroupBox.Controls.Add(this.checkBox_visual_field);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ8);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ2);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ1);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ3);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ4);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ5);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ6);
            this.liveHistGroupBox.Controls.Add(this.checkBoxZ7);
            this.liveHistGroupBox.Controls.Add(this.checkBoxRatio);
            this.liveHistGroupBox.Controls.Add(this.checkPercentHist);
            this.liveHistGroupBox.Location = new System.Drawing.Point(1465, 1456);
            this.liveHistGroupBox.Name = "liveHistGroupBox";
            this.liveHistGroupBox.Size = new System.Drawing.Size(736, 130);
            this.liveHistGroupBox.TabIndex = 69;
            this.liveHistGroupBox.TabStop = false;
            this.liveHistGroupBox.Text = "Zones";
            // 
            // chk_chart_add_states
            // 
            this.chk_chart_add_states.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk_chart_add_states.AutoSize = true;
            this.chk_chart_add_states.Location = new System.Drawing.Point(639, 85);
            this.chk_chart_add_states.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chk_chart_add_states.Name = "chk_chart_add_states";
            this.chk_chart_add_states.Size = new System.Drawing.Size(87, 36);
            this.chk_chart_add_states.TabIndex = 83;
            this.chk_chart_add_states.Text = "+{}";
            this.chk_chart_add_states.UseVisualStyleBackColor = true;
            // 
            // checkBox_showSumOfHSD
            // 
            this.checkBox_showSumOfHSD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_showSumOfHSD.AutoSize = true;
            this.checkBox_showSumOfHSD.Location = new System.Drawing.Point(470, 84);
            this.checkBox_showSumOfHSD.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_showSumOfHSD.Name = "checkBox_showSumOfHSD";
            this.checkBox_showSumOfHSD.Size = new System.Drawing.Size(157, 36);
            this.checkBox_showSumOfHSD.TabIndex = 82;
            this.checkBox_showSumOfHSD.Text = "ShowAll";
            this.checkBox_showSumOfHSD.UseVisualStyleBackColor = true;
            // 
            // checkBox_chart_add_zones
            // 
            this.checkBox_chart_add_zones.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_add_zones.AutoSize = true;
            this.checkBox_chart_add_zones.Checked = true;
            this.checkBox_chart_add_zones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chart_add_zones.Location = new System.Drawing.Point(107, 84);
            this.checkBox_chart_add_zones.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_add_zones.Name = "checkBox_chart_add_zones";
            this.checkBox_chart_add_zones.Size = new System.Drawing.Size(86, 36);
            this.checkBox_chart_add_zones.TabIndex = 81;
            this.checkBox_chart_add_zones.Text = "+Z";
            this.checkBox_chart_add_zones.UseVisualStyleBackColor = true;
            // 
            // checkBox_visual_field
            // 
            this.checkBox_visual_field.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_visual_field.AutoSize = true;
            this.checkBox_visual_field.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_visual_field.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_visual_field.Location = new System.Drawing.Point(9, 81);
            this.checkBox_visual_field.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_visual_field.Name = "checkBox_visual_field";
            this.checkBox_visual_field.Size = new System.Drawing.Size(89, 36);
            this.checkBox_visual_field.TabIndex = 80;
            this.checkBox_visual_field.Text = "VF";
            this.checkBox_visual_field.UseVisualStyleBackColor = false;
            this.checkBox_visual_field.CheckedChanged += new System.EventHandler(this.checkBox_visual_field_CheckedChanged);
            // 
            // checkBoxZ8
            // 
            this.checkBoxZ8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ8.AutoSize = true;
            this.checkBoxZ8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ8.Checked = true;
            this.checkBoxZ8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ8.Location = new System.Drawing.Point(9, 37);
            this.checkBoxZ8.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ8.Name = "checkBoxZ8";
            this.checkBoxZ8.Size = new System.Drawing.Size(70, 36);
            this.checkBoxZ8.TabIndex = 73;
            this.checkBoxZ8.Text = "T";
            this.checkBoxZ8.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ2
            // 
            this.checkBoxZ2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ2.AutoSize = true;
            this.checkBoxZ2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ2.Checked = true;
            this.checkBoxZ2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ2.Location = new System.Drawing.Point(195, 37);
            this.checkBoxZ2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ2.Name = "checkBoxZ2";
            this.checkBoxZ2.Size = new System.Drawing.Size(72, 36);
            this.checkBoxZ2.TabIndex = 74;
            this.checkBoxZ2.Text = "S";
            this.checkBoxZ2.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ1
            // 
            this.checkBoxZ1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ1.AutoSize = true;
            this.checkBoxZ1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ1.Checked = true;
            this.checkBoxZ1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ1.Location = new System.Drawing.Point(105, 37);
            this.checkBoxZ1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ1.Name = "checkBoxZ1";
            this.checkBoxZ1.Size = new System.Drawing.Size(89, 36);
            this.checkBoxZ1.TabIndex = 72;
            this.checkBoxZ1.Text = "ST";
            this.checkBoxZ1.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ3
            // 
            this.checkBoxZ3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ3.AutoSize = true;
            this.checkBoxZ3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ3.Checked = true;
            this.checkBoxZ3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ3.Location = new System.Drawing.Point(279, 38);
            this.checkBoxZ3.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ3.Name = "checkBoxZ3";
            this.checkBoxZ3.Size = new System.Drawing.Size(92, 36);
            this.checkBoxZ3.TabIndex = 75;
            this.checkBoxZ3.Text = "SN";
            this.checkBoxZ3.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ4
            // 
            this.checkBoxZ4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ4.AutoSize = true;
            this.checkBoxZ4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ4.Checked = true;
            this.checkBoxZ4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ4.Location = new System.Drawing.Point(381, 38);
            this.checkBoxZ4.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ4.Name = "checkBoxZ4";
            this.checkBoxZ4.Size = new System.Drawing.Size(73, 36);
            this.checkBoxZ4.TabIndex = 76;
            this.checkBoxZ4.Text = "N";
            this.checkBoxZ4.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ5
            // 
            this.checkBoxZ5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ5.AutoSize = true;
            this.checkBoxZ5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ5.Checked = true;
            this.checkBoxZ5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ5.Location = new System.Drawing.Point(469, 37);
            this.checkBoxZ5.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ5.Name = "checkBoxZ5";
            this.checkBoxZ5.Size = new System.Drawing.Size(80, 36);
            this.checkBoxZ5.TabIndex = 77;
            this.checkBoxZ5.Text = "IN";
            this.checkBoxZ5.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ6
            // 
            this.checkBoxZ6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ6.AutoSize = true;
            this.checkBoxZ6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ6.Checked = true;
            this.checkBoxZ6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ6.Location = new System.Drawing.Point(561, 36);
            this.checkBoxZ6.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ6.Name = "checkBoxZ6";
            this.checkBoxZ6.Size = new System.Drawing.Size(60, 36);
            this.checkBoxZ6.TabIndex = 78;
            this.checkBoxZ6.Text = "I";
            this.checkBoxZ6.UseVisualStyleBackColor = false;
            // 
            // checkBoxZ7
            // 
            this.checkBoxZ7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxZ7.AutoSize = true;
            this.checkBoxZ7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxZ7.Checked = true;
            this.checkBoxZ7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxZ7.Location = new System.Drawing.Point(635, 35);
            this.checkBoxZ7.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxZ7.Name = "checkBoxZ7";
            this.checkBoxZ7.Size = new System.Drawing.Size(77, 36);
            this.checkBoxZ7.TabIndex = 79;
            this.checkBoxZ7.Text = "IT";
            this.checkBoxZ7.UseVisualStyleBackColor = false;
            // 
            // checkBoxRatio
            // 
            this.checkBoxRatio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxRatio.AutoSize = true;
            this.checkBoxRatio.Location = new System.Drawing.Point(280, 84);
            this.checkBoxRatio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxRatio.Name = "checkBoxRatio";
            this.checkBoxRatio.Size = new System.Drawing.Size(120, 36);
            this.checkBoxRatio.TabIndex = 71;
            this.checkBoxRatio.Text = "Ratio";
            this.checkBoxRatio.UseVisualStyleBackColor = true;
            // 
            // checkBox_chart_dead
            // 
            this.checkBox_chart_dead.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_dead.AutoSize = true;
            this.checkBox_chart_dead.Checked = true;
            this.checkBox_chart_dead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chart_dead.Location = new System.Drawing.Point(2109, 1592);
            this.checkBox_chart_dead.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_dead.Name = "checkBox_chart_dead";
            this.checkBox_chart_dead.Size = new System.Drawing.Size(91, 36);
            this.checkBox_chart_dead.TabIndex = 72;
            this.checkBox_chart_dead.Text = "{D}";
            this.checkBox_chart_dead.UseVisualStyleBackColor = true;
            // 
            // checkBox_chart_stress
            // 
            this.checkBox_chart_stress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_stress.AutoSize = true;
            this.checkBox_chart_stress.Checked = true;
            this.checkBox_chart_stress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chart_stress.Location = new System.Drawing.Point(2024, 1591);
            this.checkBox_chart_stress.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_stress.Name = "checkBox_chart_stress";
            this.checkBox_chart_stress.Size = new System.Drawing.Size(90, 36);
            this.checkBox_chart_stress.TabIndex = 71;
            this.checkBox_chart_stress.Text = "{S}";
            this.checkBox_chart_stress.UseVisualStyleBackColor = true;
            // 
            // checkBox_chart_healthy
            // 
            this.checkBox_chart_healthy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_healthy.AutoSize = true;
            this.checkBox_chart_healthy.Checked = true;
            this.checkBox_chart_healthy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chart_healthy.Location = new System.Drawing.Point(1936, 1591);
            this.checkBox_chart_healthy.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_healthy.Name = "checkBox_chart_healthy";
            this.checkBox_chart_healthy.Size = new System.Drawing.Size(91, 36);
            this.checkBox_chart_healthy.TabIndex = 70;
            this.checkBox_chart_healthy.Text = "{H}";
            this.checkBox_chart_healthy.UseVisualStyleBackColor = true;
            // 
            // checkBox_chart_legend
            // 
            this.checkBox_chart_legend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_legend.AutoSize = true;
            this.checkBox_chart_legend.Location = new System.Drawing.Point(1746, 1589);
            this.checkBox_chart_legend.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_legend.Name = "checkBox_chart_legend";
            this.checkBox_chart_legend.Size = new System.Drawing.Size(149, 36);
            this.checkBox_chart_legend.TabIndex = 70;
            this.checkBox_chart_legend.Text = "Legend";
            this.checkBox_chart_legend.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.4375F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.5625F));
            this.tableLayoutPanel13.Controls.Add(this.label37, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lbl_stress_percent, 1, 0);
            this.tableLayoutPanel13.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(1060, 51);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(320, 35);
            this.tableLayoutPanel13.TabIndex = 39;
            this.tableLayoutPanel13.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel13_Paint);
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label37.AutoSize = true;
            this.label37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label37.Location = new System.Drawing.Point(6, 1);
            this.label37.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(52, 32);
            this.label37.TabIndex = 49;
            this.label37.Text = "{S}";
            // 
            // lbl_stress_percent
            // 
            this.lbl_stress_percent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_stress_percent.AutoSize = true;
            this.lbl_stress_percent.Location = new System.Drawing.Point(97, 1);
            this.lbl_stress_percent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_stress_percent.Name = "lbl_stress_percent";
            this.lbl_stress_percent.Size = new System.Drawing.Size(63, 32);
            this.lbl_stress_percent.TabIndex = 43;
            this.lbl_stress_percent.Text = "0 %";
            // 
            // lbl_density
            // 
            this.lbl_density.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_density.AutoSize = true;
            this.lbl_density.Location = new System.Drawing.Point(144, 1);
            this.lbl_density.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_density.Name = "lbl_density";
            this.lbl_density.Size = new System.Drawing.Size(77, 32);
            this.lbl_density.TabIndex = 3;
            this.lbl_density.Text = "0 pM";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 1);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 32);
            this.label18.TabIndex = 7;
            this.label18.Text = "[ROS]";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.2591F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.7409F));
            this.tableLayoutPanel6.Controls.Add(this.lbl_tox, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel6.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(686, 51);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(362, 35);
            this.tableLayoutPanel6.TabIndex = 34;
            // 
            // lbl_tox
            // 
            this.lbl_tox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_tox.AutoSize = true;
            this.lbl_tox.Location = new System.Drawing.Point(140, 1);
            this.lbl_tox.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_tox.Name = "lbl_tox";
            this.lbl_tox.Size = new System.Drawing.Size(98, 32);
            this.lbl_tox.TabIndex = 1;
            this.lbl_tox.Text = "0 zmol";
            this.lbl_tox.Click += new System.EventHandler(this.lbl_tox_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "ROS";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.65116F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.34884F));
            this.tableLayoutPanel12.Controls.Add(this.lbl_healthy_percent, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.label22, 0, 0);
            this.tableLayoutPanel12.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(1060, 4);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(320, 35);
            this.tableLayoutPanel12.TabIndex = 38;
            // 
            // lbl_healthy_percent
            // 
            this.lbl_healthy_percent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_healthy_percent.AutoSize = true;
            this.lbl_healthy_percent.Location = new System.Drawing.Point(100, 1);
            this.lbl_healthy_percent.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_healthy_percent.Name = "lbl_healthy_percent";
            this.lbl_healthy_percent.Size = new System.Drawing.Size(88, 32);
            this.lbl_healthy_percent.TabIndex = 1;
            this.lbl_healthy_percent.Text = "100%";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 1);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 32);
            this.label22.TabIndex = 8;
            this.label22.Text = "{H}";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.88704F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.11295F));
            this.tableLayoutPanel7.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.lbl_itr_s, 1, 0);
            this.tableLayoutPanel7.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(6, 51);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(301, 35);
            this.tableLayoutPanel7.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Iter/s";
            // 
            // lbl_itr_s
            // 
            this.lbl_itr_s.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_itr_s.AutoSize = true;
            this.lbl_itr_s.Location = new System.Drawing.Point(107, 1);
            this.lbl_itr_s.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_itr_s.Name = "lbl_itr_s";
            this.lbl_itr_s.Size = new System.Drawing.Size(31, 32);
            this.lbl_itr_s.TabIndex = 15;
            this.lbl_itr_s.Text = "0";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.31325F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.68675F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_density, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel5.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(686, 4);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(362, 35);
            this.tableLayoutPanel5.TabIndex = 32;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.21927F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.78073F));
            this.tableLayoutPanel10.Controls.Add(this.lbl_itr, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel10.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(6, 4);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(301, 35);
            this.tableLayoutPanel10.TabIndex = 35;
            // 
            // lbl_itr
            // 
            this.lbl_itr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_itr.AutoSize = true;
            this.lbl_itr.Location = new System.Drawing.Point(108, 1);
            this.lbl_itr.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_itr.Name = "lbl_itr";
            this.lbl_itr.Size = new System.Drawing.Size(31, 32);
            this.lbl_itr.TabIndex = 3;
            this.lbl_itr.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Iter #";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.57703F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.42297F));
            this.tableLayoutPanel8.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.lbl_bio_time, 1, 0);
            this.tableLayoutPanel8.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(319, 4);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(355, 35);
            this.tableLayoutPanel8.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 1);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 32);
            this.label14.TabIndex = 16;
            this.label14.Text = "Bio Time";
            // 
            // lbl_bio_time
            // 
            this.lbl_bio_time.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_bio_time.AutoSize = true;
            this.lbl_bio_time.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_bio_time.Location = new System.Drawing.Point(157, 1);
            this.lbl_bio_time.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_bio_time.Name = "lbl_bio_time";
            this.lbl_bio_time.Size = new System.Drawing.Size(31, 32);
            this.lbl_bio_time.TabIndex = 15;
            this.lbl_bio_time.Text = "0";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.29692F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.70308F));
            this.tableLayoutPanel14.Controls.Add(this.lbl_sim_time, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel14.ForeColor = System.Drawing.Color.Maroon;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(319, 51);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(355, 35);
            this.tableLayoutPanel14.TabIndex = 40;
            // 
            // lbl_sim_time
            // 
            this.lbl_sim_time.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_sim_time.AutoSize = true;
            this.lbl_sim_time.Location = new System.Drawing.Point(156, 1);
            this.lbl_sim_time.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_sim_time.Name = "lbl_sim_time";
            this.lbl_sim_time.Size = new System.Drawing.Size(31, 32);
            this.lbl_sim_time.TabIndex = 3;
            this.lbl_sim_time.Text = "0";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 1);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(134, 32);
            this.label19.TabIndex = 7;
            this.label19.Text = "Sim Time";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel9.ColumnCount = 4;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.55747F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.50862F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01149F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.79357F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel14, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel12, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel6, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel13, 3, 1);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(32, 1540);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1386, 95);
            this.tableLayoutPanel9.TabIndex = 29;
            // 
            // checkBoxDiff
            // 
            this.checkBoxDiff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxDiff.AutoSize = true;
            this.checkBoxDiff.Checked = true;
            this.checkBoxDiff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDiff.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBoxDiff.Location = new System.Drawing.Point(1474, 1589);
            this.checkBoxDiff.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBoxDiff.Name = "checkBoxDiff";
            this.checkBoxDiff.Size = new System.Drawing.Size(96, 36);
            this.checkBoxDiff.TabIndex = 81;
            this.checkBoxDiff.Text = "Diff";
            this.checkBoxDiff.UseVisualStyleBackColor = true;
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.BackColor = System.Drawing.Color.Teal;
            this.labelZ1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ1.Location = new System.Drawing.Point(15, 661);
            this.labelZ1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(54, 32);
            this.labelZ1.TabIndex = 82;
            this.labelZ1.Text = "ML";
            this.labelZ1.Visible = false;
            this.labelZ1.Click += new System.EventHandler(this.label63_Click);
            // 
            // labelZ8
            // 
            this.labelZ8.AutoSize = true;
            this.labelZ8.BackColor = System.Drawing.Color.Teal;
            this.labelZ8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ8.Location = new System.Drawing.Point(13, 1183);
            this.labelZ8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ8.Name = "labelZ8";
            this.labelZ8.Size = new System.Drawing.Size(58, 32);
            this.labelZ8.TabIndex = 83;
            this.labelZ8.Text = "MH";
            this.labelZ8.Visible = false;
            // 
            // labelZ2
            // 
            this.labelZ2.AutoSize = true;
            this.labelZ2.BackColor = System.Drawing.Color.Teal;
            this.labelZ2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ2.Location = new System.Drawing.Point(345, 408);
            this.labelZ2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ2.Name = "labelZ2";
            this.labelZ2.Size = new System.Drawing.Size(42, 32);
            this.labelZ2.TabIndex = 84;
            this.labelZ2.Text = "IN";
            this.labelZ2.Visible = false;
            // 
            // labelZ3
            // 
            this.labelZ3.AutoSize = true;
            this.labelZ3.BackColor = System.Drawing.Color.Teal;
            this.labelZ3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ3.Location = new System.Drawing.Point(841, 408);
            this.labelZ3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ3.Name = "labelZ3";
            this.labelZ3.Size = new System.Drawing.Size(22, 32);
            this.labelZ3.TabIndex = 85;
            this.labelZ3.Text = "I";
            this.labelZ3.Visible = false;
            // 
            // labelZ4
            // 
            this.labelZ4.AutoSize = true;
            this.labelZ4.BackColor = System.Drawing.Color.Teal;
            this.labelZ4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ4.Location = new System.Drawing.Point(1154, 661);
            this.labelZ4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ4.Name = "labelZ4";
            this.labelZ4.Size = new System.Drawing.Size(48, 32);
            this.labelZ4.TabIndex = 85;
            this.labelZ4.Text = "TL";
            this.labelZ4.Visible = false;
            // 
            // labelZ5
            // 
            this.labelZ5.AutoSize = true;
            this.labelZ5.BackColor = System.Drawing.Color.Teal;
            this.labelZ5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ5.Location = new System.Drawing.Point(1154, 1183);
            this.labelZ5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ5.Name = "labelZ5";
            this.labelZ5.Size = new System.Drawing.Size(52, 32);
            this.labelZ5.TabIndex = 86;
            this.labelZ5.Text = "TH";
            this.labelZ5.Visible = false;
            // 
            // labelZ6
            // 
            this.labelZ6.AutoSize = true;
            this.labelZ6.BackColor = System.Drawing.Color.Teal;
            this.labelZ6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ6.Location = new System.Drawing.Point(829, 1486);
            this.labelZ6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ6.Name = "labelZ6";
            this.labelZ6.Size = new System.Drawing.Size(34, 32);
            this.labelZ6.TabIndex = 87;
            this.labelZ6.Text = "S";
            this.labelZ6.Visible = false;
            // 
            // labelZ7
            // 
            this.labelZ7.AutoSize = true;
            this.labelZ7.BackColor = System.Drawing.Color.Teal;
            this.labelZ7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelZ7.Location = new System.Drawing.Point(345, 1486);
            this.labelZ7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelZ7.Name = "labelZ7";
            this.labelZ7.Size = new System.Drawing.Size(54, 32);
            this.labelZ7.TabIndex = 88;
            this.labelZ7.Text = "SN";
            this.labelZ7.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_ros_v_h);
            this.groupBox2.Controls.Add(this.radioButtonLoss);
            this.groupBox2.Controls.Add(this.radioButtonROS);
            this.groupBox2.Controls.Add(this.radioButtonCount);
            this.groupBox2.Controls.Add(this.radioButtonHistogram);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(1317, 1456);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 223);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart";
            // 
            // radioButton_ros_v_h
            // 
            this.radioButton_ros_v_h.AutoSize = true;
            this.radioButton_ros_v_h.ForeColor = System.Drawing.Color.Black;
            this.radioButton_ros_v_h.Location = new System.Drawing.Point(13, 172);
            this.radioButton_ros_v_h.Name = "radioButton_ros_v_h";
            this.radioButton_ros_v_h.Size = new System.Drawing.Size(120, 36);
            this.radioButton_ros_v_h.TabIndex = 57;
            this.radioButton_ros_v_h.Text = "[R]v{}";
            this.radioButton_ros_v_h.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoss
            // 
            this.radioButtonLoss.AutoSize = true;
            this.radioButtonLoss.ForeColor = System.Drawing.Color.Black;
            this.radioButtonLoss.Location = new System.Drawing.Point(13, 67);
            this.radioButtonLoss.Name = "radioButtonLoss";
            this.radioButtonLoss.Size = new System.Drawing.Size(117, 36);
            this.radioButtonLoss.TabIndex = 56;
            this.radioButtonLoss.Text = "Zone";
            this.radioButtonLoss.UseVisualStyleBackColor = true;
            // 
            // radioButtonROS
            // 
            this.radioButtonROS.AutoSize = true;
            this.radioButtonROS.ForeColor = System.Drawing.Color.Black;
            this.radioButtonROS.Location = new System.Drawing.Point(13, 137);
            this.radioButtonROS.Name = "radioButtonROS";
            this.radioButtonROS.Size = new System.Drawing.Size(129, 36);
            this.radioButtonROS.TabIndex = 55;
            this.radioButtonROS.Text = "[ROS]";
            this.radioButtonROS.UseVisualStyleBackColor = true;
            // 
            // radioButtonCount
            // 
            this.radioButtonCount.AutoSize = true;
            this.radioButtonCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radioButtonCount.Location = new System.Drawing.Point(13, 102);
            this.radioButtonCount.Name = "radioButtonCount";
            this.radioButtonCount.Size = new System.Drawing.Size(141, 36);
            this.radioButtonCount.TabIndex = 53;
            this.radioButtonCount.Text = "State/s";
            this.radioButtonCount.UseVisualStyleBackColor = true;
            // 
            // radioButtonHistogram
            // 
            this.radioButtonHistogram.AutoSize = true;
            this.radioButtonHistogram.Checked = true;
            this.radioButtonHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHistogram.ForeColor = System.Drawing.Color.Black;
            this.radioButtonHistogram.Location = new System.Drawing.Point(14, 32);
            this.radioButtonHistogram.Name = "radioButtonHistogram";
            this.radioButtonHistogram.Size = new System.Drawing.Size(118, 36);
            this.radioButtonHistogram.TabIndex = 52;
            this.radioButtonHistogram.TabStop = true;
            this.radioButtonHistogram.Text = "Diam";
            this.radioButtonHistogram.UseVisualStyleBackColor = true;
            // 
            // labelChartY
            // 
            this.labelChartY.AutoSize = true;
            this.labelChartY.BackColor = System.Drawing.Color.White;
            this.labelChartY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelChartY.Location = new System.Drawing.Point(1311, 722);
            this.labelChartY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChartY.Name = "labelChartY";
            this.labelChartY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelChartY.Size = new System.Drawing.Size(72, 32);
            this.labelChartY.TabIndex = 89;
            this.labelChartY.Text = "(uM)";
            this.labelChartY.UseWaitCursor = true;
            this.labelChartY.Visible = false;
            this.labelChartY.Click += new System.EventHandler(this.aliveChartYLabel_Click);
            // 
            // labelChartX
            // 
            this.labelChartX.AutoSize = true;
            this.labelChartX.BackColor = System.Drawing.Color.White;
            this.labelChartX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelChartX.Location = new System.Drawing.Point(1660, 1414);
            this.labelChartX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelChartX.Name = "labelChartX";
            this.labelChartX.Size = new System.Drawing.Size(266, 32);
            this.labelChartX.TabIndex = 90;
            this.labelChartX.Text = "Axon Diameter (um)";
            this.labelChartX.Visible = false;
            // 
            // lbl_body_plane
            // 
            this.lbl_body_plane.BackColor = System.Drawing.Color.DarkRed;
            this.lbl_body_plane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_body_plane.ForeColor = System.Drawing.Color.White;
            this.lbl_body_plane.Location = new System.Drawing.Point(506, 311);
            this.lbl_body_plane.Name = "lbl_body_plane";
            this.lbl_body_plane.Size = new System.Drawing.Size(243, 43);
            this.lbl_body_plane.TabIndex = 92;
            this.lbl_body_plane.Text = "Coronal";
            this.lbl_body_plane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_transversal_superior
            // 
            this.lbl_transversal_superior.AutoSize = true;
            this.lbl_transversal_superior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_transversal_superior.ForeColor = System.Drawing.Color.White;
            this.lbl_transversal_superior.Location = new System.Drawing.Point(1238, 367);
            this.lbl_transversal_superior.Name = "lbl_transversal_superior";
            this.lbl_transversal_superior.Size = new System.Drawing.Size(34, 32);
            this.lbl_transversal_superior.TabIndex = 95;
            this.lbl_transversal_superior.Text = "S";
            this.lbl_transversal_superior.Visible = false;
            // 
            // lbl_transversal_inf
            // 
            this.lbl_transversal_inf.AutoSize = true;
            this.lbl_transversal_inf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_transversal_inf.ForeColor = System.Drawing.Color.White;
            this.lbl_transversal_inf.Location = new System.Drawing.Point(1242, 1484);
            this.lbl_transversal_inf.Name = "lbl_transversal_inf";
            this.lbl_transversal_inf.Size = new System.Drawing.Size(22, 32);
            this.lbl_transversal_inf.TabIndex = 96;
            this.lbl_transversal_inf.Text = "I";
            this.lbl_transversal_inf.Visible = false;
            // 
            // lbl_sagittal_temp
            // 
            this.lbl_sagittal_temp.AutoSize = true;
            this.lbl_sagittal_temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_sagittal_temp.ForeColor = System.Drawing.Color.White;
            this.lbl_sagittal_temp.Location = new System.Drawing.Point(47, 388);
            this.lbl_sagittal_temp.Name = "lbl_sagittal_temp";
            this.lbl_sagittal_temp.Size = new System.Drawing.Size(32, 32);
            this.lbl_sagittal_temp.TabIndex = 95;
            this.lbl_sagittal_temp.Text = "T";
            this.lbl_sagittal_temp.Visible = false;
            // 
            // lbl_sagittal_nasal
            // 
            this.lbl_sagittal_nasal.AutoSize = true;
            this.lbl_sagittal_nasal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_sagittal_nasal.ForeColor = System.Drawing.Color.White;
            this.lbl_sagittal_nasal.Location = new System.Drawing.Point(1138, 388);
            this.lbl_sagittal_nasal.Name = "lbl_sagittal_nasal";
            this.lbl_sagittal_nasal.Size = new System.Drawing.Size(35, 32);
            this.lbl_sagittal_nasal.TabIndex = 97;
            this.lbl_sagittal_nasal.Text = "N";
            this.lbl_sagittal_nasal.Visible = false;
            // 
            // lbl_topo_it
            // 
            this.lbl_topo_it.AutoSize = true;
            this.lbl_topo_it.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_it.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_it.Location = new System.Drawing.Point(166, 1358);
            this.lbl_topo_it.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_it.Name = "lbl_topo_it";
            this.lbl_topo_it.Size = new System.Drawing.Size(39, 32);
            this.lbl_topo_it.TabIndex = 98;
            this.lbl_topo_it.Text = "IT";
            // 
            // lbl_topo_in
            // 
            this.lbl_topo_in.AutoSize = true;
            this.lbl_topo_in.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_in.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_in.Location = new System.Drawing.Point(1002, 1358);
            this.lbl_topo_in.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_in.Name = "lbl_topo_in";
            this.lbl_topo_in.Size = new System.Drawing.Size(42, 32);
            this.lbl_topo_in.TabIndex = 99;
            this.lbl_topo_in.Text = "IN";
            // 
            // lbl_topo_st
            // 
            this.lbl_topo_st.AutoSize = true;
            this.lbl_topo_st.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_st.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_st.Location = new System.Drawing.Point(166, 534);
            this.lbl_topo_st.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_st.Name = "lbl_topo_st";
            this.lbl_topo_st.Size = new System.Drawing.Size(51, 32);
            this.lbl_topo_st.TabIndex = 100;
            this.lbl_topo_st.Text = "ST";
            // 
            // lbl_topo_sn
            // 
            this.lbl_topo_sn.AutoSize = true;
            this.lbl_topo_sn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_topo_sn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_topo_sn.Location = new System.Drawing.Point(1002, 536);
            this.lbl_topo_sn.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_topo_sn.Name = "lbl_topo_sn";
            this.lbl_topo_sn.Size = new System.Drawing.Size(54, 32);
            this.lbl_topo_sn.TabIndex = 101;
            this.lbl_topo_sn.Text = "SN";
            // 
            // checkBox_chart_3d
            // 
            this.checkBox_chart_3d.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_chart_3d.AutoSize = true;
            this.checkBox_chart_3d.Location = new System.Drawing.Point(1573, 1589);
            this.checkBox_chart_3d.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.checkBox_chart_3d.Name = "checkBox_chart_3d";
            this.checkBox_chart_3d.Size = new System.Drawing.Size(89, 36);
            this.checkBox_chart_3d.TabIndex = 102;
            this.checkBox_chart_3d.Text = "3D";
            this.checkBox_chart_3d.UseVisualStyleBackColor = true;
            // 
            // groupBoxCellStateTransitions
            // 
            this.groupBoxCellStateTransitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCellStateTransitions.Controls.Add(this.txt_cell_ca2cd);
            this.groupBoxCellStateTransitions.Controls.Add(this.label44);
            this.groupBoxCellStateTransitions.Controls.Add(this.label80);
            this.groupBoxCellStateTransitions.Controls.Add(this.label81);
            this.groupBoxCellStateTransitions.Controls.Add(this.label35);
            this.groupBoxCellStateTransitions.Controls.Add(this.label6);
            this.groupBoxCellStateTransitions.Controls.Add(this.txt_cell_ch2ca);
            this.groupBoxCellStateTransitions.Controls.Add(this.chk_length_adj);
            this.groupBoxCellStateTransitions.Location = new System.Drawing.Point(1549, 219);
            this.groupBoxCellStateTransitions.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxCellStateTransitions.Name = "groupBoxCellStateTransitions";
            this.groupBoxCellStateTransitions.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBoxCellStateTransitions.Size = new System.Drawing.Size(652, 135);
            this.groupBoxCellStateTransitions.TabIndex = 72;
            this.groupBoxCellStateTransitions.TabStop = false;
            this.groupBoxCellStateTransitions.Text = "Cell Parameters {rgc}";
            // 
            // txt_cell_ca2cd
            // 
            this.txt_cell_ca2cd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_cell_ca2cd.Enabled = false;
            this.txt_cell_ca2cd.Location = new System.Drawing.Point(242, 90);
            this.txt_cell_ca2cd.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txt_cell_ca2cd.Name = "txt_cell_ca2cd";
            this.txt_cell_ca2cd.Size = new System.Drawing.Size(135, 38);
            this.txt_cell_ca2cd.TabIndex = 78;
            this.txt_cell_ca2cd.Text = "0";
            this.txt_cell_ca2cd.Visible = false;
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 90);
            this.label44.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(194, 32);
            this.label44.TabIndex = 77;
            this.label44.Text = "{CA}->{CD} >=";
            this.label44.Visible = false;
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(389, -65);
            this.label80.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(77, 32);
            this.label80.TabIndex = 66;
            this.label80.Text = "uMol";
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(389, -114);
            this.label81.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(77, 32);
            this.label81.TabIndex = 65;
            this.label81.Text = "uMol";
            // 
            // picB
            // 
            this.picB.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.picB.Location = new System.Drawing.Point(91, 443);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(1044, 1037);
            this.picB.TabIndex = 56;
            this.picB.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2974, 1691);
            this.Controls.Add(this.groupBoxCellStateTransitions);
            this.Controls.Add(this.checkBox_chart_3d);
            this.Controls.Add(this.lbl_topo_in);
            this.Controls.Add(this.lbl_topo_sn);
            this.Controls.Add(this.lbl_topo_st);
            this.Controls.Add(this.lbl_topo_it);
            this.Controls.Add(this.lbl_sagittal_nasal);
            this.Controls.Add(this.lbl_sagittal_temp);
            this.Controls.Add(this.lbl_transversal_inf);
            this.Controls.Add(this.lbl_transversal_superior);
            this.Controls.Add(this.lbl_display_view);
            this.Controls.Add(this.lbl_body_plane);
            this.Controls.Add(this.checkBox_chart_dead);
            this.Controls.Add(this.checkDisplayLineHist);
            this.Controls.Add(this.labelChartX);
            this.Controls.Add(this.checkBox_chart_stress);
            this.Controls.Add(this.checkBox_chart_legend);
            this.Controls.Add(this.labelChartY);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelZ3);
            this.Controls.Add(this.labelZ7);
            this.Controls.Add(this.labelZ6);
            this.Controls.Add(this.labelZ5);
            this.Controls.Add(this.labelZ4);
            this.Controls.Add(this.groupBoxReactionRates);
            this.Controls.Add(this.labelZ2);
            this.Controls.Add(this.checkBox_chart_healthy);
            this.Controls.Add(this.btn_save_setts);
            this.Controls.Add(this.btn_load_setts);
            this.Controls.Add(this.labelZ8);
            this.Controls.Add(this.labelZ1);
            this.Controls.Add(this.checkBoxDiff);
            this.Controls.Add(this.liveHistGroupBox);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.liveChart);
            this.Controls.Add(this.lbl_sample_type);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.lbl_x_dim);
            this.Controls.Add(this.lbl_y_dim);
            this.Controls.Add(this.lbl_topo_n);
            this.Controls.Add(this.lbl_topo_i);
            this.Controls.Add(this.lbl_topo_s);
            this.Controls.Add(this.sox_track_bar_transversal);
            this.Controls.Add(this.lbl_topo_t);
            this.Controls.Add(this.groupBoxInitialStates);
            this.Controls.Add(this.groupBoxDiffusion);
            this.Controls.Add(this.samplingParameter);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.sox_track_bar_sagittal);
            this.Controls.Add(this.groupBoxSegmentStateTransitions);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.simGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "Main_Form";
            this.Text = "Optic Nerve ROS 3D Simulator v2.7 (C) McGill University";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxInitialStates.ResumeLayout(false);
            this.groupBoxInitialStates.PerformLayout();
            this.groupBoxReactionRates.ResumeLayout(false);
            this.groupBoxReactionRates.PerformLayout();
            this.groupDDtox.ResumeLayout(false);
            this.groupDDtox.PerformLayout();
            this.groupBoxDiffusion.ResumeLayout(false);
            this.groupBoxDiffusion.PerformLayout();
            this.simGroupBox.ResumeLayout(false);
            this.simGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxSegmentStateTransitions.ResumeLayout(false);
            this.groupBoxSegmentStateTransitions.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_coronal)).EndInit();
            this.direction_group_box.ResumeLayout(false);
            this.direction_group_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_sagittal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sox_track_bar_transversal)).EndInit();
            this.samplingParameter.ResumeLayout(false);
            this.samplingParameter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveChart)).EndInit();
            this.liveHistGroupBox.ResumeLayout(false);
            this.liveHistGroupBox.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxCellStateTransitions.ResumeLayout(false);
            this.groupBoxCellStateTransitions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBoxWithInterpolationMode picB;

        private System.Windows.Forms.Button btn_start;
        private Button btn_save_model;
        private Button btn_load_model;
        private Button btn_generate_model;
        private Label label4;
        private Label lbl_num_axons;
        private GroupBox groupBox1;
        private GroupBox groupBoxInitialStates;
        private GroupBox simGroupBox;
        private Button btn_load_setts;
        private Button btn_save_setts;
        private Button btn_preprocess;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statlbl;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel statlbl_sweep;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Label label12;
        private Label lbl_image_size;
        private GroupBox groupBoxSegmentStateTransitions;
        private TextBox txt_img_size;
        private Label label13;
        private Button btn_img_snapshot;
        private TextBox txt_stop_itr;
        private Label label16;
        private GroupBox groupBoxReactionRates;
        private Label label27;
        private TextBox txt_sod_detox;
        private TextBox txt_xy_resolution;
        private Label label9;
        private GroupBox groupBoxDiffusion;
        private TextBox txt_diff_live_xy;
        private TextBox txt_membrane_coeff_healthy;
        private Label label8;
        private TextBox txt_diff_dead_xy;
        private Label label25;
        private Label label26;
        private Label label34;
        private Label label36;
        private TextBox txt_h2s_tox_thr;
        private TextBox txt_healthy_tox_prod;
        private Label label29;
        private TextBox txt_stop_time;
        private Label label5;
        private Label lbl_nerve_size;
        private GroupBox groupBox8;
        private Button btn_clr;
        private TextBox txt_status;
        private TextBox txt_nerve_scale;
        private Label label11;
        private TextBox txt_stress_tox_prod;
        private Label label15;
        private TextBox txt_new_model_params;
        private ToolStripProgressBar toolStripProgressBar1;
        private Label label23;
        private TextBox txt_3d_sample_length_um;
        private Button btn_save_state_as_list;
        private Button btn_reset;
        private CheckBox chk_show_tox;
        private Label label17;
        private CheckBox chk_show_live_axons;
        private TextBox txt_rec_interval;
        private Label lbl_display_view;
        private CheckBox chk_show_dead_axons;
        private GroupBox groupBox4;
        private TrackBar sox_track_bar_coronal;
        private TrackBar sox_track_bar_sagittal;
        private TrackBar sox_track_bar_transversal;
        private RadioButton radio_button_coronal;
        private GroupBox direction_group_box;
        private RadioButton radio_button_sagittal;
        private RadioButton radio_button_transversal;
        private TextBox txt_diff_glia_xy;
        private TextBox txt_diff_live_z;
        private TextBox txt_diff_glia_z;
        private TextBox txt_diff_dead_z;
        private CheckBox chk_use_3d_pattern;
        private ToolTip tox_image_value;
        private Label label30;
        private Label label33;
        private Label label31;
        private CheckBox chk_rgb_box;
        private Label label45;
        private GroupBox samplingParameter;
        private TextBox txt_3d_ros_um;
        private Label label38;
        private TextBox txt_3d_sod_um;
        private Label label39;
        private Label label46;
        private Label lbl_delta_z;
        private Label lbl_delta_xy;
        private Label label47;
        private Label label48;
        private Label label7;
        private Label label49;
        private Label label32;
        private Label label50;
        private Label lbl_bioIterTime;
        private Label label51;
        private TextBox txt_alpha;
        private Label label53;
        private TextBox txt_mito_percent;
        private CheckBox chk_fire_factor;
        private Label label54;
        private TextBox txt_mito_location;
        private TextBox txt_initial_ros;
        private Label label41;
        private TextBox txt_s2d_timer;
        private Label label55;
        private CheckBox chk_show_stress;
        private CheckBox chk_retina;
        private TextBox txt_glia_percent;
        private Label label58;
        private Label label59;
        private TextBox txt_sod_percent;
        private Button btn_record_avi;
        private CheckBox chk_length_adj;
        private Label lbl_topo_n;
        private Label lbl_topo_t;
        private Label lbl_topo_s;
        private Label lbl_topo_i;
        private TextBox txt_3d_membrane;
        private Label label57;
        private TextBox txt_stress_z_position;
        private Label label60;
        private TextBox txt_membrane_coeff_dead;
        private Label label62;
        private Label label61;
        private Label label40;
        private Label lbl_y_dim;
        private Label lbl_x_dim;
        private Label label42;
        private Label label43;
        private Label lbl_sample_type;
        private System.Windows.Forms.DataVisualization.Charting.Chart liveChart;
        private CheckBox checkDisplayLineHist;
        private CheckBox checkPercentHist;
        private GroupBox liveHistGroupBox;
        private CheckBox checkBox_chart_dead;
        private CheckBox checkBox_chart_stress;
        private CheckBox checkBox_chart_healthy;
        private CheckBox checkBox_chart_legend;
        private CheckBox checkBox_Back_Image;
        private CheckBox checkBoxRatio;
        private CheckBox checkBoxZ1;
        private CheckBox checkBoxZ8;
        private CheckBox checkBoxZ2;
        private CheckBox checkBoxZ3;
        private CheckBox checkBoxZ4;
        private CheckBox checkBoxZ5;
        private CheckBox checkBoxZ6;
        private CheckBox checkBoxZ7;
        private TableLayoutPanel tableLayoutPanel13;
        private Label lbl_density;
        private Label label18;
        private TableLayoutPanel tableLayoutPanel6;
        private Label lbl_tox;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel12;
        private Label lbl_healthy_percent;
        private Label label22;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label3;
        private Label lbl_itr_s;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label37;
        private Label lbl_stress_percent;
        private TableLayoutPanel tableLayoutPanel10;
        private Label lbl_itr;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label14;
        private Label lbl_bio_time;
        private TableLayoutPanel tableLayoutPanel14;
        private Label lbl_sim_time;
        private Label label19;
        private TableLayoutPanel tableLayoutPanel9;
        private CheckBox checkBoxDiff;
        private Label labelZ1;
        private Label labelZ3;
        private Label labelZ8;
        private Label labelZ2;
        private Label labelZ4;
        private Label labelZ5;
        private Label labelZ6;
        private Label labelZ7;
        private GroupBox groupBox2;
        private RadioButton radioButtonROS;
        private RadioButton radioButtonCount;
        private RadioButton radioButtonHistogram;
        private Label label64;
        private Label label21;
        private Label label20;
        private Label label63;
        private Label label56;
        private Label label67;
        private Label label66;
        private Label label73;
        private Label label74;
        private TextBox txt_s2d_tox_thr;
        private Label label71;
        private Label label72;
        private TextBox txt_s2h_tox_thr;
        private Label label75;
        private Label label76;
        private TextBox txt_membrane_coeff_stress;
        private Label label78;
        private Label label77;
        private GroupBox groupDDtox;
        private RadioButton rbDDTox0;
        private RadioButton rbDDTox3;
        private RadioButton rbDDTox1;
        private Label labelChartY;
        private Label labelChartX;
        private Label label10;
        private Label lbl_body_plane;
        private Label lbl_coronal_dist;
        private Label lbl_coronal_prox;
        private Label lbl_transversal_superior;
        private Label lbl_transversal_inf;
        private Label lbl_sagittal_temp;
        private Label lbl_sagittal_nasal;
        private Label lbl_topo_it;
        private Label lbl_topo_in;
        private Label lbl_topo_st;
        private Label lbl_topo_sn;
        private CheckBox checkBox_visual_field;
        private CheckBox checkBox_chart_3d;
        private CheckBox checkBox_chart_add_zones;
        private CheckBox checkBox_showSumOfHSD;
        private Label label28;
        private Label label35;
        private TextBox txt_cell_ch2ca;
        private Label label6;
        private Label label52;
        private Label label24;
        private CheckBox checkBox_show_glia;
        private CheckBox checkBox_show_rgc;
        private RadioButton radioButtonLoss;
        private CheckBox chk_timer_reset;
        private GroupBox groupBoxCellStateTransitions;
        private Label label80;
        private Label label81;
        private TextBox txt_cell_ca2cd;
        private Label label44;
        private RadioButton radioButton_ros_v_h;
        private CheckBox checkBox_gen_model;
        private Label label70;
        private TextBox textBox_no_iterations;
        private CheckBox chk_chart_add_states;
        private Label label65;
        private TextBox txt_other_initial;
        private Label label69;
        private Label label68;
        private Label label_test_no;
        private CheckBox noMitoScaleCheckBox;
        private Label label82;
        private TextBox txt_prod_sod_timechange;
        private Label label79;
        private TextBox txt_tissue_permeability;
        private Label label83;
    }
}

