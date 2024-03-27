using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace thinger.HalconDemo
{
    class SQLite
    {
        public SQLiteConnection Sql;
        public SQLiteConnection open()
        {
            //数据库地址 字符串
            //这里将自己建立的数据文件的路径复制下来
            string FilePath = @"Data Source= D:\sjk\lwmb.db";
            //new 数据库对象
            Sql = new SQLiteConnection(FilePath);
            //打开数据库
            Sql.Open();
            //返回数据库连接对象
            return Sql;
        }

        public SQLiteCommand command(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, open());
            return cmd;
        }

        public int Execute(string sql)  //更新操作
        {
            return command(sql).ExecuteNonQuery();
        }

        public void SqlClose()
        {
            Sql.Close();//关闭数据库连接
        }

    }//数据库操作

}
