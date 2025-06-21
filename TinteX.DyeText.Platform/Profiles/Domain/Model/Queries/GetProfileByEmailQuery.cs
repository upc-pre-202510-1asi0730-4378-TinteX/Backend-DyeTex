using TinteX.DyeText.Platform.Profiles.Domain.Model.ValueObjects;

namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);