using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
  public  class ShapeModeHelper
    {
        //创建一个halcon帮助对象
        private HalconHelper halcon = new HalconHelper();
        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="hWindowHandle"></param>
        /// <param name="hImage"></param>
        /// <param name="matchParams"></param>
        /// <returns></returns>
        public OperationResult CreateShapeMode(HTuple hWindowHandle,HObject hImage,MatchParams matchParams)
        {
            try
            {
                //提示
                halcon.disp_message(hWindowHandle, "请绘制模板区域,完成鼠标右击确认", "window", 20, 20, "red", "false");

                //Draw

                HOperatorSet.DrawRectangle2(hWindowHandle, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2);

                //Gen

                HOperatorSet.GenRectangle2(out matchParams.modelRegion, row, column, phi, length1, length2);


                //ReduceDomain

                HOperatorSet.ReduceDomain(hImage, matchParams.modelRegion, out HObject imageReduced);

                //Clear

                ClearShapeMode(ref matchParams.modelId);

                //Create

                HOperatorSet.CreateShapeModel(imageReduced, "auto", matchParams.startAngle, matchParams.rangeAngle, "auto", "auto", matchParams.metric, "auto", "auto", out matchParams.modelId);

                HOperatorSet.DispObj(hImage, hWindowHandle);

                HOperatorSet.DispObj(matchParams.modelRegion, hWindowHandle);

                if (matchParams.modelId != null)
                {
                    //提示
                    halcon.disp_message(hWindowHandle, "创建模板成功", "window", 20, 20, "green", "false");
                    return OperationResult.CreateSuccessResult();
                }
                else
                {
                    //提示
                    halcon.disp_message(hWindowHandle, "创建模板失败", "window", 20, 20, "red", "false");
                    return OperationResult.CreateFailResult();
                }
            }
            catch (Exception ex)
            {

                //提示
                halcon.disp_message(hWindowHandle, "创建模板失败:"+ex.Message, "window", 20, 20, "red", "false");

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg=ex.Message,
                 
                };
            }
           

        }
        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="hWindowHandle"></param>
        /// <param name="hImage"></param>
        /// <param name="matchParams"></param>
        /// <param name="homMat2D"></param>
        /// <returns></returns>
        public OperationResult FindShapeModel(HTuple hWindowHandle, HObject hImage, MatchParams matchParams, out HTuple homMat2D)
        {

            homMat2D = new HTuple();
            try
            {
                HOperatorSet.FindShapeModel(hImage,matchParams.modelId,matchParams.startAngle,matchParams.rangeAngle,matchParams.score,matchParams.numMatchs,matchParams.overlap, "least_squares",
                    0,matchParams.greediness,out HTuple row,out HTuple column,out HTuple angle,out HTuple score);

                //通过判断结果，证明是否找到模板
                if(row.Length>0)
                {
                    //处理

                    //显示轮廓
                    //获取仿射变换矩阵
                    HOperatorSet.VectorAngleToRigid(0,0,0,row,column,angle,out HTuple homMat2d_T);

                    //获取轮廓

                    HOperatorSet.GetShapeModelContours(out HObject contour,matchParams.modelId,1);

                    //将显示在0，0位置的轮廓仿射过去并显示

                    HOperatorSet.AffineTransContourXld(contour,out HObject contour2,homMat2d_T);

                    //产生一个十字叉
                    HOperatorSet.GenCrossContourXld(out HObject cross,row,column,20,new HTuple(45));



                    //获取中心
                    HOperatorSet.AreaCenter(matchParams.modelRegion, out HTuple area, out HTuple row0, out HTuple column0);

                    //获取圆ROI的仿射变化矩阵

                    HOperatorSet.VectorAngleToRigid(row0, column0, 0, row, column, angle, out homMat2D);




                    //显示
                    //HOperatorSet.DispObj(hImage,hWindowHandle);
                    //HOperatorSet.DispObj(contour, hWindowHandle);
                    //HOperatorSet.DispObj(contour2, hWindowHandle);
                    //HOperatorSet.DispObj(cross, hWindowHandle);


                    //提示
                    halcon.disp_message(hWindowHandle, "查找模板成功:", "window", 20, 20, "green", "false");

                    return new OperationResult()
                    {
                        IsSuccess = true,
                        ErrorMsg = "查找模板成功"
                    };
                }

                else
                {
                    //提示
                    halcon.disp_message(hWindowHandle, "查找模板失败:", "window", 20, 20, "red", "false");

                    return new OperationResult()
                    {
                        IsSuccess = false,
                        ErrorMsg="未查到模板",
                    };
                }
            }
            catch (Exception ex)
            {

                //提示
                halcon.disp_message(hWindowHandle, "查找模板失败:" + ex.Message, "window", 20, 20, "red", "false");

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = ex.Message,

                };
            }


        }

        /// <summary>
        /// 清除模板
        /// </summary>
        /// <param name="ModeId"></param>
        public void ClearShapeMode(ref HTuple ModeId )
        {
            if(ModeId != null)
            {
                HOperatorSet.ClearShapeModel(ModeId);
                ModeId = null;
            }
        }

        /// <summary>
        /// 存储模板
        /// </summary>
        /// <param name="path">模板存储文件夹</param>
        /// <param name="matchParams"></param>
        /// <param name="circleParams"></param>
        /// <returns></returns>
        public OperationResult SaveShapeModel(string path, MatchParams matchParams, CircleParams circleParams)
        {
            if (matchParams.modelId != null && matchParams.modelRegion != null && circleParams.rOI_X.Length > 0 && circleParams.rOI_Y.Length > 0)
            {

                //模板相关

                HOperatorSet.WriteShapeModel(matchParams.modelId, path + "\\model.shm");

                HOperatorSet.WriteRegion(matchParams.modelRegion, path + "\\model_region.tif");

                //圆ROI相关

                HOperatorSet.WriteTuple(circleParams.rOI_Y, path + "\\roi_row.tup");
                HOperatorSet.WriteTuple(circleParams.rOI_X, path + "\\roi_col.tup");
                HOperatorSet.WriteTuple(circleParams.circle_Direct, path + "\\roi_dir.tup");

                //参数文本

                bool result = true;

                IniConfigHelper.filePath = path + "\\param.ini";

                result &= IniConfigHelper.WriteIniData("定位参数", "起始角度", matchParams.startAngle.ToString());
                result &= IniConfigHelper.WriteIniData("定位参数", "角度范围", matchParams.rangeAngle.ToString());
                result &= IniConfigHelper.WriteIniData("定位参数", "分数", matchParams.score.ToString());
                result &= IniConfigHelper.WriteIniData("定位参数", "重叠度", matchParams.overlap.ToString());
                result &= IniConfigHelper.WriteIniData("定位参数", "数量", matchParams.numMatchs.ToString());


                result &= IniConfigHelper.WriteIniData("测量参数", "搜索点数", circleParams.circle_Elements.ToString());
                result &= IniConfigHelper.WriteIniData("测量参数", "边缘阈值", circleParams.circle_Threshold.ToString());
                result &= IniConfigHelper.WriteIniData("测量参数", "平滑系数", circleParams.circle_Sigma.ToString());
                result &= IniConfigHelper.WriteIniData("测量参数", "极性", circleParams.circle_Transition.ToString());
                result &= IniConfigHelper.WriteIniData("测量参数", "点选择", circleParams.circle_Point_Select.ToString());

                result &= IniConfigHelper.WriteIniData("标定参数", "像素距离", circleParams.scale.ToString());

                result &= IniConfigHelper.WriteIniData("直径范围", "最小直径", circleParams.circle_Dis_Min.ToString());
                result &= IniConfigHelper.WriteIniData("直径范围", "最大直径", circleParams.circle_Dis_Max.ToString());

                return result ? OperationResult.CreateSuccessResult() : new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = "INI参数保存失败"
                };
            }
            else
            {
                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = "模板参数不完全"
                };

            }
        }

        /// <summary>
        /// 获取所有的模板
        /// </summary>
        /// <param name="basePath"></param>
        /// <returns></returns>
        public List<string> GetAllShapeModels(string basePath)
        {
            List<string> result = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(basePath);

            foreach (var item in directoryInfo.GetDirectories())
            {
                result.Add(item.Name);
            }
            return result;

        }

        /// <summary>
        /// 加载模板
        /// </summary>
        /// <param name="path"></param>
        /// <param name="matchParams"></param>
        /// <param name="circleParams"></param>
        /// <returns></returns>
        public OperationResult LoadShapeModel(string path, ref MatchParams matchParams, ref CircleParams circleParams)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    HOperatorSet.ReadShapeModel(path + "\\model.shm", out matchParams.modelId);

                    HOperatorSet.ReadRegion(out matchParams.modelRegion, path + "\\model_region.tif");

                    HOperatorSet.ReadTuple(path + "\\roi_row.tup", out circleParams.rOI_Y);
                    HOperatorSet.ReadTuple(path + "\\roi_col.tup", out circleParams.rOI_X);
                    HOperatorSet.ReadTuple(path + "\\roi_dir.tup", out circleParams.circle_Direct);

                    IniConfigHelper.filePath = path + "\\param.ini";

                    matchParams.startAngle = Convert.ToDouble(IniConfigHelper.ReadIniData("定位参数", "起始角度", "-46"));
                    matchParams.rangeAngle = Convert.ToDouble(IniConfigHelper.ReadIniData("定位参数", "角度范围", "90"));
                    matchParams.score = Convert.ToDouble(IniConfigHelper.ReadIniData("定位参数", "分数", "1"));
                    matchParams.overlap = Convert.ToDouble(IniConfigHelper.ReadIniData("定位参数", "重叠度", "0.5"));
                    matchParams.numMatchs = Convert.ToInt32(IniConfigHelper.ReadIniData("定位参数", "数量", "1"));


                    circleParams.circle_Elements = Convert.ToInt32(IniConfigHelper.ReadIniData("测量参数", "搜索点数", "1"));
                    circleParams.circle_Threshold = Convert.ToInt32(IniConfigHelper.ReadIniData("测量参数", "边缘阈值", "1"));
                    circleParams.circle_Sigma = Convert.ToDouble(IniConfigHelper.ReadIniData("测量参数", "平滑系数", "1"));
                    circleParams.circle_Transition = IniConfigHelper.ReadIniData("测量参数", "极性", "max");
                    circleParams.circle_Point_Select = IniConfigHelper.ReadIniData("测量参数", "点选择", "all");

                    circleParams.scale = Convert.ToDouble(IniConfigHelper.ReadIniData("标定参数", "像素距离", "1"));

                    circleParams.circle_Dis_Min = Convert.ToDouble(IniConfigHelper.ReadIniData("直径范围", "最小直径", "1"));
                    circleParams.circle_Dis_Max = Convert.ToDouble(IniConfigHelper.ReadIniData("直径范围", "最大直径", "999"));

                    return OperationResult.CreateSuccessResult();
                }
                catch (Exception ex)
                {
                    return new OperationResult()
                    {
                        IsSuccess = false,
                        ErrorMsg = ex.Message
                    };
                }

            }
            else
            {
                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = "路径不存在"
                };
            }
        }
    }
}
