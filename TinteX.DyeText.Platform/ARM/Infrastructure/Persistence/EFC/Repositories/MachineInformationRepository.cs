using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;

public class MachineInformationRepository(AppDbContext context) : 
    BaseRepository<MachineInformation>(context), 
    IMachineInformationRepository
{
    public async Task<MachineInformation?> FindByIdAsync(Guid id)
    {
        return await Context.Set<MachineInformation>().FirstOrDefaultAsync(x => x.Id == id);
    }
}