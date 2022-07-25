using Acks;
using Server.BFF.Factories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class LogOutUserHandler : Handler<LogOutUserAck, GameSession>
{
    private readonly UpdateAppFactory _updateAppFactory;
    
    protected override void Handle(GameSession session, LogOutUserAck model)
    {
        session.UserId = null;
        _updateAppFactory.Send(ConnectedSessions.Where(x => x.UserId.HasValue).ToArray());
    }
}
