
namespace thinger.HalconDemo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.hWindowControl = new HalconDotNet.HWindowControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_Info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_SaveExcel = new System.Windows.Forms.Button();
            this.btn_OneShot = new System.Windows.Forms.Button();
            this.btn_Grab = new System.Windows.Forms.Button();
            this.btn_StopGrab = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OpenImage = new System.Windows.Forms.Button();
            this.btn_SaveImage = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.cmb_jixing = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btn_FindShapeModel = new System.Windows.Forms.Button();
            this.btn_CreatShapeModel = new System.Windows.Forms.Button();
            this.txt_NumMatchs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Overlap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Score = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Range = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Angle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_Calib = new System.Windows.Forms.Button();
            this.btn_Measure = new System.Windows.Forms.Button();
            this.btn_CircleROI = new System.Windows.Forms.Button();
            this.cmb_CirclePointSelect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_CircleTransition = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Distance = new System.Windows.Forms.TextBox();
            this.txt_CircleSigma = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CircleThreshold = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_CircleElements = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DisMax = new System.Windows.Forms.TextBox();
            this.txt_DisMin = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_ContinueMeasure = new System.Windows.Forms.Button();
            this.cmb_Product = new System.Windows.Forms.ComboBox();
            this.btn_DeleteShapeModel = new System.Windows.Forms.Button();
            this.btn_LoadShapeModel = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_ModelName = new System.Windows.Forms.TextBox();
            this.btn_SaveShapeModel = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_Measure2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Calib1 = new System.Windows.Forms.Button();
            this.btn_Measure1 = new System.Windows.Forms.Button();
            this.btn_LineROI = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Distance1 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_AngMax = new System.Windows.Forms.TextBox();
            this.txt_AngMin = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl
            // 
            this.hWindowControl.BackColor = System.Drawing.Color.Black;
            this.hWindowControl.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl.Location = new System.Drawing.Point(24, 27);
            this.hWindowControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hWindowControl.Name = "hWindowControl";
            this.hWindowControl.Size = new System.Drawing.Size(574, 410);
            this.hWindowControl.TabIndex = 0;
            this.hWindowControl.WindowSize = new System.Drawing.Size(574, 410);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_Info);
            this.groupBox1.Location = new System.Drawing.Point(24, 455);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 307);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "系统日志";
            // 
            // lst_Info
            // 
            this.lst_Info.BackColor = System.Drawing.SystemColors.Control;
            this.lst_Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lst_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lst_Info.HideSelection = false;
            this.lst_Info.Location = new System.Drawing.Point(20, 34);
            this.lst_Info.Name = "lst_Info";
            this.lst_Info.Size = new System.Drawing.Size(536, 261);
            this.lst_Info.SmallImageList = this.imageList1;
            this.lst_Info.TabIndex = 0;
            this.lst_Info.UseCompatibleStateImageBehavior = false;
            this.lst_Info.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日期时间";
            this.columnHeader1.Width = 100;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.ico");
            this.imageList1.Images.SetKeyName(1, "warning.ico");
            this.imageList1.Images.SetKeyName(2, "error.ico");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_SaveExcel);
            this.groupBox2.Controls.Add(this.btn_OneShot);
            this.groupBox2.Controls.Add(this.btn_Grab);
            this.groupBox2.Controls.Add(this.btn_StopGrab);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_OpenImage);
            this.groupBox2.Controls.Add(this.btn_SaveImage);
            this.groupBox2.Location = new System.Drawing.Point(625, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 125);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像采集";
            // 
            // btn_SaveExcel
            // 
            this.btn_SaveExcel.Location = new System.Drawing.Point(323, 78);
            this.btn_SaveExcel.Name = "btn_SaveExcel";
            this.btn_SaveExcel.Size = new System.Drawing.Size(89, 31);
            this.btn_SaveExcel.TabIndex = 9;
            this.btn_SaveExcel.Text = "保存数据";
            this.btn_SaveExcel.UseVisualStyleBackColor = true;
            this.btn_SaveExcel.Click += new System.EventHandler(this.btn_SaveExcel_Click);
            // 
            // btn_OneShot
            // 
            this.btn_OneShot.Location = new System.Drawing.Point(119, 27);
            this.btn_OneShot.Name = "btn_OneShot";
            this.btn_OneShot.Size = new System.Drawing.Size(89, 31);
            this.btn_OneShot.TabIndex = 7;
            this.btn_OneShot.Text = "单帧采图";
            this.btn_OneShot.UseVisualStyleBackColor = true;
            this.btn_OneShot.Click += new System.EventHandler(this.btn_OneShot_Click);
            // 
            // btn_Grab
            // 
            this.btn_Grab.Location = new System.Drawing.Point(221, 27);
            this.btn_Grab.Name = "btn_Grab";
            this.btn_Grab.Size = new System.Drawing.Size(89, 31);
            this.btn_Grab.TabIndex = 6;
            this.btn_Grab.Text = "连续采图";
            this.btn_Grab.UseVisualStyleBackColor = true;
            this.btn_Grab.Click += new System.EventHandler(this.btn_Grab_Click);
            // 
            // btn_StopGrab
            // 
            this.btn_StopGrab.Location = new System.Drawing.Point(323, 27);
            this.btn_StopGrab.Name = "btn_StopGrab";
            this.btn_StopGrab.Size = new System.Drawing.Size(89, 31);
            this.btn_StopGrab.TabIndex = 6;
            this.btn_StopGrab.Text = "停止采图";
            this.btn_StopGrab.UseVisualStyleBackColor = true;
            this.btn_StopGrab.Click += new System.EventHandler(this.btn_StopGrab_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "图像处理：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "实时采集：";
            // 
            // btn_OpenImage
            // 
            this.btn_OpenImage.Location = new System.Drawing.Point(119, 78);
            this.btn_OpenImage.Name = "btn_OpenImage";
            this.btn_OpenImage.Size = new System.Drawing.Size(89, 31);
            this.btn_OpenImage.TabIndex = 5;
            this.btn_OpenImage.Text = "打开图像";
            this.btn_OpenImage.UseVisualStyleBackColor = true;
            this.btn_OpenImage.Click += new System.EventHandler(this.btn_OpenImage_Click);
            // 
            // btn_SaveImage
            // 
            this.btn_SaveImage.Location = new System.Drawing.Point(221, 78);
            this.btn_SaveImage.Name = "btn_SaveImage";
            this.btn_SaveImage.Size = new System.Drawing.Size(89, 31);
            this.btn_SaveImage.TabIndex = 4;
            this.btn_SaveImage.Text = "保存图像";
            this.btn_SaveImage.UseVisualStyleBackColor = true;
            this.btn_SaveImage.Click += new System.EventHandler(this.btn_SaveImage_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cmb_jixing);
            this.gb1.Controls.Add(this.label22);
            this.gb1.Controls.Add(this.btn_FindShapeModel);
            this.gb1.Controls.Add(this.btn_CreatShapeModel);
            this.gb1.Controls.Add(this.txt_NumMatchs);
            this.gb1.Controls.Add(this.label5);
            this.gb1.Controls.Add(this.txt_Overlap);
            this.gb1.Controls.Add(this.label4);
            this.gb1.Controls.Add(this.txt_Score);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.txt_Range);
            this.gb1.Controls.Add(this.label12);
            this.gb1.Controls.Add(this.txt_Angle);
            this.gb1.Controls.Add(this.label6);
            this.gb1.Location = new System.Drawing.Point(625, 142);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(443, 119);
            this.gb1.TabIndex = 5;
            this.gb1.TabStop = false;
            this.gb1.Text = "几何定位";
            // 
            // cmb_jixing
            // 
            this.cmb_jixing.FormattingEnabled = true;
            this.cmb_jixing.Location = new System.Drawing.Point(147, 77);
            this.cmb_jixing.Name = "cmb_jixing";
            this.cmb_jixing.Size = new System.Drawing.Size(109, 31);
            this.cmb_jixing.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(109, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 24);
            this.label22.TabIndex = 4;
            this.label22.Text = "极性";
            // 
            // btn_FindShapeModel
            // 
            this.btn_FindShapeModel.Location = new System.Drawing.Point(355, 76);
            this.btn_FindShapeModel.Name = "btn_FindShapeModel";
            this.btn_FindShapeModel.Size = new System.Drawing.Size(80, 31);
            this.btn_FindShapeModel.TabIndex = 3;
            this.btn_FindShapeModel.Text = "查找模板";
            this.btn_FindShapeModel.UseVisualStyleBackColor = true;
            this.btn_FindShapeModel.Click += new System.EventHandler(this.btn_FindShapeModel_Click);
            // 
            // btn_CreatShapeModel
            // 
            this.btn_CreatShapeModel.Location = new System.Drawing.Point(269, 76);
            this.btn_CreatShapeModel.Name = "btn_CreatShapeModel";
            this.btn_CreatShapeModel.Size = new System.Drawing.Size(80, 31);
            this.btn_CreatShapeModel.TabIndex = 3;
            this.btn_CreatShapeModel.Text = "创建模板";
            this.btn_CreatShapeModel.UseVisualStyleBackColor = true;
            this.btn_CreatShapeModel.Click += new System.EventHandler(this.btn_CreatShapeModel_Click);
            // 
            // txt_NumMatchs
            // 
            this.txt_NumMatchs.Location = new System.Drawing.Point(60, 77);
            this.txt_NumMatchs.Name = "txt_NumMatchs";
            this.txt_NumMatchs.Size = new System.Drawing.Size(40, 31);
            this.txt_NumMatchs.TabIndex = 2;
            this.txt_NumMatchs.Text = "1";
            this.txt_NumMatchs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "数量";
            // 
            // txt_Overlap
            // 
            this.txt_Overlap.Location = new System.Drawing.Point(380, 30);
            this.txt_Overlap.Name = "txt_Overlap";
            this.txt_Overlap.Size = new System.Drawing.Size(40, 31);
            this.txt_Overlap.TabIndex = 2;
            this.txt_Overlap.Text = "0.4";
            this.txt_Overlap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "重叠度";
            // 
            // txt_Score
            // 
            this.txt_Score.Location = new System.Drawing.Point(277, 30);
            this.txt_Score.Name = "txt_Score";
            this.txt_Score.Size = new System.Drawing.Size(40, 31);
            this.txt_Score.TabIndex = 2;
            this.txt_Score.Text = "0.8";
            this.txt_Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "分数";
            // 
            // txt_Range
            // 
            this.txt_Range.Location = new System.Drawing.Point(181, 30);
            this.txt_Range.Name = "txt_Range";
            this.txt_Range.Size = new System.Drawing.Size(40, 31);
            this.txt_Range.TabIndex = 2;
            this.txt_Range.Text = "360";
            this.txt_Range.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(128, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 24);
            this.label12.TabIndex = 1;
            this.label12.Text = "范围(°)";
            // 
            // txt_Angle
            // 
            this.txt_Angle.Location = new System.Drawing.Point(78, 30);
            this.txt_Angle.Name = "txt_Angle";
            this.txt_Angle.Size = new System.Drawing.Size(40, 31);
            this.txt_Angle.TabIndex = 2;
            this.txt_Angle.Text = "0";
            this.txt_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "角度(°)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btn_Calib);
            this.groupBox3.Controls.Add(this.btn_Measure);
            this.groupBox3.Controls.Add(this.btn_CircleROI);
            this.groupBox3.Controls.Add(this.cmb_CirclePointSelect);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cmb_CircleTransition);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_Distance);
            this.groupBox3.Controls.Add(this.txt_CircleSigma);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_CircleThreshold);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txt_CircleElements);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(625, 462);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 189);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "圆测量";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(338, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 31);
            this.button2.TabIndex = 26;
            this.button2.Text = "报表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Location = new System.Drawing.Point(188, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 24);
            this.label20.TabIndex = 16;
            this.label20.Text = "mm";
            // 
            // btn_Calib
            // 
            this.btn_Calib.Location = new System.Drawing.Point(338, 106);
            this.btn_Calib.Name = "btn_Calib";
            this.btn_Calib.Size = new System.Drawing.Size(80, 31);
            this.btn_Calib.TabIndex = 15;
            this.btn_Calib.Text = "标定";
            this.btn_Calib.UseVisualStyleBackColor = true;
            this.btn_Calib.Click += new System.EventHandler(this.btn_Calib_Click);
            // 
            // btn_Measure
            // 
            this.btn_Measure.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Measure.Location = new System.Drawing.Point(246, 147);
            this.btn_Measure.Name = "btn_Measure";
            this.btn_Measure.Size = new System.Drawing.Size(80, 31);
            this.btn_Measure.TabIndex = 15;
            this.btn_Measure.Text = "半径测量";
            this.btn_Measure.UseVisualStyleBackColor = false;
            this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // btn_CircleROI
            // 
            this.btn_CircleROI.Location = new System.Drawing.Point(247, 106);
            this.btn_CircleROI.Name = "btn_CircleROI";
            this.btn_CircleROI.Size = new System.Drawing.Size(80, 31);
            this.btn_CircleROI.TabIndex = 14;
            this.btn_CircleROI.Text = "圆ROI";
            this.btn_CircleROI.UseVisualStyleBackColor = true;
            this.btn_CircleROI.Click += new System.EventHandler(this.btn_CircleROI_Click);
            // 
            // cmb_CirclePointSelect
            // 
            this.cmb_CirclePointSelect.FormattingEnabled = true;
            this.cmb_CirclePointSelect.Location = new System.Drawing.Point(310, 29);
            this.cmb_CirclePointSelect.Name = "cmb_CirclePointSelect";
            this.cmb_CirclePointSelect.Size = new System.Drawing.Size(109, 31);
            this.cmb_CirclePointSelect.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 24);
            this.label11.TabIndex = 11;
            this.label11.Text = "点选择";
            // 
            // cmb_CircleTransition
            // 
            this.cmb_CircleTransition.FormattingEnabled = true;
            this.cmb_CircleTransition.Location = new System.Drawing.Point(101, 110);
            this.cmb_CircleTransition.Name = "cmb_CircleTransition";
            this.cmb_CircleTransition.Size = new System.Drawing.Size(109, 31);
            this.cmb_CircleTransition.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 24);
            this.label17.TabIndex = 9;
            this.label17.Text = "实际距离";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "极性";
            // 
            // txt_Distance
            // 
            this.txt_Distance.Location = new System.Drawing.Point(101, 151);
            this.txt_Distance.Name = "txt_Distance";
            this.txt_Distance.Size = new System.Drawing.Size(83, 31);
            this.txt_Distance.TabIndex = 6;
            this.txt_Distance.Text = "100";
            this.txt_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_CircleSigma
            // 
            this.txt_CircleSigma.Location = new System.Drawing.Point(310, 71);
            this.txt_CircleSigma.Name = "txt_CircleSigma";
            this.txt_CircleSigma.Size = new System.Drawing.Size(109, 31);
            this.txt_CircleSigma.TabIndex = 6;
            this.txt_CircleSigma.Text = "0";
            this.txt_CircleSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 3;
            this.label8.Text = "平滑系数";
            // 
            // txt_CircleThreshold
            // 
            this.txt_CircleThreshold.Location = new System.Drawing.Point(101, 67);
            this.txt_CircleThreshold.Name = "txt_CircleThreshold";
            this.txt_CircleThreshold.Size = new System.Drawing.Size(109, 31);
            this.txt_CircleThreshold.TabIndex = 7;
            this.txt_CircleThreshold.Text = "0";
            this.txt_CircleThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "边缘阈值";
            // 
            // txt_CircleElements
            // 
            this.txt_CircleElements.Location = new System.Drawing.Point(101, 28);
            this.txt_CircleElements.Name = "txt_CircleElements";
            this.txt_CircleElements.Size = new System.Drawing.Size(109, 31);
            this.txt_CircleElements.TabIndex = 8;
            this.txt_CircleElements.Text = "0";
            this.txt_CircleElements.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "搜索点数";
            // 
            // txt_DisMax
            // 
            this.txt_DisMax.Location = new System.Drawing.Point(143, 24);
            this.txt_DisMax.Name = "txt_DisMax";
            this.txt_DisMax.Size = new System.Drawing.Size(52, 31);
            this.txt_DisMax.TabIndex = 7;
            this.txt_DisMax.Text = "0";
            this.txt_DisMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_DisMin
            // 
            this.txt_DisMin.Location = new System.Drawing.Point(63, 23);
            this.txt_DisMin.Name = "txt_DisMin";
            this.txt_DisMin.Size = new System.Drawing.Size(60, 31);
            this.txt_DisMin.TabIndex = 7;
            this.txt_DisMin.Text = "0";
            this.txt_DisMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_ContinueMeasure);
            this.groupBox4.Controls.Add(this.cmb_Product);
            this.groupBox4.Controls.Add(this.btn_DeleteShapeModel);
            this.groupBox4.Controls.Add(this.btn_LoadShapeModel);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txt_ModelName);
            this.groupBox4.Controls.Add(this.btn_SaveShapeModel);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(625, 657);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(443, 105);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "模板管理";
            // 
            // btn_ContinueMeasure
            // 
            this.btn_ContinueMeasure.Location = new System.Drawing.Point(339, 62);
            this.btn_ContinueMeasure.Name = "btn_ContinueMeasure";
            this.btn_ContinueMeasure.Size = new System.Drawing.Size(80, 31);
            this.btn_ContinueMeasure.TabIndex = 13;
            this.btn_ContinueMeasure.Text = "连续测量";
            this.btn_ContinueMeasure.UseVisualStyleBackColor = true;
            this.btn_ContinueMeasure.Click += new System.EventHandler(this.btn_ContinueMeasure_Click);
            // 
            // cmb_Product
            // 
            this.cmb_Product.FormattingEnabled = true;
            this.cmb_Product.Location = new System.Drawing.Point(103, 63);
            this.cmb_Product.Name = "cmb_Product";
            this.cmb_Product.Size = new System.Drawing.Size(109, 31);
            this.cmb_Product.TabIndex = 12;
            // 
            // btn_DeleteShapeModel
            // 
            this.btn_DeleteShapeModel.Location = new System.Drawing.Point(339, 25);
            this.btn_DeleteShapeModel.Name = "btn_DeleteShapeModel";
            this.btn_DeleteShapeModel.Size = new System.Drawing.Size(80, 31);
            this.btn_DeleteShapeModel.TabIndex = 9;
            this.btn_DeleteShapeModel.Text = "删除模板";
            this.btn_DeleteShapeModel.UseVisualStyleBackColor = true;
            this.btn_DeleteShapeModel.Click += new System.EventHandler(this.btn_DeleteShapeModel_Click);
            // 
            // btn_LoadShapeModel
            // 
            this.btn_LoadShapeModel.Location = new System.Drawing.Point(247, 62);
            this.btn_LoadShapeModel.Name = "btn_LoadShapeModel";
            this.btn_LoadShapeModel.Size = new System.Drawing.Size(80, 31);
            this.btn_LoadShapeModel.TabIndex = 10;
            this.btn_LoadShapeModel.Text = "加载模板";
            this.btn_LoadShapeModel.UseVisualStyleBackColor = true;
            this.btn_LoadShapeModel.Click += new System.EventHandler(this.btn_LoadShapeModel_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 24);
            this.label15.TabIndex = 5;
            this.label15.Text = "模板名称";
            // 
            // txt_ModelName
            // 
            this.txt_ModelName.Location = new System.Drawing.Point(103, 27);
            this.txt_ModelName.Name = "txt_ModelName";
            this.txt_ModelName.Size = new System.Drawing.Size(109, 31);
            this.txt_ModelName.TabIndex = 8;
            this.txt_ModelName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SaveShapeModel
            // 
            this.btn_SaveShapeModel.Location = new System.Drawing.Point(247, 25);
            this.btn_SaveShapeModel.Name = "btn_SaveShapeModel";
            this.btn_SaveShapeModel.Size = new System.Drawing.Size(80, 31);
            this.btn_SaveShapeModel.TabIndex = 11;
            this.btn_SaveShapeModel.Text = "保存模板";
            this.btn_SaveShapeModel.UseVisualStyleBackColor = true;
            this.btn_SaveShapeModel.Click += new System.EventHandler(this.btn_SaveShapeModel_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(29, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 24);
            this.label16.TabIndex = 7;
            this.label16.Text = "模板选择";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_Measure2);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.btn_Calib1);
            this.groupBox5.Controls.Add(this.btn_Measure1);
            this.groupBox5.Controls.Add(this.btn_LineROI);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txt_Distance1);
            this.groupBox5.Location = new System.Drawing.Point(625, 332);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(443, 132);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "线测量";
            // 
            // btn_Measure2
            // 
            this.btn_Measure2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Measure2.Location = new System.Drawing.Point(247, 60);
            this.btn_Measure2.Name = "btn_Measure2";
            this.btn_Measure2.Size = new System.Drawing.Size(80, 31);
            this.btn_Measure2.TabIndex = 30;
            this.btn_Measure2.Text = "线角度测量";
            this.btn_Measure2.UseVisualStyleBackColor = false;
            this.btn_Measure2.Click += new System.EventHandler(this.btn_Measure2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 25;
            this.button1.Text = "报表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Location = new System.Drawing.Point(189, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 24);
            this.label21.TabIndex = 24;
            this.label21.Text = "mm";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(97, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(109, 31);
            this.comboBox1.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 24);
            this.label14.TabIndex = 22;
            this.label14.Text = "极性";
            // 
            // btn_Calib1
            // 
            this.btn_Calib1.Location = new System.Drawing.Point(340, 21);
            this.btn_Calib1.Name = "btn_Calib1";
            this.btn_Calib1.Size = new System.Drawing.Size(80, 31);
            this.btn_Calib1.TabIndex = 20;
            this.btn_Calib1.Text = "标定";
            this.btn_Calib1.UseVisualStyleBackColor = true;
            this.btn_Calib1.Click += new System.EventHandler(this.btn_Calib1_Click);
            // 
            // btn_Measure1
            // 
            this.btn_Measure1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Measure1.Location = new System.Drawing.Point(340, 58);
            this.btn_Measure1.Name = "btn_Measure1";
            this.btn_Measure1.Size = new System.Drawing.Size(80, 31);
            this.btn_Measure1.TabIndex = 21;
            this.btn_Measure1.Text = "线距离测量";
            this.btn_Measure1.UseVisualStyleBackColor = false;
            this.btn_Measure1.Click += new System.EventHandler(this.btn_Measure1_Click);
            // 
            // btn_LineROI
            // 
            this.btn_LineROI.Location = new System.Drawing.Point(247, 21);
            this.btn_LineROI.Name = "btn_LineROI";
            this.btn_LineROI.Size = new System.Drawing.Size(80, 31);
            this.btn_LineROI.TabIndex = 19;
            this.btn_LineROI.Text = "线ROI";
            this.btn_LineROI.UseVisualStyleBackColor = true;
            this.btn_LineROI.Click += new System.EventHandler(this.btn_LineROI_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 24);
            this.label13.TabIndex = 17;
            this.label13.Text = "实际距离";
            // 
            // txt_Distance1
            // 
            this.txt_Distance1.Location = new System.Drawing.Point(97, 60);
            this.txt_Distance1.Name = "txt_Distance1";
            this.txt_Distance1.Size = new System.Drawing.Size(88, 31);
            this.txt_Distance1.TabIndex = 16;
            this.txt_Distance1.Text = "100";
            this.txt_Distance1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.txt_AngMax);
            this.groupBox6.Controls.Add(this.txt_DisMin);
            this.groupBox6.Controls.Add(this.txt_AngMin);
            this.groupBox6.Controls.Add(this.txt_DisMax);
            this.groupBox6.Location = new System.Drawing.Point(625, 264);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(443, 60);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "公差";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 24);
            this.label18.TabIndex = 29;
            this.label18.Text = "距离";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(403, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 24);
            this.label27.TabIndex = 29;
            this.label27.Text = "°";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(253, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 24);
            this.label26.TabIndex = 28;
            this.label26.Text = "角度";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(195, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 24);
            this.label24.TabIndex = 9;
            this.label24.Text = "mm";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(333, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(35, 24);
            this.label25.TabIndex = 27;
            this.label25.Text = "° ~";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(123, 26);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 24);
            this.label23.TabIndex = 8;
            this.label23.Text = "~";
            // 
            // txt_AngMax
            // 
            this.txt_AngMax.Location = new System.Drawing.Point(366, 23);
            this.txt_AngMax.Name = "txt_AngMax";
            this.txt_AngMax.Size = new System.Drawing.Size(37, 31);
            this.txt_AngMax.TabIndex = 26;
            this.txt_AngMax.Text = "0";
            this.txt_AngMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_AngMin
            // 
            this.txt_AngMin.Location = new System.Drawing.Point(296, 23);
            this.txt_AngMin.Name = "txt_AngMin";
            this.txt_AngMin.Size = new System.Drawing.Size(37, 31);
            this.txt_AngMin.TabIndex = 26;
            this.txt_AngMin.Text = "0";
            this.txt_AngMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 781);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hWindowControl);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C#与Halcon联合编程——几何定位与测量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HalconDotNet.HWindowControl hWindowControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lst_Info;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_OneShot;
        private System.Windows.Forms.Button btn_Grab;
        private System.Windows.Forms.Button btn_StopGrab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OpenImage;
        private System.Windows.Forms.Button btn_SaveImage;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btn_FindShapeModel;
        private System.Windows.Forms.Button btn_CreatShapeModel;
        private System.Windows.Forms.TextBox txt_NumMatchs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Overlap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Score;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Range;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Angle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Calib;
        private System.Windows.Forms.Button btn_Measure;
        private System.Windows.Forms.Button btn_CircleROI;
        private System.Windows.Forms.ComboBox cmb_CirclePointSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_CircleTransition;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Distance;
        private System.Windows.Forms.TextBox txt_CircleSigma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_DisMax;
        private System.Windows.Forms.TextBox txt_DisMin;
        private System.Windows.Forms.TextBox txt_CircleThreshold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_CircleElements;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_ContinueMeasure;
        private System.Windows.Forms.ComboBox cmb_Product;
        private System.Windows.Forms.Button btn_DeleteShapeModel;
        private System.Windows.Forms.Button btn_LoadShapeModel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_ModelName;
        private System.Windows.Forms.Button btn_SaveShapeModel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_Calib1;
        private System.Windows.Forms.Button btn_Measure1;
        private System.Windows.Forms.Button btn_LineROI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Distance1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_SaveExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmb_jixing;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btn_Measure2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_AngMax;
        private System.Windows.Forms.TextBox txt_AngMin;
    }
}

