using TinteX.DyeText.Platform.IAM.Domain.Model.Commands;
using TinteX.DyeText.Platform.IAM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}