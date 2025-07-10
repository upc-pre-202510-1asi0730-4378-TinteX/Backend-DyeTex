using TinteX.DyeText.Platform.IAM.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.IAM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}