namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record RequestInvoiceResource(    
    Guid Id,
    Guid RequestId,
    double TotalAmount,
    DateOnly IssueDate
    );