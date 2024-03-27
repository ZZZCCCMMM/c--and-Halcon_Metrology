using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;



namespace thinger.HalconDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "aa";
            textBox2.Text = "33";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //构造连接数据库的字符串
            SQLiteConnectionStringBuilder connectionString = new SQLiteConnectionStringBuilder();
            connectionString.DataSource = "D://sjk//lwmb.db";
            //连接数据库
            SQLiteConnection conn = new SQLiteConnection(connectionString.ToString());
            conn.Open();
            //查询语句select
            string sql = string.Format("select* from User");
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
            //获取数据
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable re = ds.Tables[0];
            //及时释放资源 
            da.Dispose();
            conn.Close();
            int wzdflwjsygfww = 0;
            int wzdflwjsygfw = 0;
            foreach (DataRow v in re.Rows)  //循环表中数据
            {
                string dlname = v["name"].ToString();
                string dlmark = v["password"].ToString();
                if (textBox1.Text == dlname)
                {
                    if (textBox2.Text == dlmark)
                    {
                        wzdflwjsygfw = 1;
                    }
                    wzdflwjsygfww = 1;
                }
            }
            if (wzdflwjsygfww == 0)
            {
                MessageBox.Show("账号不存在");
            }
            else
            {
                if (wzdflwjsygfw == 0)
                {
                    MessageBox.Show("密码不正确");
                }
                else
                {
                    MessageBox.Show("登陆成功");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
