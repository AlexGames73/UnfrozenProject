using Acks;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Network.Factories
{
    [Dependency]
    public class GetUsersFactory
    {
        public void Send()
        {
            TcpClient.Instance.CurrentSession.Send(new GetUsersAck());
        }
    }
}
