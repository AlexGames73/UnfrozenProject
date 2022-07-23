using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.ViewModels;

namespace Server.DAL.Logic.Repositories;

public interface IMessageRepository
{
    Task<Guid> CreateOrUpdateAsync(MessageBinding model);
    Task<PageView<MessageView>> ReadAsync(MessageFilterBinding filter, PageBinding page);
    Task DeleteAsync(MessageFilterBinding filter);
}
