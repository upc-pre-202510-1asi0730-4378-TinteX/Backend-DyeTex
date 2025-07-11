using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Queries;
using TinteX.DyeText.Platform.SAP.Domain.Repository;
using TinteX.DyeText.Platform.SAP.Domain.Services;

namespace TinteX.DyeText.Platform.SAP.Application.Internal.QueryServices;

public class PaymentCardQueryService(IPaymentCardRepository paymentCardRepository) : IPaymentCardQueryService
{
    public async Task<IEnumerable<PaymentCard>> Handle(GetAllPaymentCardsQuery query)
    {
        return await paymentCardRepository.ListAsync();
    }
}