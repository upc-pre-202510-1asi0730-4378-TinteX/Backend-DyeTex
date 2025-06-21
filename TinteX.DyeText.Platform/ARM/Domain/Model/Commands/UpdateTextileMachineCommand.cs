namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record UpdateTextileMachineCommand(
    Guid Id,
    Guid MachineInformationId,
    string Name,
    string AssetType,
    string Status,
    string SerialNumber,
    string Floor,
    string Zone,
    string DateInstallation
    );