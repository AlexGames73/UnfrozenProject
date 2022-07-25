using Server.DAL.Logic.BindingModels;
using Server.DAL.Logic.ViewModels;

namespace Server.DAL.Logic.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateOrUpdateAsync(UserBinding model);
    Task<PageView<UserView>> ReadAsync(UserFilterBinding? filter = null, PageBinding? page = null);
    Task DeleteAsync(UserFilterBinding? filter = null);
}
