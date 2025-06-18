namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record UpdateDeviceConfigurationResource(
    Guid Id,
    string ConnectionProtocol,
    string IpAddress,
    int UpdateFrequency
);