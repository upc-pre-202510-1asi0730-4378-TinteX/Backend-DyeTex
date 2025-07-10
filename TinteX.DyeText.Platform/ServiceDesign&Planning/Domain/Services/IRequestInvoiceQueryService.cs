using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IRequestInvoiceQueryService {
    Task<RequestInvoice?> GetByRequestIdAsync(RequestId requestId);
    Task<IEnumerable<RequestInvoice>> Handle(GetAllRequestInvoiceQuery query);
}