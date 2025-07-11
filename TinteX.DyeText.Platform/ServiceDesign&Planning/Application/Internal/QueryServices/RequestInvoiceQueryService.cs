using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class RequestInvoiceQueryService : IRequestInvoiceQueryService {
    private readonly IRequestInvoiceRepository _requestInvoiceRepository;

    public RequestInvoiceQueryService(IRequestInvoiceRepository requestInvoiceRepository)
    {
        _requestInvoiceRepository = requestInvoiceRepository;
    }

    public async Task<RequestInvoice?> GetByRequestIdAsync(RequestId requestId)
    {
        return await _requestInvoiceRepository.GetByRequestIdAsync(requestId);
    }

    public async Task<IEnumerable<RequestInvoice>> Handle(GetAllRequestInvoiceQuery query)
    {
        return await _requestInvoiceRepository.GetAllAsync();
    }
}