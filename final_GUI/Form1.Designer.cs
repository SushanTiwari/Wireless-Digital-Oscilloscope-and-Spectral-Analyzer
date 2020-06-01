namespace final_GUI
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
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bluetoothSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.linear_db = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.freq_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.peak_to_peak = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.max_sampling_freq = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.trigger_value = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(16, 438);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(641, 374);
            this.zedGraphControl2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bluetoothSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bluetoothSettingsToolStripMenuItem
            // 
            this.bluetoothSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOMPortToolStripMenuItem});
            this.bluetoothSettingsToolStripMenuItem.Name = "bluetoothSettingsToolStripMenuItem";
            this.bluetoothSettingsToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.bluetoothSettingsToolStripMenuItem.Text = "Bluetooth Settings";
            // 
            // cOMPortToolStripMenuItem
            // 
            this.cOMPortToolStripMenuItem.Name = "cOMPortToolStripMenuItem";
            this.cOMPortToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.cOMPortToolStripMenuItem.Text = "COM Port";
            this.cOMPortToolStripMenuItem.Click += new System.EventHandler(this.COMPortToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 818);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1196, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Yellow;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 20);
            this.toolStripStatusLabel1.Text = "Bluetooth Status:";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 18);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(665, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(527, 770);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.richTextBox1);
            this.groupBox11.Location = new System.Drawing.Point(20, 654);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(237, 110);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Keyboard Terminal";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(11, 21);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(217, 80);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox13);
            this.groupBox6.Controls.Add(this.groupBox12);
            this.groupBox6.Location = new System.Drawing.Point(8, 436);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(509, 210);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Vertical";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.groupBox10);
            this.groupBox13.Controls.Add(this.button4);
            this.groupBox13.Controls.Add(this.trackBar3);
            this.groupBox13.Location = new System.Drawing.Point(31, 23);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox13.Size = new System.Drawing.Size(228, 180);
            this.groupBox13.TabIndex = 9;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Analog Control";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox2);
            this.groupBox10.Location = new System.Drawing.Point(36, 116);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(160, 57);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Voltage/Div";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 23);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "1V";
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(63, 76);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 4;
            this.button4.Text = "Analog";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(36, 23);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar3.Maximum = 8;
            this.trackBar3.Minimum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(160, 56);
            this.trackBar3.TabIndex = 2;
            this.trackBar3.Value = 1;
            this.trackBar3.ValueChanged += new System.EventHandler(this.TrackBar3_ValueChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.linear_db);
            this.groupBox12.Controls.Add(this.button5);
            this.groupBox12.Location = new System.Drawing.Point(279, 41);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox12.Size = new System.Drawing.Size(184, 160);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "DFT Control";
            // 
            // linear_db
            // 
            this.linear_db.BackColor = System.Drawing.Color.DarkTurquoise;
            this.linear_db.ForeColor = System.Drawing.Color.Blue;
            this.linear_db.Location = new System.Drawing.Point(39, 33);
            this.linear_db.Margin = new System.Windows.Forms.Padding(4);
            this.linear_db.Name = "linear_db";
            this.linear_db.Size = new System.Drawing.Size(100, 28);
            this.linear_db.TabIndex = 6;
            this.linear_db.Text = "Linear";
            this.linear_db.UseVisualStyleBackColor = false;
            this.linear_db.Click += new System.EventHandler(this.Linear_db_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 92);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(132, 28);
            this.button5.TabIndex = 5;
            this.button5.Text = "DFT Phase";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.freq_box);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.peak_to_peak);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.max_sampling_freq);
            this.groupBox5.Location = new System.Drawing.Point(267, 228);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(251, 180);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Measurements";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frequency";
            // 
            // freq_box
            // 
            this.freq_box.Location = new System.Drawing.Point(115, 122);
            this.freq_box.Margin = new System.Windows.Forms.Padding(4);
            this.freq_box.Name = "freq_box";
            this.freq_box.Size = new System.Drawing.Size(129, 22);
            this.freq_box.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Peak-Peak";
            // 
            // peak_to_peak
            // 
            this.peak_to_peak.Location = new System.Drawing.Point(115, 78);
            this.peak_to_peak.Margin = new System.Windows.Forms.Padding(4);
            this.peak_to_peak.Name = "peak_to_peak";
            this.peak_to_peak.Size = new System.Drawing.Size(129, 22);
            this.peak_to_peak.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sampling Freq";
            // 
            // max_sampling_freq
            // 
            this.max_sampling_freq.Location = new System.Drawing.Point(115, 36);
            this.max_sampling_freq.Margin = new System.Windows.Forms.Padding(4);
            this.max_sampling_freq.Name = "max_sampling_freq";
            this.max_sampling_freq.Size = new System.Drawing.Size(129, 22);
            this.max_sampling_freq.TabIndex = 0;
            this.max_sampling_freq.Text = "1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.trackBar2);
            this.groupBox4.Location = new System.Drawing.Point(8, 228);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(251, 180);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trigger";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.trigger_value);
            this.groupBox8.Location = new System.Drawing.Point(27, 81);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(167, 87);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Trigger Value";
            // 
            // trigger_value
            // 
            this.trigger_value.Location = new System.Drawing.Point(8, 41);
            this.trigger_value.Margin = new System.Windows.Forms.Padding(4);
            this.trigger_value.Name = "trigger_value";
            this.trigger_value.Size = new System.Drawing.Size(132, 22);
            this.trigger_value.TabIndex = 0;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(8, 23);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(235, 56);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Value = 138;
            this.trackBar2.ValueChanged += new System.EventHandler(this.TrackBar2_ValueChanged);
            this.trackBar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBar2_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(267, 39);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(251, 181);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Run Control";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(76, 69);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 3;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.comboBox1);
            this.groupBox7.Location = new System.Drawing.Point(24, 105);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(208, 69);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Sampling Freq";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fs",
            "Fs/4",
            "Fs/16",
            "Fs/100"});
            this.comboBox1.Location = new System.Drawing.Point(20, 23);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Fs";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Single";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(24, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run/Stop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Location = new System.Drawing.Point(8, 39);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(251, 181);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Horizontal";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Location = new System.Drawing.Point(27, 69);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(163, 89);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Time/Div";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(8, 23);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(235, 56);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 2;
            this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Red;
            this.zedGraphControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.zedGraphControl1.Location = new System.Drawing.Point(16, 57);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(641, 374);
            this.zedGraphControl1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1196, 844);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Digital Oscilloscope";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bluetoothSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMPortToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox max_sampling_freq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox freq_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox peak_to_peak;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox trigger_value;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox10;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button linear_db;
    }
}

