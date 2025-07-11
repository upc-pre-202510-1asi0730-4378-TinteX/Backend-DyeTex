namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

public record MaintenanceId(Guid Value) {
    public static MaintenanceId NewId() => new(Guid.NewGuid());
}