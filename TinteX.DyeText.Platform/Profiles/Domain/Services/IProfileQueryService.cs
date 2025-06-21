using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}