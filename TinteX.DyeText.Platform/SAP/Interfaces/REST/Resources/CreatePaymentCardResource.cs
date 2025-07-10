namespace TinteX.DyeText.Platform.SAP.Interfaces.REST.Resources;

public record CreatePaymentCardResource(
    string UserName,
    string Country,
    string NumberCard,
    string ExpirationDate,
    string CVV
    ) { }