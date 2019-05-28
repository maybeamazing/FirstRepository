using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisition
{
    class Omron501DataAcquisition
    {
        //读取欧姆龙NJ系列PLC数据（FINS协议）
        public Dictionary<string, float> AcquireData(string ip, int port)
        {

            //握手报文命令
            byte[] ShakeHandCommand = new byte[20];
            ShakeHandCommand[0] = 0x46;
            ShakeHandCommand[1] = 0x49;
            ShakeHandCommand[2] = 0x4E;
            ShakeHandCommand[3] = 0x53;
            ShakeHandCommand[4] = 0x00;
            ShakeHandCommand[5] = 0x00;
            ShakeHandCommand[6] = 0x00;
            ShakeHandCommand[7] = 0x0C;
            ShakeHandCommand[8] = 0x00;
            ShakeHandCommand[9] = 0x00;
            ShakeHandCommand[10] = 0x00;
            ShakeHandCommand[11] = 0x00;
            ShakeHandCommand[12] = 0x00;
            ShakeHandCommand[13] = 0x00;
            ShakeHandCommand[14] = 0x00;
            ShakeHandCommand[15] = 0x00;
            ShakeHandCommand[16] = 0x00;
            ShakeHandCommand[17] = 0x00;
            ShakeHandCommand[18] = 0x00;
            ShakeHandCommand[19] = 0x64;//上位机节点号

            //第一次读取数据指令 读D652
            byte[] FirstCommand = new byte[34];
            FirstCommand[0] = 0x46;
            FirstCommand[1] = 0x49;
            FirstCommand[2] = 0x4E;
            FirstCommand[3] = 0x53;
            FirstCommand[4] = 0x00;
            FirstCommand[5] = 0x00;
            FirstCommand[6] = 0x00;
            FirstCommand[7] = 0x1A;
            FirstCommand[8] = 0x00;
            FirstCommand[9] = 0x00;
            FirstCommand[10] = 0x00;
            FirstCommand[11] = 0x02;
            FirstCommand[12] = 0x00;
            FirstCommand[13] = 0x00;
            FirstCommand[14] = 0x00;
            FirstCommand[15] = 0x00;
            FirstCommand[16] = 0x80;
            FirstCommand[17] = 0x00;
            FirstCommand[18] = 0x02;
            FirstCommand[19] = 0x00;
            FirstCommand[20] = 0x01;    //PLC节点号
            FirstCommand[21] = 0x00;
            FirstCommand[22] = 0x00;
            FirstCommand[23] = 0x64;    //上位机节点号
            FirstCommand[24] = 0x00;
            FirstCommand[25] = 0x00;
            FirstCommand[26] = 0x01;
            FirstCommand[27] = 0x01;
            FirstCommand[28] = 0x82;    //DM区代号
            FirstCommand[29] = 0x00;   //[29]、[30]一起表示D12地址
            FirstCommand[30] = 0x0C;
            FirstCommand[31] = 0x00;
            FirstCommand[32] = 0x00;
            FirstCommand[33] = 0x24;    //读取36个寄存器



            //第二次读取数据指令 读D20
            byte[] SecondCommand = new byte[34];
            SecondCommand[0] = 0x46;
            SecondCommand[1] = 0x49;
            SecondCommand[2] = 0x4E;
            SecondCommand[3] = 0x53;
            SecondCommand[4] = 0x00;
            SecondCommand[5] = 0x00;
            SecondCommand[6] = 0x00;
            SecondCommand[7] = 0x1A;
            SecondCommand[8] = 0x00;
            SecondCommand[9] = 0x00;
            SecondCommand[10] = 0x00;
            SecondCommand[11] = 0x02;
            SecondCommand[12] = 0x00;
            SecondCommand[13] = 0x00;
            SecondCommand[14] = 0x00;
            SecondCommand[15] = 0x00;
            SecondCommand[16] = 0x80;
            SecondCommand[17] = 0x00;
            SecondCommand[18] = 0x02;
            SecondCommand[19] = 0x00;
            SecondCommand[20] = 0x01;    //PLC节点号
            SecondCommand[21] = 0x00;
            SecondCommand[22] = 0x00;
            SecondCommand[23] = 0x64;    //上位机节点号
            SecondCommand[24] = 0x00;
            SecondCommand[25] = 0x00;
            SecondCommand[26] = 0x01;
            SecondCommand[27] = 0x01;
            SecondCommand[28] = 0x82;    //DM区代号
            SecondCommand[29] = 0x00;   //[29]、[30]一起表示D52地址
            SecondCommand[30] = 0x34;
            SecondCommand[31] = 0x00;
            SecondCommand[32] = 0x00;
            SecondCommand[33] = 0x24; 

            //第三次读取数据指令 
            byte[] ThirdCommand = new byte[34];
            ThirdCommand[0] = 0x46;
            ThirdCommand[1] = 0x49;
            ThirdCommand[2] = 0x4E;
            ThirdCommand[3] = 0x53;
            ThirdCommand[4] = 0x00;
            ThirdCommand[5] = 0x00;
            ThirdCommand[6] = 0x00;
            ThirdCommand[7] = 0x1A;
            ThirdCommand[8] = 0x00;
            ThirdCommand[9] = 0x00;
            ThirdCommand[10] = 0x00;
            ThirdCommand[11] = 0x02;
            ThirdCommand[12] = 0x00;
            ThirdCommand[13] = 0x00;
            ThirdCommand[14] = 0x00;
            ThirdCommand[15] = 0x00;
            ThirdCommand[16] = 0x80;
            ThirdCommand[17] = 0x00;
            ThirdCommand[18] = 0x02;
            ThirdCommand[19] = 0x00;
            ThirdCommand[20] = 0x01;    //PLC节点号
            ThirdCommand[21] = 0x00;
            ThirdCommand[22] = 0x00;
            ThirdCommand[23] = 0x64;    //上位机节点号
            ThirdCommand[24] = 0x00;
            ThirdCommand[25] = 0x00;
            ThirdCommand[26] = 0x01;
            ThirdCommand[27] = 0x01;
            ThirdCommand[28] = 0x82;    //DM区代号
            ThirdCommand[29] = 0x01;   //[29]、[30]一起表示D276地址
            ThirdCommand[30] = 0x14;
            ThirdCommand[31] = 0x00;
            ThirdCommand[32] = 0x00;
            ThirdCommand[33] = 0x24;

            //第四次读取数据指令 
            byte[] FourthCommand = new byte[34];
            FourthCommand[0] = 0x46;
            FourthCommand[1] = 0x49;
            FourthCommand[2] = 0x4E;
            FourthCommand[3] = 0x53;
            FourthCommand[4] = 0x00;
            FourthCommand[5] = 0x00;
            FourthCommand[6] = 0x00;
            FourthCommand[7] = 0x1A;
            FourthCommand[8] = 0x00;
            FourthCommand[9] = 0x00;
            FourthCommand[10] = 0x00;
            FourthCommand[11] = 0x02;
            FourthCommand[12] = 0x00;
            FourthCommand[13] = 0x00;
            FourthCommand[14] = 0x00;
            FourthCommand[15] = 0x00;
            FourthCommand[16] = 0x80;
            FourthCommand[17] = 0x00;
            FourthCommand[18] = 0x02;
            FourthCommand[19] = 0x00;
            FourthCommand[20] = 0x01;    //PLC节点号
            FourthCommand[21] = 0x00;
            FourthCommand[22] = 0x00;
            FourthCommand[23] = 0x64;    //上位机节点号
            FourthCommand[24] = 0x00;
            FourthCommand[25] = 0x00;
            FourthCommand[26] = 0x01;
            FourthCommand[27] = 0x01;
            FourthCommand[28] = 0x82;    //DM区代号
            FourthCommand[29] = 0x01;   //[29]、[30]一起表示D476地址
            FourthCommand[30] = 0xDC;
            FourthCommand[31] = 0x00;
            FourthCommand[32] = 0x00;
            FourthCommand[33] = 0x24;

            //第五次读取数据指令 
            byte[] FifthCommand = new byte[34];
            FifthCommand[0] = 0x46;
            FifthCommand[1] = 0x49;
            FifthCommand[2] = 0x4E;
            FifthCommand[3] = 0x53;
            FifthCommand[4] = 0x00;
            FifthCommand[5] = 0x00;
            FifthCommand[6] = 0x00;
            FifthCommand[7] = 0x1A;
            FifthCommand[8] = 0x00;
            FifthCommand[9] = 0x00;
            FifthCommand[10] = 0x00;
            FifthCommand[11] = 0x02;
            FifthCommand[12] = 0x00;
            FifthCommand[13] = 0x00;
            FifthCommand[14] = 0x00;
            FifthCommand[15] = 0x00;
            FifthCommand[16] = 0x80;
            FifthCommand[17] = 0x00;
            FifthCommand[18] = 0x02;
            FifthCommand[19] = 0x00;
            FifthCommand[20] = 0x01;    //PLC节点号
            FifthCommand[21] = 0x00;
            FifthCommand[22] = 0x00;
            FifthCommand[23] = 0x64;    //上位机节点号
            FifthCommand[24] = 0x00;
            FifthCommand[25] = 0x00;
            FifthCommand[26] = 0x01;
            FifthCommand[27] = 0x01;
            FifthCommand[28] = 0x82;    //DM区代号
            FifthCommand[29] = 0x02;   //[29]、[30]一起表示D676地址
            FifthCommand[30] = 0xA4;
            FifthCommand[31] = 0x00;
            FifthCommand[32] = 0x00;
            FifthCommand[33] = 0x24;


            //第六次读取数据指令 
            byte[] SixthCommand = new byte[34];
            SixthCommand[0] = 0x46;
            SixthCommand[1] = 0x49;
            SixthCommand[2] = 0x4E;
            SixthCommand[3] = 0x53;
            SixthCommand[4] = 0x00;
            SixthCommand[5] = 0x00;
            SixthCommand[6] = 0x00;
            SixthCommand[7] = 0x1A;
            SixthCommand[8] = 0x00;
            SixthCommand[9] = 0x00;
            SixthCommand[10] = 0x00;
            SixthCommand[11] = 0x02;
            SixthCommand[12] = 0x00;
            SixthCommand[13] = 0x00;
            SixthCommand[14] = 0x00;
            SixthCommand[15] = 0x00;
            SixthCommand[16] = 0x80;
            SixthCommand[17] = 0x00;
            SixthCommand[18] = 0x02;
            SixthCommand[19] = 0x00;
            SixthCommand[20] = 0x01;    //PLC节点号
            SixthCommand[21] = 0x00;
            SixthCommand[22] = 0x00;
            SixthCommand[23] = 0x64;    //上位机节点号
            SixthCommand[24] = 0x00;
            SixthCommand[25] = 0x00;
            SixthCommand[26] = 0x01;
            SixthCommand[27] = 0x01;
            SixthCommand[28] = 0x82;    //DM区代号
            SixthCommand[29] = 0x03;   //[29]、[30]一起表示D876地址
            SixthCommand[30] = 0x6C;
            SixthCommand[31] = 0x00;
            SixthCommand[32] = 0x00;
            SixthCommand[33] = 0x24;

            //第七次读取数据指令
            byte[] SeventhCommand = new byte[34];
            SeventhCommand[0] = 0x46;
            SeventhCommand[1] = 0x49;
            SeventhCommand[2] = 0x4E;
            SeventhCommand[3] = 0x53;
            SeventhCommand[4] = 0x00;
            SeventhCommand[5] = 0x00;
            SeventhCommand[6] = 0x00;
            SeventhCommand[7] = 0x1A;
            SeventhCommand[8] = 0x00;
            SeventhCommand[9] = 0x00;
            SeventhCommand[10] = 0x00;
            SeventhCommand[11] = 0x02;
            SeventhCommand[12] = 0x00;
            SeventhCommand[13] = 0x00;
            SeventhCommand[14] = 0x00;
            SeventhCommand[15] = 0x00;
            SeventhCommand[16] = 0x80;
            SeventhCommand[17] = 0x00;
            SeventhCommand[18] = 0x02;
            SeventhCommand[19] = 0x00;
            SeventhCommand[20] = 0x01;    //PLC节点号
            SeventhCommand[21] = 0x00;
            SeventhCommand[22] = 0x00;
            SeventhCommand[23] = 0x64;    //上位机节点号
            SeventhCommand[24] = 0x00;
            SeventhCommand[25] = 0x00;
            SeventhCommand[26] = 0x01;
            SeventhCommand[27] = 0x01;
            SeventhCommand[28] = 0x82;    //DM区代号
            SeventhCommand[29] = 0x04;   //[29]、[30]一起表示D1076地址
            SeventhCommand[30] = 0x34;
            SeventhCommand[31] = 0x00;
            SeventhCommand[32] = 0x00;
            SeventhCommand[33] = 0x24;

            //第八次读取数据指令
            byte[] EighthCommand = new byte[34];
            EighthCommand[0] = 0x46;
            EighthCommand[1] = 0x49;
            EighthCommand[2] = 0x4E;
            EighthCommand[3] = 0x53;
            EighthCommand[4] = 0x00;
            EighthCommand[5] = 0x00;
            EighthCommand[6] = 0x00;
            EighthCommand[7] = 0x1A;
            EighthCommand[8] = 0x00;
            EighthCommand[9] = 0x00;
            EighthCommand[10] = 0x00;
            EighthCommand[11] = 0x02;
            EighthCommand[12] = 0x00;
            EighthCommand[13] = 0x00;
            EighthCommand[14] = 0x00;
            EighthCommand[15] = 0x00;
            EighthCommand[16] = 0x80;
            EighthCommand[17] = 0x00;
            EighthCommand[18] = 0x02;
            EighthCommand[19] = 0x00;
            EighthCommand[20] = 0x01;    //PLC节点号
            EighthCommand[21] = 0x00;
            EighthCommand[22] = 0x00;
            EighthCommand[23] = 0x64;    //上位机节点号
            EighthCommand[24] = 0x00;
            EighthCommand[25] = 0x00;
            EighthCommand[26] = 0x01;
            EighthCommand[27] = 0x01;
            EighthCommand[28] = 0x82;    //DM区代号
            EighthCommand[29] = 0x04;   //[29]、[30]一起表示D1276地址
            EighthCommand[30] = 0xFC;
            EighthCommand[31] = 0x00;
            EighthCommand[32] = 0x00;
            EighthCommand[33] = 0x24;

            //第九次读取数据指令
            byte[] NinthCommand = new byte[34];
            NinthCommand[0] = 0x46;
            NinthCommand[1] = 0x49;
            NinthCommand[2] = 0x4E;
            NinthCommand[3] = 0x53;
            NinthCommand[4] = 0x00;
            NinthCommand[5] = 0x00;
            NinthCommand[6] = 0x00;
            NinthCommand[7] = 0x1A;
            NinthCommand[8] = 0x00;
            NinthCommand[9] = 0x00;
            NinthCommand[10] = 0x00;
            NinthCommand[11] = 0x02;
            NinthCommand[12] = 0x00;
            NinthCommand[13] = 0x00;
            NinthCommand[14] = 0x00;
            NinthCommand[15] = 0x00;
            NinthCommand[16] = 0x80;
            NinthCommand[17] = 0x00;
            NinthCommand[18] = 0x02;
            NinthCommand[19] = 0x00;
            NinthCommand[20] = 0x01;    //PLC节点号
            NinthCommand[21] = 0x00;
            NinthCommand[22] = 0x00;
            NinthCommand[23] = 0x64;    //上位机节点号
            NinthCommand[24] = 0x00;
            NinthCommand[25] = 0x00;
            NinthCommand[26] = 0x01;
            NinthCommand[27] = 0x01;
            NinthCommand[28] = 0x82;    //DM区代号
            NinthCommand[29] = 0x05;   //[29]、[30]一起表示D1476地址
            NinthCommand[30] = 0xC4;
            NinthCommand[31] = 0x00;
            NinthCommand[32] = 0x00;
            NinthCommand[33] = 0x24;

            //第十次读取数据指令
            byte[] TenthCommand = new byte[34];
            TenthCommand[0] = 0x46;
            TenthCommand[1] = 0x49;
            TenthCommand[2] = 0x4E;
            TenthCommand[3] = 0x53;
            TenthCommand[4] = 0x00;
            TenthCommand[5] = 0x00;
            TenthCommand[6] = 0x00;
            TenthCommand[7] = 0x1A;
            TenthCommand[8] = 0x00;
            TenthCommand[9] = 0x00;
            TenthCommand[10] = 0x00;
            TenthCommand[11] = 0x02;
            TenthCommand[12] = 0x00;
            TenthCommand[13] = 0x00;
            TenthCommand[14] = 0x00;
            TenthCommand[15] = 0x00;
            TenthCommand[16] = 0x80;
            TenthCommand[17] = 0x00;
            TenthCommand[18] = 0x02;
            TenthCommand[19] = 0x00;
            TenthCommand[20] = 0x01;    //PLC节点号
            TenthCommand[21] = 0x00;
            TenthCommand[22] = 0x00;
            TenthCommand[23] = 0x64;    //上位机节点号
            TenthCommand[24] = 0x00;
            TenthCommand[25] = 0x00;
            TenthCommand[26] = 0x01;
            TenthCommand[27] = 0x01;
            TenthCommand[28] = 0x82;    //DM区代号
            TenthCommand[29] = 0x06;   //[29]、[30]一起表示D1676地址
            TenthCommand[30] = 0x8C;
            TenthCommand[31] = 0x00;
            TenthCommand[32] = 0x00;
            TenthCommand[33] = 0x24;

            //第十一次读取数据指令
            byte[] EleventhCommand = new byte[34];
            EleventhCommand[0] = 0x46;
            EleventhCommand[1] = 0x49;
            EleventhCommand[2] = 0x4E;
            EleventhCommand[3] = 0x53;
            EleventhCommand[4] = 0x00;
            EleventhCommand[5] = 0x00;
            EleventhCommand[6] = 0x00;
            EleventhCommand[7] = 0x1A;
            EleventhCommand[8] = 0x00;
            EleventhCommand[9] = 0x00;
            EleventhCommand[10] = 0x00;
            EleventhCommand[11] = 0x02;
            EleventhCommand[12] = 0x00;
            EleventhCommand[13] = 0x00;
            EleventhCommand[14] = 0x00;
            EleventhCommand[15] = 0x00;
            EleventhCommand[16] = 0x80;
            EleventhCommand[17] = 0x00;
            EleventhCommand[18] = 0x02;
            EleventhCommand[19] = 0x00;
            EleventhCommand[20] = 0x01;    //PLC节点号
            EleventhCommand[21] = 0x00;
            EleventhCommand[22] = 0x00;
            EleventhCommand[23] = 0x64;    //上位机节点号
            EleventhCommand[24] = 0x00;
            EleventhCommand[25] = 0x00;
            EleventhCommand[26] = 0x01;
            EleventhCommand[27] = 0x01;
            EleventhCommand[28] = 0x82;    //DM区代号
            EleventhCommand[29] = 0x00;   //[29]、[30]一起表示D90地址
            EleventhCommand[30] = 0x5A;
            EleventhCommand[31] = 0x00;
            EleventhCommand[32] = 0x00;
            EleventhCommand[33] = 0x0A;

            //第十二次读取数据指令
            byte[] TwelfthCommand = new byte[34] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x02, 0x00, 0x01, 0x00, 0x00, 0x64, 0x00, 0x00, 0x01, 0x01, 0x82, 0x08, 0x22, 0x00, 0x00, 0x0A };

            //第十三次读取数据指令
            byte[] ThirteenthCommand = new byte[34] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x02, 0x00, 0x01, 0x00, 0x00, 0x64, 0x00, 0x00, 0x01, 0x01, 0x82, 0x08, 0x86, 0x00, 0x00, 0x0A };

            //第十四次读取数据指令
            byte[] FourteenthCommand = new byte[34] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x02, 0x00, 0x01, 0x00, 0x00, 0x64, 0x00, 0x00, 0x01, 0x01, 0x82, 0x08, 0xEA, 0x00, 0x00, 0x0A };

            //第十五次读取数据指令
            byte[] FifteenthCommand = new byte[34] { 0x46, 0x49, 0x4E, 0x53, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x80, 0x00, 0x02, 0x00, 0x01, 0x00, 0x00, 0x64, 0x00, 0x00, 0x01, 0x01, 0x82, 0x09, 0x4E, 0x00, 0x00, 0x0A };


            byte[] ShakeHandResponse = new byte[50];
            byte[] FirstResponse = new byte[150];
            byte[] SecondResponse = new byte[150];
            byte[] ThirdResponse = new byte[150];
            byte[] FourthResponse = new byte[150];
            byte[] FifthResponse = new byte[150];
            byte[] SixthResponse = new byte[150];
            byte[] SeventhResponse = new byte[150];
            byte[] EighthResponse = new byte[150];
            byte[] NinthResponse = new byte[150];
            byte[] TenthResponse = new byte[150];
            byte[] EleventhResponse = new byte[150];
            byte[] TwelfthResponse = new byte[150];
            byte[] ThirteenthResponse = new byte[150];
            byte[] FourteenthResponse = new byte[150];
            byte[] FifteenthResponse = new byte[150];

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            socket.Send(ShakeHandCommand, 0, 20, SocketFlags.None);
            socket.Receive(ShakeHandResponse, 0, 50, SocketFlags.None);

            socket.Send(FirstCommand, 0, 34, SocketFlags.None);
            socket.Receive(FirstResponse, 0, 150, SocketFlags.None);

            socket.Send(SecondCommand, 0, 34, SocketFlags.None);
            socket.Receive(SecondResponse, 0, 150, SocketFlags.None);

            socket.Send(ThirdCommand, 0, 34, SocketFlags.None);
            socket.Receive(ThirdResponse, 0, 150, SocketFlags.None);

            socket.Send(FourthCommand, 0, 34, SocketFlags.None);
            socket.Receive(FourthResponse, 0, 150, SocketFlags.None);

            socket.Send(FifthCommand, 0, 34, SocketFlags.None);
            socket.Receive(FifthResponse, 0, 150, SocketFlags.None);

            socket.Send(SixthCommand, 0, 34, SocketFlags.None);
            socket.Receive(SixthResponse, 0, 150, SocketFlags.None);

            socket.Send(SeventhCommand, 0, 34, SocketFlags.None);
            socket.Receive(SeventhResponse, 0, 150, SocketFlags.None);

            socket.Send(EighthCommand, 0, 34, SocketFlags.None);
            socket.Receive(EighthResponse, 0, 150, SocketFlags.None);

            socket.Send(NinthCommand, 0, 34, SocketFlags.None);
            socket.Receive(NinthResponse, 0, 150, SocketFlags.None);

            socket.Send(TenthCommand, 0, 34, SocketFlags.None);
            socket.Receive(TenthResponse, 0, 150, SocketFlags.None);

            socket.Send(EleventhCommand, 0, 34, SocketFlags.None);
            socket.Receive(EleventhResponse, 0, 150, SocketFlags.None);

            socket.Send(TwelfthCommand, 0, 34, SocketFlags.None);
            socket.Receive(TwelfthCommand, 0, 150, SocketFlags.None);

            socket.Send(ThirteenthCommand, 0, 34, SocketFlags.None);
            socket.Receive(ThirteenthCommand, 0, 150, SocketFlags.None);

            socket.Send(FourteenthCommand, 0, 34, SocketFlags.None);
            socket.Receive(FourteenthCommand, 0, 150, SocketFlags.None);

            socket.Send(FifteenthCommand, 0, 34, SocketFlags.None);
            socket.Receive(FifteenthCommand, 0, 150, SocketFlags.None);


            socket.Close();

            //解析第一次回应
            float S1_BadProduction = (FirstResponse[30] * 256 + FirstResponse[31]);
            float S1_CurrentProduction = (FirstResponse[32] * 256 + FirstResponse[33]);
            float S1_QualifiedRate = (S1_CurrentProduction - S1_BadProduction) / S1_CurrentProduction;

            float S2_BadProduction = (FirstResponse[50] * 256 + FirstResponse[51]);
            float S2_CurrentProduction = (FirstResponse[52] * 256 + FirstResponse[53]);
            float S2_QualifiedRate = (S2_CurrentProduction - S2_BadProduction) / S2_CurrentProduction;

            float S3_BadProduction = (FirstResponse[70] * 256 + FirstResponse[71]);
            float S3_CurrentProduction = (FirstResponse[72] * 256 + FirstResponse[73]);
            float S3_QualifiedRate = (S3_CurrentProduction - S3_BadProduction) / S3_CurrentProduction;

            float S4_BadProduction = (FirstResponse[90] * 256 + FirstResponse[91]);
            float S4_CurrentProduction = (FirstResponse[92] * 256 + FirstResponse[93]);
            float S4_QualifiedRate = (S4_CurrentProduction - S4_BadProduction) / S4_CurrentProduction;

//----------------------------------------------------------------------------------------------------------------------

            //解析第二次回应
            float T1_BadProduction = (SecondResponse[30] * 256 + SecondResponse[31]);
            float T1_CurrentProduction = (SecondResponse[32] * 256 + SecondResponse[33]);
            float T1_QualifiedRate = (T1_CurrentProduction - T1_BadProduction) / T1_CurrentProduction;

            float T2_BadProduction = (SecondResponse[50] * 256 + SecondResponse[51]);
            float T2_CurrentProduction = (SecondResponse[52] * 256 + SecondResponse[53]);
            float T2_QualifiedRate = (T2_CurrentProduction - T2_BadProduction) / T2_CurrentProduction;

            float T3_BadProduction = (SecondResponse[70] * 256 + SecondResponse[71]);
            float T3_CurrentProduction = (SecondResponse[72] * 256 + SecondResponse[73]);
            float T3_QualifiedRate = (T3_CurrentProduction - T3_BadProduction) / T3_CurrentProduction;

            float T4_BadProduction = (SecondResponse[90] * 256 + SecondResponse[91]);
            float T4_CurrentProduction = (SecondResponse[92] * 256 + SecondResponse[93]);
            float T4_QualifiedRate = (T4_CurrentProduction - T4_BadProduction) / T4_CurrentProduction;



//----------------------------------------------------------------------------------------------------------------------

            //解析第三次回应
            float S1_PC_RealValue = ((float)(ThirdResponse[30] * 256 + ThirdResponse[31]) / 10);
            float S1_PS_RealValue = ((float)(ThirdResponse[34] * 256 + ThirdResponse[35]) / 10);
            float S1_PS_Rise = ((float)(ThirdResponse[54] * 256 + ThirdResponse[55]) / 10);
            float S1_PS_Fall = ((float)(ThirdResponse[58] * 256 + ThirdResponse[59]) / 10);
            float S1_PS_r_f = ((float)(ThirdResponse[62] * 256 + ThirdResponse[63]) / 10);

            //解析第四次回应
            float S2_PC_RealValue = ((float)(FourthResponse[30] * 256 + FourthResponse[31]) / 10);
            float S2_PS_RealValue = ((float)(FourthResponse[34] * 256 + FourthResponse[35]) / 10);
            float S2_PS_Rise = ((float)(FourthResponse[54] * 256 + FourthResponse[55]) / 10);
            float S2_PS_Fall = ((float)(FourthResponse[58] * 256 + FourthResponse[59]) / 10);
            float S2_PS_r_f = ((float)(FourthResponse[62] * 256 + FourthResponse[63]) / 10);

            //解析第五次回应
            float S3_PC_RealValue = ((float)(FifthResponse[30] * 256 + FifthResponse[31]) / 10);
            float S3_PS_RealValue = ((float)(FifthResponse[34] * 256 + FifthResponse[35]) / 10);
            float S3_PS_Rise = ((float)(FifthResponse[54] * 256 + FifthResponse[55]) / 10);
            float S3_PS_Fall = ((float)(FifthResponse[58] * 256 + FifthResponse[59]) / 10);
            float S3_PS_r_f = ((float)(FifthResponse[62] * 256 + FifthResponse[63]) / 10);

            //解析第六次回应
            float S4_PC_RealValue = ((float)(SixthResponse[30] * 256 + SixthResponse[31]) / 10);
            float S4_PS_RealValue = ((float)(SixthResponse[34] * 256 + SixthResponse[35]) / 10);
            float S4_PS_Rise = ((float)(SixthResponse[54] * 256 + SixthResponse[55]) / 10);
            float S4_PS_Fall = ((float)(SixthResponse[58] * 256 + SixthResponse[59]) / 10);
            float S4_PS_r_f = ((float)(SixthResponse[62] * 256 + SixthResponse[63]) / 10);

            //解析第七次回应
            float T1_PC_RealValue = ((float)(SeventhResponse[30] * 256 + SeventhResponse[31]) / 10);
            float T1_PS_RealValue = ((float)(SeventhResponse[34] * 256 + SeventhResponse[35]) / 10);
            float T1_PS_Rise = ((float)(SeventhResponse[54] * 256 + SeventhResponse[55]) / 10);
            float T1_PS_Fall = ((float)(SeventhResponse[58] * 256 + SeventhResponse[59]) / 10);
            float T1_PS_r_f = ((float)(SeventhResponse[62] * 256 + SeventhResponse[63]) / 10);

            //解析第八次回应
            float T2_PC_RealValue = ((float)(EighthResponse[30] * 256 + EighthResponse[31]) / 10);
            float T2_PS_RealValue = ((float)(EighthResponse[34] * 256 + EighthResponse[35]) / 10);
            float T2_PS_Rise = ((float)(EighthResponse[54] * 256 + EighthResponse[55]) / 10);
            float T2_PS_Fall = ((float)(EighthResponse[58] * 256 + EighthResponse[59]) / 10);
            float T2_PS_r_f = ((float)(EighthResponse[62] * 256 + EighthResponse[63]) / 10);

            //解析第九次回应
            float T3_PC_RealValue = ((float)(NinthResponse[30] * 256 + NinthResponse[31]) / 10);
            float T3_PS_RealValue = ((float)(NinthResponse[34] * 256 + NinthResponse[35]) / 10);
            float T3_PS_Rise = ((float)(NinthResponse[54] * 256 + NinthResponse[55]) / 10);
            float T3_PS_Fall = ((float)(NinthResponse[58] * 256 + NinthResponse[59]) / 10);
            float T3_PS_r_f = ((float)(NinthResponse[62] * 256 + NinthResponse[63]) / 10);

            //解析第十次回应
            float T4_PC_RealValue = ((float)(TenthResponse[30] * 256 + TenthResponse[31]) / 10);
            float T4_PS_RealValue = ((float)(TenthResponse[34] * 256 + TenthResponse[35]) / 10);
            float T4_PS_Rise = ((float)(TenthResponse[54] * 256 + TenthResponse[55]) / 10);
            float T4_PS_Fall = ((float)(TenthResponse[58] * 256 + TenthResponse[59]) / 10);
            float T4_PS_r_f = ((float)(TenthResponse[62] * 256 + TenthResponse[63]) / 10);

            //第十一次回应
            float CurrentPlanProduction = EleventhResponse[30] * 256 + EleventhResponse[31];
            float CurrentRealProduction = EleventhResponse[34] * 256 + EleventhResponse[35];

            //第十二次回应
            float P1_BadProduction = (TwelfthResponse[30] * 256 + TwelfthResponse[31]);
            float P1_CurrentProduction = (TwelfthResponse[32] * 256 + TwelfthResponse[33]);
            float P1_QualifiedRate = (P1_CurrentProduction - P1_BadProduction) / P1_CurrentProduction;
            //第十三次回应
            float P2_BadProduction = (ThirteenthResponse[30] * 256 + ThirteenthResponse[31]);
            float P2_CurrentProduction = (ThirteenthResponse[32] * 256 + ThirteenthResponse[33]);
            float P2_QualifiedRate = (P2_CurrentProduction - P2_BadProduction) / P2_CurrentProduction;
            //第十四次回应
            float P3_BadProduction = (FourteenthResponse[30] * 256 + FourteenthResponse[31]);
            float P3_CurrentProduction = (FourteenthResponse[32] * 256 + FourteenthResponse[33]);
            float P3_QualifiedRate = (P3_CurrentProduction - P3_BadProduction) / P3_CurrentProduction;
            //第十五次回应
            float P4_BadProduction = (FifteenthResponse[30] * 256 + FifteenthResponse[31]);
            float P4_CurrentProduction = (FifteenthResponse[32] * 256 + FifteenthResponse[33]);
            float P4_QualifiedRate = (P4_CurrentProduction - P4_BadProduction) / P4_CurrentProduction;



            Dictionary<string, float> dic = new Dictionary<string, float>();


            dic.Add("S1_BadProduction", S1_BadProduction);
            dic.Add("S1_CurrentProduction", S1_CurrentProduction);
            dic.Add("S1_QualifiedRate", S1_QualifiedRate);
            dic.Add("S2_BadProduction", S2_BadProduction);
            dic.Add("S2_CurrentProduction", S2_CurrentProduction);
            dic.Add("S2_QualifiedRate", S2_QualifiedRate);
            dic.Add("S3_BadProduction", S3_BadProduction);
            dic.Add("S3_CurrentProduction", S3_CurrentProduction);
            dic.Add("S3_QualifiedRate", S3_QualifiedRate);
            dic.Add("S4_BadProduction", S4_BadProduction);
            dic.Add("S4_CurrentProduction", S4_CurrentProduction);
            dic.Add("S4_QualifiedRate", S4_QualifiedRate);

            dic.Add("T1_BadProduction", T1_BadProduction);
            dic.Add("T1_CurrentProduction", T1_CurrentProduction);
            dic.Add("T1_QualifiedRate", T1_QualifiedRate);
            dic.Add("T2_BadProduction", T2_BadProduction);
            dic.Add("T2_CurrentProduction", T2_CurrentProduction);
            dic.Add("T2_QualifiedRate", T2_QualifiedRate);
            dic.Add("T3_BadProduction", T3_BadProduction);
            dic.Add("T3_CurrentProduction", T3_CurrentProduction);
            dic.Add("T3_QualifiedRate", T3_QualifiedRate);
            dic.Add("T4_BadProduction", T4_BadProduction);
            dic.Add("T4_CurrentProduction", T4_CurrentProduction);
            dic.Add("T4_QualifiedRate", T4_QualifiedRate);

            dic.Add("CurrentPlanProduction", CurrentPlanProduction);
            dic.Add("CurrentRealProduction", CurrentRealProduction);

            dic.Add("S1_PC_RealValue", S1_PC_RealValue);
            dic.Add("S1_PS_RealValue", S1_PS_RealValue);
            dic.Add("S1_PS_Rise", S1_PS_Rise);
            dic.Add("S1_PS_Fall", S1_PS_Fall);
            dic.Add("S1_PS_r_f", S1_PS_r_f);
            dic.Add("S2_PC_RealValue", S2_PC_RealValue);
            dic.Add("S2_PS_RealValue", S2_PS_RealValue);
            dic.Add("S2_PS_Rise", S2_PS_Rise);
            dic.Add("S2_PS_Fall", S2_PS_Fall);
            dic.Add("S2_PS_r_f", S2_PS_r_f);
            dic.Add("S3_PC_RealValue", S3_PC_RealValue);
            dic.Add("S3_PS_RealValue", S3_PS_RealValue);
            dic.Add("S3_PS_Rise", S3_PS_Rise);
            dic.Add("S3_PS_Fall", S3_PS_Fall);
            dic.Add("S3_PS_r_f", S3_PS_r_f);
            dic.Add("S4_PC_RealValue", S4_PC_RealValue);
            dic.Add("S4_PS_RealValue", S4_PS_RealValue);
            dic.Add("S4_PS_Rise", S4_PS_Rise);
            dic.Add("S4_PS_Fall", S4_PS_Fall);
            dic.Add("S4_PS_r_f", S4_PS_r_f);

            dic.Add("T1_PC_RealValue", T1_PC_RealValue);
            dic.Add("T1_PS_RealValue", T1_PS_RealValue);
            dic.Add("T1_PS_Rise", T1_PS_Rise);
            dic.Add("T1_PS_Fall", T1_PS_Fall);
            dic.Add("T1_PS_r_f", T1_PS_r_f);
            dic.Add("T2_PC_RealValue", T2_PC_RealValue);
            dic.Add("T2_PS_RealValue", T2_PS_RealValue);
            dic.Add("T2_PS_Rise", T2_PS_Rise);
            dic.Add("T2_PS_Fall", T2_PS_Fall);
            dic.Add("T2_PS_r_f", T2_PS_r_f);
            dic.Add("T3_PC_RealValue", T3_PC_RealValue);
            dic.Add("T3_PS_RealValue", T3_PS_RealValue);
            dic.Add("T3_PS_Rise", T3_PS_Rise);
            dic.Add("T3_PS_Fall", T3_PS_Fall);
            dic.Add("T3_PS_r_f", T3_PS_r_f);
            dic.Add("T4_PC_RealValue", T4_PC_RealValue);
            dic.Add("T4_PS_RealValue", T4_PS_RealValue);
            dic.Add("T4_PS_Rise", T4_PS_Rise);
            dic.Add("T4_PS_Fall", T4_PS_Fall);
            dic.Add("T4_PS_r_f", T4_PS_r_f);

            dic.Add("P1_BadProduction", P1_BadProduction);
            dic.Add("P1_CurrentProduction", P1_CurrentProduction);
            dic.Add("P1_QualifiedRate", P1_QualifiedRate);
            dic.Add("P2_BadProduction", P2_BadProduction);
            dic.Add("P2_CurrentProduction", P2_CurrentProduction);
            dic.Add("P2_QualifiedRate", P2_QualifiedRate);
            dic.Add("P3_BadProduction", P3_BadProduction);
            dic.Add("P3_CurrentProduction", P3_CurrentProduction);
            dic.Add("P3_QualifiedRate", P3_QualifiedRate);
            dic.Add("P4_BadProduction", P4_BadProduction);
            dic.Add("P4_CurrentProduction", P4_CurrentProduction);
            dic.Add("P4_QualifiedRate", P4_QualifiedRate);


            return dic;
        }
    }
}
