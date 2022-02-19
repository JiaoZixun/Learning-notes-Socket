using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
namespace ServerManySelf
{
    class Server
    {
        private TcpListener listener;//监听
        private NetworkStream streamToClient;//流对象
        private TcpClient remoteClient;
        private int BufferSize = 1024;//缓存大小,结果返回只需要个位数，改大会多条信息合并为一条接收
        /// <summary>
        /// 构造函数
        /// 创建服务端连接实例
        /// </summary>
        public Server()
        {
            Console.WriteLine("Server is running ...");
            IPAddress ip = IPAddress.Parse("127.0.0.1");//获取ip地址
            listener = new TcpListener(ip, 8500);
            listener.Start();//开始监听
            Console.WriteLine("Start Listening...");
            //获取一个连接，中断方法
            remoteClient = listener.AcceptTcpClient();
            //打印连接到的客户端信息
            Console.WriteLine("Client Connected! {0}<--{1}", remoteClient.Client.LocalEndPoint, remoteClient.Client.RemoteEndPoint);
            //获取流，并写入buffer中
            streamToClient = remoteClient.GetStream();
        }
        /// <summary>
        /// 获取客户端传入消息
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {

            byte[] buffer = new byte[BufferSize];
            int bytesRead = streamToClient.Read(buffer, 0, BufferSize);//一直等待客户端传信息
            Console.WriteLine("Reading data,{0} bytes...", bytesRead);

            //获得请求的字符串
            string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            //string msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
            return msg;
        }
        /// <summary>
        /// 关闭服务端连接
        /// </summary>
        public void close()
        {
            listener.Stop();
        }
    }
}
