using TinteX.DyeText.Platform.SAP.Domain.Model.Commands;
using TinteX.DyeText.Platform.SAP.Domain.Model.ValueObjects;

namespace TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;

public class PaymentCard
{
    protected PaymentCard()
    {
        Id = Guid.NewGuid();
        UserName = string.Empty;
        Country = string.Empty;
        Card = new UserCard();
    }

    public PaymentCard(CreatePaymentCardCommand command)
    {
        UserName = command.UserName;
        Country = command.Country;
        Card = new UserCard
        (
            command.ExpirationDate,
            command.NumberCard,
            command.CVV
        );
    }

    public Guid Id { get; set; }

    public string Country { get; private set; }

    public string UserName { get; private set; }

    public UserCard Card { get; private set; }
    
}