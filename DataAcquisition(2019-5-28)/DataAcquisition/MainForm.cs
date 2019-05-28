using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcquisition
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            LoadLastCfgFile();  //加载上一次配置设置
        }

        #region 

        #endregion

        private void btnAddMitsubishiFX3uDataAquision_Click(object sender, EventArgs e)
        {
            MitsubishiFX3uPanel acPanel = new MitsubishiFX3uPanel();
            acPanel.TopLevel = false;
            acPanel.Parent = mainFlowLayoutPanel;
            acPanel.Show();
        }

        private void btnAddOmron501DataAquision_Click(object sender, EventArgs e)
        {
            Omron501Panel arPanel = new Omron501Panel();
            arPanel.TopLevel = false;
            arPanel.Parent = mainFlowLayoutPanel;
            arPanel.Show();
        }

        private void btnAddSiemens200DataAquision_Click(object sender, EventArgs e)
        {
            Siemens200Panel wPanel = new Siemens200Panel();
            wPanel.TopLevel = false;
            wPanel.Parent = mainFlowLayoutPanel;
            wPanel.Show();
        }

        private void btnAddSiemens1200DataAquision_Click(object sender, EventArgs e)
        {
            Siemens1200Panel pPanel = new Siemens1200Panel();
            pPanel.TopLevel = false;
            pPanel.Parent = mainFlowLayoutPanel;
            pPanel.Show();
        }

        private void btnAddEnergyConsumptionAquision_Click(object sender, EventArgs e)
        {
            EnergyConsumptionPanel pPanel = new EnergyConsumptionPanel();
            pPanel.TopLevel = false;
            pPanel.Parent = mainFlowLayoutPanel;
            pPanel.Show();
        }


        private void btnAddTorqueAquision_Click(object sender, EventArgs e)
        {
            TorquePanel pPanel = new TorquePanel();
            pPanel.TopLevel = false;
            pPanel.Parent = mainFlowLayoutPanel;
            pPanel.Show();
        }

        
        private void btnAddLabviewAquision_Click(object sender, EventArgs e)
        {
            LabviewPanel pPanel = new LabviewPanel();
            pPanel.TopLevel = false;
            pPanel.Parent = mainFlowLayoutPanel;
            pPanel.Show();
        }




        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                FileStream fs = new FileStream("DataAcquisitionConfig.ini", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);

                foreach (Control c in mainFlowLayoutPanel.Controls)
                {
                    if (c is Omron501Panel)
                    {
                        Omron501Panel panel = c as Omron501Panel;
                        sw.WriteLine("Begin");
                        sw.WriteLine("Omron501Panel");
                        sw.WriteLine("TargetIp");
                        sw.WriteLine(panel.IpAddr.Text);
                        sw.WriteLine("TargetPort");
                        sw.WriteLine(panel.Port.Text);
                        sw.WriteLine("End");
                    }
                    else if (c is MitsubishiFX3uPanel)
                    {
                        MitsubishiFX3uPanel panel = c as MitsubishiFX3uPanel;
                        sw.WriteLine("Begin");
                        sw.WriteLine("MitsubishiFX3uPanel");
                        sw.WriteLine("TargetIp");
                        sw.WriteLine(panel.IpAddr.Text);
                        sw.WriteLine("TargetPort");
                        sw.WriteLine(panel.Port.Text);
                        sw.WriteLine("End");
                    }
                    else if (c is Siemens1200Panel)
                    {
                        Siemens1200Panel panel = c as Siemens1200Panel;
                        sw.WriteLine("Begin");
                        sw.WriteLine("Siemens1200Panel");
                        sw.WriteLine("TargetIp");
                        sw.WriteLine(panel.IpAddr.Text);
                        sw.WriteLine("TargetPort");
                        sw.WriteLine(panel.Port.Text);
                        sw.WriteLine("End");
                    }
                    else if (c is Siemens200Panel)
                    {
                        Siemens200Panel panel = c as Siemens200Panel;
                        sw.WriteLine("Begin");
                        sw.WriteLine("Siemens200Panel");
                        sw.WriteLine("TargetIp");
                        sw.WriteLine(panel.IpAddr.Text);
                        sw.WriteLine("TargetPort");
                        sw.WriteLine(panel.Port.Text);
                        sw.WriteLine("End");
                    }
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存最后配置文件失败，原因：\n" + ex.Message);
            }
        }

        private void LoadLastCfgFile()
        {
            try
            {
                StreamReader sr = new StreamReader("DataAcquisitionConfig.ini", Encoding.Default);
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "Omron501Panel")
                    {
                        Omron501Panel panel = new Omron501Panel();
                        panel.TopLevel = false;
                        panel.Show();
                        panel.Parent = mainFlowLayoutPanel;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.IpAddr.Text = line;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.Port.Text = line;

                    }
                    else if (line == "MitsubishiFX3uPanel")
                    {
                        MitsubishiFX3uPanel panel = new MitsubishiFX3uPanel();
                        panel.TopLevel = false;
                        panel.Show();
                        panel.Parent = mainFlowLayoutPanel;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.IpAddr.Text = line;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.Port.Text = line;
                    }
                    else if (line == "Siemens1200Panel")
                    {
                        Siemens1200Panel panel = new Siemens1200Panel();
                        panel.TopLevel = false;
                        panel.Show();
                        panel.Parent = mainFlowLayoutPanel;
                        line = sr.ReadLine();
                        line = sr.ReadLine();                      
                        panel.IpAddr.Text = line;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.Port.Text = line;
                    }
                    else if (line == "Siemens200Panel")
                    {
                        Siemens200Panel panel = new Siemens200Panel();
                        panel.TopLevel = false;
                        panel.Show();
                        panel.Parent = mainFlowLayoutPanel;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.IpAddr.Text = line;
                        line = sr.ReadLine();
                        line = sr.ReadLine();
                        panel.Port.Text = line;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载上一次关闭软件时的配置文件失败，原因：\n" + ex.Message);
            }

        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in mainFlowLayoutPanel.Controls)
            {
                if (c is Omron501Panel)
                {
                    Omron501Panel panel = c as Omron501Panel;
                    panel.btnStartAcquire_Click(null, null);
                }
                else if (c is MitsubishiFX3uPanel)
                {
                    MitsubishiFX3uPanel panel = c as MitsubishiFX3uPanel;
                    panel.btnStartAcquire_Click(null, null);
                }
                else if (c is Siemens200Panel)
                {
                    Siemens200Panel panel = c as Siemens200Panel;
                    panel.btnStartAcquire_Click(null, null);
                }
                else if (c is Siemens1200Panel)
                {
                    Siemens1200Panel panel = c as Siemens1200Panel;
                    panel.btnStartAcquire_Click(null, null);
                }
                else if (c is EnergyConsumptionPanel)
                {
                    EnergyConsumptionPanel panel = c as EnergyConsumptionPanel;
                    panel.btnStartAcquire_Click(null, null);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           // btnStartAll_Click(null, null);
        }

    }
}
