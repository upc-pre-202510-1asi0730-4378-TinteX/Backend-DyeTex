using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Repository;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.SAP.Infrastructure.Persistence.EFC.Repositories;

public class PaymentCardRepository(AppDbContext context)
    : BaseRepository<PaymentCard>(context), IPaymentCardRepository
{
    
}