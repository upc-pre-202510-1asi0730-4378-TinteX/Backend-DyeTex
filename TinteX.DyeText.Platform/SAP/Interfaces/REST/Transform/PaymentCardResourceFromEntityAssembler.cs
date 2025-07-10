using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.SAP.Interfaces.REST.Transform;

public class PaymentCardResourceFromEntityAssembler
{
    public static PaymentCardResource ToResourceFromEntity(PaymentCard entity) =>
        new PaymentCardResource(
            entity.Id,
            entity.UserName,
            entity.Country,
            entity.Card.NumberCard,
            entity.Card.ExpirationDate,
            entity.Card.CVV
        );
}