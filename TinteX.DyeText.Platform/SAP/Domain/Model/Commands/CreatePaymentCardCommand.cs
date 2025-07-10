namespace TinteX.DyeText.Platform.SAP.Domain.Model.Commands;

public record CreatePaymentCardCommand(
    string UserName,
    string Country,
    string NumberCard,
    string ExpirationDate,
    string CVV
);