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
    public class CircleParams
    {

        public CircleParams()
        {
            circle_Elements = 60;

            circle_Caliper_Width = 15;

            circle_Caliper_Height = 60;

            circle_Min_Points_Num = 5;

            circle_Threshold = 15;

            circle_Sigma = 1;

            circle_Transition = "all";

            circle_Point_Select = "max";

            circle_Dis_Min = 1;

            circle_Dis_Max = 999;

            scale = 1.0;

            circle_Direct = "inner";

        }

        public List<string> time = new List<string>();
        public List<string> dis = new List<string>();
        public List<string> div = new List<string>();


        /// <summary>
        /// 卡尺数量
        /// </summary>
        public int circle_Elements;


        //圆卡尺工具宽度
        public int circle_Caliper_Width;

        //圆卡尺工具高度
        public int circle_Caliper_Height;


        //拟合圆最小点数
        public int circle_Min_Points_Num;

        //圆边缘点阈值
        public int circle_Threshold;

        //圆边缘点滤波系数
        public double circle_Sigma;

        //圆边缘点极性
        public string circle_Transition;

        //圆边缘点选择
        public string circle_Point_Select;


        //圆最小直径
        public double circle_Dis_Min;


        //圆最大直径
        public double circle_Dis_Max;

        //像素标定系数

        public double scale;

        public HTuple rOI_X;

        public HTuple rOI_Y;

        public HTuple circle_Direct;

        //输出圆数据
        public HTuple circleCenter_X;

        public HTuple circleCenter_Y;

        public HTuple circleRadius;

        //输出结果
        public double distance=0.0;
        public string ResultStr;


    }
}
