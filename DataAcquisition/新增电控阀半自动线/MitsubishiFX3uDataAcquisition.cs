using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisition
{
    class MitsubishiFX3uDataAcquisition
    {
        //读取三菱Fx3u系列PLC数据（Modbus Tcp协议）
        public Dictionary<string, float> AcquireData(string ip, int port)
        {
            #region   //报文
            //第一个命令报文     
            byte[] FirstCommand = new byte[12];
            FirstCommand[0] = 0x00;
            FirstCommand[1] = 0x00;
            FirstCommand[2] = 0x00;
            FirstCommand[3] = 0x00;
            FirstCommand[4] = 0x00;
            FirstCommand[5] = 0x06;
            FirstCommand[6] = 0x01;
            FirstCommand[7] = 0x03;
            FirstCommand[8] = 0x07;
            FirstCommand[9] = 0xD0;
            FirstCommand[10] = 0x00;
            FirstCommand[11] = 0x32;

            //第二个命令报文
            byte[] SecondCommand = new byte[12];
            SecondCommand[0] = 0x00;
            SecondCommand[1] = 0x00;
            SecondCommand[2] = 0x00;
            SecondCommand[3] = 0x00;
            SecondCommand[4] = 0x00;
            SecondCommand[5] = 0x06;
            SecondCommand[6] = 0x01;
            SecondCommand[7] = 0x03;
            SecondCommand[8] = 0x08;
            SecondCommand[9] = 0xE3;
            SecondCommand[10] = 0x00;
            SecondCommand[11] = 0x32;

            //第三个命令报文
            byte[] ThirdCommand = new byte[12];
            ThirdCommand[0] = 0x00;
            ThirdCommand[1] = 0x00;
            ThirdCommand[2] = 0x00;
            ThirdCommand[3] = 0x00;
            ThirdCommand[4] = 0x00;
            ThirdCommand[5] = 0x06;
            ThirdCommand[6] = 0x01;
            ThirdCommand[7] = 0x03;
            ThirdCommand[8] = 0x05;
            ThirdCommand[9] = 0x3B;
            ThirdCommand[10] = 0x00;
            ThirdCommand[11] = 0x01;

            //第四个命令报文
            byte[] FourthCommand = new byte[12];
            FourthCommand[0] = 0x00;
            FourthCommand[1] = 0x00;
            FourthCommand[2] = 0x00;
            FourthCommand[3] = 0x00;
            FourthCommand[4] = 0x00;
            FourthCommand[5] = 0x06;
            FourthCommand[6] = 0x01;
            FourthCommand[7] = 0x01;
            FourthCommand[8] = 0x00;
            FourthCommand[9] = 0x00;
            FourthCommand[10] = 0x00;
            FourthCommand[11] = 0x01;
            #endregion

            byte[] FirstResponse = new byte[150];
            byte[] SecondResponse = new byte[150];
            byte[] ThirdResponse = new byte[20];
            byte[] FourthResponse = new byte[20];


            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);        //串口连接

            socket.Send(FirstCommand, 0, 12, SocketFlags.None);
            socket.Receive(FirstResponse, 0, 150, SocketFlags.None);
            socket.Send(SecondCommand, 0, 12, SocketFlags.None);
            socket.Receive(SecondResponse, 0, 150, SocketFlags.None);
            socket.Send(ThirdCommand, 0, 12, SocketFlags.None);
            socket.Receive(ThirdResponse, 0, 20, SocketFlags.None);
            socket.Send(FourthCommand, 0, 12, SocketFlags.None);
            socket.Receive(FourthResponse, 0, 20, SocketFlags.None);

            socket.Close();                 //串口连接关闭

            //解析第一次回应
            float Position = (float)((FirstResponse[21] * 256 + FirstResponse[22]) / 100.0);
            float Pressure = (float)((FirstResponse[41] * 256 + FirstResponse[42]) / 10.0);
            float UpperComputerSensor = (float)((FirstResponse[105] * 256 + FirstResponse[106]) / 1000.0);
            float QualifiedProduction = FirstResponse[49] * 256 + FirstResponse[50];
            float UnqualifiedProduction = FirstResponse[85] * 256 + FirstResponse[86];

            //解析第二次回应
            float StandardValue = -(float)((SecondResponse[15] * 256 + SecondResponse[16]) / 1000.0);
            float LocalComputerSensor = (float)((SecondResponse[99] * 256 + SecondResponse[100]) / 1000.0);

            //解析第三次回应
            float PlcRuntime = ThirdResponse[9] * 256 + ThirdResponse[10];

            //解析第四次回应
            float AbnormalAlarm = FourthResponse[9];

            Dictionary<string, float> dic = new Dictionary<string, float>();
            dic.Add("Position", Position);
            dic.Add("Pressure", Pressure);
            dic.Add("QualifiedProduction", QualifiedProduction);
            dic.Add("UnqualifiedProduction", UnqualifiedProduction);
            dic.Add("UpperComputerSensor", UpperComputerSensor);
            dic.Add("StandardValue", StandardValue);
            dic.Add("LocalComputerSensor", LocalComputerSensor);
            dic.Add("PlcRuntime", PlcRuntime);
            dic.Add("AbnormalAlarm", AbnormalAlarm);
            return dic;
        }
    }
}
