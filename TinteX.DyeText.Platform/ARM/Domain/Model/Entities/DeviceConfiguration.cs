using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

public class DeviceConfiguration
{
    protected DeviceConfiguration()
    {
        Id = Guid.NewGuid();
        ConnectionProtocol = string.Empty;
        IpAddress = string.Empty;
        UpdateFrequency = 0;
    }

    public DeviceConfiguration(CreateDeviceConfigurationCommand command)
    {
        ConnectionProtocol = command.ConnectionProtocol;
        IpAddress = command.IpAddress;
        UpdateFrequency = command.UpdateFrequency;
    }

    public DeviceConfiguration Update(UpdateDeviceConfigurationCommand command)
    {
        ConnectionProtocol = command.ConnectionProtocol;
        IpAddress = command.IpAddress;
        UpdateFrequency = command.UpdateFrequency;
        return this;
    }

    public Guid Id { get; private set; }
    public string ConnectionProtocol { get; private set; }
    public string IpAddress { get; private set; }
    public int UpdateFrequency { get; private set; }

    public void ConfigurateConnection(string protocol, string ip)
    {
        ConnectionProtocol = protocol;
        IpAddress = ip;
    }

    public void SetUpdateFrequency(int frequency)
    {
        UpdateFrequency = frequency;
    }

    public Dictionary<string, string> GetDeviceStatus()
    {
        return new Dictionary<string, string>
        {
            { "ConnectionProtocol", ConnectionProtocol },
            { "IpAddress", IpAddress },
            { "UpdateFrequency", UpdateFrequency.ToString() }
        };
    }
}