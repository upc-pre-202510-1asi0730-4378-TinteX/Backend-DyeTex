using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IRequestInvoiceCommandService {
    Task<RequestInvoiceId> Handle(CreateRequestInvoiceCommand command);
    Task Handle(DeleteRequestInvoiceCommand command);
}