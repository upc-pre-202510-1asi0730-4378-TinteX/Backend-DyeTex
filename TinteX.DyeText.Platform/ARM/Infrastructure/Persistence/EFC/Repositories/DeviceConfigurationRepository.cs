using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.ARM.Infrastructure.Persistence.EFC.Repositories;

public class DeviceConfigurationRepository(AppDbContext context)
    :BaseRepository<DeviceConfiguration>(context),
        IDeviceConfigurationRepository
{
    
    public async Task<DeviceConfiguration?> FindByIpAddressAsync(string ipAddress)
    {
        return await Context.Set<DeviceConfiguration>().FirstOrDefaultAsync(f => f.IpAddress == ipAddress);
    }
}