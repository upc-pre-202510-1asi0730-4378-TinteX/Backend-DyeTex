using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Analytics.Domain.Services
{
    public interface ITaskDueStatusCountCommandService
    {
        Task Handle(UpdateTaskDueStatusCountCommand command);
    }
}