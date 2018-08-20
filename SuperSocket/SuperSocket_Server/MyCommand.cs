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
    public class MyCommand : CommandBase<MySession, StringRequestInfo>
    {
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            session.Send("Hello World!");
            string sens = "we have connected!";
            byte[] sendbytes = Encoding.Default.GetBytes(sens);
            session.Send(sendbytes, 0, sendbytes.Length);
        }
    }
}
