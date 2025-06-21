using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.ValueObjects;
using TinteX.DyeText.Platform.Profiles.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context)
 : BaseRepository<Profile>(context), IProfileRepository
{
 public async Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
 {
  return Context.Set<Profile>().FirstOrDefault(p => p.Email == email);
 }    
}
