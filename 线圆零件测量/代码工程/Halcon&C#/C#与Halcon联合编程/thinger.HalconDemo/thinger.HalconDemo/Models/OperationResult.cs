using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
    /// <summary>
    /// 操作结果类
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }


        public static OperationResult CreateSuccessResult()
        {
            return new OperationResult()
            {
                IsSuccess = true,
                ErrorMsg = "Success"
            };
        }

        public static OperationResult CreateFailResult()
        {
            return new OperationResult()
            {
                IsSuccess = false,
                ErrorMsg = "Fail"
            };
        }

    }
}
