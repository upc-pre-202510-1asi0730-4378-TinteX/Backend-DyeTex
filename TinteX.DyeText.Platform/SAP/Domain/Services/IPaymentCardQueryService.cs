using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.SAP.Domain.Services;

public interface IPaymentCardQueryService
{
    Task<IEnumerable<PaymentCard>> Handle(GetAllPaymentCardsQuery query);
}