using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record CreateRequestInvoiceCommand(
        RequestId RequestId,
        double TotalAmount,
        DateOnly IssueDate
    );