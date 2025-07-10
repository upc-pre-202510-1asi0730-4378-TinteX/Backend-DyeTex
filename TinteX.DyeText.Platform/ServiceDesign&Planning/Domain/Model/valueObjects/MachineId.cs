namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

public record MachineId(Guid Value) {
    public static MachineId NewId() => new(Guid.NewGuid());
}