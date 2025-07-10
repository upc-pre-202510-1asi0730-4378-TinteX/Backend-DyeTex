using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Repositories;

public class RequestInvoiceRepository : IRequestInvoiceRepository {
    private readonly AppDbContext _context;

    public RequestInvoiceRepository(AppDbContext context) {
        _context = context;
    }
    
    public async Task<IEnumerable<RequestInvoice>> GetAllAsync()
    {
        return await _context.RequestInvoices.ToListAsync();
    }
    
    public async Task<RequestInvoice?> GetByRequestIdAsync(RequestId requestId)
    {
        return await _context.RequestInvoices
            .FirstOrDefaultAsync(i => i.RequestId.Value == requestId.Value);
    }
    
    public async Task AddAsync(RequestInvoice invoice) {
        await _context.RequestInvoices.AddAsync(invoice);
    }
    
    public void Remove(RequestInvoice invoice)
    {
        _context.RequestInvoices.Remove(invoice);
    }

}