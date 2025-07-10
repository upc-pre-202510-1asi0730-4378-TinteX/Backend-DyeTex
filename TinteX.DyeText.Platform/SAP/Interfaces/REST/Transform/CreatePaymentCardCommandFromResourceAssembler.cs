using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Commands;
using TinteX.DyeText.Platform.SAP.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.SAP.Interfaces.REST.Transform;

public static class CreatePaymentCardCommandFromResourceAssembler
{
    public static CreatePaymentCardCommand ToCommandFromResource(CreatePaymentCardResource resource)
    {
        return new CreatePaymentCardCommand(
            resource.UserName,
            resource.Country,
            resource.NumberCard,
            resource.ExpirationDate,
            resource.CVV
        );
    }
}