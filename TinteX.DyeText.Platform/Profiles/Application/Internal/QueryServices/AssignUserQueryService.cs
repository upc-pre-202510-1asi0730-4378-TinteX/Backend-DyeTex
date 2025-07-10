using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;
using TinteX.DyeText.Platform.Profiles.Domain.Repositories;
using TinteX.DyeText.Platform.Profiles.Domain.Services;

namespace TinteX.DyeText.Platform.Profiles.Application.Internal.QueryServices;

public class AssignUserQueryService(IAssignUserRepository assignUserRepository)
    : IAssignUserQueryService
{
    public async Task<AssignUser?> Handle(GetAssignUserByIdQuery query)
    {
        return await assignUserRepository.FindAssignUserByIdAsync(query.Id);
    }

    public async Task<IEnumerable<AssignUser>> Handle(GetAllAssignUserQuery query)
    {
        return await assignUserRepository.ListAsync();
    }
}