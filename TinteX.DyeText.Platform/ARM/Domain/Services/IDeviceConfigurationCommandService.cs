using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Services;

public interface IDeviceConfigurationCommandService
{
    Task<DeviceConfiguration?> Handle(CreateDeviceConfigurationCommand command);
    Task<DeviceConfiguration?> Handle(UpdateDeviceConfigurationCommand command);
}