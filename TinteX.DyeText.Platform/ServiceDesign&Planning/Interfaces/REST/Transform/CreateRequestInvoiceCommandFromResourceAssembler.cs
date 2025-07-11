using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class CreateRequestInvoiceCommandFromResourceAssembler
{
    public static CreateRequestInvoiceCommand ToCommandFromResource(CreateRequestInvoiceResource resource)
    {
        return new CreateRequestInvoiceCommand(
            new RequestId(resource.RequestId),
            resource.TotalAmount,
            resource.IssueDate
        );
    }
}