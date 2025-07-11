using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;
using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.SAP.Domain.Services;

public interface IPaymentCardCommandService
{
    Task<PaymentCard?> Handle(CreatePaymentCardCommand command);
}