using TinteX.DyeText.Platform.IAM.Domain.Model.Commands;
using TinteX.DyeText.Platform.IAM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}