using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thinger.HalconDemo
{
    /// <summary>
    /// ���������
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// �Ƿ�ɹ�
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// ������Ϣ
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
