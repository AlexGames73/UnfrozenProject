using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.ViewModels;

namespace Server.DAL.Logic.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateOrUpdateAsync(UserBinding model);
    Task<PageView<UserView>> ReadAsync(UserFilterBinding filter, PageBinding page);
    Task DeleteAsync(UserFilterBinding filter);
}
