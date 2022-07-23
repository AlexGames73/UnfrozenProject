using Acks;
using Answers;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using Structs;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class GetMessagesHandler : Handler<GetMessagesAck, GameSession>
{
    private readonly IMessageRepository _messageRepository;
    
    protected override async Task HandleAsync(GameSession session, GetMessagesAck model)
    {
        if (!session.UserId.HasValue)
        {
            return;
        }
        
        var messages = await _messageRepository.ReadAsync(new MessageFilterBinding(), new PageBinding
        {
            Count = model.Count,
            Offset = model.Offset
        });
        
        session.Send(new GetMessagesAns
        {
            Messages = messages.Elements
                .Select(x => new Message
                {
                    DateTime = x.DateTime.AddMinutes(session.TimeZoneMinutesOffset).ToString("g"),
                    Content = x.Content,
                    FromColor = x.FromUser.Color.ToArgb(),
                    FromUsername = x.FromUser.Username,
                    IsOnline = ConnectedSessions.Any(y => y.UserId == x.FromUser.Id)
                })
                .ToList()
        });
    }
}
