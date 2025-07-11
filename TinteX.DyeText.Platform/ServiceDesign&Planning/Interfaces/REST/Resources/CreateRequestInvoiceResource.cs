namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record CreateRequestInvoiceResource(
        Guid RequestId,
        double TotalAmount,
        DateOnly IssueDate
        );