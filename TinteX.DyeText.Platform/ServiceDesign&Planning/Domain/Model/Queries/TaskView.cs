using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;

public record TaskView(TaskId TaskId, string Name, ETaskStatus Status);