namespace TinteX.DyeText.Platform.SAP.Domain.Model.ValueObjects;

public record UserCard(string ExpirationDate, string NumberCard, string CVV)
{
    public UserCard() : this( 
        string.Empty,
        string.Empty,
        string.Empty
    ){}
};