using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PPTAddinsMSDN
{
    public static class SocketManagement
    {
        public static void SocketBind()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            IPEndPoint endPoint = new IPEndPoint(ip, 2018);
            Debug.WriteLine(ip.ToString());
            socket.Bind(endPoint);
            Debug.WriteLine("绑定成功\r\n");
            //Globals.Ribbons.RibbonUI.DebugLabel.Label = "绑定成功";
            socket.Listen(2);
            Debug.WriteLine("监听成功\r\n");
            //Globals.Ribbons.RibbonUI.DebugLabel.Label = "监听成功";
            //等待客户端的连接
            //如果连接成功
            //Socket socketSend=socket.Accept();
            //RichTxt.AppendText(socketSend.RemoteEndPoint.ToString()+" : 连接成功\r\n");

            //开一个新线程
            Thread thread = new Thread(Listen);
            thread.IsBackground = true;
            thread.Start(socket);
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="o"></param>
        public static void Listen(object o)
        {
            var serverSocket = o as Socket;
            while (true)
            {
                //等待连接并且创建一个负责通讯的socket
                var send = serverSocket.Accept();
                //获取链接的IP地址
                var sendIpoint = send.RemoteEndPoint.ToString();
                Debug.WriteLine(send.RemoteEndPoint.ToString() + " : 连接成功\r\n");
                //Globals.Ribbons.RibbonUI.DebugLabel.Label = send.RemoteEndPoint.ToString() + " : 连接成功\r\n";
                //开启一个新线程不停接收消息
                Thread thread = new Thread(Recive);
                thread.IsBackground = true;
                thread.Start(send);
            }
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="o"></param>
        public static void Recive(object o)
        {

            try
            {
                var send = o as Socket;
                while (true)
                {
                    //获取发送过来的消息容器
                    byte[] buffer = new byte[1024 * 1024 * 20];
                    var effective = send.Receive(buffer);
                    //有效字节为0则跳过
                    if (effective <= 3)
                    {
                        break;
                    }
                    //这里绑定了IP send.RemoteEndPoint + 
                    string str = Encoding.UTF8.GetString(buffer, 0, effective);
                    string[] ip = send.RemoteEndPoint.ToString().Split(':');
                    try
                    {
                        string[] th = str.Split(',');
                         th[0]


                    }
                    catch
                    {
                        //令人窒息的Bug！！！！
                    }


                    Debug.WriteLine(send.RemoteEndPoint.ToString()+":"+str);
                    //var buffers = Encoding.UTF8.GetBytes("Recived:" + str);
                    //将得到的字符串再返回给下位机
                    //send.Send(buffers);
                    //拿到值了
                    //ExcelAct(str);
                    //Range["F2"].Value2 = "sss";


                }
            }
            catch
            {

            }



        }


        /// <summary>
        /// 这是发送消息的方法！
        /// 基本用不到！
        /// </summary>
        static void SendSocket()
        {
            Socket socketClient = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("192.168.0.111");
            IPEndPoint point = new IPEndPoint(ip, 2333);
            //进行连接
            socketClient.Connect(point);

            //不停的接收服务器端发送的消息
            Thread thread = new Thread(Recive);
            thread.IsBackground = true;
            thread.Start(socketClient);

            //不停的给服务器发送数据
            int i = 0;
            while (true)
            {
                i++;
                var buffter = Encoding.UTF8.GetBytes($"Test Send Message:{i}");
                var temp = socketClient.Send(buffter);
                Thread.Sleep(1000);
            }
        }
    }
}
