using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace thinger.HalconDemo
{
    public partial class Form2 : Form
    {
        public List<string> gsmc;
        public List<string> cpmc;
        public List<string> nei;
        public List<string> time;
        public List<string> dis;
        public List<string> div;
        public List<string> cly;
        public List<string> clsj;
        public Form2()
        {
            InitializeComponent();
        }

        public void ExportDataToExcel(DataGridView myDGV)
        {
            string path = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "请选择要导出的位置";
            saveDialog.Filter = "Excel文件| *.xlsx;*.xls;*.XLSX|PDF文件|*.pdf|Word文件|*.word";
            saveDialog.ShowDialog();
            path = saveDialog.FileName;
            if (path.IndexOf(":") < 0) return; //判断是否点击取消
            try
            {
                Thread.Sleep(1000);
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                //写入标题
                for (int k = 0; k < myDGV.Columns.Count; k++)
                {
                    if (myDGV.Columns[k].Visible)//导出可见的标题
                    {
                        //"\t"就等于键盘上的Tab,加个"\t"的意思是: 填充完后进入下一个单元格.
                        sb.Append(myDGV.Columns[k].HeaderText.ToString().Trim() + "\t");
                    }
                }
                sb.Append(Environment.NewLine);//换行
                                               //写入每行数值
                for (int i = 0; i < myDGV.Rows.Count - 1; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    for (int j = 0; j < myDGV.Columns.Count; j++)
                    {
                        if (myDGV.Columns[j].Visible)//导出可见的单元格
                        {
                            //注意单元格有一定的字节数量限制,如果超出,就会出现两个单元格的内容是一模一样的.
                            //具体限制是多少字节,没有作深入研究.
                            sb.Append(myDGV.Rows[i].Cells[j].Value.ToString().Trim() + "\t");
                        }
                    }
                    sb.Append(Environment.NewLine); //换行
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                MessageBox.Show(path + "，导出成功", "系统提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count == 0)
            {
                MessageBox.Show("当前无数据可导出!");
            }
            else
            {
                ExportDataToExcel(Grid);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < time.Count; i++)
            {
                Grid.Rows.Add();

                Grid.Rows[i].Cells[0].Value = i+1;
                Grid.Rows[i].Cells[1].Value = gsmc[i];
                Grid.Rows[i].Cells[2].Value = cpmc[i];
                Grid.Rows[i].Cells[3].Value = nei[i];
                Grid.Rows[i].Cells[4].Value = dis[i];
                Grid.Rows[i].Cells[5].Value = div[i];
                Grid.Rows[i].Cells[6].Value = time[i];
                Grid.Rows[i].Cells[7].Value = cly[i];
                Grid.Rows[i].Cells[8].Value = clsj[i];
            }

        }


        public void ExportDataToPDF(DataGridView myDGV)
        {
            string path = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "请选择要导出的位置";
            saveDialog.DefaultExt = ".pdf";
            saveDialog.Filter = "Text documents (.pdf)|*.pdf";
            saveDialog.ShowDialog();
            path = saveDialog.FileName;
            if (path.IndexOf(":") < 0) return; //判断是否点击取消
            try
            {
                Thread.Sleep(1000);
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                StringBuilder sb = new StringBuilder();
                //写入标题
                for (int k = 0; k < myDGV.Columns.Count; k++)
                {
                    if (myDGV.Columns[k].Visible)//导出可见的标题
                    {
                        //"\t"就等于键盘上的Tab,加个"\t"的意思是: 填充完后进入下一个单元格.
                        sb.Append(myDGV.Columns[k].HeaderText.ToString().Trim() + "\t");
                    }
                }
                sb.Append(Environment.NewLine);//换行
                                               //写入每行数值
                for (int i = 0; i < myDGV.Rows.Count - 1; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    for (int j = 0; j < myDGV.Columns.Count; j++)
                    {
                        if (myDGV.Columns[j].Visible)//导出可见的单元格
                        {
                            //注意单元格有一定的字节数量限制,如果超出,就会出现两个单元格的内容是一模一样的.
                            //具体限制是多少字节,没有作深入研究.
                            sb.Append(myDGV.Rows[i].Cells[j].Value.ToString().Trim() + "\t");
                        }
                    }
                    sb.Append(Environment.NewLine); //换行
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                MessageBox.Show(path + "，导出成功", "系统提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
