using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class UpdateTaskNameCommandFromResourceAssembler
{
    public static UpdateTaskNameCommand ToCommandFromResource(Guid taskId, UpdatePlanningTaskResource resource)
    {
        return new UpdateTaskNameCommand(
            new TaskId(taskId),
            resource.NewName
        );
    }
}