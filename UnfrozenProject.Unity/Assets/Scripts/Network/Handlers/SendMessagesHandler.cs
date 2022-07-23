using Answers;
using Network.Factories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Network.Handlers
{
    public class SendMessagesHandler : Handler<SendMessageAns, GameSession>
    {
        private readonly GetMessagesFactory _getMessagesFactory;

        protected override void Handle(GameSession session, SendMessageAns model)
        {
            _getMessagesFactory.Send();
        }
    }
}
