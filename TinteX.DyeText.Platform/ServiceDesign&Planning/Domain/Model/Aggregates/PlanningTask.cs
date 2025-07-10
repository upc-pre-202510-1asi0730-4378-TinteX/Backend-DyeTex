using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

public partial class PlanningTask  {
    public TaskId Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public PlanningTask(string name, string? description = null)
    {
        Id = TaskId.NewId();
        Name = name;
        Description = description;
    }

    public PlanningTask(CreatePlanningTaskCommand command)
    {
        Id = TaskId.NewId();
        Name = command.Name;
        Description = command.Description;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }

    protected PlanningTask() { }
}