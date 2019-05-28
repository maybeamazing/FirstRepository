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
    public partial class Omron501Panel : Form
    {
        public string TargetIp = string.Empty;
        public int TargetPort = -1;


        bool bWorking = false;

        BackgroundWorker AquireWorker = new BackgroundWorker();
        public Omron501Panel()
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
                    // 在这里填写：采集、上传代码
                    Omron501DataAcquisition da = new Omron501DataAcquisition();
                    Dictionary<string, float> dic = da.AcquireData(TargetIp, TargetPort);


                    // string sql = string.Format("update NJ501ReservedData set  S1_BadProduction={0},S1_CurrentProduction={1},S1_QualifiedRate={2},S2_BadProduction={3},S2_CurrentProduction={4},S2_QualifiedRate={5},S3_BadProduction={6},S3_CurrentProduction={7},S3_QualifiedRate={8},S4_BadProduction={9},S4_CurrentProduction={10},S4_QualifiedRate={11},T1_BadProduction={12}, T1_CurrentProduction={13}, T1_QualifiedRate={14}, T2_BadProduction={15}, T2_CurrentProduction={16}, T2_QualifiedRate={17}, T3_BadProduction={18}, T3_CurrentProduction={19}, T3_QualifiedRate={20}, T4_BadProduction={21}, T4_CurrentProduction={22}, T4_QualifiedRate={23}, CurrentPlanProduction={24}, CurrentRealProduction={25},S1_PC_RealValue={26}, S1_PS_RealValue={27}, S1_PS_Rise={28}, S1_PS_Fall={29}, S1_PS_r_f={30}, S2_PC_RealValue={31}, S2_PS_RealValue={32}, S2_PS_Rise={33}, S2_PS_Fall={34}, S2_PS_r_f={35}, S3_PC_RealValue={36}, S3_PS_RealValue={37}, S3_PS_Rise={38}, S3_PS_Fall={39}, S3_PS_r_f={40}, S4_PC_RealValue={41}, S4_PS_RealValue={42}, S4_PS_Rise={43}, S4_PS_Fall={44}, S4_PS_r_f={45},T1_PC_RealValue={46}, T1_PS_RealValue={47}, T1_PS_Rise={48}, T1_PS_Fall={49}, T1_PS_r_f={50}, T2_PC_RealValue={51}, T2_PS_RealValue={52}, T2_PS_Rise={53}, T2_PS_Fall={54}, T2_PS_r_f={55}, T3_PC_RealValue={56}, T3_PS_RealValue={57}, T3_PS_Rise={58}, T3_PS_Fall={59}, T3_PS_r_f={60}, T4_PC_RealValue={61}, T4_PS_RealValue={62}, T4_PS_Rise={63}, T4_PS_Fall={64}, T4_PS_r_f={65},P1_BadProduction={66},P1_CurrentProduction={67},P1_QualifiedRate={68},P2_BadProduction={69},P2_CurrentProduction={70},P2_QualifiedRate={71},P3_BadProduction={72},P3_CurrentProduction={73},P3_QualifiedRate={74},P4_BadProduction={75},P4_CurrentProduction={76},P4_QualifiedRate={77} where Id=1",
                    //dic["S1_BadProduction"], dic["S1_CurrentProduction"], dic["S1_QualifiedRate"], dic["S2_BadProduction"], dic["S2_CurrentProduction"], dic["S2_QualifiedRate"], dic["S3_BadProduction"], dic["S3_CurrentProduction"], dic["S3_QualifiedRate"], dic["S4_BadProduction"], dic["S4_CurrentProduction"], dic["S4_QualifiedRate"],
                    //dic["T1_BadProduction"], dic["T1_CurrentProduction"], dic["T1_QualifiedRate"], dic["T2_BadProduction"], dic["T2_CurrentProduction"], dic["T2_QualifiedRate"], dic["T3_BadProduction"], dic["T3_CurrentProduction"], dic["T3_QualifiedRate"], dic["T4_BadProduction"], dic["T4_CurrentProduction"], dic["T4_QualifiedRate"], dic["CurrentPlanProduction"], dic["CurrentRealProduction"],
                    //dic["S1_PC_RealValue"], dic["S1_PS_RealValue"], dic["S1_PS_Rise"], dic["S1_PS_Fall"], dic["S1_PS_r_f"], dic["S2_PC_RealValue"], dic["S2_PS_RealValue"], dic["S2_PS_Rise"], dic["S2_PS_Fall"], dic["S2_PS_r_f"], dic["S3_PC_RealValue"], dic["S3_PS_RealValue"], dic["S3_PS_Rise"], dic["S3_PS_Fall"], dic["S3_PS_r_f"], dic["S4_PC_RealValue"], dic["S4_PS_RealValue"], dic["S4_PS_Rise"], dic["S4_PS_Fall"], dic["S4_PS_r_f"],
                    //dic["T1_PC_RealValue"], dic["T1_PS_RealValue"], dic["T1_PS_Rise"], dic["T1_PS_Fall"], dic["T1_PS_r_f"], dic["T2_PC_RealValue"], dic["T2_PS_RealValue"], dic["T2_PS_Rise"], dic["T2_PS_Fall"], dic["T2_PS_r_f"], dic["T3_PC_RealValue"], dic["T3_PS_RealValue"], dic["T3_PS_Rise"], dic["T3_PS_Fall"], dic["T3_PS_r_f"], dic["T4_PC_RealValue"], dic["T4_PS_RealValue"], dic["T4_PS_Rise"], dic["T4_PS_Fall"], dic["T4_PS_r_f"],
                    //dic["P1_BadProduction"], dic["P1_CurrentProduction"], dic["P1_QualifiedRate"], dic["P2_BadProduction"], dic["P2_CurrentProduction"], dic["P2_QualifiedRate"], dic["P3_BadProduction"], dic["P3_CurrentProduction"], dic["P3_QualifiedRate"], dic["P4_BadProduction"], dic["P4_CurrentProduction"], dic["P4_QualifiedRate"]);

                    string sql = string.Format("update NJ501ReservedData set  S1_BadProduction={0},S1_CurrentProduction={1},S1_QualifiedRate={2},S2_BadProduction={3},S2_CurrentProduction={4},S2_QualifiedRate={5},S3_BadProduction={6},S3_CurrentProduction={7},S3_QualifiedRate={8},S4_BadProduction={9},S4_CurrentProduction={10},S4_QualifiedRate={11},T1_BadProduction={12}, T1_CurrentProduction={13}, T1_QualifiedRate={14}, T2_BadProduction={15}, T2_CurrentProduction={16}, T2_QualifiedRate={17}, T3_BadProduction={18}, T3_CurrentProduction={19}, T3_QualifiedRate={20}, T4_BadProduction={21}, T4_CurrentProduction={22}, T4_QualifiedRate={23}, CurrentPlanProduction={24}, CurrentRealProduction={25},S1_PC_RealValue={26}, S1_PS_RealValue={27}, S1_PS_Rise={28}, S1_PS_Fall={29}, S1_PS_r_f={30}, S2_PC_RealValue={31}, S2_PS_RealValue={32}, S2_PS_Rise={33}, S2_PS_Fall={34}, S2_PS_r_f={35}, S3_PC_RealValue={36}, S3_PS_RealValue={37}, S3_PS_Rise={38}, S3_PS_Fall={39}, S3_PS_r_f={40}, S4_PC_RealValue={41}, S4_PS_RealValue={42}, S4_PS_Rise={43}, S4_PS_Fall={44}, S4_PS_r_f={45},T1_PC_RealValue={46}, T1_PS_RealValue={47}, T1_PS_Rise={48}, T1_PS_Fall={49}, T1_PS_r_f={50}, T2_PC_RealValue={51}, T2_PS_RealValue={52}, T2_PS_Rise={53}, T2_PS_Fall={54}, T2_PS_r_f={55}, T3_PC_RealValue={56}, T3_PS_RealValue={57}, T3_PS_Rise={58}, T3_PS_Fall={59}, T3_PS_r_f={60}, T4_PC_RealValue={61}, T4_PS_RealValue={62}, T4_PS_Rise={63}, T4_PS_Fall={64}, T4_PS_r_f={65} where Id=1",
                   dic["S1_BadProduction"], dic["S1_CurrentProduction"], dic["S1_QualifiedRate"], dic["S2_BadProduction"], dic["S2_CurrentProduction"], dic["S2_QualifiedRate"], dic["S3_BadProduction"], dic["S3_CurrentProduction"], dic["S3_QualifiedRate"], dic["S4_BadProduction"], dic["S4_CurrentProduction"], dic["S4_QualifiedRate"],
                   dic["T1_BadProduction"], dic["T1_CurrentProduction"], dic["T1_QualifiedRate"], dic["T2_BadProduction"], dic["T2_CurrentProduction"], dic["T2_QualifiedRate"], dic["T3_BadProduction"], dic["T3_CurrentProduction"], dic["T3_QualifiedRate"], dic["T4_BadProduction"], dic["T4_CurrentProduction"], dic["T4_QualifiedRate"], dic["CurrentPlanProduction"], dic["CurrentRealProduction"],
                   dic["S1_PC_RealValue"], dic["S1_PS_RealValue"], dic["S1_PS_Rise"], dic["S1_PS_Fall"], dic["S1_PS_r_f"], dic["S2_PC_RealValue"], dic["S2_PS_RealValue"], dic["S2_PS_Rise"], dic["S2_PS_Fall"], dic["S2_PS_r_f"], dic["S3_PC_RealValue"], dic["S3_PS_RealValue"], dic["S3_PS_Rise"], dic["S3_PS_Fall"], dic["S3_PS_r_f"], dic["S4_PC_RealValue"], dic["S4_PS_RealValue"], dic["S4_PS_Rise"], dic["S4_PS_Fall"], dic["S4_PS_r_f"],
                   dic["T1_PC_RealValue"], dic["T1_PS_RealValue"], dic["T1_PS_Rise"], dic["T1_PS_Fall"], dic["T1_PS_r_f"], dic["T2_PC_RealValue"], dic["T2_PS_RealValue"], dic["T2_PS_Rise"], dic["T2_PS_Fall"], dic["T2_PS_r_f"], dic["T3_PC_RealValue"], dic["T3_PS_RealValue"], dic["T3_PS_Rise"], dic["T3_PS_Fall"], dic["T3_PS_r_f"], dic["T4_PC_RealValue"], dic["T4_PS_RealValue"], dic["T4_PS_Rise"], dic["T4_PS_Fall"], dic["T4_PS_r_f"]);





                    //string sqL = string.Format("insert into NJ501ReservedData (Number,S1_BadProduction,S1_CurrentProduction,S1_QualifiedRate,S2_BadProduction,S2_CurrentProduction,S2_QualifiedRate,S3_BadProduction,S3_CurrentProduction,S3_QualifiedRate,S4_BadProduction,S4_CurrentProduction,S4_QualifiedRate,T1_BadProduction, T1_CurrentProduction, T1_QualifiedRate, T2_BadProduction, T2_CurrentProduction, T2_QualifiedRate, T3_BadProduction, T3_CurrentProduction, T3_QualifiedRate, T4_BadProduction, T4_CurrentProduction, T4_QualifiedRate, CurrentPlanProduction, CurrentRealProduction,S1_PC_RealValue, S1_PS_RealValue, S1_PS_Rise, S1_PS_Fall, S1_PS_r_f, S2_PC_RealValue, S2_PS_RealValue, S2_PS_Rise, S2_PS_Fall, S2_PS_r_f, S3_PC_RealValue, S3_PS_RealValue, S3_PS_Rise, S3_PS_Fall, S3_PS_r_f, S4_PC_RealValue, S4_PS_RealValue, S4_PS_Rise, S4_PS_Fall, S4_PS_r_f,T1_PC_RealValue, T1_PS_RealValue, T1_PS_Rise, T1_PS_Fall, T1_PS_r_f, T2_PC_RealValue, T2_PS_RealValue, T2_PS_Rise, T2_PS_Fall, T2_PS_r_f, T3_PC_RealValue, T3_PS_RealValue, T3_PS_Rise, T3_PS_Fall, T3_PS_r_f, T4_PC_RealValue, T4_PS_RealValue, T4_PS_Rise, T4_PS_Fall, T4_PS_r_f,P1_BadProduction,P1_CurrentProduction,P1_QualifiedRate,P2_BadProduction,P2_CurrentProduction,P2_QualifiedRate,P3_BadProduction,P3_CurrentProduction,P3_QualifiedRate,P4_BadProduction,P4_CurrentProduction,P4_QualifiedRate,LastUpdateTime) values (0,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65},{66},{67},{68},{69},{70},{71},{72},{73},{74},{75},{76},{77})",
                    //dic["S1_BadProduction"], dic["S1_CurrentProduction"], dic["S1_QualifiedRate"], dic["S2_BadProduction"], dic["S2_CurrentProduction"], dic["S2_QualifiedRate"], dic["S3_BadProduction"], dic["S3_CurrentProduction"], dic["S3_QualifiedRate"], dic["S4_BadProduction"], dic["S4_CurrentProduction"], dic["S4_QualifiedRate"],
                    //dic["T1_BadProduction"], dic["T1_CurrentProduction"], dic["T1_QualifiedRate"], dic["T2_BadProduction"], dic["T2_CurrentProduction"], dic["T2_QualifiedRate"], dic["T3_BadProduction"], dic["T3_CurrentProduction"], dic["T3_QualifiedRate"], dic["T4_BadProduction"], dic["T4_CurrentProduction"], dic["T4_QualifiedRate"], dic["CurrentPlanProduction"], dic["CurrentRealProduction"],
                    //dic["S1_PC_RealValue"], dic["S1_PS_RealValue"], dic["S1_PS_Rise"], dic["S1_PS_Fall"], dic["S1_PS_r_f"], dic["S2_PC_RealValue"], dic["S2_PS_RealValue"], dic["S2_PS_Rise"], dic["S2_PS_Fall"], dic["S2_PS_r_f"], dic["S3_PC_RealValue"], dic["S3_PS_RealValue"], dic["S3_PS_Rise"], dic["S3_PS_Fall"], dic["S3_PS_r_f"], dic["S4_PC_RealValue"], dic["S4_PS_RealValue"], dic["S4_PS_Rise"], dic["S4_PS_Fall"], dic["S4_PS_r_f"],
                    //dic["T1_PC_RealValue"], dic["T1_PS_RealValue"], dic["T1_PS_Rise"], dic["T1_PS_Fall"], dic["T1_PS_r_f"], dic["T2_PC_RealValue"], dic["T2_PS_RealValue"], dic["T2_PS_Rise"], dic["T2_PS_Fall"], dic["T2_PS_r_f"], dic["T3_PC_RealValue"], dic["T3_PS_RealValue"], dic["T3_PS_Rise"], dic["T3_PS_Fall"], dic["T3_PS_r_f"], dic["T4_PC_RealValue"], dic["T4_PS_RealValue"], dic["T4_PS_Rise"], dic["T4_PS_Fall"], dic["T4_PS_r_f"],
                    //dic["P1_BadProduction"], dic["P1_CurrentProduction"], dic["P1_QualifiedRate"], dic["P2_BadProduction"], dic["P2_CurrentProduction"], dic["P2_QualifiedRate"], dic["P3_BadProduction"], dic["P3_CurrentProduction"], dic["P3_QualifiedRate"], dic["P4_BadProduction"], dic["P4_CurrentProduction"], dic["P4_QualifiedRate"]);


                    string sqL = string.Format("insert into NJ501ReservedData (Number,S1_BadProduction,S1_CurrentProduction,S1_QualifiedRate,S2_BadProduction,S2_CurrentProduction,S2_QualifiedRate,S3_BadProduction,S3_CurrentProduction,S3_QualifiedRate,S4_BadProduction,S4_CurrentProduction,S4_QualifiedRate,T1_BadProduction, T1_CurrentProduction, T1_QualifiedRate, T2_BadProduction, T2_CurrentProduction, T2_QualifiedRate, T3_BadProduction, T3_CurrentProduction, T3_QualifiedRate, T4_BadProduction, T4_CurrentProduction, T4_QualifiedRate, CurrentPlanProduction, CurrentRealProduction,S1_PC_RealValue, S1_PS_RealValue, S1_PS_Rise, S1_PS_Fall, S1_PS_r_f, S2_PC_RealValue, S2_PS_RealValue, S2_PS_Rise, S2_PS_Fall, S2_PS_r_f, S3_PC_RealValue, S3_PS_RealValue, S3_PS_Rise, S3_PS_Fall, S3_PS_r_f, S4_PC_RealValue, S4_PS_RealValue, S4_PS_Rise, S4_PS_Fall, S4_PS_r_f,T1_PC_RealValue, T1_PS_RealValue, T1_PS_Rise, T1_PS_Fall, T1_PS_r_f, T2_PC_RealValue, T2_PS_RealValue, T2_PS_Rise, T2_PS_Fall, T2_PS_r_f, T3_PC_RealValue, T3_PS_RealValue, T3_PS_Rise, T3_PS_Fall, T3_PS_r_f, T4_PC_RealValue, T4_PS_RealValue, T4_PS_Rise, T4_PS_Fall, T4_PS_r_f,LastUpdateTime) values (0,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},{61},{62},{63},{64},{65})",
                    dic["S1_BadProduction"], dic["S1_CurrentProduction"], dic["S1_QualifiedRate"], dic["S2_BadProduction"], dic["S2_CurrentProduction"], dic["S2_QualifiedRate"], dic["S3_BadProduction"], dic["S3_CurrentProduction"], dic["S3_QualifiedRate"], dic["S4_BadProduction"], dic["S4_CurrentProduction"], dic["S4_QualifiedRate"],
                    dic["T1_BadProduction"], dic["T1_CurrentProduction"], dic["T1_QualifiedRate"], dic["T2_BadProduction"], dic["T2_CurrentProduction"], dic["T2_QualifiedRate"], dic["T3_BadProduction"], dic["T3_CurrentProduction"], dic["T3_QualifiedRate"], dic["T4_BadProduction"], dic["T4_CurrentProduction"], dic["T4_QualifiedRate"], dic["CurrentPlanProduction"], dic["CurrentRealProduction"],
                    dic["S1_PC_RealValue"], dic["S1_PS_RealValue"], dic["S1_PS_Rise"], dic["S1_PS_Fall"], dic["S1_PS_r_f"], dic["S2_PC_RealValue"], dic["S2_PS_RealValue"], dic["S2_PS_Rise"], dic["S2_PS_Fall"], dic["S2_PS_r_f"], dic["S3_PC_RealValue"], dic["S3_PS_RealValue"], dic["S3_PS_Rise"], dic["S3_PS_Fall"], dic["S3_PS_r_f"], dic["S4_PC_RealValue"], dic["S4_PS_RealValue"], dic["S4_PS_Rise"], dic["S4_PS_Fall"], dic["S4_PS_r_f"],
                    dic["T1_PC_RealValue"], dic["T1_PS_RealValue"], dic["T1_PS_Rise"], dic["T1_PS_Fall"], dic["T1_PS_r_f"], dic["T2_PC_RealValue"], dic["T2_PS_RealValue"], dic["T2_PS_Rise"], dic["T2_PS_Fall"], dic["T2_PS_r_f"], dic["T3_PC_RealValue"], dic["T3_PS_RealValue"], dic["T3_PS_Rise"], dic["T3_PS_Fall"], dic["T3_PS_r_f"], dic["T4_PC_RealValue"], dic["T4_PS_RealValue"], dic["T4_PS_Rise"], dic["T4_PS_Fall"], dic["T4_PS_r_f"]);



                    //HtpCom.Post(sql);
                    HttpCom.Post(sqL);

                    // Display the collected things, 不要去管                  
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

                System.Threading.Thread.Sleep(200);
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
