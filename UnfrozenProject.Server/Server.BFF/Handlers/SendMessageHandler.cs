using Acks;
using Server.BFF.Factories;
using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.Repositories;
using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF.Handlers;

public class SendMessageHandler : Handler<SendMessageAck, GameSession>
{
    private readonly IMessageRepository _messageRepository;
    private readonly UpdateAppFactory _updateAppFactory;
    
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
        
        _updateAppFactory.Send(ConnectedSessions.Where(x => x.UserId.HasValue).ToArray());
    }
}
