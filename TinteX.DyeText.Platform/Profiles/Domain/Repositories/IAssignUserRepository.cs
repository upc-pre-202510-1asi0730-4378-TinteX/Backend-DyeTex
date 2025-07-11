using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.Profiles.Domain.Repositories;

public interface IAssignUserRepository : IBaseRepository<AssignUser>
{
    Task<AssignUser?> FindAssignUserByIdAsync(Guid id);
}