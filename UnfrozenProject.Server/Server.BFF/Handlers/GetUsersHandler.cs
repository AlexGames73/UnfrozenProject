using Acks;
using Answers;
using Server.DAL.Logic.Repositories;
using Structs;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class GetUsersHandler : Handler<GetUsersAck, GameSession>
{
    private readonly IUserRepository _userRepository;
    
    protected override async Task HandleAsync(GameSession session, GetUsersAck model)
    {
        var users = await _userRepository.ReadAsync();
        
        session.Send(new GetUsersAns
        {
            Users = users.Elements
                .Select(x => new User
                {
                    UserId = x.Id.ToString(),
                    Color = x.Color.ToArgb(),
                    Username = x.Username,
                    IsOnline = ConnectedSessions.Any(y => y.UserId == x.Id)
                })
                .OrderByDescending(x => x.IsOnline)
                .ThenBy(x => x.Username)
                .ToList()
        });
    }
}
