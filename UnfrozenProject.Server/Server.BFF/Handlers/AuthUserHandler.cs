using System.Drawing;
using Acks;
using Answers;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class AuthUserHandler : Handler<AuthUserAck, GameSession>
{
    private readonly IUserRepository _userRepository;
    
    protected override async Task HandleAsync(GameSession session, AuthUserAck model)
    {
        var userId = await _userRepository.CreateOrUpdateAsync(new UserBinding
        {
            Username = model.Username,
            Color = Color.FromArgb(model.Color)
        });

        if (ConnectedSessions.Any(x => x.UserId == userId))
        {
            session.Send(new AuthUserAns
            {
                UserId = "",
                Error = "Such user is already online!"
            });
            return;
        }

        session.UserId = userId;
        session.TimeZoneMinutesOffset = model.TimeZoneMinutesOffset;

        session.Send(new AuthUserAns
        {
            UserId = session.UserId.Value.ToString(),
            Error = ""
        });
        
        foreach (var connectedSession in ConnectedSessions)
        {
            if (connectedSession.UserId.HasValue)
            {
                connectedSession.Send(new SendMessageAns());
            }
        }
    }
}
