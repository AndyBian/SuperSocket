﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocket_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var appServer = new MyServer();

            //服务器端口
            int port = 2000;
            string ip = "192.168.1.3";

            //设置服务监听端口
            if (!appServer.Setup(ip,port))
            {
                Console.WriteLine("端口设置失败!");
                Console.ReadKey();
                return;
            }

            //新连接事件
            appServer.NewSessionConnected += new SessionHandler<MySession>(NewSessionConnected);

            //收到消息事件
            //appServer.NewRequestReceived += new RequestHandler<MySession, StringRequestInfo>(NewRequestReceived);

            //连接断开事件
            appServer.SessionClosed += new SessionHandler<MySession, CloseReason>(SessionClosed);

            //启动服务
            if (!appServer.Start())
            {
                Console.WriteLine("启动服务失败!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("启动服务成功，输入exit退出!");

            while (true)
            {
                var str = Console.ReadLine();
                if (str.ToLower().Equals("exit"))
                {
                    break;
                }
            }

            Console.WriteLine();

            //停止服务
            appServer.Stop();

            Console.WriteLine("服务已停止，按任意键退出!");
            Console.ReadKey();

        }

        static void NewSessionConnected(MySession session)
        {
            //向对应客户端发送数据
            session.Send("Hello User!");
        }

        static void NewRequestReceived(MySession session, StringRequestInfo requestInfo)
        {
            /**
             * requestInfo为客户端发送的指令，默认为命令行协议
             * 例：
             * 发送 ping 127.0.0.1 -n 5
             * requestInfo.Key: "ping"
             * requestInfo.Body: "127.0.0.1 -n 5"
             * requestInfo.Parameters: ["127.0.0.1","-n","5"]
             **/
            
            switch (requestInfo.Key.ToUpper())
            {
                case ("HELLO"):
                    session.Send("Hello World!");
                    break;

                default:
                    session.Send("未知的指令。");
                    break;
            }
        }

        static void SessionClosed(MySession session, CloseReason reason)
        {

        }


    }
}
