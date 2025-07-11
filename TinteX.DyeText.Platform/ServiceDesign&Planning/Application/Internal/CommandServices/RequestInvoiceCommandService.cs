using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.CommandServices;

public class RequestInvoiceCommandService : IRequestInvoiceCommandService {
    private readonly IRequestInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestInvoiceCommandService(IRequestInvoiceRepository invoiceRepository, IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RequestInvoiceId> Handle(CreateRequestInvoiceCommand command)
    {
        var invoice = new RequestInvoice(command);
        await _invoiceRepository.AddAsync(invoice);
        await _unitOfWork.CompleteAsync();
        return invoice.Id;
    }
    
    public async Task Handle(DeleteRequestInvoiceCommand command)
    {
        var invoice = await _invoiceRepository.GetByRequestIdAsync(command.RequestId);
        if (invoice is null) throw new ArgumentException($"Invoice with request ID {command.RequestId} not found.");

        _invoiceRepository.Remove(invoice);
        await _unitOfWork.CompleteAsync();
    }
}