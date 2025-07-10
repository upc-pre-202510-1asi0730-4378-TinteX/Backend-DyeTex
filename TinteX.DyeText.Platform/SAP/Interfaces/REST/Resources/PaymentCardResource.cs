namespace TinteX.DyeText.Platform.SAP.Interfaces.REST.Resources;

public record PaymentCardResource(
    Guid Id,
    string UserName,
    string Country,
    string NumberCard,
    string ExpirationDate,
    string CVV
    ) { }