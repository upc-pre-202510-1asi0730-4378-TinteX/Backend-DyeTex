using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ARM.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.CommandServices;

public class TextileMachineCommandService(
    ITextileMachineRepository textileMachineRepository,
    IUnitOfWork unitOfWork) 
    : ITextileMachineCommandService
{
    public async Task<TextileMachine?> Handle(CreateTextileMachineCommand command)
    {
        var textileMachine = new TextileMachine(command);
        await textileMachineRepository.AddAsync(textileMachine);
        await unitOfWork.CompleteAsync();
        return textileMachine;
    }

    public async Task<TextileMachine?> Handle(UpdateTextileMachineCommand command)
    {
        var textileMachine = await textileMachineRepository.FindByIdAsync(command.Id);
        if (textileMachine == null) 
            throw new InvalidOperationException($"Textile machine with ID {command.Id} does not exist.");

        var aux = textileMachine.Update(command);

        try
        {
            textileMachineRepository.Update(aux);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return aux;
    }
}