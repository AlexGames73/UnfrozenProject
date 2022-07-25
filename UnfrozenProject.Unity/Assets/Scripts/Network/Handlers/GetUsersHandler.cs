using Answers;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Network.Handlers
{
    public class GetUsersHandler : Handler<GetUsersAns, GameSession>
    {
        protected override void Handle(GameSession session, GetUsersAns model)
        {
            Dispatcher.Do(() =>
            {
                TcpClient.Instance.usersUpdateEvent.Invoke(model.Users);
            });
        }
    }
}
