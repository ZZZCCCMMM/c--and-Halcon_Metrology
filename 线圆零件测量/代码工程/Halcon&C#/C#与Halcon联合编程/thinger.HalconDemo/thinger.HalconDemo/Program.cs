using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thinger.HalconDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //if (true) //false
            //{
            //    Form1 form1 = new Form1();
            //    if (form1.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new FrmMain());
            //    }
            //}
        }
    }
}
