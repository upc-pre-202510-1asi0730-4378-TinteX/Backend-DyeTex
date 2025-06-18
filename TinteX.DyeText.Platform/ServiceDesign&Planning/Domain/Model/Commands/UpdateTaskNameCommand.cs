namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record UpdateTaskNameCommand(Guid TaskId, string NewName);