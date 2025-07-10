using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class CreatePlanningTaskCommandFromResourceAssembler
{
    public static CreatePlanningTaskCommand ToCommandFromResource(CreatePlanningTaskResource resource)
    {
        return new CreatePlanningTaskCommand(
            resource.Name,
            resource.Description
        );
    }
}