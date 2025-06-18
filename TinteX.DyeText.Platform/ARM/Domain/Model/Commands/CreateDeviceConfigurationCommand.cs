namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record CreateDeviceConfigurationCommand(
    string ConnectionProtocol,
    string IpAddress,
    int UpdateFrequency
);