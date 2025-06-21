namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record CreateTextileMachineCommand(
    Guid MachineInformationId,
    string Name,
    string AssetType,
    string Status,
    string SerialNumber,
    string Floor,
    string Zone,
    string DateInstallation
    );