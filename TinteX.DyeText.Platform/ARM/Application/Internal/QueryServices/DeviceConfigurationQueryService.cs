using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.QueryServices;

public class DeviceConfigurationQueryService(IDeviceConfigurationRepository deviceConfigurationRepository)
    : IDeviceConfigurationQueryService
{
    
    public async Task<DeviceConfiguration?> GetByIpAddress(string ipAddress)
    {
        return await deviceConfigurationRepository.FindByIpAddressAsync(ipAddress);
    }

    public async Task<IEnumerable<DeviceConfiguration>> GetAll()
    {
        return await deviceConfigurationRepository.ListAsync();
    }
}