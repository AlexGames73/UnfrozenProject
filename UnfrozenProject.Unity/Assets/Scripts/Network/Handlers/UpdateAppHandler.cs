using Answers;
using Network.Factories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Network.Handlers
{
    public class UpdateAppHandler : Handler<UpdateAppAns, GameSession>
    {
        private readonly GetMessagesFactory _getMessagesFactory;
        private readonly GetUsersFactory _getUsersFactory;

        protected override void Handle(GameSession session, UpdateAppAns model)
        {
            _getMessagesFactory.Send();
            _getUsersFactory.Send();
        }
    }
}
