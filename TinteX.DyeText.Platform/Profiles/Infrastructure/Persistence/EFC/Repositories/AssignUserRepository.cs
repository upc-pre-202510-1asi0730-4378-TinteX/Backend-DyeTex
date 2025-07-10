using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class AssignUserRepository(AppDbContext context)
    : BaseRepository<AssignUser>(context),
        IAssignUserRepository
{
    public async Task<AssignUser?> FindAssignUserByIdAsync(Guid id)
    {
        return await Context.Set<AssignUser>().FirstOrDefaultAsync(a => a.Id == id);
    }
}