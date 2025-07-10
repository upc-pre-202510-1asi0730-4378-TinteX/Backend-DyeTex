using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.Profiles.Domain.Services;

public interface IAssignUserQueryService
{
    Task<IEnumerable<AssignUser>> Handle(GetAllAssignUserQuery query);
    Task<AssignUser?> Handle(GetAssignUserByIdQuery query);
}