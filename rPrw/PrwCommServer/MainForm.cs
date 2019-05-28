using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrwCommServer
{
    public partial class MainForm : Form
    {
        public static MainForm TheForm;
        public SynchronizationContext m_syncContext = null;
        public int MaxLogCount = 5000;
        public static string DataBasePathName = null;
        public static int Port = 1186;

        public ServiceHost m_host = null;
        public Thread WcfHostThread = null;
        delegate void MyDelegate();


        public MainForm()
        {
            InitializeComponent();
            m_syncContext = SynchronizationContext.Current;
            TheForm = this;

            DataBasePathName = Registor.GetRegistryKeyString("DataBasePathName", "");
            if (DataBasePathName == "")
            {
                DataBasePathName = "D:\\DB.mdb";
                Registor.SetRegistryKey("DataBasePathName", DataBasePathName);
            }

            Port = Registor.GetRegistryKeyInt("Port", -1);
            if (Port == -1)
            {
                Port = 1185;
                Registor.SetRegistryKey("Port", Port);
            }
            MaxLogCount = Registor.GetRegistryKeyInt("MaxLogCount", -1);
            if (MaxLogCount == -1)
            {
                MaxLogCount = 5000;
                Registor.SetRegistryKey("MaxLogCount", MaxLogCount);
            }
        }
        public void StartService()
        {
            linkLabel_ServiceStatus.Text = "服务已启动";
        }

        public void WcfHostThreadProcess()
        {
            try
            {
                if (m_host == null)//判断服务是否关闭 
                {
                    Port = 1185;
                    m_host = new ServiceHost(typeof(PrwCommServer.PrwCommService), new Uri(string.Format("http://localhost:{0}/", Port)));
                    m_host.Open();
                    
                    MyDelegate del = new MyDelegate(StartService);
                    this.BeginInvoke(del);
                    
                }
            }
            catch (System.Exception ex)
            {
                m_host = null;
                MessageBox.Show(ex.Message + "\n请尝试以管理员身份运行此程序");
            }
        }


        private void button_StartService_Click(object sender, EventArgs e)
        {
            if (m_host == null)
            {
                WcfHostThread = new Thread(WcfHostThreadProcess);
                WcfHostThread.Start();
                WcfHostThread.Join();
            }
        }

        private void button_StopService_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_host != null && m_host.State != CommunicationState.Closed)//判断服务是否关闭 
                {
                    m_host.Close();//关闭服务 
                    m_host = null;
                    this.linkLabel_ServiceStatus.Text = "服务已关闭";
                    WcfHostThread.Abort();
                    WcfHostThread = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            button_StopService_Click(null, null);
        }

        public void _Log(object obj)
        {
            if (!CheckBox_UseLog.Checked)
                return;

            int count = listBox_Log.Items.Count;
            if (count > MaxLogCount)
            {
                listBox_Log.Items.Clear();
            }

            string data = obj as string;
            listBox_Log.BeginUpdate();
            string sLog = DateTime.Now.ToString() + " \\> " + data;
            listBox_Log.Items.Add(sLog);

            if (checkBox_ListBoxAutoRoll.Checked)
            {
                listBox_Log.SelectedIndex = listBox_Log.Items.Count - 1;
                listBox_Log.SelectedIndex = -1;
            }

            listBox_Log.EndUpdate();
        }

        public static void Log(string str)
        {
            TheForm.m_syncContext.Post(TheForm._Log, str);
        }

        private void button_ClearLog_Click(object sender, EventArgs e)
        {
            listBox_Log.Items.Clear();
        }

        private void button_Settings_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.ShowDialog();
        }

        private void listBox_Log_DoubleClick(object sender, EventArgs e)
        {
            if (checkBox_ListBoxAutoRoll.Checked == false)
            {
                WatchForm wf = new WatchForm();
                wf.textBox_Watch.Text = listBox_Log.SelectedItem.ToString();
                wf.textBox_Watch.Select(0, 0);
                wf.Show();
            }
        }

        private void linkLabel_ServiceStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
