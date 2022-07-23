using Answers;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Network.Handlers
{
    public class AuthUserHandler : Handler<AuthUserAns, GameSession>
    {
        protected override void Handle(GameSession session, AuthUserAns model)
        {
            Dispatcher.Do(() =>
            {
                if (!string.IsNullOrEmpty(model.Error))
                {
                    session.LogInError = model.Error;
                    TcpClient.Instance.authUserErrorEvent.Invoke();
                    return;
                }

                session.LogInError = "";
                session.UserId = model.UserId;
                TcpClient.Instance.authUserDoneEvent.Invoke();
            });
        }
    }
}
