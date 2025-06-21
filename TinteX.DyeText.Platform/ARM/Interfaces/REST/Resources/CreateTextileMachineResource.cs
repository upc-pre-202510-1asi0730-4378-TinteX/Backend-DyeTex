namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record CreateTextileMachineResource(
    Guid MachineInformationId,
    string Name,
    string AssetType,
    string Status,
    string SerialNumber,
    string Floor,
    string Zone,
    string DateInstallation
    );