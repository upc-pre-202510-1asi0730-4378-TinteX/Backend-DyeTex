using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ARM.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.CommandServices;

public class DeviceConfigurationCommandService(
    IDeviceConfigurationRepository deviceConfigurationRepository,
    IUnitOfWork unitOfWork
) : IDeviceConfigurationCommandService
{
    public async Task<DeviceConfiguration?> Handle(CreateDeviceConfigurationCommand command)
    {
        var deviceConfiguration = new DeviceConfiguration(command);
        await deviceConfigurationRepository.AddAsync(deviceConfiguration);
        await unitOfWork.CompleteAsync();
        return deviceConfiguration;
    }

    public async Task<DeviceConfiguration?> Handle(UpdateDeviceConfigurationCommand command)
    {
        var deviceConfiguration = await deviceConfigurationRepository.FindByIpAddressAsync(command.IpAddress);
        if (deviceConfiguration == null)
            throw new InvalidOperationException($"Device configuration with IP {command.IpAddress} does not exist.");

        var updatedDeviceConfiguration = deviceConfiguration.Update(command);

        try
        {
            deviceConfigurationRepository.Update(updatedDeviceConfiguration);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return updatedDeviceConfiguration;
    }
}