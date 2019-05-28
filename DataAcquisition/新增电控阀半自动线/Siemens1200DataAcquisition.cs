using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace DataAcquisition
{
    class Siemens1200DataAcquisition
    {
        //读取西门子S71200系列PLC数据（Modbus Tcp协议）
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
            FirstCommand[6] = 0x02;
            FirstCommand[7] = 0x04;//数据存在M去，所以功能码为4
            FirstCommand[8] = 0x01;
            FirstCommand[9] = 0x05;
            FirstCommand[10] = 0x00;
            FirstCommand[11] = 0x40;

            //第二个命令报文     
            byte[] SecondCommand = new byte[12];
            SecondCommand[0] = 0x00;
            SecondCommand[1] = 0x00;
            SecondCommand[2] = 0x00;
            SecondCommand[3] = 0x00;
            SecondCommand[4] = 0x00;
            SecondCommand[5] = 0x06;
            SecondCommand[6] = 0x02;
            SecondCommand[7] = 0x04;//数据存在M去，所以功能码为4
            SecondCommand[8] = 0x01;
            SecondCommand[9] = 0x37;
            SecondCommand[10] = 0x00;
            SecondCommand[11] = 0x40;

            //第三个命令报文     
            byte[] ThirdCommand = new byte[12];
            ThirdCommand[0] = 0x00;
            ThirdCommand[1] = 0x00;
            ThirdCommand[2] = 0x00;
            ThirdCommand[3] = 0x00;
            ThirdCommand[4] = 0x00;
            ThirdCommand[5] = 0x06;
            ThirdCommand[6] = 0x02;
            ThirdCommand[7] = 0x04;//数据存在M去，所以功能码为4
            ThirdCommand[8] = 0x01;
            ThirdCommand[9] = 0x69;
            ThirdCommand[10] = 0x00;
            ThirdCommand[11] = 0x40;

            byte[] FirstResponse = new byte[150];
            byte[] SecondResponse = new byte[150];
            byte[] ThirdResponse = new byte[150];

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(ip, port);        //串口连接

            socket.Send(FirstCommand, 0, 12, SocketFlags.None);
            socket.Receive(FirstResponse, 0, 150, SocketFlags.None);
            socket.Send(SecondCommand, 0, 12, SocketFlags.None);
            socket.Receive(SecondResponse, 0, 150, SocketFlags.None);
            socket.Send(ThirdCommand, 0, 12, SocketFlags.None);
            socket.Receive(ThirdResponse, 0, 150, SocketFlags.None);

            socket.Close();                 //串口连接关闭

            //解析第一次回应
            byte[] PS_Value_1_Reverse = new byte[4] { FirstResponse[12], FirstResponse[11], FirstResponse[10], FirstResponse[9] };
            byte[] PD_Value_1_Reverse = new byte[4] { FirstResponse[20], FirstResponse[19], FirstResponse[18], FirstResponse[17] };
            byte[] PC_Value_1_Reverse = new byte[4] { FirstResponse[28], FirstResponse[27], FirstResponse[26], FirstResponse[25] };
            byte[] PC_Reduce_PS_Value_1_Reverse = new byte[4] { FirstResponse[32], FirstResponse[31], FirstResponse[30], FirstResponse[29] };
            byte[] PS_SettingValue_1_Reverse = new byte[4] {FirstResponse[36],FirstResponse[35],FirstResponse[34],FirstResponse[33] };                          
            byte[] PS_SettingValue_1_UpLimit_Reverse= new byte[4] { FirstResponse[56], FirstResponse[55], FirstResponse[54], FirstResponse[53] };
            byte[] PS_SettingValue_1_DownLimit_Reverse = new byte[4] { FirstResponse[52], FirstResponse[51], FirstResponse[50], FirstResponse[49] };
            byte[] Pressure_1_Reverse = new byte[4] { FirstResponse[64], FirstResponse[63], FirstResponse[62], FirstResponse[61] };

            float PS_Value_1 = BitConverter.ToSingle(PS_Value_1_Reverse, 0);
            float PD_Value_1= BitConverter.ToSingle(PD_Value_1_Reverse, 0);
            float PC_Value_1 = BitConverter.ToSingle(PC_Value_1_Reverse, 0);
            float PC_Reduce_PS_Value_1 = BitConverter.ToSingle(PC_Reduce_PS_Value_1_Reverse, 0);
            float PS_SettingValue_1= BitConverter.ToSingle(PS_SettingValue_1_Reverse, 0);
            float PS_SettingValue_1_UpLimit= BitConverter.ToSingle(PS_SettingValue_1_UpLimit_Reverse, 0);
            float PS_SettingValue_1_DownLimit= BitConverter.ToSingle(PS_SettingValue_1_DownLimit_Reverse, 0);
            float Pressure_1 = BitConverter.ToSingle(Pressure_1_Reverse,0);

            //解析第二次回应
            byte[] PS_Value_2_Reverse = new byte[4] { SecondResponse[12], SecondResponse[11], SecondResponse[10], SecondResponse[9] };
            byte[] PD_Value_2_Reverse = new byte[4] { SecondResponse[20], SecondResponse[19], SecondResponse[18], SecondResponse[17] };
            byte[] PC_Value_2_Reverse = new byte[4] { SecondResponse[28], SecondResponse[27], SecondResponse[26], SecondResponse[25] };
            byte[] PC_Reduce_PS_Value_2_Reverse = new byte[4] { SecondResponse[32], SecondResponse[31], SecondResponse[30], SecondResponse[29] };
            byte[] PS_SettingValue_2_Reverse = new byte[4] { SecondResponse[36], SecondResponse[35], SecondResponse[34], SecondResponse[33] };
            byte[] PS_SettingValue_2_UpLimit_Reverse = new byte[4] { SecondResponse[56], SecondResponse[55], SecondResponse[54], SecondResponse[53] };
            byte[] PS_SettingValue_2_DownLimit_Reverse = new byte[4] { SecondResponse[52], SecondResponse[51], SecondResponse[50], SecondResponse[49] };
            byte[] Pressure_2_Reverse = new byte[4] { SecondResponse[64], SecondResponse[63], SecondResponse[62], SecondResponse[61] };

            float PS_Value_2 = BitConverter.ToSingle(PS_Value_2_Reverse, 0);
            float PD_Value_2 = BitConverter.ToSingle(PD_Value_2_Reverse, 0);
            float PC_Value_2 = BitConverter.ToSingle(PC_Value_2_Reverse, 0);
            float PC_Reduce_PS_Value_2 = BitConverter.ToSingle(PC_Reduce_PS_Value_2_Reverse, 0);
            float PS_SettingValue_2 = BitConverter.ToSingle(PS_SettingValue_2_Reverse, 0);
            float PS_SettingValue_2_UpLimit = BitConverter.ToSingle(PS_SettingValue_2_UpLimit_Reverse, 0);
            float PS_SettingValue_2_DownLimit = BitConverter.ToSingle(PS_SettingValue_2_DownLimit_Reverse, 0);
            float Pressure_2 = BitConverter.ToSingle(Pressure_2_Reverse, 0);

            //解析第三次回应
            byte[] PS_Value_3_Reverse = new byte[4] { ThirdResponse[12], ThirdResponse[11], ThirdResponse[10], ThirdResponse[9] };
            byte[] PD_Value_3_Reverse = new byte[4] { ThirdResponse[20], ThirdResponse[19], ThirdResponse[18], ThirdResponse[17] };
            byte[] PC_Value_3_Reverse = new byte[4] { ThirdResponse[28], ThirdResponse[27], ThirdResponse[26], ThirdResponse[25] };
            byte[] PC_Reduce_PS_Value_3_Reverse = new byte[4] { ThirdResponse[32], ThirdResponse[31], ThirdResponse[30], ThirdResponse[29] };
            byte[] PS_SettingValue_3_Reverse = new byte[4] { ThirdResponse[36], ThirdResponse[35], ThirdResponse[34], ThirdResponse[33] };
            byte[] PS_SettingValue_3_UpLimit_Reverse = new byte[4] { ThirdResponse[56], ThirdResponse[55], ThirdResponse[54], ThirdResponse[53] };
            byte[] PS_SettingValue_3_DownLimit_Reverse = new byte[4] { ThirdResponse[52], ThirdResponse[51], ThirdResponse[50], ThirdResponse[49] };
            byte[] Pressure_3_Reverse = new byte[4] { ThirdResponse[64], ThirdResponse[63], ThirdResponse[62], ThirdResponse[61] };

            float PS_Value_3 = BitConverter.ToSingle(PS_Value_3_Reverse, 0);
            float PD_Value_3 = BitConverter.ToSingle(PD_Value_3_Reverse, 0);
            float PC_Value_3 = BitConverter.ToSingle(PC_Value_3_Reverse, 0);
            float PC_Reduce_PS_Value_3 = BitConverter.ToSingle(PC_Reduce_PS_Value_3_Reverse, 0);
            float PS_SettingValue_3 = BitConverter.ToSingle(PS_SettingValue_3_Reverse, 0);
            float PS_SettingValue_3_UpLimit = BitConverter.ToSingle(PS_SettingValue_3_UpLimit_Reverse, 0);
            float PS_SettingValue_3_DownLimit = BitConverter.ToSingle(PS_SettingValue_3_DownLimit_Reverse, 0);
            float Pressure_3 = BitConverter.ToSingle(Pressure_3_Reverse, 0);

            dic.Add("PS_Value_1", PS_Value_1);
            dic.Add("PD_Value_1", PD_Value_1);
            dic.Add("PC_Value_1", PC_Value_1);
            dic.Add("PC_Reduce_PS_Value_1", PC_Reduce_PS_Value_1);
            dic.Add("PS_SettingValue_1", PS_SettingValue_1);
            dic.Add("PS_SettingValue_1_UpLimit", PS_SettingValue_1_UpLimit);
            dic.Add("PS_SettingValue_1_DownLimit", PS_SettingValue_1_DownLimit);
            dic.Add("Pressure_1", Pressure_1);

            dic.Add("PS_Value_2", PS_Value_2);
            dic.Add("PD_Value_2", PD_Value_2);
            dic.Add("PC_Value_2", PC_Value_2);
            dic.Add("PC_Reduce_PS_Value_2", PC_Reduce_PS_Value_2);
            dic.Add("PS_SettingValue_2", PS_SettingValue_2);
            dic.Add("PS_SettingValue_2_UpLimit", PS_SettingValue_2_UpLimit);
            dic.Add("PS_SettingValue_2_DownLimit", PS_SettingValue_2_DownLimit);
            dic.Add("Pressure_2", Pressure_2);

            dic.Add("PS_Value_3", PS_Value_3);
            dic.Add("PD_Value_3", PD_Value_3);
            dic.Add("PC_Value_3", PC_Value_3);
            dic.Add("PC_Reduce_PS_Value_3", PC_Reduce_PS_Value_3);
            dic.Add("PS_SettingValue_3", PS_SettingValue_3);
            dic.Add("PS_SettingValue_3_UpLimit", PS_SettingValue_3_UpLimit);
            dic.Add("PS_SettingValue_3_DownLimit", PS_SettingValue_3_DownLimit);
            dic.Add("Pressure_3", Pressure_3);

            return dic;
        }

    }
}
