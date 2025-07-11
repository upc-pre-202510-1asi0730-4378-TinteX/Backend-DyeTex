using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class PlanningTaskResourceFromEntityAssembler
{
    public static PlanningTaskResource ToResourceFromEntity(PlanningTask entity, string machineName)
    {
        return new PlanningTaskResource(
            Id: entity.Id.Value,
            Name: entity.Name,
            Description: entity.Description,
            TextileMachineId: entity.TextileMachineId,
            TextileMachineName: machineName
        );
    }
}