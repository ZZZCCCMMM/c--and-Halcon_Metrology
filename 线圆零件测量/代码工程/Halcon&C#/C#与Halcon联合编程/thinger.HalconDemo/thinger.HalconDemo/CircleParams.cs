using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
    /// <summary>
    /// Բ����
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
        /// ��������
        /// </summary>
        public int circle_Elements;


        //Բ���߹��߿��
        public int circle_Caliper_Width;

        //Բ���߹��߸߶�
        public int circle_Caliper_Height;


        //���Բ��С����
        public int circle_Min_Points_Num;

        //Բ��Ե����ֵ
        public int circle_Threshold;

        //Բ��Ե���˲�ϵ��
        public double circle_Sigma;

        //Բ��Ե�㼫��
        public string circle_Transition;

        //Բ��Ե��ѡ��
        public string circle_Point_Select;


        //Բ��Сֱ��
        public double circle_Dis_Min;


        //Բ���ֱ��
        public double circle_Dis_Max;

        //���ر궨ϵ��

        public double scale;

        public HTuple rOI_X;

        public HTuple rOI_Y;

        public HTuple circle_Direct;

        //���Բ����
        public HTuple circleCenter_X;

        public HTuple circleCenter_Y;

        public HTuple circleRadius;

        //������
        public double distance=0.0;
        public string ResultStr;


    }
}
