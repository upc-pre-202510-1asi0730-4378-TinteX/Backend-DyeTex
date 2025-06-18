namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record CreateDeviceConfigurationResource(
    string ConnectionProtocol,
    string IpAddress,
    int UpdateFrequency
);