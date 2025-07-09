using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;

public class TextileMachineRepository(AppDbContext context)
    :BaseRepository<TextileMachine>(context),
    ITextileMachineRepository
{
    public async Task<TextileMachine?> FindByIdAsync(Guid id)
    {
        return await Context.Set<TextileMachine>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TextileMachine?> FindByNameAsync(string name)
    {
        return await Context.Set<TextileMachine>().FirstOrDefaultAsync(f => f.Name == name);
    }
}