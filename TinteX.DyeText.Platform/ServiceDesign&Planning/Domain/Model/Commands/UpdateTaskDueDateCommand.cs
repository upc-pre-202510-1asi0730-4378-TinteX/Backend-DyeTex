namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record UpdateTaskDueDateCommand(Guid TaskId, DateTime NewDueDate);