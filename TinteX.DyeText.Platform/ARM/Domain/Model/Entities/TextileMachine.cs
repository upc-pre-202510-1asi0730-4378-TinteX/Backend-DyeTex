using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

public class TextileMachine
{
    protected TextileMachine()
    {
        Id = Guid.NewGuid();
        MachineInformationId = Guid.Empty;
        Name = string.Empty;
        AssetType = string.Empty;
        Status = string.Empty;
        SerialNumber = string.Empty;
        Floor = string.Empty;
        Zone = string.Empty;
        DateInstallation = new DateTime();
    }

    public TextileMachine(CreateTextileMachineCommand command)
    {
        MachineInformationId = command.MachineInformationId;
        Name = command.Name;
        AssetType = command.AssetType;
        Status = command.Status;
        SerialNumber = command.SerialNumber;
        Floor = command.Floor;
        Zone = command.Zone;
    }
    
    public TextileMachine Update(UpdateTextileMachineCommand command)
    {
        Id = command.Id;
        MachineInformationId = command.MachineInformationId;
        Name = command.Name;
        AssetType = command.AssetType;
        Status = command.Status;
        SerialNumber = command.SerialNumber;
        Floor = command.Floor;
        Zone = command.Zone;
        DateInstallation = command.DateInstallation;
        return this;
    }
    
    public Guid Id { get; private set; }
    public Guid MachineInformationId { get; private set; }
    public string Name { get; private set; }
    public string AssetType { get; private set; }
    public string Status { get; private set; }
    public string SerialNumber { get; private set; }
    public string Floor { get; private set; }
    public string Zone { get; private set; }
    public DateTime DateInstallation { get; private set; }
}