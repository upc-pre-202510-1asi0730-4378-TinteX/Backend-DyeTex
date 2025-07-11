namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

public record TaskId(Guid Value){
    public static TaskId NewId() => new(Guid.NewGuid());
}