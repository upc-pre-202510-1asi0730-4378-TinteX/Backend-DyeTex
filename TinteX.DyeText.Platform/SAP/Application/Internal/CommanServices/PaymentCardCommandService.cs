using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Domain.Services;
using TinteX.DyeText.Platform.SAP.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.SAP.Domain.Model.Commands;
using TinteX.DyeText.Platform.SAP.Domain.Repository;
using TinteX.DyeText.Platform.SAP.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.SAP.Application.Internal.CommanServices;

public class PaymentCardCommandService(
    IPaymentCardRepository paymentCardRepository, 
    IUnitOfWork unitOfWork) 
    : IPaymentCardCommandService
{
    public async Task<PaymentCard?> Handle(CreatePaymentCardCommand command)
    {
        var card = new PaymentCard(command);
        try
        {
            await paymentCardRepository.AddAsync(card);
            await unitOfWork.CompleteAsync();
            return card;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}