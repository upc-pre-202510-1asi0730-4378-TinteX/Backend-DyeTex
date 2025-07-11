using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

public partial class RequestInvoice  {
    public RequestInvoiceId Id { get; private set; }
    public RequestId RequestId { get; private set; }
    public double TotalAmount { get; private set; }
    public DateOnly IssueDate { get; private set; }

    public RequestInvoice(RequestId requestId, double totalAmount, DateOnly issueDate)
    {
        Id = RequestInvoiceId.NewId();
        RequestId = requestId;
        TotalAmount = totalAmount;
        IssueDate = issueDate;
    }

    public RequestInvoice(CreateRequestInvoiceCommand command)
    {
        Id = RequestInvoiceId.NewId();
        RequestId = command.RequestId;
        TotalAmount = command.TotalAmount;
        IssueDate = command.IssueDate;
    }

    protected RequestInvoice() { }
}
