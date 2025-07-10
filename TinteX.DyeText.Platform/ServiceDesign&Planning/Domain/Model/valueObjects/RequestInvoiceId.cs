namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

public record RequestInvoiceId(Guid Value) {
    public static RequestInvoiceId NewId() => new(Guid.NewGuid());

    public override string ToString() => Value.ToString();
}