using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
   public class ImageHelper
    {   //相机对象句柄
        private HTuple acqHandle;

        public bool isCamOK = false;
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="Drvname"></param>
        /// <param name="CamName"></param>
        /// <returns></returns>
        public OperationResult OpenCam(string CamName,string Drvname= "GigEVision2")
        {
            try
            {
                HOperatorSet.CloseAllFramegrabbers();
                HOperatorSet.OpenFramegrabber(Drvname, 0, 0, 0, 0, 0, 0, "progressive",-1, "default", -1, "false", "default", CamName,0, -1, out acqHandle);
                isCamOK = true;
                return OperationResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {
                
                isCamOK = false;
                acqHandle = null;

                return new OperationResult()
                {
                    IsSuccess = false,
                    ErrorMsg = ex.Message
                };
            }
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public OperationResult CloseCam()
        {
            try
            {
                if(acqHandle !=null)
                {
                    HOperatorSet.CloseFramegrabber(acqHandle);
                    acqHandle = null;
                }

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


        /// <summary>
        /// 采集图像
        /// </summary>
        /// <param name="HwindowHandle"></param>
        /// <param name="hImage"></param>
        /// <returns></returns>
        public OperationResult GrabImage(ref HTuple hWindowHandle, ref HObject hImage)
        {
            try
            {
                HOperatorSet.GrabImage(out hImage, acqHandle);
                //显示全图
                HOperatorSet.GetImageSize(hImage, out HTuple width, out HTuple height);

                //设置窗体句柄的大小
                HOperatorSet.SetPart(hWindowHandle, 0, 0, height - 1, width - 1);

                //显示
                HOperatorSet.DispObj(hImage, hWindowHandle);

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

        /// <summary>
        /// 读取图像并显示在窗口上
        /// </summary>
        /// <param name="path"></param>
        /// <param name="HwindowHandle"></param>
        /// <param name="hImage"></param>
        /// <returns></returns>
        public OperationResult ReadImage(string path,ref HTuple hWindowHandle,ref HObject hImage)
        {

            try
            {
                //根据路径读取图像
                HOperatorSet.ReadImage(out hImage, path);

                //显示全图
                HOperatorSet.GetImageSize(hImage, out HTuple width, out HTuple height);

                //设置窗体句柄的大小
                HOperatorSet.SetPart(hWindowHandle, 0, 0, height - 1, width - 1);

                //显示
                HOperatorSet.DispObj(hImage, hWindowHandle);

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

        /// <summary>
        /// 保存图像
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hImage"></param>
        /// <returns></returns>
        public OperationResult SaveImage(string path,String format, HObject hImage)
        {
            try
            {
                HOperatorSet.WriteImage(hImage,format,0,path);
                return OperationResult.CreateSuccessResult();
            }
            catch (Exception ex)
            {

                return new OperationResult
                {
                    IsSuccess = false,

                    ErrorMsg = ex.Message
                };
            }
        }
    }
}
