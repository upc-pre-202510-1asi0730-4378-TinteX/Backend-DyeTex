namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record UpdateDeviceConfigurationCommand(
    string ConnectionProtocol,
    string IpAddress,
    int UpdateFrequency
);