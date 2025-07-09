using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

namespace TinteX.DyeText.Platform.ARM.Domain.Services;

public interface IDeviceConfigurationQueryService
{
    Task<DeviceConfiguration?> GetByIpAddress(string ipAddress);
    Task<IEnumerable<DeviceConfiguration>> GetAll();
}