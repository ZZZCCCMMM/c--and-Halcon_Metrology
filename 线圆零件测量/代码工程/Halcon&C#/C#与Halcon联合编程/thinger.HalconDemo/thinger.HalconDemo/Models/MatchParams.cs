using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
  public  class MatchParams
    {

        /// <summary>
        /// 模板匹配参数
        /// </summary>
        public MatchParams()
        {
            startAngle = 0;
            rangeAngle = 360;
            score = 0.8;
            numMatchs = 1;
            overlap = 0.4;
            greediness = 0.9;
            scaleRMin = 0.8;
            scaleRMax = 1.2;
            scaleCMin = 0.8;
            scaleCMax = 1.2;
            metric = "use_polarity";

            HOperatorSet.GenEmptyObj(out modelRegion); // 创建一空的模板区域
        }

        //起始角度
        public double startAngle;
        //角度范围
        public double rangeAngle;
        //最小分数
        public double score;
       // 行最小缩放
        public double scaleRMin;
        // 行最大缩放
        public double scaleRMax;
        // 列最小缩放
        public double scaleCMin;
        // 列最大缩放
        public double scaleCMax;
        // 贪心算法
        public double greediness;
        //匹配数量
        public int numMatchs;
        //最大重叠度
        public double overlap;
        //极性
        public HTuple metric;
        //模板区域
        public HObject modelRegion;

        //模板ID
        public HTuple modelId;

        ~MatchParams()
        {
            if(modelId !=null)
            {
                HOperatorSet.ClearShapeModel(modelId); //// 清除模型句柄
            }

        }
    }
}
