using System;
using ServerManySelf;

namespace _HFL_
{
    class Program
    {
        /*
        static void Main1(string[] args)
        {
            DateTime start = DateTime.Now;
            // 创建一个Web请求
            HttpWebRequest request = WebRequest.Create("http://127.0.0.1:8000/execute_identify/url=tupian/timestamp=000001") as HttpWebRequest;

            // 获取Web服务器输出的数据
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // 取得输出流
                StreamReader reader = new StreamReader(response.GetResponseStream());
                Console.WriteLine(reader.ReadToEnd());
            }
            DateTime end = DateTime.Now;
            Console.WriteLine("总共用时：", end - start);
        }
        */
        /// <summary>
        /// 调用服务端类
        /// 生成服务端
        /// 等待客户端连接
        /// 接收客户端信息
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Server s = new Server();
            int flag = 0;//20次空连后服务器断开
            do
            {
                string msg = s.GetMessage();
                Console.WriteLine("Received:{0}", msg);
                //当从客户端接收到空字符串时，flag++
                if (msg == "")
                {
                    flag++;
                }
                //当标记大于20时，服务端退出
                if (flag > 20)
                {
                    break;
                }
            } while (true);
            s.close();
        }
    }
}




