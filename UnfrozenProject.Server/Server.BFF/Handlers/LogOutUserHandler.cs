using Acks;
using Answers;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class LogOutUserHandler : Handler<LogOutUserAck, GameSession>
{
    protected override void Handle(GameSession session, LogOutUserAck model)
    {
        session.UserId = null;
        foreach (var gameSession in ConnectedSessions)
        {
            if (gameSession.UserId.HasValue)
            {
                gameSession.Send(new SendMessageAns());
            }
        }
    }
}
