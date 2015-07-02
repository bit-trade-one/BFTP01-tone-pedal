namespace HID_PnP_Demo
{
    partial class Form1
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ReadWriteThread = new System.ComponentModel.BackgroundWorker();
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.txtbx_KB_Val_01 = new System.Windows.Forms.TextBox();
            this.StatusBox_lbl = new System.Windows.Forms.Label();
            this.lbl_FW_Version = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colum_lbl = new System.Windows.Forms.Label();
            this.debug01_lbl = new System.Windows.Forms.Label();
            this.debug02_lbl = new System.Windows.Forms.Label();
            this.debug03_lbl = new System.Windows.Forms.Label();
            this.txtbx_KB_Val_02 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_03 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_06 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_05 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_04 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_09 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_08 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_07 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_12 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_11 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_10 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_15 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_14 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_13 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_18 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_17 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_16 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_21 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_20 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_19 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_24 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_23 = new System.Windows.Forms.TextBox();
            this.txtbx_KB_Val_22 = new System.Windows.Forms.TextBox();
            this.cmbbx_Set_01 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_02 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_03 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_04 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_05 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_06 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_07 = new System.Windows.Forms.ComboBox();
            this.cmbbx_Set_08 = new System.Windows.Forms.ComboBox();
            this.nud_Set_Val_01 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_02 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_03 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_04 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_05 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_06 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_07 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_08 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_10 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_09 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_12 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_11 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_14 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_13 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_16 = new System.Windows.Forms.NumericUpDown();
            this.nud_Set_Val_15 = new System.Windows.Forms.NumericUpDown();
            this.lbl_title_01 = new System.Windows.Forms.Label();
            this.lbl_title_02 = new System.Windows.Forms.Label();
            this.lbl_title_03 = new System.Windows.Forms.Label();
            this.lbl_title_04 = new System.Windows.Forms.Label();
            this.lbl_title_05 = new System.Windows.Forms.Label();
            this.lbl_title_06 = new System.Windows.Forms.Label();
            this.lbl_title_07 = new System.Windows.Forms.Label();
            this.lbl_title_08 = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.ilist_loadsave_btn = new System.Windows.Forms.ImageList(this.components);
            this.btn_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_reset = new System.Windows.Forms.Button();
            this.ilist_reset_btn = new System.Windows.Forms.ImageList(this.components);
            this.btn_soft_reset = new System.Windows.Forms.Button();
            this.btn_key_clr_01 = new System.Windows.Forms.Button();
            this.btn_key_clr_02 = new System.Windows.Forms.Button();
            this.btn_key_clr_03 = new System.Windows.Forms.Button();
            this.btn_key_clr_04 = new System.Windows.Forms.Button();
            this.btn_key_clr_05 = new System.Windows.Forms.Button();
            this.btn_key_clr_06 = new System.Windows.Forms.Button();
            this.btn_key_clr_07 = new System.Windows.Forms.Button();
            this.btn_key_clr_08 = new System.Windows.Forms.Button();
            this.chkbx_key_modifier_01 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_02 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_03 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_04 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_05 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_06 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_12 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_11 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_10 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_09 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_08 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_07 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_18 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_17 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_16 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_15 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_14 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_13 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_24 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_23 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_22 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_21 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_20 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_19 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_30 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_29 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_28 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_27 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_26 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_25 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_36 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_35 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_34 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_33 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_32 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_31 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_42 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_41 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_40 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_39 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_38 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_37 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_48 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_47 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_46 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_45 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_44 = new System.Windows.Forms.CheckBox();
            this.chkbx_key_modifier_43 = new System.Windows.Forms.CheckBox();
            this.btn_eeprom_init = new System.Windows.Forms.Button();
            this.Status_NC_pb = new System.Windows.Forms.PictureBox();
            this.Status_C_pb = new System.Windows.Forms.PictureBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.ilist_set_btn = new System.Windows.Forms.ImageList(this.components);
            this.BackGround_pb = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_NC_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_C_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadWriteThread
            // 
            this.ReadWriteThread.WorkerReportsProgress = true;
            this.ReadWriteThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReadWriteThread_DoWork);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 6;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // txtbx_KB_Val_01
            // 
            this.txtbx_KB_Val_01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_01.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_01.Location = new System.Drawing.Point(104, 121);
            this.txtbx_KB_Val_01.Name = "txtbx_KB_Val_01";
            this.txtbx_KB_Val_01.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_01.TabIndex = 130;
            this.txtbx_KB_Val_01.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_01.Visible = false;
            this.txtbx_KB_Val_01.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_01.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_01.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // StatusBox_lbl
            // 
            this.StatusBox_lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatusBox_lbl.AutoSize = true;
            this.StatusBox_lbl.BackColor = System.Drawing.Color.Transparent;
            this.StatusBox_lbl.ForeColor = System.Drawing.Color.White;
            this.StatusBox_lbl.Location = new System.Drawing.Point(756, 472);
            this.StatusBox_lbl.Name = "StatusBox_lbl";
            this.StatusBox_lbl.Size = new System.Drawing.Size(79, 12);
            this.StatusBox_lbl.TabIndex = 92;
            this.StatusBox_lbl.Text = "ÉfÉoÉCÉXñ¢ê⁄ë±";
            // 
            // lbl_FW_Version
            // 
            this.lbl_FW_Version.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_FW_Version.BackColor = System.Drawing.Color.Transparent;
            this.lbl_FW_Version.ForeColor = System.Drawing.Color.White;
            this.lbl_FW_Version.Location = new System.Drawing.Point(499, 472);
            this.lbl_FW_Version.Name = "lbl_FW_Version";
            this.lbl_FW_Version.Size = new System.Drawing.Size(188, 12);
            this.lbl_FW_Version.TabIndex = 91;
            this.lbl_FW_Version.Text = "FW Version";
            this.lbl_FW_Version.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colum_lbl);
            this.groupBox1.Controls.Add(this.debug01_lbl);
            this.groupBox1.Controls.Add(this.debug02_lbl);
            this.groupBox1.Controls.Add(this.debug03_lbl);
            this.groupBox1.Location = new System.Drawing.Point(10, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 146);
            this.groupBox1.TabIndex = 990;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // colum_lbl
            // 
            this.colum_lbl.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colum_lbl.Location = new System.Drawing.Point(6, 15);
            this.colum_lbl.Name = "colum_lbl";
            this.colum_lbl.Size = new System.Drawing.Size(848, 24);
            this.colum_lbl.TabIndex = 991;
            this.colum_lbl.Text = "label1";
            // 
            // debug01_lbl
            // 
            this.debug01_lbl.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.debug01_lbl.Location = new System.Drawing.Point(6, 48);
            this.debug01_lbl.Name = "debug01_lbl";
            this.debug01_lbl.Size = new System.Drawing.Size(848, 24);
            this.debug01_lbl.TabIndex = 992;
            this.debug01_lbl.Text = "label1";
            // 
            // debug02_lbl
            // 
            this.debug02_lbl.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.debug02_lbl.Location = new System.Drawing.Point(6, 81);
            this.debug02_lbl.Name = "debug02_lbl";
            this.debug02_lbl.Size = new System.Drawing.Size(848, 24);
            this.debug02_lbl.TabIndex = 993;
            this.debug02_lbl.Text = "label1";
            // 
            // debug03_lbl
            // 
            this.debug03_lbl.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.debug03_lbl.Location = new System.Drawing.Point(6, 114);
            this.debug03_lbl.Name = "debug03_lbl";
            this.debug03_lbl.Size = new System.Drawing.Size(848, 24);
            this.debug03_lbl.TabIndex = 994;
            this.debug03_lbl.Text = "label1";
            // 
            // txtbx_KB_Val_02
            // 
            this.txtbx_KB_Val_02.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_02.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_02.Location = new System.Drawing.Point(165, 121);
            this.txtbx_KB_Val_02.Name = "txtbx_KB_Val_02";
            this.txtbx_KB_Val_02.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_02.TabIndex = 131;
            this.txtbx_KB_Val_02.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_02.Visible = false;
            this.txtbx_KB_Val_02.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_02.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_02.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_03
            // 
            this.txtbx_KB_Val_03.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_03.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_03.Location = new System.Drawing.Point(226, 121);
            this.txtbx_KB_Val_03.Name = "txtbx_KB_Val_03";
            this.txtbx_KB_Val_03.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_03.TabIndex = 132;
            this.txtbx_KB_Val_03.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_03.Visible = false;
            this.txtbx_KB_Val_03.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_03.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_03.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_06
            // 
            this.txtbx_KB_Val_06.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_06.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_06.Location = new System.Drawing.Point(226, 211);
            this.txtbx_KB_Val_06.Name = "txtbx_KB_Val_06";
            this.txtbx_KB_Val_06.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_06.TabIndex = 232;
            this.txtbx_KB_Val_06.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_06.Visible = false;
            this.txtbx_KB_Val_06.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_06.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_06.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_05
            // 
            this.txtbx_KB_Val_05.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_05.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_05.Location = new System.Drawing.Point(165, 211);
            this.txtbx_KB_Val_05.Name = "txtbx_KB_Val_05";
            this.txtbx_KB_Val_05.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_05.TabIndex = 231;
            this.txtbx_KB_Val_05.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_05.Visible = false;
            this.txtbx_KB_Val_05.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_05.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_05.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_04
            // 
            this.txtbx_KB_Val_04.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_04.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_04.Location = new System.Drawing.Point(104, 211);
            this.txtbx_KB_Val_04.Name = "txtbx_KB_Val_04";
            this.txtbx_KB_Val_04.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_04.TabIndex = 230;
            this.txtbx_KB_Val_04.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_04.Visible = false;
            this.txtbx_KB_Val_04.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_04.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_04.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_09
            // 
            this.txtbx_KB_Val_09.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_09.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_09.Location = new System.Drawing.Point(226, 301);
            this.txtbx_KB_Val_09.Name = "txtbx_KB_Val_09";
            this.txtbx_KB_Val_09.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_09.TabIndex = 332;
            this.txtbx_KB_Val_09.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_09.Visible = false;
            this.txtbx_KB_Val_09.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_09.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_09.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_08
            // 
            this.txtbx_KB_Val_08.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_08.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_08.Location = new System.Drawing.Point(165, 301);
            this.txtbx_KB_Val_08.Name = "txtbx_KB_Val_08";
            this.txtbx_KB_Val_08.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_08.TabIndex = 331;
            this.txtbx_KB_Val_08.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_08.Visible = false;
            this.txtbx_KB_Val_08.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_08.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_08.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_07
            // 
            this.txtbx_KB_Val_07.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_07.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_07.Location = new System.Drawing.Point(104, 301);
            this.txtbx_KB_Val_07.Name = "txtbx_KB_Val_07";
            this.txtbx_KB_Val_07.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_07.TabIndex = 330;
            this.txtbx_KB_Val_07.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_07.Visible = false;
            this.txtbx_KB_Val_07.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_07.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_07.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_12
            // 
            this.txtbx_KB_Val_12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_12.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_12.Location = new System.Drawing.Point(226, 391);
            this.txtbx_KB_Val_12.Name = "txtbx_KB_Val_12";
            this.txtbx_KB_Val_12.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_12.TabIndex = 432;
            this.txtbx_KB_Val_12.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_12.Visible = false;
            this.txtbx_KB_Val_12.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_12.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_11
            // 
            this.txtbx_KB_Val_11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_11.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_11.Location = new System.Drawing.Point(165, 391);
            this.txtbx_KB_Val_11.Name = "txtbx_KB_Val_11";
            this.txtbx_KB_Val_11.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_11.TabIndex = 431;
            this.txtbx_KB_Val_11.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_11.Visible = false;
            this.txtbx_KB_Val_11.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_11.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_10
            // 
            this.txtbx_KB_Val_10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_10.Location = new System.Drawing.Point(104, 391);
            this.txtbx_KB_Val_10.Name = "txtbx_KB_Val_10";
            this.txtbx_KB_Val_10.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_10.TabIndex = 430;
            this.txtbx_KB_Val_10.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_10.Visible = false;
            this.txtbx_KB_Val_10.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_10.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_15
            // 
            this.txtbx_KB_Val_15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_15.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_15.Location = new System.Drawing.Point(762, 121);
            this.txtbx_KB_Val_15.Name = "txtbx_KB_Val_15";
            this.txtbx_KB_Val_15.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_15.TabIndex = 532;
            this.txtbx_KB_Val_15.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_15.Visible = false;
            this.txtbx_KB_Val_15.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_15.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_15.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_14
            // 
            this.txtbx_KB_Val_14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_14.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_14.Location = new System.Drawing.Point(701, 121);
            this.txtbx_KB_Val_14.Name = "txtbx_KB_Val_14";
            this.txtbx_KB_Val_14.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_14.TabIndex = 531;
            this.txtbx_KB_Val_14.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_14.Visible = false;
            this.txtbx_KB_Val_14.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_14.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_13
            // 
            this.txtbx_KB_Val_13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_13.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_13.Location = new System.Drawing.Point(640, 121);
            this.txtbx_KB_Val_13.Name = "txtbx_KB_Val_13";
            this.txtbx_KB_Val_13.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_13.TabIndex = 530;
            this.txtbx_KB_Val_13.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_13.Visible = false;
            this.txtbx_KB_Val_13.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_13.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_18
            // 
            this.txtbx_KB_Val_18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_18.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_18.Location = new System.Drawing.Point(762, 211);
            this.txtbx_KB_Val_18.Name = "txtbx_KB_Val_18";
            this.txtbx_KB_Val_18.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_18.TabIndex = 632;
            this.txtbx_KB_Val_18.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_18.Visible = false;
            this.txtbx_KB_Val_18.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_18.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_18.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_17
            // 
            this.txtbx_KB_Val_17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_17.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_17.Location = new System.Drawing.Point(701, 211);
            this.txtbx_KB_Val_17.Name = "txtbx_KB_Val_17";
            this.txtbx_KB_Val_17.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_17.TabIndex = 631;
            this.txtbx_KB_Val_17.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_17.Visible = false;
            this.txtbx_KB_Val_17.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_17.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_17.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_16
            // 
            this.txtbx_KB_Val_16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_16.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_16.Location = new System.Drawing.Point(640, 211);
            this.txtbx_KB_Val_16.Name = "txtbx_KB_Val_16";
            this.txtbx_KB_Val_16.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_16.TabIndex = 630;
            this.txtbx_KB_Val_16.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_16.Visible = false;
            this.txtbx_KB_Val_16.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_16.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_16.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_21
            // 
            this.txtbx_KB_Val_21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_21.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_21.Location = new System.Drawing.Point(762, 301);
            this.txtbx_KB_Val_21.Name = "txtbx_KB_Val_21";
            this.txtbx_KB_Val_21.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_21.TabIndex = 732;
            this.txtbx_KB_Val_21.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_21.Visible = false;
            this.txtbx_KB_Val_21.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_21.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_20
            // 
            this.txtbx_KB_Val_20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_20.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_20.Location = new System.Drawing.Point(701, 301);
            this.txtbx_KB_Val_20.Name = "txtbx_KB_Val_20";
            this.txtbx_KB_Val_20.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_20.TabIndex = 731;
            this.txtbx_KB_Val_20.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_20.Visible = false;
            this.txtbx_KB_Val_20.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_20.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_20.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_19
            // 
            this.txtbx_KB_Val_19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_19.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_19.Location = new System.Drawing.Point(640, 301);
            this.txtbx_KB_Val_19.Name = "txtbx_KB_Val_19";
            this.txtbx_KB_Val_19.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_19.TabIndex = 730;
            this.txtbx_KB_Val_19.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_19.Visible = false;
            this.txtbx_KB_Val_19.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_19.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_19.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_24
            // 
            this.txtbx_KB_Val_24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_24.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_24.Location = new System.Drawing.Point(762, 391);
            this.txtbx_KB_Val_24.Name = "txtbx_KB_Val_24";
            this.txtbx_KB_Val_24.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_24.TabIndex = 832;
            this.txtbx_KB_Val_24.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_24.Visible = false;
            this.txtbx_KB_Val_24.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_24.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_24.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_23
            // 
            this.txtbx_KB_Val_23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_23.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_23.Location = new System.Drawing.Point(701, 391);
            this.txtbx_KB_Val_23.Name = "txtbx_KB_Val_23";
            this.txtbx_KB_Val_23.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_23.TabIndex = 831;
            this.txtbx_KB_Val_23.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_23.Visible = false;
            this.txtbx_KB_Val_23.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_23.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // txtbx_KB_Val_22
            // 
            this.txtbx_KB_Val_22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(106)))), ((int)(((byte)(106)))));
            this.txtbx_KB_Val_22.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtbx_KB_Val_22.Location = new System.Drawing.Point(640, 391);
            this.txtbx_KB_Val_22.Name = "txtbx_KB_Val_22";
            this.txtbx_KB_Val_22.Size = new System.Drawing.Size(60, 19);
            this.txtbx_KB_Val_22.TabIndex = 830;
            this.txtbx_KB_Val_22.Text = "Ç±Ç±Ç…ì¸óÕ";
            this.txtbx_KB_Val_22.Visible = false;
            this.txtbx_KB_Val_22.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_KeyboardValue_PreviewKeyDown);
            this.txtbx_KB_Val_22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyDown);
            this.txtbx_KB_Val_22.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyboardValue_KeyUp);
            // 
            // cmbbx_Set_01
            // 
            this.cmbbx_Set_01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_01.FormattingEnabled = true;
            this.cmbbx_Set_01.Location = new System.Drawing.Point(174, 56);
            this.cmbbx_Set_01.Name = "cmbbx_Set_01";
            this.cmbbx_Set_01.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_01.TabIndex = 100;
            this.cmbbx_Set_01.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_02
            // 
            this.cmbbx_Set_02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_02.FormattingEnabled = true;
            this.cmbbx_Set_02.Location = new System.Drawing.Point(174, 146);
            this.cmbbx_Set_02.Name = "cmbbx_Set_02";
            this.cmbbx_Set_02.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_02.TabIndex = 200;
            this.cmbbx_Set_02.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_03
            // 
            this.cmbbx_Set_03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_03.FormattingEnabled = true;
            this.cmbbx_Set_03.Location = new System.Drawing.Point(174, 236);
            this.cmbbx_Set_03.Name = "cmbbx_Set_03";
            this.cmbbx_Set_03.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_03.TabIndex = 300;
            this.cmbbx_Set_03.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_04
            // 
            this.cmbbx_Set_04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_04.FormattingEnabled = true;
            this.cmbbx_Set_04.Location = new System.Drawing.Point(174, 326);
            this.cmbbx_Set_04.Name = "cmbbx_Set_04";
            this.cmbbx_Set_04.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_04.TabIndex = 400;
            this.cmbbx_Set_04.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_05
            // 
            this.cmbbx_Set_05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_05.FormattingEnabled = true;
            this.cmbbx_Set_05.Location = new System.Drawing.Point(710, 56);
            this.cmbbx_Set_05.Name = "cmbbx_Set_05";
            this.cmbbx_Set_05.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_05.TabIndex = 500;
            this.cmbbx_Set_05.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_06
            // 
            this.cmbbx_Set_06.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_06.FormattingEnabled = true;
            this.cmbbx_Set_06.Location = new System.Drawing.Point(710, 146);
            this.cmbbx_Set_06.Name = "cmbbx_Set_06";
            this.cmbbx_Set_06.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_06.TabIndex = 600;
            this.cmbbx_Set_06.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_07
            // 
            this.cmbbx_Set_07.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_07.FormattingEnabled = true;
            this.cmbbx_Set_07.Location = new System.Drawing.Point(710, 236);
            this.cmbbx_Set_07.Name = "cmbbx_Set_07";
            this.cmbbx_Set_07.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_07.TabIndex = 700;
            this.cmbbx_Set_07.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // cmbbx_Set_08
            // 
            this.cmbbx_Set_08.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbx_Set_08.FormattingEnabled = true;
            this.cmbbx_Set_08.Location = new System.Drawing.Point(710, 326);
            this.cmbbx_Set_08.Name = "cmbbx_Set_08";
            this.cmbbx_Set_08.Size = new System.Drawing.Size(155, 20);
            this.cmbbx_Set_08.TabIndex = 800;
            this.cmbbx_Set_08.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Set_SelectedIndexChanged);
            // 
            // nud_Set_Val_01
            // 
            this.nud_Set_Val_01.Location = new System.Drawing.Point(104, 88);
            this.nud_Set_Val_01.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_01.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_01.Name = "nud_Set_Val_01";
            this.nud_Set_Val_01.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_01.TabIndex = 110;
            this.nud_Set_Val_01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_01.Visible = false;
            // 
            // nud_Set_Val_02
            // 
            this.nud_Set_Val_02.Location = new System.Drawing.Point(189, 88);
            this.nud_Set_Val_02.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_02.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_02.Name = "nud_Set_Val_02";
            this.nud_Set_Val_02.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_02.TabIndex = 111;
            this.nud_Set_Val_02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_02.Visible = false;
            // 
            // nud_Set_Val_03
            // 
            this.nud_Set_Val_03.Location = new System.Drawing.Point(104, 178);
            this.nud_Set_Val_03.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_03.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_03.Name = "nud_Set_Val_03";
            this.nud_Set_Val_03.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_03.TabIndex = 210;
            this.nud_Set_Val_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_03.Visible = false;
            // 
            // nud_Set_Val_04
            // 
            this.nud_Set_Val_04.Location = new System.Drawing.Point(189, 178);
            this.nud_Set_Val_04.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_04.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_04.Name = "nud_Set_Val_04";
            this.nud_Set_Val_04.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_04.TabIndex = 211;
            this.nud_Set_Val_04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_04.Visible = false;
            // 
            // nud_Set_Val_05
            // 
            this.nud_Set_Val_05.Location = new System.Drawing.Point(104, 268);
            this.nud_Set_Val_05.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_05.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_05.Name = "nud_Set_Val_05";
            this.nud_Set_Val_05.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_05.TabIndex = 310;
            this.nud_Set_Val_05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_05.Visible = false;
            // 
            // nud_Set_Val_06
            // 
            this.nud_Set_Val_06.Location = new System.Drawing.Point(189, 268);
            this.nud_Set_Val_06.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_06.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_06.Name = "nud_Set_Val_06";
            this.nud_Set_Val_06.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_06.TabIndex = 311;
            this.nud_Set_Val_06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_06.Visible = false;
            // 
            // nud_Set_Val_07
            // 
            this.nud_Set_Val_07.Location = new System.Drawing.Point(104, 358);
            this.nud_Set_Val_07.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_07.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_07.Name = "nud_Set_Val_07";
            this.nud_Set_Val_07.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_07.TabIndex = 410;
            this.nud_Set_Val_07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_07.Visible = false;
            // 
            // nud_Set_Val_08
            // 
            this.nud_Set_Val_08.Location = new System.Drawing.Point(189, 358);
            this.nud_Set_Val_08.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_08.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_08.Name = "nud_Set_Val_08";
            this.nud_Set_Val_08.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_08.TabIndex = 411;
            this.nud_Set_Val_08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_08.Visible = false;
            // 
            // nud_Set_Val_10
            // 
            this.nud_Set_Val_10.Location = new System.Drawing.Point(725, 88);
            this.nud_Set_Val_10.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_10.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_10.Name = "nud_Set_Val_10";
            this.nud_Set_Val_10.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_10.TabIndex = 511;
            this.nud_Set_Val_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_10.Visible = false;
            // 
            // nud_Set_Val_09
            // 
            this.nud_Set_Val_09.Location = new System.Drawing.Point(640, 88);
            this.nud_Set_Val_09.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_09.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_09.Name = "nud_Set_Val_09";
            this.nud_Set_Val_09.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_09.TabIndex = 510;
            this.nud_Set_Val_09.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_09.Visible = false;
            // 
            // nud_Set_Val_12
            // 
            this.nud_Set_Val_12.Location = new System.Drawing.Point(725, 178);
            this.nud_Set_Val_12.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_12.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_12.Name = "nud_Set_Val_12";
            this.nud_Set_Val_12.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_12.TabIndex = 611;
            this.nud_Set_Val_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_12.Visible = false;
            // 
            // nud_Set_Val_11
            // 
            this.nud_Set_Val_11.Location = new System.Drawing.Point(640, 178);
            this.nud_Set_Val_11.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_11.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_11.Name = "nud_Set_Val_11";
            this.nud_Set_Val_11.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_11.TabIndex = 610;
            this.nud_Set_Val_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_11.Visible = false;
            // 
            // nud_Set_Val_14
            // 
            this.nud_Set_Val_14.Location = new System.Drawing.Point(725, 268);
            this.nud_Set_Val_14.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_14.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_14.Name = "nud_Set_Val_14";
            this.nud_Set_Val_14.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_14.TabIndex = 711;
            this.nud_Set_Val_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_14.Visible = false;
            // 
            // nud_Set_Val_13
            // 
            this.nud_Set_Val_13.Location = new System.Drawing.Point(640, 268);
            this.nud_Set_Val_13.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_13.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_13.Name = "nud_Set_Val_13";
            this.nud_Set_Val_13.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_13.TabIndex = 710;
            this.nud_Set_Val_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_13.Visible = false;
            // 
            // nud_Set_Val_16
            // 
            this.nud_Set_Val_16.Location = new System.Drawing.Point(725, 358);
            this.nud_Set_Val_16.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_16.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_16.Name = "nud_Set_Val_16";
            this.nud_Set_Val_16.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_16.TabIndex = 811;
            this.nud_Set_Val_16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_16.Visible = false;
            // 
            // nud_Set_Val_15
            // 
            this.nud_Set_Val_15.Location = new System.Drawing.Point(640, 358);
            this.nud_Set_Val_15.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nud_Set_Val_15.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.nud_Set_Val_15.Name = "nud_Set_Val_15";
            this.nud_Set_Val_15.Size = new System.Drawing.Size(80, 19);
            this.nud_Set_Val_15.TabIndex = 810;
            this.nud_Set_Val_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Set_Val_15.Visible = false;
            // 
            // lbl_title_01
            // 
            this.lbl_title_01.AutoSize = true;
            this.lbl_title_01.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_01.ForeColor = System.Drawing.Color.White;
            this.lbl_title_01.Location = new System.Drawing.Point(32, 88);
            this.lbl_title_01.Name = "lbl_title_01";
            this.lbl_title_01.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_01.TabIndex = 101;
            this.lbl_title_01.Text = "label1";
            this.lbl_title_01.Visible = false;
            // 
            // lbl_title_02
            // 
            this.lbl_title_02.AutoSize = true;
            this.lbl_title_02.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_02.ForeColor = System.Drawing.Color.White;
            this.lbl_title_02.Location = new System.Drawing.Point(32, 178);
            this.lbl_title_02.Name = "lbl_title_02";
            this.lbl_title_02.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_02.TabIndex = 201;
            this.lbl_title_02.Text = "label1";
            this.lbl_title_02.Visible = false;
            // 
            // lbl_title_03
            // 
            this.lbl_title_03.AutoSize = true;
            this.lbl_title_03.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_03.ForeColor = System.Drawing.Color.White;
            this.lbl_title_03.Location = new System.Drawing.Point(32, 268);
            this.lbl_title_03.Name = "lbl_title_03";
            this.lbl_title_03.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_03.TabIndex = 301;
            this.lbl_title_03.Text = "label1";
            this.lbl_title_03.Visible = false;
            // 
            // lbl_title_04
            // 
            this.lbl_title_04.AutoSize = true;
            this.lbl_title_04.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_04.ForeColor = System.Drawing.Color.White;
            this.lbl_title_04.Location = new System.Drawing.Point(32, 358);
            this.lbl_title_04.Name = "lbl_title_04";
            this.lbl_title_04.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_04.TabIndex = 401;
            this.lbl_title_04.Text = "label1";
            this.lbl_title_04.Visible = false;
            // 
            // lbl_title_05
            // 
            this.lbl_title_05.AutoSize = true;
            this.lbl_title_05.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_05.ForeColor = System.Drawing.Color.White;
            this.lbl_title_05.Location = new System.Drawing.Point(568, 88);
            this.lbl_title_05.Name = "lbl_title_05";
            this.lbl_title_05.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_05.TabIndex = 501;
            this.lbl_title_05.Text = "label1";
            this.lbl_title_05.Visible = false;
            // 
            // lbl_title_06
            // 
            this.lbl_title_06.AutoSize = true;
            this.lbl_title_06.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_06.ForeColor = System.Drawing.Color.White;
            this.lbl_title_06.Location = new System.Drawing.Point(568, 178);
            this.lbl_title_06.Name = "lbl_title_06";
            this.lbl_title_06.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_06.TabIndex = 601;
            this.lbl_title_06.Text = "label1";
            this.lbl_title_06.Visible = false;
            // 
            // lbl_title_07
            // 
            this.lbl_title_07.AutoSize = true;
            this.lbl_title_07.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_07.ForeColor = System.Drawing.Color.White;
            this.lbl_title_07.Location = new System.Drawing.Point(568, 268);
            this.lbl_title_07.Name = "lbl_title_07";
            this.lbl_title_07.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_07.TabIndex = 701;
            this.lbl_title_07.Text = "label1";
            this.lbl_title_07.Visible = false;
            // 
            // lbl_title_08
            // 
            this.lbl_title_08.AutoSize = true;
            this.lbl_title_08.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title_08.ForeColor = System.Drawing.Color.White;
            this.lbl_title_08.Location = new System.Drawing.Point(568, 358);
            this.lbl_title_08.Name = "lbl_title_08";
            this.lbl_title_08.Size = new System.Drawing.Size(35, 12);
            this.lbl_title_08.TabIndex = 801;
            this.lbl_title_08.Text = "label1";
            this.lbl_title_08.Visible = false;
            // 
            // btn_load
            // 
            this.btn_load.ImageIndex = 0;
            this.btn_load.ImageList = this.ilist_loadsave_btn;
            this.btn_load.Location = new System.Drawing.Point(653, 433);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(97, 35);
            this.btn_load.TabIndex = 902;
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.MouseLeave += new System.EventHandler(this.btn_load_MouseLeave);
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            this.btn_load.MouseEnter += new System.EventHandler(this.btn_load_MouseEnter);
            // 
            // ilist_loadsave_btn
            // 
            this.ilist_loadsave_btn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilist_loadsave_btn.ImageStream")));
            this.ilist_loadsave_btn.TransparentColor = System.Drawing.Color.Transparent;
            this.ilist_loadsave_btn.Images.SetKeyName(0, "BT_LOAD.png");
            this.ilist_loadsave_btn.Images.SetKeyName(1, "BT_LOAD_MOUSE-ON.png");
            this.ilist_loadsave_btn.Images.SetKeyName(2, "BT_SAVE.png");
            this.ilist_loadsave_btn.Images.SetKeyName(3, "BT_SAVE_MOUSE-ON.png");
            // 
            // btn_save
            // 
            this.btn_save.ImageIndex = 2;
            this.btn_save.ImageList = this.ilist_loadsave_btn;
            this.btn_save.Location = new System.Drawing.Point(766, 433);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(97, 35);
            this.btn_save.TabIndex = 903;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.MouseLeave += new System.EventHandler(this.btn_save_MouseLeave);
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            this.btn_save.MouseEnter += new System.EventHandler(this.btn_save_MouseEnter);
            // 
            // btn_reset
            // 
            this.btn_reset.ImageIndex = 0;
            this.btn_reset.ImageList = this.ilist_reset_btn;
            this.btn_reset.Location = new System.Drawing.Point(816, 0);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(62, 28);
            this.btn_reset.TabIndex = 904;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.MouseLeave += new System.EventHandler(this.btn_reset_MouseLeave);
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            this.btn_reset.MouseEnter += new System.EventHandler(this.btn_reset_MouseEnter);
            // 
            // ilist_reset_btn
            // 
            this.ilist_reset_btn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilist_reset_btn.ImageStream")));
            this.ilist_reset_btn.TransparentColor = System.Drawing.Color.Transparent;
            this.ilist_reset_btn.Images.SetKeyName(0, "BT_RESET.png");
            this.ilist_reset_btn.Images.SetKeyName(1, "BT_RESET_MOUSE-ON.png");
            // 
            // btn_soft_reset
            // 
            this.btn_soft_reset.Location = new System.Drawing.Point(630, 500);
            this.btn_soft_reset.Name = "btn_soft_reset";
            this.btn_soft_reset.Size = new System.Drawing.Size(121, 29);
            this.btn_soft_reset.TabIndex = 905;
            this.btn_soft_reset.Text = "soft reset";
            this.btn_soft_reset.UseVisualStyleBackColor = true;
            this.btn_soft_reset.Click += new System.EventHandler(this.btn_soft_reset_Click);
            // 
            // btn_key_clr_01
            // 
            this.btn_key_clr_01.Location = new System.Drawing.Point(287, 119);
            this.btn_key_clr_01.Name = "btn_key_clr_01";
            this.btn_key_clr_01.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_01.TabIndex = 133;
            this.btn_key_clr_01.Text = "∏ÿ±";
            this.btn_key_clr_01.UseVisualStyleBackColor = true;
            this.btn_key_clr_01.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_02
            // 
            this.btn_key_clr_02.Location = new System.Drawing.Point(287, 209);
            this.btn_key_clr_02.Name = "btn_key_clr_02";
            this.btn_key_clr_02.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_02.TabIndex = 233;
            this.btn_key_clr_02.Text = "∏ÿ±";
            this.btn_key_clr_02.UseVisualStyleBackColor = true;
            this.btn_key_clr_02.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_03
            // 
            this.btn_key_clr_03.Location = new System.Drawing.Point(287, 299);
            this.btn_key_clr_03.Name = "btn_key_clr_03";
            this.btn_key_clr_03.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_03.TabIndex = 333;
            this.btn_key_clr_03.Text = "∏ÿ±";
            this.btn_key_clr_03.UseVisualStyleBackColor = true;
            this.btn_key_clr_03.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_04
            // 
            this.btn_key_clr_04.Location = new System.Drawing.Point(287, 389);
            this.btn_key_clr_04.Name = "btn_key_clr_04";
            this.btn_key_clr_04.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_04.TabIndex = 433;
            this.btn_key_clr_04.Text = "∏ÿ±";
            this.btn_key_clr_04.UseVisualStyleBackColor = true;
            this.btn_key_clr_04.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_05
            // 
            this.btn_key_clr_05.Location = new System.Drawing.Point(823, 119);
            this.btn_key_clr_05.Name = "btn_key_clr_05";
            this.btn_key_clr_05.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_05.TabIndex = 533;
            this.btn_key_clr_05.Text = "∏ÿ±";
            this.btn_key_clr_05.UseVisualStyleBackColor = true;
            this.btn_key_clr_05.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_06
            // 
            this.btn_key_clr_06.Location = new System.Drawing.Point(823, 209);
            this.btn_key_clr_06.Name = "btn_key_clr_06";
            this.btn_key_clr_06.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_06.TabIndex = 633;
            this.btn_key_clr_06.Text = "∏ÿ±";
            this.btn_key_clr_06.UseVisualStyleBackColor = true;
            this.btn_key_clr_06.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_07
            // 
            this.btn_key_clr_07.Location = new System.Drawing.Point(823, 299);
            this.btn_key_clr_07.Name = "btn_key_clr_07";
            this.btn_key_clr_07.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_07.TabIndex = 733;
            this.btn_key_clr_07.Text = "∏ÿ±";
            this.btn_key_clr_07.UseVisualStyleBackColor = true;
            this.btn_key_clr_07.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // btn_key_clr_08
            // 
            this.btn_key_clr_08.Location = new System.Drawing.Point(823, 389);
            this.btn_key_clr_08.Name = "btn_key_clr_08";
            this.btn_key_clr_08.Size = new System.Drawing.Size(42, 22);
            this.btn_key_clr_08.TabIndex = 833;
            this.btn_key_clr_08.Text = "∏ÿ±";
            this.btn_key_clr_08.UseVisualStyleBackColor = true;
            this.btn_key_clr_08.Click += new System.EventHandler(this.btn_key_clr_Click);
            // 
            // chkbx_key_modifier_01
            // 
            this.chkbx_key_modifier_01.AutoSize = true;
            this.chkbx_key_modifier_01.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_01.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_01.Location = new System.Drawing.Point(104, 88);
            this.chkbx_key_modifier_01.Name = "chkbx_key_modifier_01";
            this.chkbx_key_modifier_01.Size = new System.Drawing.Size(53, 16);
            this.chkbx_key_modifier_01.TabIndex = 991;
            this.chkbx_key_modifier_01.Text = "Ctrl L";
            this.chkbx_key_modifier_01.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_02
            // 
            this.chkbx_key_modifier_02.AutoSize = true;
            this.chkbx_key_modifier_02.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_02.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_02.Location = new System.Drawing.Point(174, 88);
            this.chkbx_key_modifier_02.Name = "chkbx_key_modifier_02";
            this.chkbx_key_modifier_02.Size = new System.Drawing.Size(58, 16);
            this.chkbx_key_modifier_02.TabIndex = 992;
            this.chkbx_key_modifier_02.Text = "Shift L";
            this.chkbx_key_modifier_02.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_03
            // 
            this.chkbx_key_modifier_03.AutoSize = true;
            this.chkbx_key_modifier_03.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_03.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_03.Location = new System.Drawing.Point(244, 88);
            this.chkbx_key_modifier_03.Name = "chkbx_key_modifier_03";
            this.chkbx_key_modifier_03.Size = new System.Drawing.Size(49, 16);
            this.chkbx_key_modifier_03.TabIndex = 993;
            this.chkbx_key_modifier_03.Text = "Alt L";
            this.chkbx_key_modifier_03.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_04
            // 
            this.chkbx_key_modifier_04.AutoSize = true;
            this.chkbx_key_modifier_04.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_04.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_04.Location = new System.Drawing.Point(104, 104);
            this.chkbx_key_modifier_04.Name = "chkbx_key_modifier_04";
            this.chkbx_key_modifier_04.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_04.TabIndex = 994;
            this.chkbx_key_modifier_04.Text = "checkBox4";
            this.chkbx_key_modifier_04.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_05
            // 
            this.chkbx_key_modifier_05.AutoSize = true;
            this.chkbx_key_modifier_05.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_05.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_05.Location = new System.Drawing.Point(174, 104);
            this.chkbx_key_modifier_05.Name = "chkbx_key_modifier_05";
            this.chkbx_key_modifier_05.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_05.TabIndex = 995;
            this.chkbx_key_modifier_05.Text = "checkBox5";
            this.chkbx_key_modifier_05.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_06
            // 
            this.chkbx_key_modifier_06.AutoSize = true;
            this.chkbx_key_modifier_06.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_06.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_06.Location = new System.Drawing.Point(244, 104);
            this.chkbx_key_modifier_06.Name = "chkbx_key_modifier_06";
            this.chkbx_key_modifier_06.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_06.TabIndex = 996;
            this.chkbx_key_modifier_06.Text = "checkBox6";
            this.chkbx_key_modifier_06.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_12
            // 
            this.chkbx_key_modifier_12.AutoSize = true;
            this.chkbx_key_modifier_12.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_12.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_12.Location = new System.Drawing.Point(244, 194);
            this.chkbx_key_modifier_12.Name = "chkbx_key_modifier_12";
            this.chkbx_key_modifier_12.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_12.TabIndex = 1002;
            this.chkbx_key_modifier_12.Text = "checkBox7";
            this.chkbx_key_modifier_12.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_11
            // 
            this.chkbx_key_modifier_11.AutoSize = true;
            this.chkbx_key_modifier_11.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_11.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_11.Location = new System.Drawing.Point(174, 194);
            this.chkbx_key_modifier_11.Name = "chkbx_key_modifier_11";
            this.chkbx_key_modifier_11.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_11.TabIndex = 1001;
            this.chkbx_key_modifier_11.Text = "checkBox8";
            this.chkbx_key_modifier_11.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_10
            // 
            this.chkbx_key_modifier_10.AutoSize = true;
            this.chkbx_key_modifier_10.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_10.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_10.Location = new System.Drawing.Point(104, 194);
            this.chkbx_key_modifier_10.Name = "chkbx_key_modifier_10";
            this.chkbx_key_modifier_10.Size = new System.Drawing.Size(80, 16);
            this.chkbx_key_modifier_10.TabIndex = 1000;
            this.chkbx_key_modifier_10.Text = "checkBox9";
            this.chkbx_key_modifier_10.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_09
            // 
            this.chkbx_key_modifier_09.AutoSize = true;
            this.chkbx_key_modifier_09.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_09.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_09.Location = new System.Drawing.Point(244, 178);
            this.chkbx_key_modifier_09.Name = "chkbx_key_modifier_09";
            this.chkbx_key_modifier_09.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_09.TabIndex = 999;
            this.chkbx_key_modifier_09.Text = "checkBox10";
            this.chkbx_key_modifier_09.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_08
            // 
            this.chkbx_key_modifier_08.AutoSize = true;
            this.chkbx_key_modifier_08.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_08.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_08.Location = new System.Drawing.Point(174, 178);
            this.chkbx_key_modifier_08.Name = "chkbx_key_modifier_08";
            this.chkbx_key_modifier_08.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_08.TabIndex = 998;
            this.chkbx_key_modifier_08.Text = "checkBox11";
            this.chkbx_key_modifier_08.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_07
            // 
            this.chkbx_key_modifier_07.AutoSize = true;
            this.chkbx_key_modifier_07.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_07.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_07.Location = new System.Drawing.Point(104, 178);
            this.chkbx_key_modifier_07.Name = "chkbx_key_modifier_07";
            this.chkbx_key_modifier_07.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_07.TabIndex = 997;
            this.chkbx_key_modifier_07.Text = "checkBox12";
            this.chkbx_key_modifier_07.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_18
            // 
            this.chkbx_key_modifier_18.AutoSize = true;
            this.chkbx_key_modifier_18.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_18.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_18.Location = new System.Drawing.Point(244, 284);
            this.chkbx_key_modifier_18.Name = "chkbx_key_modifier_18";
            this.chkbx_key_modifier_18.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_18.TabIndex = 1008;
            this.chkbx_key_modifier_18.Text = "checkBox13";
            this.chkbx_key_modifier_18.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_17
            // 
            this.chkbx_key_modifier_17.AutoSize = true;
            this.chkbx_key_modifier_17.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_17.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_17.Location = new System.Drawing.Point(174, 284);
            this.chkbx_key_modifier_17.Name = "chkbx_key_modifier_17";
            this.chkbx_key_modifier_17.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_17.TabIndex = 1007;
            this.chkbx_key_modifier_17.Text = "checkBox14";
            this.chkbx_key_modifier_17.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_16
            // 
            this.chkbx_key_modifier_16.AutoSize = true;
            this.chkbx_key_modifier_16.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_16.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_16.Location = new System.Drawing.Point(104, 284);
            this.chkbx_key_modifier_16.Name = "chkbx_key_modifier_16";
            this.chkbx_key_modifier_16.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_16.TabIndex = 1006;
            this.chkbx_key_modifier_16.Text = "checkBox15";
            this.chkbx_key_modifier_16.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_15
            // 
            this.chkbx_key_modifier_15.AutoSize = true;
            this.chkbx_key_modifier_15.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_15.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_15.Location = new System.Drawing.Point(244, 268);
            this.chkbx_key_modifier_15.Name = "chkbx_key_modifier_15";
            this.chkbx_key_modifier_15.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_15.TabIndex = 1005;
            this.chkbx_key_modifier_15.Text = "checkBox16";
            this.chkbx_key_modifier_15.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_14
            // 
            this.chkbx_key_modifier_14.AutoSize = true;
            this.chkbx_key_modifier_14.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_14.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_14.Location = new System.Drawing.Point(174, 268);
            this.chkbx_key_modifier_14.Name = "chkbx_key_modifier_14";
            this.chkbx_key_modifier_14.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_14.TabIndex = 1004;
            this.chkbx_key_modifier_14.Text = "checkBox17";
            this.chkbx_key_modifier_14.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_13
            // 
            this.chkbx_key_modifier_13.AutoSize = true;
            this.chkbx_key_modifier_13.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_13.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_13.Location = new System.Drawing.Point(104, 268);
            this.chkbx_key_modifier_13.Name = "chkbx_key_modifier_13";
            this.chkbx_key_modifier_13.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_13.TabIndex = 1003;
            this.chkbx_key_modifier_13.Text = "checkBox18";
            this.chkbx_key_modifier_13.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_24
            // 
            this.chkbx_key_modifier_24.AutoSize = true;
            this.chkbx_key_modifier_24.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_24.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_24.Location = new System.Drawing.Point(244, 374);
            this.chkbx_key_modifier_24.Name = "chkbx_key_modifier_24";
            this.chkbx_key_modifier_24.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_24.TabIndex = 1014;
            this.chkbx_key_modifier_24.Text = "checkBox19";
            this.chkbx_key_modifier_24.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_23
            // 
            this.chkbx_key_modifier_23.AutoSize = true;
            this.chkbx_key_modifier_23.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_23.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_23.Location = new System.Drawing.Point(174, 374);
            this.chkbx_key_modifier_23.Name = "chkbx_key_modifier_23";
            this.chkbx_key_modifier_23.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_23.TabIndex = 1013;
            this.chkbx_key_modifier_23.Text = "checkBox20";
            this.chkbx_key_modifier_23.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_22
            // 
            this.chkbx_key_modifier_22.AutoSize = true;
            this.chkbx_key_modifier_22.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_22.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_22.Location = new System.Drawing.Point(104, 374);
            this.chkbx_key_modifier_22.Name = "chkbx_key_modifier_22";
            this.chkbx_key_modifier_22.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_22.TabIndex = 1012;
            this.chkbx_key_modifier_22.Text = "checkBox21";
            this.chkbx_key_modifier_22.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_21
            // 
            this.chkbx_key_modifier_21.AutoSize = true;
            this.chkbx_key_modifier_21.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_21.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_21.Location = new System.Drawing.Point(244, 358);
            this.chkbx_key_modifier_21.Name = "chkbx_key_modifier_21";
            this.chkbx_key_modifier_21.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_21.TabIndex = 1011;
            this.chkbx_key_modifier_21.Text = "checkBox22";
            this.chkbx_key_modifier_21.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_20
            // 
            this.chkbx_key_modifier_20.AutoSize = true;
            this.chkbx_key_modifier_20.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_20.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_20.Location = new System.Drawing.Point(174, 358);
            this.chkbx_key_modifier_20.Name = "chkbx_key_modifier_20";
            this.chkbx_key_modifier_20.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_20.TabIndex = 1010;
            this.chkbx_key_modifier_20.Text = "checkBox23";
            this.chkbx_key_modifier_20.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_19
            // 
            this.chkbx_key_modifier_19.AutoSize = true;
            this.chkbx_key_modifier_19.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_19.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_19.Location = new System.Drawing.Point(104, 358);
            this.chkbx_key_modifier_19.Name = "chkbx_key_modifier_19";
            this.chkbx_key_modifier_19.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_19.TabIndex = 1009;
            this.chkbx_key_modifier_19.Text = "checkBox24";
            this.chkbx_key_modifier_19.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_30
            // 
            this.chkbx_key_modifier_30.AutoSize = true;
            this.chkbx_key_modifier_30.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_30.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_30.Location = new System.Drawing.Point(780, 104);
            this.chkbx_key_modifier_30.Name = "chkbx_key_modifier_30";
            this.chkbx_key_modifier_30.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_30.TabIndex = 1020;
            this.chkbx_key_modifier_30.Text = "checkBox25";
            this.chkbx_key_modifier_30.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_29
            // 
            this.chkbx_key_modifier_29.AutoSize = true;
            this.chkbx_key_modifier_29.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_29.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_29.Location = new System.Drawing.Point(710, 104);
            this.chkbx_key_modifier_29.Name = "chkbx_key_modifier_29";
            this.chkbx_key_modifier_29.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_29.TabIndex = 1019;
            this.chkbx_key_modifier_29.Text = "checkBox26";
            this.chkbx_key_modifier_29.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_28
            // 
            this.chkbx_key_modifier_28.AutoSize = true;
            this.chkbx_key_modifier_28.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_28.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_28.Location = new System.Drawing.Point(640, 104);
            this.chkbx_key_modifier_28.Name = "chkbx_key_modifier_28";
            this.chkbx_key_modifier_28.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_28.TabIndex = 1018;
            this.chkbx_key_modifier_28.Text = "checkBox27";
            this.chkbx_key_modifier_28.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_27
            // 
            this.chkbx_key_modifier_27.AutoSize = true;
            this.chkbx_key_modifier_27.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_27.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_27.Location = new System.Drawing.Point(780, 88);
            this.chkbx_key_modifier_27.Name = "chkbx_key_modifier_27";
            this.chkbx_key_modifier_27.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_27.TabIndex = 1017;
            this.chkbx_key_modifier_27.Text = "checkBox28";
            this.chkbx_key_modifier_27.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_26
            // 
            this.chkbx_key_modifier_26.AutoSize = true;
            this.chkbx_key_modifier_26.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_26.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_26.Location = new System.Drawing.Point(710, 88);
            this.chkbx_key_modifier_26.Name = "chkbx_key_modifier_26";
            this.chkbx_key_modifier_26.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_26.TabIndex = 1016;
            this.chkbx_key_modifier_26.Text = "checkBox29";
            this.chkbx_key_modifier_26.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_25
            // 
            this.chkbx_key_modifier_25.AutoSize = true;
            this.chkbx_key_modifier_25.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_25.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_25.Location = new System.Drawing.Point(640, 88);
            this.chkbx_key_modifier_25.Name = "chkbx_key_modifier_25";
            this.chkbx_key_modifier_25.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_25.TabIndex = 1015;
            this.chkbx_key_modifier_25.Text = "checkBox30";
            this.chkbx_key_modifier_25.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_36
            // 
            this.chkbx_key_modifier_36.AutoSize = true;
            this.chkbx_key_modifier_36.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_36.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_36.Location = new System.Drawing.Point(779, 194);
            this.chkbx_key_modifier_36.Name = "chkbx_key_modifier_36";
            this.chkbx_key_modifier_36.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_36.TabIndex = 1026;
            this.chkbx_key_modifier_36.Text = "checkBox31";
            this.chkbx_key_modifier_36.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_35
            // 
            this.chkbx_key_modifier_35.AutoSize = true;
            this.chkbx_key_modifier_35.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_35.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_35.Location = new System.Drawing.Point(709, 194);
            this.chkbx_key_modifier_35.Name = "chkbx_key_modifier_35";
            this.chkbx_key_modifier_35.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_35.TabIndex = 1025;
            this.chkbx_key_modifier_35.Text = "checkBox32";
            this.chkbx_key_modifier_35.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_34
            // 
            this.chkbx_key_modifier_34.AutoSize = true;
            this.chkbx_key_modifier_34.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_34.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_34.Location = new System.Drawing.Point(640, 194);
            this.chkbx_key_modifier_34.Name = "chkbx_key_modifier_34";
            this.chkbx_key_modifier_34.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_34.TabIndex = 1024;
            this.chkbx_key_modifier_34.Text = "checkBox33";
            this.chkbx_key_modifier_34.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_33
            // 
            this.chkbx_key_modifier_33.AutoSize = true;
            this.chkbx_key_modifier_33.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_33.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_33.Location = new System.Drawing.Point(779, 178);
            this.chkbx_key_modifier_33.Name = "chkbx_key_modifier_33";
            this.chkbx_key_modifier_33.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_33.TabIndex = 1023;
            this.chkbx_key_modifier_33.Text = "checkBox34";
            this.chkbx_key_modifier_33.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_32
            // 
            this.chkbx_key_modifier_32.AutoSize = true;
            this.chkbx_key_modifier_32.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_32.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_32.Location = new System.Drawing.Point(709, 178);
            this.chkbx_key_modifier_32.Name = "chkbx_key_modifier_32";
            this.chkbx_key_modifier_32.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_32.TabIndex = 1022;
            this.chkbx_key_modifier_32.Text = "checkBox35";
            this.chkbx_key_modifier_32.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_31
            // 
            this.chkbx_key_modifier_31.AutoSize = true;
            this.chkbx_key_modifier_31.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_31.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_31.Location = new System.Drawing.Point(640, 178);
            this.chkbx_key_modifier_31.Name = "chkbx_key_modifier_31";
            this.chkbx_key_modifier_31.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_31.TabIndex = 1021;
            this.chkbx_key_modifier_31.Text = "checkBox36";
            this.chkbx_key_modifier_31.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_42
            // 
            this.chkbx_key_modifier_42.AutoSize = true;
            this.chkbx_key_modifier_42.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_42.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_42.Location = new System.Drawing.Point(780, 284);
            this.chkbx_key_modifier_42.Name = "chkbx_key_modifier_42";
            this.chkbx_key_modifier_42.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_42.TabIndex = 1032;
            this.chkbx_key_modifier_42.Text = "checkBox37";
            this.chkbx_key_modifier_42.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_41
            // 
            this.chkbx_key_modifier_41.AutoSize = true;
            this.chkbx_key_modifier_41.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_41.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_41.Location = new System.Drawing.Point(710, 284);
            this.chkbx_key_modifier_41.Name = "chkbx_key_modifier_41";
            this.chkbx_key_modifier_41.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_41.TabIndex = 1031;
            this.chkbx_key_modifier_41.Text = "checkBox38";
            this.chkbx_key_modifier_41.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_40
            // 
            this.chkbx_key_modifier_40.AutoSize = true;
            this.chkbx_key_modifier_40.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_40.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_40.Location = new System.Drawing.Point(640, 284);
            this.chkbx_key_modifier_40.Name = "chkbx_key_modifier_40";
            this.chkbx_key_modifier_40.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_40.TabIndex = 1030;
            this.chkbx_key_modifier_40.Text = "checkBox39";
            this.chkbx_key_modifier_40.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_39
            // 
            this.chkbx_key_modifier_39.AutoSize = true;
            this.chkbx_key_modifier_39.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_39.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_39.Location = new System.Drawing.Point(780, 268);
            this.chkbx_key_modifier_39.Name = "chkbx_key_modifier_39";
            this.chkbx_key_modifier_39.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_39.TabIndex = 1029;
            this.chkbx_key_modifier_39.Text = "checkBox40";
            this.chkbx_key_modifier_39.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_38
            // 
            this.chkbx_key_modifier_38.AutoSize = true;
            this.chkbx_key_modifier_38.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_38.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_38.Location = new System.Drawing.Point(710, 268);
            this.chkbx_key_modifier_38.Name = "chkbx_key_modifier_38";
            this.chkbx_key_modifier_38.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_38.TabIndex = 1028;
            this.chkbx_key_modifier_38.Text = "checkBox41";
            this.chkbx_key_modifier_38.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_37
            // 
            this.chkbx_key_modifier_37.AutoSize = true;
            this.chkbx_key_modifier_37.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_37.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_37.Location = new System.Drawing.Point(640, 268);
            this.chkbx_key_modifier_37.Name = "chkbx_key_modifier_37";
            this.chkbx_key_modifier_37.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_37.TabIndex = 1027;
            this.chkbx_key_modifier_37.Text = "checkBox42";
            this.chkbx_key_modifier_37.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_48
            // 
            this.chkbx_key_modifier_48.AutoSize = true;
            this.chkbx_key_modifier_48.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_48.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_48.Location = new System.Drawing.Point(780, 374);
            this.chkbx_key_modifier_48.Name = "chkbx_key_modifier_48";
            this.chkbx_key_modifier_48.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_48.TabIndex = 1038;
            this.chkbx_key_modifier_48.Text = "checkBox43";
            this.chkbx_key_modifier_48.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_47
            // 
            this.chkbx_key_modifier_47.AutoSize = true;
            this.chkbx_key_modifier_47.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_47.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_47.Location = new System.Drawing.Point(710, 374);
            this.chkbx_key_modifier_47.Name = "chkbx_key_modifier_47";
            this.chkbx_key_modifier_47.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_47.TabIndex = 1037;
            this.chkbx_key_modifier_47.Text = "checkBox44";
            this.chkbx_key_modifier_47.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_46
            // 
            this.chkbx_key_modifier_46.AutoSize = true;
            this.chkbx_key_modifier_46.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_46.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_46.Location = new System.Drawing.Point(640, 374);
            this.chkbx_key_modifier_46.Name = "chkbx_key_modifier_46";
            this.chkbx_key_modifier_46.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_46.TabIndex = 1036;
            this.chkbx_key_modifier_46.Text = "checkBox45";
            this.chkbx_key_modifier_46.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_45
            // 
            this.chkbx_key_modifier_45.AutoSize = true;
            this.chkbx_key_modifier_45.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_45.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_45.Location = new System.Drawing.Point(780, 358);
            this.chkbx_key_modifier_45.Name = "chkbx_key_modifier_45";
            this.chkbx_key_modifier_45.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_45.TabIndex = 1035;
            this.chkbx_key_modifier_45.Text = "checkBox46";
            this.chkbx_key_modifier_45.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_44
            // 
            this.chkbx_key_modifier_44.AutoSize = true;
            this.chkbx_key_modifier_44.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_44.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_44.Location = new System.Drawing.Point(710, 358);
            this.chkbx_key_modifier_44.Name = "chkbx_key_modifier_44";
            this.chkbx_key_modifier_44.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_44.TabIndex = 1034;
            this.chkbx_key_modifier_44.Text = "checkBox47";
            this.chkbx_key_modifier_44.UseVisualStyleBackColor = false;
            // 
            // chkbx_key_modifier_43
            // 
            this.chkbx_key_modifier_43.AutoSize = true;
            this.chkbx_key_modifier_43.BackColor = System.Drawing.Color.Transparent;
            this.chkbx_key_modifier_43.ForeColor = System.Drawing.Color.White;
            this.chkbx_key_modifier_43.Location = new System.Drawing.Point(640, 358);
            this.chkbx_key_modifier_43.Name = "chkbx_key_modifier_43";
            this.chkbx_key_modifier_43.Size = new System.Drawing.Size(86, 16);
            this.chkbx_key_modifier_43.TabIndex = 1033;
            this.chkbx_key_modifier_43.Text = "checkBox48";
            this.chkbx_key_modifier_43.UseVisualStyleBackColor = false;
            // 
            // btn_eeprom_init
            // 
            this.btn_eeprom_init.Location = new System.Drawing.Point(762, 506);
            this.btn_eeprom_init.Name = "btn_eeprom_init";
            this.btn_eeprom_init.Size = new System.Drawing.Size(108, 23);
            this.btn_eeprom_init.TabIndex = 1039;
            this.btn_eeprom_init.Text = "EEPROMèâä˙âª";
            this.btn_eeprom_init.UseVisualStyleBackColor = true;
            this.btn_eeprom_init.Click += new System.EventHandler(this.btn_eeprom_init_Click);
            // 
            // Status_NC_pb
            // 
            this.Status_NC_pb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Status_NC_pb.BackColor = System.Drawing.Color.Transparent;
            this.Status_NC_pb.Image = global::Tone_Pedal_USB_CT.Properties.Resources.OFF_Black;
            this.Status_NC_pb.Location = new System.Drawing.Point(843, 474);
            this.Status_NC_pb.Name = "Status_NC_pb";
            this.Status_NC_pb.Size = new System.Drawing.Size(27, 8);
            this.Status_NC_pb.TabIndex = 95;
            this.Status_NC_pb.TabStop = false;
            this.Status_NC_pb.Visible = false;
            // 
            // Status_C_pb
            // 
            this.Status_C_pb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Status_C_pb.BackColor = System.Drawing.Color.Transparent;
            this.Status_C_pb.Image = global::Tone_Pedal_USB_CT.Properties.Resources.ON_Black;
            this.Status_C_pb.Location = new System.Drawing.Point(843, 474);
            this.Status_C_pb.Name = "Status_C_pb";
            this.Status_C_pb.Size = new System.Drawing.Size(27, 8);
            this.Status_C_pb.TabIndex = 94;
            this.Status_C_pb.TabStop = false;
            this.Status_C_pb.Visible = false;
            // 
            // btn_set
            // 
            this.btn_set.BackColor = System.Drawing.Color.Transparent;
            this.btn_set.Enabled = false;
            this.btn_set.ImageIndex = 0;
            this.btn_set.ImageList = this.ilist_set_btn;
            this.btn_set.Location = new System.Drawing.Point(350, 423);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(180, 53);
            this.btn_set.TabIndex = 901;
            this.btn_set.UseVisualStyleBackColor = false;
            this.btn_set.MouseLeave += new System.EventHandler(this.btn_set_MouseLeave);
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            this.btn_set.MouseEnter += new System.EventHandler(this.btn_set_MouseEnter);
            // 
            // ilist_set_btn
            // 
            this.ilist_set_btn.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilist_set_btn.ImageStream")));
            this.ilist_set_btn.TransparentColor = System.Drawing.Color.Transparent;
            this.ilist_set_btn.Images.SetKeyName(0, "BT_SET.png");
            this.ilist_set_btn.Images.SetKeyName(1, "BT_SET_MOUSE-ON.png");
            // 
            // BackGround_pb
            // 
            this.BackGround_pb.Image = global::Tone_Pedal_USB_CT.Properties.Resources.BG;
            this.BackGround_pb.Location = new System.Drawing.Point(0, 0);
            this.BackGround_pb.Name = "BackGround_pb";
            this.BackGround_pb.Size = new System.Drawing.Size(878, 485);
            this.BackGround_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BackGround_pb.TabIndex = 163;
            this.BackGround_pb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(878, 698);
            this.Controls.Add(this.StatusBox_lbl);
            this.Controls.Add(this.lbl_FW_Version);
            this.Controls.Add(this.btn_eeprom_init);
            this.Controls.Add(this.chkbx_key_modifier_48);
            this.Controls.Add(this.chkbx_key_modifier_47);
            this.Controls.Add(this.chkbx_key_modifier_46);
            this.Controls.Add(this.chkbx_key_modifier_45);
            this.Controls.Add(this.chkbx_key_modifier_44);
            this.Controls.Add(this.chkbx_key_modifier_43);
            this.Controls.Add(this.chkbx_key_modifier_42);
            this.Controls.Add(this.chkbx_key_modifier_41);
            this.Controls.Add(this.chkbx_key_modifier_40);
            this.Controls.Add(this.chkbx_key_modifier_39);
            this.Controls.Add(this.chkbx_key_modifier_38);
            this.Controls.Add(this.chkbx_key_modifier_37);
            this.Controls.Add(this.chkbx_key_modifier_36);
            this.Controls.Add(this.chkbx_key_modifier_35);
            this.Controls.Add(this.chkbx_key_modifier_34);
            this.Controls.Add(this.chkbx_key_modifier_33);
            this.Controls.Add(this.chkbx_key_modifier_32);
            this.Controls.Add(this.chkbx_key_modifier_31);
            this.Controls.Add(this.chkbx_key_modifier_30);
            this.Controls.Add(this.chkbx_key_modifier_29);
            this.Controls.Add(this.chkbx_key_modifier_28);
            this.Controls.Add(this.chkbx_key_modifier_27);
            this.Controls.Add(this.chkbx_key_modifier_26);
            this.Controls.Add(this.chkbx_key_modifier_25);
            this.Controls.Add(this.chkbx_key_modifier_24);
            this.Controls.Add(this.chkbx_key_modifier_23);
            this.Controls.Add(this.chkbx_key_modifier_22);
            this.Controls.Add(this.chkbx_key_modifier_21);
            this.Controls.Add(this.chkbx_key_modifier_20);
            this.Controls.Add(this.chkbx_key_modifier_19);
            this.Controls.Add(this.chkbx_key_modifier_18);
            this.Controls.Add(this.chkbx_key_modifier_17);
            this.Controls.Add(this.chkbx_key_modifier_16);
            this.Controls.Add(this.chkbx_key_modifier_15);
            this.Controls.Add(this.chkbx_key_modifier_14);
            this.Controls.Add(this.chkbx_key_modifier_13);
            this.Controls.Add(this.chkbx_key_modifier_12);
            this.Controls.Add(this.chkbx_key_modifier_11);
            this.Controls.Add(this.chkbx_key_modifier_10);
            this.Controls.Add(this.chkbx_key_modifier_09);
            this.Controls.Add(this.chkbx_key_modifier_08);
            this.Controls.Add(this.chkbx_key_modifier_07);
            this.Controls.Add(this.chkbx_key_modifier_06);
            this.Controls.Add(this.chkbx_key_modifier_05);
            this.Controls.Add(this.chkbx_key_modifier_04);
            this.Controls.Add(this.chkbx_key_modifier_03);
            this.Controls.Add(this.chkbx_key_modifier_02);
            this.Controls.Add(this.chkbx_key_modifier_01);
            this.Controls.Add(this.btn_key_clr_08);
            this.Controls.Add(this.btn_key_clr_07);
            this.Controls.Add(this.btn_key_clr_06);
            this.Controls.Add(this.btn_key_clr_05);
            this.Controls.Add(this.btn_key_clr_04);
            this.Controls.Add(this.btn_key_clr_03);
            this.Controls.Add(this.btn_key_clr_02);
            this.Controls.Add(this.btn_key_clr_01);
            this.Controls.Add(this.btn_soft_reset);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.lbl_title_08);
            this.Controls.Add(this.lbl_title_07);
            this.Controls.Add(this.lbl_title_06);
            this.Controls.Add(this.lbl_title_05);
            this.Controls.Add(this.lbl_title_04);
            this.Controls.Add(this.lbl_title_03);
            this.Controls.Add(this.lbl_title_02);
            this.Controls.Add(this.lbl_title_01);
            this.Controls.Add(this.nud_Set_Val_16);
            this.Controls.Add(this.nud_Set_Val_15);
            this.Controls.Add(this.nud_Set_Val_14);
            this.Controls.Add(this.nud_Set_Val_13);
            this.Controls.Add(this.nud_Set_Val_12);
            this.Controls.Add(this.nud_Set_Val_11);
            this.Controls.Add(this.nud_Set_Val_10);
            this.Controls.Add(this.nud_Set_Val_09);
            this.Controls.Add(this.Status_NC_pb);
            this.Controls.Add(this.Status_C_pb);
            this.Controls.Add(this.nud_Set_Val_08);
            this.Controls.Add(this.nud_Set_Val_07);
            this.Controls.Add(this.nud_Set_Val_06);
            this.Controls.Add(this.nud_Set_Val_05);
            this.Controls.Add(this.nud_Set_Val_04);
            this.Controls.Add(this.nud_Set_Val_03);
            this.Controls.Add(this.nud_Set_Val_02);
            this.Controls.Add(this.nud_Set_Val_01);
            this.Controls.Add(this.cmbbx_Set_08);
            this.Controls.Add(this.cmbbx_Set_07);
            this.Controls.Add(this.cmbbx_Set_06);
            this.Controls.Add(this.cmbbx_Set_05);
            this.Controls.Add(this.cmbbx_Set_04);
            this.Controls.Add(this.cmbbx_Set_03);
            this.Controls.Add(this.cmbbx_Set_02);
            this.Controls.Add(this.cmbbx_Set_01);
            this.Controls.Add(this.txtbx_KB_Val_24);
            this.Controls.Add(this.txtbx_KB_Val_23);
            this.Controls.Add(this.txtbx_KB_Val_22);
            this.Controls.Add(this.txtbx_KB_Val_21);
            this.Controls.Add(this.txtbx_KB_Val_20);
            this.Controls.Add(this.txtbx_KB_Val_19);
            this.Controls.Add(this.txtbx_KB_Val_18);
            this.Controls.Add(this.txtbx_KB_Val_17);
            this.Controls.Add(this.txtbx_KB_Val_16);
            this.Controls.Add(this.txtbx_KB_Val_15);
            this.Controls.Add(this.txtbx_KB_Val_14);
            this.Controls.Add(this.txtbx_KB_Val_13);
            this.Controls.Add(this.txtbx_KB_Val_12);
            this.Controls.Add(this.txtbx_KB_Val_11);
            this.Controls.Add(this.txtbx_KB_Val_10);
            this.Controls.Add(this.txtbx_KB_Val_09);
            this.Controls.Add(this.txtbx_KB_Val_08);
            this.Controls.Add(this.txtbx_KB_Val_07);
            this.Controls.Add(this.txtbx_KB_Val_06);
            this.Controls.Add(this.txtbx_KB_Val_05);
            this.Controls.Add(this.txtbx_KB_Val_04);
            this.Controls.Add(this.txtbx_KB_Val_03);
            this.Controls.Add(this.txtbx_KB_Val_02);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbx_KB_Val_01);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.BackGround_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(888, 730);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Tone Pedal+, Configuration Tool ver";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Set_Val_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_NC_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Status_C_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackGround_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker ReadWriteThread;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.TextBox txtbx_KB_Val_01;
        private System.Windows.Forms.PictureBox Status_C_pb;
        private System.Windows.Forms.PictureBox Status_NC_pb;
        private System.Windows.Forms.Label StatusBox_lbl;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.PictureBox BackGround_pb;
        private System.Windows.Forms.Label lbl_FW_Version;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label colum_lbl;
        private System.Windows.Forms.Label debug01_lbl;
        private System.Windows.Forms.Label debug02_lbl;
        private System.Windows.Forms.Label debug03_lbl;
        private System.Windows.Forms.TextBox txtbx_KB_Val_02;
        private System.Windows.Forms.TextBox txtbx_KB_Val_03;
        private System.Windows.Forms.TextBox txtbx_KB_Val_06;
        private System.Windows.Forms.TextBox txtbx_KB_Val_05;
        private System.Windows.Forms.TextBox txtbx_KB_Val_04;
        private System.Windows.Forms.TextBox txtbx_KB_Val_09;
        private System.Windows.Forms.TextBox txtbx_KB_Val_08;
        private System.Windows.Forms.TextBox txtbx_KB_Val_07;
        private System.Windows.Forms.TextBox txtbx_KB_Val_12;
        private System.Windows.Forms.TextBox txtbx_KB_Val_11;
        private System.Windows.Forms.TextBox txtbx_KB_Val_10;
        private System.Windows.Forms.TextBox txtbx_KB_Val_15;
        private System.Windows.Forms.TextBox txtbx_KB_Val_14;
        private System.Windows.Forms.TextBox txtbx_KB_Val_13;
        private System.Windows.Forms.TextBox txtbx_KB_Val_18;
        private System.Windows.Forms.TextBox txtbx_KB_Val_17;
        private System.Windows.Forms.TextBox txtbx_KB_Val_16;
        private System.Windows.Forms.TextBox txtbx_KB_Val_21;
        private System.Windows.Forms.TextBox txtbx_KB_Val_20;
        private System.Windows.Forms.TextBox txtbx_KB_Val_19;
        private System.Windows.Forms.TextBox txtbx_KB_Val_24;
        private System.Windows.Forms.TextBox txtbx_KB_Val_23;
        private System.Windows.Forms.TextBox txtbx_KB_Val_22;
        private System.Windows.Forms.ComboBox cmbbx_Set_01;
        private System.Windows.Forms.ComboBox cmbbx_Set_02;
        private System.Windows.Forms.ComboBox cmbbx_Set_03;
        private System.Windows.Forms.ComboBox cmbbx_Set_04;
        private System.Windows.Forms.ComboBox cmbbx_Set_05;
        private System.Windows.Forms.ComboBox cmbbx_Set_06;
        private System.Windows.Forms.ComboBox cmbbx_Set_07;
        private System.Windows.Forms.ComboBox cmbbx_Set_08;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_01;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_02;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_03;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_04;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_05;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_06;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_07;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_08;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_10;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_09;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_12;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_11;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_14;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_13;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_16;
        private System.Windows.Forms.NumericUpDown nud_Set_Val_15;
        private System.Windows.Forms.Label lbl_title_01;
        private System.Windows.Forms.Label lbl_title_02;
        private System.Windows.Forms.Label lbl_title_03;
        private System.Windows.Forms.Label lbl_title_04;
        private System.Windows.Forms.Label lbl_title_05;
        private System.Windows.Forms.Label lbl_title_06;
        private System.Windows.Forms.Label lbl_title_07;
        private System.Windows.Forms.Label lbl_title_08;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_soft_reset;
        private System.Windows.Forms.Button btn_key_clr_01;
        private System.Windows.Forms.Button btn_key_clr_02;
        private System.Windows.Forms.Button btn_key_clr_03;
        private System.Windows.Forms.Button btn_key_clr_04;
        private System.Windows.Forms.Button btn_key_clr_05;
        private System.Windows.Forms.Button btn_key_clr_06;
        private System.Windows.Forms.Button btn_key_clr_07;
        private System.Windows.Forms.Button btn_key_clr_08;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_01;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_02;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_03;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_04;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_05;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_06;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_12;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_11;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_10;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_09;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_08;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_07;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_18;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_17;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_16;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_15;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_14;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_13;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_24;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_23;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_22;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_21;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_20;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_19;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_30;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_29;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_28;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_27;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_26;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_25;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_36;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_35;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_34;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_33;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_32;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_31;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_42;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_41;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_40;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_39;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_38;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_37;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_48;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_47;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_46;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_45;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_44;
        private System.Windows.Forms.CheckBox chkbx_key_modifier_43;
        private System.Windows.Forms.Button btn_eeprom_init;
        private System.Windows.Forms.ImageList ilist_set_btn;
        private System.Windows.Forms.ImageList ilist_loadsave_btn;
        private System.Windows.Forms.ImageList ilist_reset_btn;
    }
}

