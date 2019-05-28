using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace DataAcquisition
{
    class EnergyConsumptionAcquisition
    {
        //读取电能表的数据（Modbus Tcp协议）
        public Dictionary<string, float> AcquireData(string ip, int port)
        {
            Dictionary<string, float> dic = new Dictionary<string, float>();

            //第一个命令报文     
            byte[] FirstCommand = new byte[12];
            FirstCommand[0] = 0x00;
            FirstCommand[1] = 0x00;
            FirstCommand[2] = 0x00;
            FirstCommand[3] = 0x00;
            FirstCommand[4] = 0x00;
            FirstCommand[5] = 0x06;
            FirstCommand[6] = 0x01;
            FirstCommand[7] = 0x03;//数据存在M去，所以功能码为4
            FirstCommand[8] = 0x00;
            FirstCommand[9] = 0x06;
            FirstCommand[10] = 0x00;
            FirstCommand[11] = 0x02;

            

            byte[] FirstResponse = new byte[150];
           

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(ip, port);        //串口连接

            socket.Send(FirstCommand, 0, 12, SocketFlags.None);
            socket.Receive(FirstResponse, 0, 150, SocketFlags.None);
           

            socket.Close();        //串口连接关闭

            //解析第一次回应

            float ElectricCurrent = (float)((FirstResponse[9]*256*256*256+ FirstResponse[10]*256*256+ FirstResponse[11]*256+ FirstResponse[12])/1000.0);
          
            dic.Add("ElectricCurrent", ElectricCurrent);
          
            return dic;
        }

    }
}
