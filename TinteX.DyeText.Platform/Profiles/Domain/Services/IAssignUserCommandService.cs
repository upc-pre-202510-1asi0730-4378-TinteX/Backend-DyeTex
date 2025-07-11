using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Profiles.Domain.Services;

public interface IAssignUserCommandService
{
    Task<AssignUser?> Handle(CreateAssignUserCommand command);
    Task<AssignUser?> Handle(UpdateAssignUserCommand command);
}