namespace TinteX.DyeText.Platform.SAP.Domain.Model.Commands;

public record CreatePaymentCardCommand(
    string NumberCard,
    string ExpirationDate,
    string CVV,
    string UserName,
    string Country
);