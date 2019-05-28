using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace PrwCommServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“PrwCommService”。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PrwCommService : IPrwCommService
    {
        public static object theLock = new object();

        public void DoWork()
        {
        }

        public string Write(string streamLength, Stream stream)
        {
            lock (theLock)
            {
                string retStr = string.Empty;
                string theStr = GetStringFromStream(stream, streamLength);
                string sql = theStr;
                int tid = Thread.CurrentThread.ManagedThreadId;
                MainForm.Log(string.Format("[Write param tid = {0}]: {1}", tid, sql));
                SqlConnection conn = new SqlConnection("server=(local);user id=sa;password=asd135781;database=szxinzhi;");
                //string sqlstr = "Data Source=数据库服务器名称;Initial Catalog=数据库名;Persist Security Info=True;User ID=sa;Password=用户密码";
                try
                {
                    int pos = sql.IndexOf("where");
                    if (pos != -1)
                    {
                        string insertStr = string.Format(", LastUpdateTime = '{0}'", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sql = sql.Insert(pos - 1, insertStr);
                    }
                    //else {
                    //    string insertStr = ", LastUpdateTime";
                    //    int pos1= sql.IndexOf("AbnormalAlarm");
                    //    sql = sql.Insert(pos1 +13, insertStr);
                    //    string insertString = string.Format(", '{0}'", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //    int pos2 = sql.LastIndexOf(')');
                    //    sql = sql.Insert(pos2 , insertString);
                    //}
                    else
                    {
                        string insertString = string.Format(", '{0}'", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        int pos2 = sql.LastIndexOf(')');
                        sql = sql.Insert(pos2, insertString);
                    }
                    conn.Open();
                    SqlCommand sqlcmd = new SqlCommand(sql, conn);
                    sqlcmd.ExecuteNonQuery();
                    retStr = "ok";
                }
                catch (Exception ex)
                {
                    retStr = "fail\n" + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                MainForm.Log(string.Format("[Write return tid = {0}]: {1}", tid, retStr));
                return retStr;
            }
        }

        public string Read(string streamLength, Stream stream)
        {
            lock (theLock)
            {
                OleDbConnection dbCon = null;
                OleDbDataReader reader = null;
                string retStr = string.Empty;
                string theStr = GetStringFromStream(stream, streamLength);
                string sql = theStr;
                int tid = Thread.CurrentThread.ManagedThreadId;
                MainForm.Log(string.Format("[Read param tid = {0}]: {1}", tid, sql));

                try
                {
                    string strcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainForm.DataBasePathName;
                    dbCon = new OleDbConnection(strcon);                             //定义数据库连接对象
                    dbCon.Open();                                                    //打开数据库连接
                    OleDbCommand cmd = new OleDbCommand(sql, dbCon);                 //定义Command对象
                    reader = cmd.ExecuteReader();                                    //执行Command命令

                    List<string> list = new List<string>();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            list.Add(reader.GetName(i));
                            list.Add(reader[i].ToString());
                        }
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i != list.Count - 1)
                        {
                            retStr += (list[i] + "\n");
                        }
                        else
                        {
                            retStr += list[i];
                        }
                    }

                    MainForm.Log(string.Format("[Read return tid = {0}]: {1}", tid, "ok"));
                }
                catch (Exception ex)
                {
                    retStr = "fail\n" + ex.Message;

                    MainForm.Log(string.Format("[Read return tid = {0}]: fail, {1}", tid, ex.Message));
                }
                finally
                {
                    dbCon.Close();
                }

                return retStr;
            }
        }


        public string GetStringFromStream(Stream stream, string streamLength)
        {
            int byLength = Convert.ToInt32(streamLength);
            byte[] resultByte = new byte[byLength];
            stream.Read(resultByte, 0, resultByte.Length);
            string theStr = Encoding.Default.GetString(resultByte);
            return theStr;
        }

        public string UploadPrinterStatus(string streamLength, Stream stream)
        {
            return Write(streamLength, stream);
        }

        public string DownloadPrinterCmd(string streamLength, Stream stream)
        {
            return Read(streamLength, stream);
        }

        //更新立库状态
        public string UploadWareHouseStatus(string streamLength, Stream stream)
        {
            return Write(streamLength, stream);
        }

        //下载立库状态
        public string DownloadWareHouseCmd(string streamLength, Stream stream)
        {
            return Read(streamLength, stream);
        }

        public string UploadRobotStatus(string streamLength, Stream stream)
        {
            return Write(streamLength, stream);
        }

        public string DownloadRobotCmd(string streamLength, Stream stream)
        {
            return Read(streamLength, stream);
        }
    }
}
