using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class RequestInvoiceResourceFromEntityAssembler
{
    public static RequestInvoiceResource ToResourceFromEntity(RequestInvoice invoice)
    {
        return new RequestInvoiceResource(
            Id: invoice.Id.Value,
            RequestId: invoice.RequestId.Value,
            TotalAmount: invoice.TotalAmount,
            IssueDate: invoice.IssueDate
        );
    }
}