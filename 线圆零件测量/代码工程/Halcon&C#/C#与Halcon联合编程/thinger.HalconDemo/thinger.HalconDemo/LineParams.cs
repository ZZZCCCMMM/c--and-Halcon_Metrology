using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
    /// <summary>
    /// 圆参数
    /// </summary>
    public class LineParams
    {

        public LineParams()
        {
            line_Transition = "all";
        }

        /// <summary>
        /// 卡尺数量
        /// </summary>

        //线边缘点极性
        public string line_Transition;


        //像素标定系数

        public double scale;

        public HTuple rOI_X;

        public HTuple rOI_Y;

        public HTuple circle_Direct;


        //输出结果
        public double distance = 0.0;
        public HTuple angle;
        public HTuple row1;
        public HTuple row2;
        public HTuple column1;
        public HTuple column2;

        public HTuple LineModel;
        public HTuple LineMode2;
        public HTuple L1StartRowDraw;
        public HTuple L1StartColumnDraw;
        public HTuple L1EndRowDraw;
        public HTuple L1EndColumnDraw;

        public HTuple L2StartRowDraw;
        public HTuple L2StartColumnDraw;
        public HTuple L2EndRowDraw;
        public HTuple L2EndColumnDraw;

        public HObject ho_Contour;
        public HTuple MetrologyHandle;
        public HTuple MetrologyHandle1;


        public HTuple Index1 = null, Index2 = null,Index3 = null;

        public List<string> time = new List<string>();
        public List<string> dis = new List<string>();
        public List<string> div = new List<string>();

        public string ResultStr;

    }
}
