using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class TaskResourceFromEntityAssembler
{
    public static TaskResource ToResourceFromEntity(TaskView view)
    {
        return new TaskResource(view.Id, view.Name, view.DueDate); 
    }
}
