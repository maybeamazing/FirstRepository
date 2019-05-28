using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcquisition
{
    public partial class Siemens200Panel : Form
    {
        public string TargetIp = string.Empty;
        public int TargetPort = -1;
        //public int WorkshopNum = -1;
        bool bWorking = false;
        BackgroundWorker AquireWorker = new BackgroundWorker();

        public Siemens200Panel()
        {
            InitializeComponent();
        }
        public void btnStartAcquire_Click(object sender, EventArgs e)
        {
            if (!bWorking)
            {
                btnStartAcquire.Enabled = false;
                //this.Text = string.Format("空调 {0}车间", RoomNum.Text);
                TargetIp = IpAddr.Text;
                TargetPort = int.Parse(Port.Text);
                //WorkshopNum = int.Parse(RoomNum.Text);
                bWorking = true;
                AquireWorker.DoWork += AquireWorker_DoWork;
                AquireWorker.RunWorkerAsync();
            }
            else
            {
                listBox1.Items.Add("数据查询线程已经在运行，请先停止");
            }
        }

        private void AquireWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bWorking)
            {
                try
                {
                    // 采集、上传代码
                    Siemens200DataAcquisition da = new Siemens200DataAcquisition();
                    Dictionary<string, float> dic = da.AcquireData(TargetIp, TargetPort);

                    // SQL语句的格式 
                    string sql = string.Format("update Siemens200RealtimeData set Jumping ={0} where Number=1", dic["Jumping"]);
                    string sqL = string.Format("insert into Siemens200ReservedData (Number,Jumping,LastUpdateTime) values (1, {0})", dic["Jumping"]);

                    // 使用HttpCom.Post(sql)函数发送给WCF驻留程序对应的SQL语句
                    HttpCom.Post(sql);
                    HttpCom.Post(sqL);

                    // 显示采集的数据                
                    if (checkBox_Record.Checked)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            if (listBox1.Items.Count > 2000)
                            {
                                listBox1.Items.Clear();
                            }

                            listBox1.Items.Add("-------------------------------------\n");
                            listBox1.Items.Add(DateTime.Now.ToString());

                            foreach (var item in dic)
                            {
                                string atxt = item.Key + ": " + item.Value.ToString();
                                listBox1.Items.Add(atxt);

                                if (checkBox_Roll.Checked)
                                {
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    listBox1.SelectedIndex = -1;
                                }
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        Invoke(new EventHandler(delegate
                        {
                            if (listBox1.Items.Count > 2000)
                            {
                                listBox1.Items.Clear();
                            }

                            listBox1.Items.Add("-------------------------------------\n");
                            listBox1.Items.Add(DateTime.Now.ToString());
                            listBox1.Items.Add(ex.Message);

                            if (checkBox_Roll.Checked)
                            {
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                listBox1.SelectedIndex = -1;
                            }
                        }));
                    }
                    catch (Exception ex1)
                    {
                        throw ex1;
                    }

                }

                System.Threading.Thread.Sleep(2000);
            }

            Invoke(new EventHandler(delegate
            {
                btnStartAcquire.Enabled = true;
            }));
        }

        private void btnStopAcquire_Click(object sender, EventArgs e)
        {
            bWorking = false;
            btnStartAcquire.Enabled = true;
        }

        private void btnClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

      
    }
}
