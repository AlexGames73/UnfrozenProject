using Answers;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Network.Handlers
{ 
    public class GetMessagesHandler : Handler<GetMessagesAns, GameSession>
    {
        protected override void Handle(GameSession session, GetMessagesAns model)
        {
            Dispatcher.Do(() =>
            {
                TcpClient.Instance.messagesUpdateEvent.Invoke(model.Messages);
            });
        }
    }
}
