using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket_Server
{
    [MyCommandFilterAttribute]
    public class MyCommand_Login:CommandBase<MySession, StringRequestInfo>
    {
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            session.isLogin = true;
            session.Send("Login Successfully");
        }
    }

}
