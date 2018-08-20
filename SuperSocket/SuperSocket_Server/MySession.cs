using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{    
    public class MySession : AppSession<MySession>
    {
        public bool isLogin;
        protected override void OnSessionStarted()
        {
            //输出客户端IP地址
            Console.WriteLine(this.LocalEndPoint.Address.ToString());
            this.Send("\n\rHello User");
            string sens = "we have connected!";
            byte[] sendbytes = Encoding.Default.GetBytes(sens);
            this.Send(sendbytes, 0, sendbytes.Length);
            MysessionManager.SessionList.Add(this);

            foreach (var se in MysessionManager.SessionList)
            {
                string sens1 = "we have connected 333333333333!";
                byte[] sendbytes1 = Encoding.Default.GetBytes(sens1);
                se.Send(sendbytes1, 0, sendbytes1.Length);
            }
        }

        /// <summary>
        /// 未知的Command
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("\n\r未知的命令");
        }

        /// <summary>
        /// 捕捉异常并输出
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send("\n\r异常: {0}", e.Message);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
            Console.WriteLine(reason.ToString());
            MysessionManager.SessionList.Remove(this);
        }

    }
}
