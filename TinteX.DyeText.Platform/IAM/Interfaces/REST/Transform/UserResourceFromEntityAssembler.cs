using TinteX.DyeText.Platform.IAM.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.IAM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}