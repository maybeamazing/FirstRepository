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
    public partial class Siemens1200Panel : Form
    {
        public string TargetIp = string.Empty;
        public int TargetPort = -1;
        //public int WorkshopNum = -1;
        bool bWorking = false;
        BackgroundWorker AquireWorker = new BackgroundWorker();
        public Siemens1200Panel()
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
                    Siemens1200DataAcquisition da = new Siemens1200DataAcquisition();
                    Dictionary<string, float> dic = da.AcquireData(TargetIp, TargetPort);
                    if (dic == null)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            listBox1.Items.Add("连接失败\n");
                        }));
                    }
                    string sql = string.Format("update Siemens1200RealtimeData set PS_Value_1={0},PD_Value_1={1},PC_Value_1={2},PC_Reduce_PS_Value_1={3}, PS_SettingValue_1={4}, PS_SettingValue_1_UpLimit={5}, PS_SettingValue_1_DownLimit={6}, Pressure_1={7}, PS_Value_2={8}, PD_Value_2={9}, PC_Value_2={10}, PC_Reduce_PS_Value_2={11}, PS_SettingValue_2={12}, PS_SettingValue_2_UpLimit={13}, PS_SettingValue_2_DownLimit={14}, Pressure_2={15},PS_Value_3={16}, PD_Value_3={17}, PC_Value_3={18}, PC_Reduce_PS_Value_3={19}, PS_SettingValue_3={20}, PS_SettingValue_3_UpLimit={21}, PS_SettingValue_3_DownLimit={22}, Pressure_3={23} where Id=1", dic["PS_Value_1"], dic["PD_Value_1"], dic["PC_Value_1"], dic["PC_Reduce_PS_Value_1"], dic["PS_SettingValue_1"], dic["PS_SettingValue_1_UpLimit"], dic["PS_SettingValue_1_DownLimit"], dic["Pressure_1"], dic["PS_Value_2"], dic["PD_Value_2"], dic["PC_Value_2"], dic["PC_Reduce_PS_Value_2"], dic["PS_SettingValue_2"], dic["PS_SettingValue_2_UpLimit"], dic["PS_SettingValue_2_DownLimit"], dic["Pressure_2"], dic["PS_Value_3"], dic["PD_Value_3"], dic["PC_Value_3"], dic["PC_Reduce_PS_Value_3"], dic["PS_SettingValue_3"], dic["PS_SettingValue_3_UpLimit"], dic["PS_SettingValue_3_DownLimit"], dic["Pressure_3"]);
                    

                    string sqL = string.Format("insert into Siemens1200ReservedData (Number,PS_Value_1,PD_Value_1,PC_Value_1,PC_Reduce_PS_Value_1, PS_SettingValue_1, PS_SettingValue_1_UpLimit, PS_SettingValue_1_DownLimit, Pressure_1, PS_Value_2, PD_Value_2, PC_Value_2, PC_Reduce_PS_Value_2, PS_SettingValue_2, PS_SettingValue_2_UpLimit, PS_SettingValue_2_DownLimit, Pressure_2,PS_Value_3, PD_Value_3, PC_Value_3, PC_Reduce_PS_Value_3, PS_SettingValue_3, PS_SettingValue_3_UpLimit, PS_SettingValue_3_DownLimit, Pressure_3, LastUpdateTime)  values (1, {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23})", dic["PS_Value_1"], dic["PD_Value_1"], dic["PC_Value_1"], dic["PC_Reduce_PS_Value_1"], dic["PS_SettingValue_1"],dic["PS_SettingValue_1_UpLimit"],dic["PS_SettingValue_1_DownLimit"],dic["Pressure_1"],dic["PS_Value_2"], dic["PD_Value_2"], dic["PC_Value_2"], dic["PC_Reduce_PS_Value_2"], dic["PS_SettingValue_2"],dic["PS_SettingValue_2_UpLimit"],dic["PS_SettingValue_2_DownLimit"],dic["Pressure_2"],dic["PS_Value_3"], dic["PD_Value_3"], dic["PC_Value_3"], dic["PC_Reduce_PS_Value_3"], dic["PS_SettingValue_3"],dic["PS_SettingValue_3_UpLimit"],dic["PS_SettingValue_3_DownLimit"],dic["Pressure_3"]);

                    //使用HttpCom.Post(sql)函数发送给WCF驻留程序对应的SQL语句
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
                System.Threading.Thread.Sleep(2000);
            }
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
