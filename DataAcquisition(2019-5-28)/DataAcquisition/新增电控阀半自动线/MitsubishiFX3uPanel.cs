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
    public partial class MitsubishiFX3uPanel : Form
    {
        public string TargetIp = string.Empty;
        public int TargetPort = -1;
        bool bWorking = false;

        BackgroundWorker AquireWorker = new BackgroundWorker();

        public MitsubishiFX3uPanel()
        {
            InitializeComponent();
        }
        public void btnStartAcquire_Click(object sender, EventArgs e)
        {
            if (!bWorking)
            {
                btnStartAcquire.Enabled = false;
                TargetIp = IpAddr.Text;
                TargetPort = int.Parse(Port.Text);
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
                    MitsubishiFX3uDataAcquisition da = new MitsubishiFX3uDataAcquisition();
                    Dictionary<string, float> dic = da.AcquireData(TargetIp, TargetPort);

                    
                    string sql = string.Format("update Fx3uReservedData set Position ={0}, Pressure={1}, QualifiedProduction={2}, UnqualifiedProduction={3}, UpperComputerSensor={4}, StandardValue={5}, LocalComputerSensor={6}, PlcRuntime={7}, AbnormalAlarm={8} where Id=1", dic["Position"], dic["Pressure"], dic["QualifiedProduction"], dic["UnqualifiedProduction"], dic["UpperComputerSensor"], dic["StandardValue"], dic["LocalComputerSensor"], dic["PlcRuntime"], dic["AbnormalAlarm"]);
                    string sqL = string.Format("insert into Fx3uReservedData (Number,Position,Pressure,QualifiedProduction,UnqualifiedProduction,UpperComputerSensor,StandardValue,LocalComputerSensor,PlcRuntime,AbnormalAlarm,LastUpdateTime) values (0, {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", dic["Position"], dic["Pressure"], dic["QualifiedProduction"], dic["UnqualifiedProduction"], dic["UpperComputerSensor"], dic["StandardValue"], dic["LocalComputerSensor"], dic["PlcRuntime"], dic["AbnormalAlarm"]);

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
