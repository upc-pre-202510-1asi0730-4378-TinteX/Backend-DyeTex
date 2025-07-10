namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record PlanningTaskResource(
    Guid Id,
    string Name,
    string? Description
    );