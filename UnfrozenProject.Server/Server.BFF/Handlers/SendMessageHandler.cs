using Acks;
using Answers;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class SendMessageHandler : Handler<SendMessageAck, GameSession>
{
    private readonly IMessageRepository _messageRepository;
    
    protected override async Task HandleAsync(GameSession session, SendMessageAck model)
    {
        if (!session.UserId.HasValue)
        {
            return;
        }

        await _messageRepository.CreateOrUpdateAsync(new MessageBinding
        {
            FromUserId = session.UserId.Value,
            ToUserId = session.UserId.Value,
            Content = model.Content
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
