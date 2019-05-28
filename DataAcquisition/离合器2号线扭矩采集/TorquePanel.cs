using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcquisition
{
    public partial class TorquePanel : Form
    {
        BackgroundWorker AquireWorker = new BackgroundWorker();
        bool bWorking = false;

        public TorquePanel()
        {
            InitializeComponent();
        }

        private void btnStartAcquire_Click(object sender, EventArgs e)
        {
            if (!bWorking)
            {
                btnStartAcquire.Enabled = false;
                bWorking = true;
                AquireWorker.DoWork += AquireWorker_DoWork;
                AquireWorker.RunWorkerAsync();

            }
            else
            {

            }
        }

        private void AquireWorker_DoWork(object sender, DoWorkEventArgs e)
        {   
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);
                
            Socket client = newsock.Accept();
            IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;
            Invoke(new EventHandler(delegate
            {
                listBox1.Items.Add("已连接的客户端IP：" + clientip.Address + ",端口：" + clientip.Port);
            }));

            byte[] data = new byte[1024];
            int recv;
            try
            {
                while (bWorking)
                {
                    //用循环来不断的从客户端获取信息    
                    recv = client.Receive(data);
                    Invoke(new EventHandler(delegate
                    {
                        string sql=Encoding.ASCII.GetString(data, 0, recv);
                        //HttpCom.Post(sql);
                        listBox1.Items.Add("接收到"+recv.ToString()+"个字节长度的数据");
                    }));
                }

            }
            catch (Exception)
            {
                Invoke(new EventHandler(delegate
                {
                    listBox1.Items.Add("已断开的客户端IP：" + clientip.Address + ",端口：" + clientip.Port);
                    client.Close();
                    newsock.Close();
                }));
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
