namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

public record RequestId(Guid Value) {
    public static RequestId NewId() => new(Guid.NewGuid());
}