using Acks;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Network.Factories
{
    [Dependency]
    public class GetMessagesFactory
    {
        public void Send()
        {
            TcpClient.Instance.CurrentSession.Send(new GetMessagesAck
            {
                Count = 20,
                Offset = 0
            });
        }
    }
}
