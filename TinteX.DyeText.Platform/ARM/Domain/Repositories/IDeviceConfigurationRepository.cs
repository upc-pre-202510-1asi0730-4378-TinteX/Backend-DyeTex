using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Domain.Repositories;

public interface IDeviceConfigurationRepository : IBaseRepository<DeviceConfiguration>
{
    Task<DeviceConfiguration?> FindByIpAddressAsync(string ipAddress);

    Task<IEnumerable<DeviceConfiguration>> ListAsync();
}