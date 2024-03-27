using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thinger.HalconDemo
{

    /// <summary>
    /// 圆极性
    /// </summary>
    public enum CircleTransition
    {
        all,
        positive,
        negative
    }
    public enum MatchTransition
    {
        use_polarity,
        ignore_global_polarity,
        ignore_local_polarity,
        ignore_color_polarity

    }

    public enum LineTransition
    {
        all,
        positive,
        negative
    }

    /// <summary>
    /// 点选择
    /// </summary>
    public enum CirclePointSelect
    {
        max,
        first,
        last
    }


    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitialShapeModeList();
            InitialParam();

            this.lst_Info.Columns[1].Width = this.lst_Info.Width - this.lst_Info.Columns[0].Width;

            var result = halcon.HalconInitial(this.hWindowControl, out hWindowHandle);

            if (result.IsSuccess)
            {
                AddLog(0, "Halcon初始化成功");

            }

            else
            {
                AddLog(1, "Halcon初始化失败：" + result.ErrorMsg);

                return;
            }

            if (image.isCamOK == false)
            {
                result = image.OpenCam(camName);
                if (result.IsSuccess)
                {

                    AddLog(0, "相机打开成功");
                }
                else
                {

                    AddLog(1, "相机打开失败：" + result.ErrorMsg);
                    return;
                }
            }

        }

        private const string camName = "c42f90fe697d_Hikrobot_MVCE10031GM"; //相机名字

        //创建一个ImageHelper对象
        private ImageHelper image = new ImageHelper();

        //创建一个hWindowHandle

        private HTuple hWindowHandle = new HTuple();

        //创建一个hImage

        private HObject hImage = new HObject();

        //创建一个Halcon操作对象

        private HalconHelper halcon = new HalconHelper();

        //连续采图线程标志
        private CancellationTokenSource cts;

        //创建一个模板匹配对象

        private ShapeModeHelper shapeModel = new ShapeModeHelper();

        //创建一个匹配参数对象

        private MatchParams matchParams = new MatchParams();

        //创建一个圆参数对象
        private CircleParams circleParams = new CircleParams();

        //创建一个线参数对象
        private LineParams lineParams = new LineParams();

        //创建一个数据库对象
        private SQLite sql = new SQLite();


        private Form2 Form2 = new Form2();

        public List<string> nei = new List<string>();

        public List<string> gsmc = new List<string>();

        public List<string> cpmc = new List<string>();

        private List<string> cly = new List<string>();

        public List<string> clsj = new List<string>();


        //初始化参数
        private void InitialParam()
        {


            this.cmb_CircleTransition.DataSource = Enum.GetNames(typeof(CircleTransition));
            this.comboBox1.DataSource = Enum.GetNames(typeof(LineTransition));
            this.cmb_jixing.DataSource = Enum.GetNames(typeof(MatchTransition));
            this.cmb_CirclePointSelect.DataSource = Enum.GetNames(typeof(CirclePointSelect));

            //初始化参数
            this.txt_Angle.Text = matchParams.startAngle.ToString();
            this.txt_Range.Text = matchParams.rangeAngle.ToString();
            this.txt_Overlap.Text = matchParams.overlap.ToString();
            this.txt_Score.Text = matchParams.score.ToString();
            this.txt_NumMatchs.Text = matchParams.numMatchs.ToString();


            this.txt_CircleElements.Text = circleParams.circle_Elements.ToString();
            this.txt_CircleThreshold.Text = circleParams.circle_Threshold.ToString();
            this.txt_CircleSigma.Text = circleParams.circle_Sigma.ToString();
            this.cmb_CircleTransition.Text = circleParams.circle_Transition;
            this.comboBox1.Text = lineParams.line_Transition;
            this.cmb_jixing.Text = matchParams.metric;
            this.cmb_CirclePointSelect.Text = circleParams.circle_Point_Select;

            this.txt_DisMin.Text = circleParams.circle_Dis_Min.ToString();
            this.txt_DisMax.Text = circleParams.circle_Dis_Max.ToString();

        }

        //打开图像
        private void btn_OpenImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = ".bmp|*.bmp|.png|*.png|.jpg|*.jpg|.tif|*.tif|.jpeg|*.jpeg";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;

                    var result = image.ReadImage(path, ref hWindowHandle, ref hImage);
                    if (result.IsSuccess)

                    {
                        AddLog(0, "打开图像成功");
                    }

                    else
                    {

                        AddLog(1, "打开图像失败：" + result.ErrorMsg);
                    }
                }
            }
        }

        //保存图像
        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = ".bmp|*.bmp|.png|*.png|.jpg|*.jpg|.jpeg|*.jpeg";
                saveFileDialog.DefaultExt = ".bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = image.SaveImage(saveFileDialog.FileName, saveFileDialog.FileName.Substring(saveFileDialog.FileName.LastIndexOf('.') + 1), hImage);
                    if (result.IsSuccess)
                    {

                        AddLog(0, "图像保存成功");
                    }
                    else
                    {

                        AddLog(1, "图像保存失败：" + result.ErrorMsg);
                    }
                }
            }
        }

        //采集单帧图像
        private void btn_OneShot_Click(object sender, EventArgs e)
        {
            var result = image.GrabImage(ref hWindowHandle, ref hImage);

            if (result.IsSuccess)
            {
                AddLog(0, "图像采集成功");
            }
            else
            {
                AddLog(1, "图像采集失败：" + result.ErrorMsg);
            }

        }
        #region MyRegion 显示信息

        private string CurrentTime
        {
            get { return DateTime.Now.ToString("HH:mm:ss"); }
        }

        private void AddLog(int index, string log)
        {
            if (this.lst_Info.InvokeRequired)
            {
                this.lst_Info.Invoke(new Action(() =>
                {
                    ListViewItem listViewItem = new ListViewItem(" " + CurrentTime, index);
                    listViewItem.SubItems.Add(log);
                    this.lst_Info.Items.Insert(0, listViewItem);
                }));
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem(" " + CurrentTime, index);
                listViewItem.SubItems.Add(log);
                this.lst_Info.Items.Insert(0, listViewItem);
            }
        }

        #endregion

        #region 连续采集单帧图像
        private void btn_Grab_Click(object sender, EventArgs e)
        {
            if (image.isCamOK == false)
            {
                var result = image.OpenCam(camName);
                if (result.IsSuccess)
                {
                    AddLog(0, "相机打开成功");
                }
                else
                {
                    AddLog(1, "相机打开失败：" + result.ErrorMsg);
                    return;
                }
            }
            cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                GrabImageThread();
            }, cts.Token);
            AddLog(0, "开始连续彩图");
        }

        private void GrabImageThread()
        {
            while (!cts.IsCancellationRequested)
            {
                if (image.isCamOK)
                {
                    var result = image.GrabImage(ref hWindowHandle, ref hImage);

                    if (result.IsSuccess)
                    {
                        //处理
                    }

                    else
                    {
                        AddLog(1, "连续彩图失败");
                        break;
                    }
                }
                else
                {
                    AddLog(1, "连续彩图失败");
                    break;
                }

            }
        }

        #endregion

        //停止采集图像
        private void btn_StopGrab_Click(object sender, EventArgs e)
        {
            AddLog(0, "停止连续彩图");

            cts.Cancel();
        }

        //创建模板
        private void btn_CreatShapeModel_Click(object sender, EventArgs e)
        {
            this.hWindowControl.Focus();
            matchParams.metric = this.cmb_jixing.Text;
            var result = shapeModel.CreateShapeMode(hWindowHandle, hImage, matchParams);

            if (result.IsSuccess)
            {
                AddLog(0, "创建模板成功");
            }
        }

        //查找模板
        private void btn_FindShapeModel_Click(object sender, EventArgs e)
        {
            //判断图像
            if (!halcon.ObjectValided(hImage))
            {
                AddLog(1, "查找模板失败：图像不存在");
                return;
            }


            if (matchParams.modelId == null)
            {
                AddLog(1, "查找模板失败：模板不存在");
                return;
            }

            matchParams.startAngle = Convert.ToDouble(this.txt_Angle.Text.Trim()); //起始角度
            matchParams.rangeAngle = Convert.ToDouble(this.txt_Range.Text.Trim()); //范围
            matchParams.overlap = Convert.ToDouble(this.txt_Overlap.Text.Trim()); //重叠度
            matchParams.score = Convert.ToDouble(this.txt_Score.Text.Trim());  //分数
            matchParams.numMatchs = Convert.ToInt32(this.txt_NumMatchs.Text.Trim());//数量
            matchParams.metric = this.cmb_jixing.Text;

            var result = shapeModel.FindShapeModel(hWindowHandle, hImage, matchParams, out HTuple homMat2D);

            if (result.IsSuccess)
            {
                AddLog(0, "查找模板成功");
            }
            else
            {
                AddLog(1, "查找模板失败：" + result.ErrorMsg);
            }
        }

        //连续查找模板
        private void btn_ContinueFind_Click(object sender, EventArgs e)
        {
            if (matchParams.modelId == null)
            {
                AddLog(1, "查找模板失败：模板不存在");
                return;
            }

            matchParams.startAngle = Convert.ToDouble(this.txt_Angle.Text.Trim()); //起始角度
            matchParams.rangeAngle = Convert.ToDouble(this.txt_Range.Text.Trim()); //范围
            matchParams.overlap = Convert.ToDouble(this.txt_Overlap.Text.Trim()); //重叠度
            matchParams.score = Convert.ToDouble(this.txt_Score.Text.Trim());  //分数
            matchParams.numMatchs = Convert.ToInt32(this.txt_NumMatchs.Text.Trim());//数量

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;

                    FileInfo[] files = new DirectoryInfo(path).GetFiles();

                    Task.Run(() =>
                    {
                        foreach (var item in files)
                        {
                            if (image.ReadImage(item.FullName, ref hWindowHandle, ref hImage).IsSuccess)
                            {

                                var result = shapeModel.FindShapeModel(hWindowHandle, hImage, matchParams, out HTuple homMat2D);

                                if (!result.IsSuccess)
                                {
                                    AddLog(1, "查找模板失败：模板不存在");

                                }
                            }

                            Thread.Sleep(2000);
                        }



                    });


                }

            }
        }

        //圆ROI
        private void btn_CircleROI_Click(object sender, EventArgs e)
        {
            this.hWindowControl.Focus();

            halcon.draw_spoke3(hImage, out HObject hRegions, hWindowHandle, circleParams.circle_Elements, circleParams.circle_Caliper_Height, circleParams.circle_Caliper_Width, out circleParams.rOI_Y, out circleParams.rOI_X, out circleParams.circle_Direct);

            if (circleParams.rOI_X.Length < 4)
            {
                halcon.disp_message(hWindowHandle, "画圆ROI失败", "window", 20, 20, "red", "false");

                AddLog(1, "创建ROI失败");
            }

            else
            {
                HOperatorSet.DispObj(hImage, hWindowHandle);
                HOperatorSet.DispObj(hRegions, hWindowHandle);
                halcon.disp_message(hWindowHandle, "画圆ROI成功", "window", 20, 20, "green", "false");
                AddLog(0, "创建ROI成功");
                btn_CircleFit_Click(sender, e);
            }
        }

        //圆拟合
        private void btn_CircleFit_Click(object sender, EventArgs e)
        {
            circleParams.circle_Elements = Convert.ToInt32(this.txt_CircleElements.Text.Trim());
            circleParams.circle_Threshold = Convert.ToInt32(this.txt_CircleThreshold.Text.Trim());
            circleParams.circle_Sigma = Convert.ToInt32(this.txt_CircleSigma.Text.Trim());
            circleParams.circle_Transition = this.cmb_CircleTransition.Text;
            circleParams.circle_Point_Select = this.cmb_CirclePointSelect.Text;


            var result = halcon.Fit_Circle(hImage, 0, ref circleParams, out HObject result_Circle);

            HOperatorSet.DispObj(hImage, hWindowHandle);
            HOperatorSet.DispObj(result_Circle, hWindowHandle);

            if (result.IsSuccess)
            {
                halcon.disp_message(hWindowHandle, "圆拟合成功,圆半径：" + circleParams.circleRadius.ToString(), "window", 20, 20, "green", "false");
                AddLog(0, "圆拟合成功,圆半径：" + circleParams.circleRadius.ToString());
            }
            else
            {
                halcon.disp_message(hWindowHandle, "圆拟合失败：" + result.ErrorMsg, "window", 20, 20, "red", "false");
                AddLog(0, "圆拟合失败");
            }
        }

        //圆标定
        private void btn_Calib_Click(object sender, EventArgs e)
        {
            if (circleParams.circleRadius != null && circleParams.circleRadius.TupleInt() > 0)

            {
                circleParams.scale = Convert.ToDouble(this.txt_Distance.Text.Trim()) / (circleParams.circleRadius * 2);
                AddLog(0, "标定成功" + circleParams.scale.ToString() + "mm");
            }

            else
            {
                AddLog(1, "标定失败");

            }
        }

        #region 圆测量

        private void btn_Measure_Click(object sender, EventArgs e)
        {
            System.DateTime time1 = new System.DateTime();
            time1 = System.DateTime.Now;
            circleParams.circle_Dis_Max = Convert.ToDouble(this.txt_DisMax.Text.Trim());

            circleParams.circle_Dis_Min = Convert.ToDouble(this.txt_DisMin.Text.Trim());

            var result = Measure(hImage, hWindowHandle);

            if (result.IsSuccess)
            {
                AddLog(0, "测量成功，结果为：" + circleParams.distance.ToString("F4") + "mm");

                if (true)
                {
                    System.DateTime time2 = new System.DateTime();
                    time2 = System.DateTime.Now;
                    TimeSpan time3 = time2 - time1;
                    string time4 = (1000*time3.TotalSeconds).ToString("F2");
                    string time5 = time2.ToString();
                    //string Ins = "insert into Circle(time,radius,divide)values" + "('" + time4 + "','" + circleParams.distance.ToString("F4") + "mm" + "','" + circleParams.ResultStr + "')";
                    //sql.Execute(Ins);

                    nei.Add("圆半径");
                    gsmc.Add("xxx公司");
                    cpmc.Add("硬币");
                    circleParams.time.Add(time4 + "ms");
                    circleParams.dis.Add(circleParams.distance.ToString("F4") + "mm");
                    circleParams.div.Add(circleParams.ResultStr);
                    cly.Add("aa");
                    clsj.Add(time5);

                }//数据存入数据库
            }
            else
            {
                AddLog(1, "测量失败：" + result.ErrorMsg);
            }
        }

        private OperationResult Measure(HObject hImage, HTuple hWindowHandle)
        {
            try
            {
                HTuple ResultStr = new HTuple();

                //查找模板
                matchParams.startAngle = Convert.ToDouble(this.txt_Angle.Text.Trim()); //起始角度
                matchParams.rangeAngle = Convert.ToDouble(this.txt_Range.Text.Trim()); //范围
                matchParams.overlap = Convert.ToDouble(this.txt_Overlap.Text.Trim()); //重叠度
                matchParams.score = Convert.ToDouble(this.txt_Score.Text.Trim());  //分数
                matchParams.numMatchs = Convert.ToInt32(this.txt_NumMatchs.Text.Trim());//数量

                var result = shapeModel.FindShapeModel(hWindowHandle, hImage, matchParams, out HTuple homMat2D);



                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = result.ErrorMsg;

                result = halcon.Fit_Circle(hImage, homMat2D, ref circleParams, out HObject result_Circle);

                HOperatorSet.DispObj(result_Circle, hWindowHandle);

                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = ResultStr.TupleConcat(result.ErrorMsg);

                circleParams.distance = circleParams.scale * circleParams.circleRadius * 2;

                ResultStr = ResultStr.TupleConcat("测量距离成功");
                ResultStr = ResultStr.TupleConcat("测量距离：" + circleParams.distance.ToString("F4") + "mm");

                if (circleParams.distance >= circleParams.circle_Dis_Min && circleParams.distance <= circleParams.circle_Dis_Max)
                {
                    ResultStr = ResultStr.TupleConcat("OK");

                    circleParams.ResultStr = "OK";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "green", "false");
                }
                else
                {
                    ResultStr = ResultStr.TupleConcat("NG");

                    circleParams.ResultStr = "NG";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "red", "false");
                }


                return OperationResult.CreateSuccessResult();

            }
            catch (Exception ex)
            {
                halcon.disp_message(hWindowHandle, "测量失败：" + ex.Message, "window", 20, 20, "red", "false");

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = ex.Message
                };
            }
        }

        #endregion

        #region 保存模板


        private string basePath = Application.StartupPath + "\\model";

        private void btn_SaveShapeModel_Click(object sender, EventArgs e)
        {
            //判断
            if (this.txt_ModelName.Text.Trim().Length == 0)
            {
                MessageBox.Show("模板名称不能为空", "保存模板");
                return;
            }

            if (shapeModel.GetAllShapeModels(basePath).Contains(this.txt_ModelName.Text.Trim()))
            {
                DialogResult dialogResult = MessageBox.Show("模板名称已经存在，是否覆盖？", "创建模板", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            //文件夹路径
            string path = basePath + "\\" + this.txt_ModelName.Text.Trim();

            //如果包含，删除
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                directoryInfo.Delete(true);
            }

            //创建文件夹
            Directory.CreateDirectory(path);

            var result = shapeModel.SaveShapeModel(path, matchParams, circleParams);

            if (result.IsSuccess)
            {
                InitialShapeModeList();

                AddLog(0, "模板保存成功,模板名称：" + this.txt_ModelName.Text.Trim());
            }
            else
            {
                AddLog(1, "模板保存失败：" + result.ErrorMsg);
            }
        }
        #endregion

        //初始化模板显示
        private void InitialShapeModeList()
        {
            this.cmb_Product.Items.Clear();

            this.cmb_Product.Text = "";

            var list = shapeModel.GetAllShapeModels(basePath).ToArray();

            if (list.Length > 0)
            {
                this.cmb_Product.Items.AddRange(shapeModel.GetAllShapeModels(basePath).ToArray());

                this.cmb_Product.SelectedIndex = 0;
            }
        }
        //删除模板
        private void btn_DeleteShapeModel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("是否确定要删除模板名？", "删除模板", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                //文件夹路径
                string path = basePath + "\\" + this.cmb_Product.Text.Trim();
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                directoryInfo.Delete(true);

                InitialShapeModeList();

                AddLog(0, "删除模板成功");
            }
        }
        //加载模板
        private void btn_LoadShapeModel_Click(object sender, EventArgs e)
        {
            string path = basePath + "\\" + this.cmb_Product.Text.Trim();

            var result = shapeModel.LoadShapeModel(path, ref matchParams, ref circleParams);

            if (result.IsSuccess)
            {
                InitialParam();
                AddLog(0, "模板加载成功：" + this.cmb_Product.Text.Trim());
            }
            else
            {
                AddLog(1, "模板加载失败");
            }
        }
        //连续测量
        private void btn_ContinueMeasure_Click(object sender, EventArgs e)
        {

            circleParams.circle_Dis_Max = Convert.ToDouble(this.txt_DisMax.Text.Trim());
            circleParams.circle_Dis_Min = Convert.ToDouble(this.txt_DisMin.Text.Trim());

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;

                    FileInfo[] files = new DirectoryInfo(path).GetFiles();

                    Task.Run(() =>
                    {
                        foreach (var item in files)
                        {
                            if (image.ReadImage(item.FullName, ref hWindowHandle, ref hImage).IsSuccess)
                            {
                                var result = Measure(hImage, hWindowHandle);

                                if (result.IsSuccess)
                                {
                                    AddLog(0, "测量成功，结果为：" + circleParams.distance.ToString("F4"));
                                }
                                else
                                {
                                    AddLog(1, "测量失败：" + result.ErrorMsg);
                                }
                            }

                            Thread.Sleep(2000);
                        }

                    });


                }

            }
        }

        //直线ROI
        private void btn_LineROI_Click(object sender, EventArgs e)
        {

            this.hWindowControl.Focus();

            HOperatorSet.CreateMetrologyModel(out lineParams.MetrologyHandle);
            HOperatorSet.CreateMetrologyModel(out lineParams.MetrologyHandle1);
            halcon.disp_message(hWindowHandle, "请画出要识别的第一直线", "window", 20, 20, "red", "false");
            lineParams.line_Transition = this.comboBox1.Text;

            //画第一条线
            HOperatorSet.DrawLine(hWindowHandle, out lineParams.row1, out lineParams.column1, out lineParams.row2, out lineParams.column2);
            HOperatorSet.AddMetrologyObjectLineMeasure(lineParams.MetrologyHandle, lineParams.row1, lineParams.column1, lineParams.row2, lineParams.column2, 20, 5, 1, 30, new HTuple(), new HTuple(), out lineParams.Index1);
            HOperatorSet.ApplyMetrologyModel(hImage, lineParams.MetrologyHandle);
            HOperatorSet.GetMetrologyObjectResultContour(out lineParams.ho_Contour, lineParams.MetrologyHandle, 0, "all", 1.5);
            HOperatorSet.DispObj(lineParams.ho_Contour, hWindowHandle);

            HOperatorSet.GetMetrologyObjectResult(lineParams.MetrologyHandle, 0, lineParams.line_Transition, "result_type", "all_param", out lineParams.LineModel);

            if (lineParams.LineModel.Length == 0)
            {
                halcon.disp_message(hWindowHandle, "画线ROI失败", "window", 20, 20, "red", "false");

                AddLog(1, "创建ROI失败");
            }

            else
            {

                HOperatorSet.AddMetrologyObjectLineMeasure(lineParams.MetrologyHandle1, lineParams.LineModel.TupleSelect(0), lineParams.LineModel.TupleSelect(1), lineParams.LineModel.TupleSelect(2), lineParams.LineModel.TupleSelect(3), 20, 5, 1, 30, new HTuple(), new HTuple(), out lineParams.Index1);

                //HOperatorSet.AreaCenter(matchParams.modelRegion, out HTuple area, out HTuple row, out HTuple column);
                //HOperatorSet.SetMetrologyModelParam(MetrologyHandle1, "reference_system", ((row.TupleConcat(column))).TupleConcat(0));
                HOperatorSet.ApplyMetrologyModel(hImage, lineParams.MetrologyHandle1);
                HOperatorSet.GetMetrologyObjectResult(lineParams.MetrologyHandle1, 0, lineParams.line_Transition, "result_type", "all_param", out lineParams.LineModel);

                lineParams.L1StartRowDraw = lineParams.LineModel.TupleSelect(0);
                lineParams.L1StartColumnDraw = lineParams.LineModel.TupleSelect(1);
                lineParams.L1EndRowDraw = lineParams.LineModel.TupleSelect(2);
                lineParams.L1EndColumnDraw = lineParams.LineModel.TupleSelect(3);


                halcon.disp_message(hWindowHandle, "请画出要识别的第二直线", "window", 20, 20, "red", "false");

                //画第二条线
                HOperatorSet.DrawLine(hWindowHandle, out lineParams.row1, out lineParams.column1, out lineParams.row2, out lineParams.column2);
                HOperatorSet.AddMetrologyObjectLineMeasure(lineParams.MetrologyHandle, lineParams.row1, lineParams.column1, lineParams.row2, lineParams.column2, 20, 5, 1, 30, new HTuple(), new HTuple(), out lineParams.Index2);

                HOperatorSet.ApplyMetrologyModel(hImage, lineParams.MetrologyHandle);
                HOperatorSet.GetMetrologyObjectResultContour(out lineParams.ho_Contour, lineParams.MetrologyHandle, 1, "all", 1.5);
                HOperatorSet.DispObj(lineParams.ho_Contour, hWindowHandle);

                HOperatorSet.GetMetrologyObjectResult(lineParams.MetrologyHandle, 1, lineParams.line_Transition, "result_type", "all_param", out lineParams.LineMode2);


                if (lineParams.LineMode2.Length == 0)
                {
                    halcon.disp_message(hWindowHandle, "画线ROI失败", "window", 20, 20, "red", "false");

                    AddLog(1, "创建ROI失败");
                }

                else
                {

                    HOperatorSet.AddMetrologyObjectLineMeasure(lineParams.MetrologyHandle1, lineParams.LineMode2.TupleSelect(0), lineParams.LineMode2.TupleSelect(1), lineParams.LineMode2.TupleSelect(2), lineParams.LineMode2.TupleSelect(3), 20, 5, 1, 30, new HTuple(), new HTuple(), out lineParams.Index2);

                    //HOperatorSet.AreaCenter(matchParams.modelRegion, out HTuple area, out HTuple row, out HTuple column);
                    //HOperatorSet.SetMetrologyModelParam(MetrologyHandle1, "reference_system", ((row.TupleConcat(column))).TupleConcat(0));
                    HOperatorSet.ApplyMetrologyModel(hImage, lineParams.MetrologyHandle1);
                    HOperatorSet.GetMetrologyObjectResult(lineParams.MetrologyHandle1, 1, lineParams.line_Transition, "result_type", "all_param", out lineParams.LineMode2);

                    lineParams.L2StartRowDraw = lineParams.LineMode2.TupleSelect(0);
                    lineParams.L2StartColumnDraw = lineParams.LineMode2.TupleSelect(1);
                    lineParams.L2EndRowDraw = lineParams.LineMode2.TupleSelect(2);
                    lineParams.L2EndColumnDraw = lineParams.LineMode2.TupleSelect(3);

                    halcon.disp_message(hWindowHandle, "画线ROI成功", "window", 20, 20, "green", "false");
                    AddLog(0, "创建ROI成功");
                    halcon.disp_message(hWindowHandle, "线拟合成功", "window", 20, 20, "green", "false");
                    AddLog(0, "线拟合成功");
                }
            }

        }

        //直线测量
        private void btn_Measure1_Click(object sender, EventArgs e)
        {
            System.DateTime time1 = new System.DateTime();
            time1 = System.DateTime.Now;
            circleParams.circle_Dis_Max = Convert.ToDouble(this.txt_DisMax.Text.Trim());
            circleParams.circle_Dis_Min = Convert.ToDouble(this.txt_DisMin.Text.Trim());

            var result = MeasureLine(hImage, hWindowHandle);

            if (result.IsSuccess)
            {

                if (true)
                {
                    AddLog(0, "测量成功，结果为：" + lineParams.distance.ToString("F4") + "mm");
                    System.DateTime time2 = new System.DateTime();
                    time2 = System.DateTime.Now;
                    TimeSpan time3 = time2 - time1;
                    string time4 = (1000 * time3.TotalSeconds).ToString("F2");
                    string time5 = time2.ToString();
                    //string Ins = "insert into line(time,dis,angle)values" + "('" + time4 + "','" + lineParams.distance.ToString("F4") + "mm" + "','" + lineParams.ResultStr + "')";
                    //sql.Execute(Ins);

                    nei.Add("线距离");
                    gsmc.Add("xxx公司");
                    cpmc.Add("石英晶振");
                    lineParams.time.Add(time4 + "ms");
                    lineParams.dis.Add(lineParams.distance.ToString("F4") + "mm");
                    lineParams.div.Add(lineParams.ResultStr);
                    cly.Add("aa");
                    clsj.Add(time5);

                }//数据存入数据库
            }
            else
            {
                AddLog(1, "测量失败：" + result.ErrorMsg);
            }
        }

        private OperationResult MeasureLine(HObject hImage, HTuple hWindowHandle)
        {
            try
            {
                HTuple ResultStr = new HTuple();

                //查找模板
                matchParams.startAngle = Convert.ToDouble(this.txt_Angle.Text.Trim()); //起始角度
                matchParams.rangeAngle = Convert.ToDouble(this.txt_Range.Text.Trim()); //范围
                matchParams.overlap = Convert.ToDouble(this.txt_Overlap.Text.Trim()); //重叠度
                //matchParams.score = 0.4;
                matchParams.score = Convert.ToDouble(this.txt_Score.Text.Trim());  //分数
                matchParams.numMatchs = Convert.ToInt32(this.txt_NumMatchs.Text.Trim());//数量

                var result = shapeModel.FindShapeModel(hWindowHandle, hImage, matchParams, out HTuple homMat2D);



                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = result.ErrorMsg;

                result = halcon.Fit_Line(hImage, homMat2D, ref lineParams, out HObject result_Line, out HObject result_Line2, out HTuple LineModel, out HTuple LineMode2);

                HOperatorSet.DispObj(hImage, hWindowHandle);
                HOperatorSet.DispObj(result_Line, hWindowHandle);
                HOperatorSet.DispObj(result_Line2, hWindowHandle);

                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = ResultStr.TupleConcat(result.ErrorMsg);

                HOperatorSet.AngleLl(LineModel[0], LineModel[1], LineModel[2], LineModel[3], LineMode2[0], LineMode2[1], LineMode2[2], LineMode2[3], out HTuple angle);

                HOperatorSet.DistanceSs(LineModel[0], LineModel[1], LineModel[2], LineModel[3], LineMode2[0], LineMode2[1], LineMode2[2], LineMode2[3], out HTuple distanceMin, out HTuple distanceMax);

                lineParams.distance = lineParams.scale * distanceMin;

                lineParams.angle = ( 180 * angle)/ Math.PI;

                ResultStr = ResultStr.TupleConcat("测量距离成功");
                ResultStr = ResultStr.TupleConcat("测量距离：" + lineParams.distance.ToString("F4") + "mm");
                ResultStr = ResultStr.TupleConcat("测量角度成功");
                ResultStr = ResultStr.TupleConcat("测量角度：" + lineParams.angle+ "°");

                if (lineParams.distance >= circleParams.circle_Dis_Min && lineParams.distance <= circleParams.circle_Dis_Max)
                {
                    ResultStr = ResultStr.TupleConcat("OK");

                    lineParams.ResultStr = "OK";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "green", "false");
                }
                else
                {
                    ResultStr = ResultStr.TupleConcat("NG");

                    lineParams.ResultStr = "NG";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "red", "false");
                }


                return OperationResult.CreateSuccessResult();

            }
            catch (Exception ex)
            {
                halcon.disp_message(hWindowHandle, "测量失败：" + ex.Message, "window", 20, 20, "red", "false");

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = ex.Message
                };
            }
        }


        private OperationResult MeasureLineAngle(HObject hImage, HTuple hWindowHandle)
        {
            try
            {
                HTuple ResultStr = new HTuple();

                //查找模板
                matchParams.startAngle = Convert.ToDouble(this.txt_Angle.Text.Trim()); //起始角度
                matchParams.rangeAngle = Convert.ToDouble(this.txt_Range.Text.Trim()); //范围
                matchParams.overlap = Convert.ToDouble(this.txt_Overlap.Text.Trim()); //重叠度
                //matchParams.score = 0.4;
                matchParams.score = Convert.ToDouble(this.txt_Score.Text.Trim());  //分数
                matchParams.numMatchs = Convert.ToInt32(this.txt_NumMatchs.Text.Trim());//数量

                var result = shapeModel.FindShapeModel(hWindowHandle, hImage, matchParams, out HTuple homMat2D);



                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = result.ErrorMsg;

                result = halcon.Fit_Line(hImage, homMat2D, ref lineParams, out HObject result_Line, out HObject result_Line2, out HTuple LineModel, out HTuple LineMode2);

                HOperatorSet.DispObj(hImage, hWindowHandle);
                HOperatorSet.DispObj(result_Line, hWindowHandle);
                HOperatorSet.DispObj(result_Line2, hWindowHandle);

                if (result.IsSuccess == false)
                {
                    halcon.disp_message(hWindowHandle, result.ErrorMsg, "window", 20, 20, "red", "false");

                    return result;
                }

                ResultStr = ResultStr.TupleConcat(result.ErrorMsg);

                HOperatorSet.AngleLl(LineModel[0], LineModel[1], LineModel[2], LineModel[3], LineMode2[0], LineMode2[1], LineMode2[2], LineMode2[3], out HTuple angle);

                //HOperatorSet.DistanceSs(LineModel[0], LineModel[1], LineModel[2], LineModel[3], LineMode2[0], LineMode2[1], LineMode2[2], LineMode2[3], out HTuple distanceMin, out HTuple distanceMax);

                //lineParams.distance = lineParams.scale * distanceMin;

                lineParams.angle = (180 * angle) / Math.PI;

                //ResultStr = ResultStr.TupleConcat("测量距离成功");
                //ResultStr = ResultStr.TupleConcat("测量距离：" + lineParams.distance.ToString("F4") + "mm");
                ResultStr = ResultStr.TupleConcat("测量角度成功");
                ResultStr = ResultStr.TupleConcat("测量角度：" + lineParams.angle + "°");

                if (lineParams.angle >= circleParams.circle_Dis_Min && lineParams.angle <= circleParams.circle_Dis_Max)
                {
                    ResultStr = ResultStr.TupleConcat("OK");

                    lineParams.ResultStr = "OK";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "green", "false");
                }
                else
                {
                    ResultStr = ResultStr.TupleConcat("NG");

                    lineParams.ResultStr = "NG";

                    halcon.disp_message(hWindowHandle, ResultStr, "window", 20, 20, "red", "false");
                }


                return OperationResult.CreateSuccessResult();

            }
            catch (Exception ex)
            {
                halcon.disp_message(hWindowHandle, "测量失败：" + ex.Message, "window", 20, 20, "red", "false");

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = ex.Message
                };
            }
        }

        //报表
        private void btn_SaveExcel_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.gsmc = gsmc;
            form2.cpmc = cpmc;
            form2.nei = nei;
            form2.time = lineParams.time;
            form2.dis = lineParams.dis;
            form2.div = lineParams.div;
            form2.cly = cly;
            form2.clsj = clsj;
            form2.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.gsmc = gsmc;
            form2.cpmc = cpmc;
            form2.nei = nei;
            form2.time = circleParams.time;
            form2.dis = circleParams.dis;
            form2.div = circleParams.div;
            form2.cly = cly;
            form2.clsj = clsj;
            form2.Show();
        }

        private void btn_Calib1_Click(object sender, EventArgs e)
        {
            halcon.Fit_Line(hImage, 0, ref lineParams, out HObject result_Line, out HObject result_Line2, out HTuple LineModel, out HTuple LineMode2);

            HOperatorSet.DistanceSs(LineModel[0], LineModel[1], LineModel[2], LineModel[3], LineMode2[0], LineMode2[1], LineMode2[2], LineMode2[3], out HTuple distanceMin, out HTuple distanceMax);

            if (distanceMin != null && distanceMin.TupleInt() > 0)

            {
                lineParams.scale = Convert.ToDouble(this.txt_Distance1.Text.Trim()) / (distanceMin);
                AddLog(0, "标定成功" + lineParams.scale.ToString() + "mm");
            }

            else
            {
                AddLog(1, "标定失败");

            }
        }

        private void btn_Measure2_Click(object sender, EventArgs e)
        {
            System.DateTime time1 = new System.DateTime();
            time1 = System.DateTime.Now;
            circleParams.circle_Dis_Max = Convert.ToDouble(this.txt_AngMax.Text.Trim());
            circleParams.circle_Dis_Min = Convert.ToDouble(this.txt_AngMin.Text.Trim());

            var result = MeasureLineAngle(hImage, hWindowHandle);

            if (result.IsSuccess)
            {

                if (true)
                {
                    AddLog(0, "测量成功，结果为：" + lineParams.angle + "°");
                    System.DateTime time2 = new System.DateTime();
                    time2 = System.DateTime.Now;
                    TimeSpan time3 = time2 - time1;
                    string time4 = (1000 * time3.TotalSeconds).ToString("F2");
                    string time5 = time2.ToString();
                    //string Ins = "insert into line(time,dis,angle)values" + "('" + time4 + "','" + lineParams.distance.ToString("F4") + "mm" + "','" + lineParams.ResultStr + "')";
                    //sql.Execute(Ins);

                    nei.Add("线角度");
                    gsmc.Add("xxx公司");
                    cpmc.Add("石英晶振");
                    lineParams.time.Add(time4 + "ms");
                    lineParams.dis.Add(lineParams.angle + "°");
                    lineParams.div.Add(lineParams.ResultStr);
                    cly.Add("aa");
                    clsj.Add(time5);

                }//数据存入数据库
            }
            else
            {
                AddLog(1, "测量失败：" + result.ErrorMsg);
            }
        }
    }
}
