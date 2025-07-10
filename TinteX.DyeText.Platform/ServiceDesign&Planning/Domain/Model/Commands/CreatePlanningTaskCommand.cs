namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record CreatePlanningTaskCommand(
    string Name,
    string? Description
    );