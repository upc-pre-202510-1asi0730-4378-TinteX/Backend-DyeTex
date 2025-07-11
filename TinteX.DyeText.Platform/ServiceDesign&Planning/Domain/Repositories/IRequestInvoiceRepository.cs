using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;

public interface IRequestInvoiceRepository {
    Task<RequestInvoice?> GetByRequestIdAsync(RequestId requestId);
    Task AddAsync(RequestInvoice invoice);
    Task<IEnumerable<RequestInvoice>> GetAllAsync();
    void Remove(RequestInvoice invoice);
}