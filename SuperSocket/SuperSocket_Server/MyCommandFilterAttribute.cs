using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{
    public class MyCommandFilterAttribute : CommandFilterAttribute
    {
        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            //throw new NotImplementedException();

            MySession session = commandContext.Session as MySession;

            //判断是否已登录
            if (session != null && !session.isLogin)
            {
                //判断当前命令是否为LOGIN
                if (!commandContext.RequestInfo.Key.Equals("LOGIN"))
                {
                    
                }
            }
        }

        /// <summary>
        /// 命令监视器-执行命令后调用
        /// </summary>
        /// <param name="commandContext"></param>
        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {
            //throw new NotImplementedException();
        }
    }
}
