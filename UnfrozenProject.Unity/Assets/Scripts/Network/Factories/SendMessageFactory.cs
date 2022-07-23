using Acks;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Network.Factories
{
    [Dependency]
    public class SendMessageFactory
    {
        public void Send(string message)
        {
            TcpClient.Instance.CurrentSession.Send(new SendMessageAck
            {
                Content = message
            });
        }
    }
}
