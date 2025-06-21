using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.ValueObjects;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}
