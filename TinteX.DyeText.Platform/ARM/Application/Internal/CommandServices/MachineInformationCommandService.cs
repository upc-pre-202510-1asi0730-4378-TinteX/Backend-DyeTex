using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ARM.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.CommandServices;

public class MachineInformationCommandService(
    IMachineInformationRepository machineInformationRepository,
    IUnitOfWork unitOfWork
    ) : IMachineInformationCommandService
{
    public async Task<MachineInformation?> Handle(CreateMachineInformationCommand command)
    {
        var machineInformation = new MachineInformation(command);
        await machineInformationRepository.AddAsync(machineInformation);
        await unitOfWork.CompleteAsync();
        return machineInformation;
    }

    public async Task<MachineInformation?> Handle(UpdateMachineInformationCommand command)
    {
        var machineInformation = await machineInformationRepository.FindByIdAsync(command.Id);
        if (machineInformation == null) 
            throw new InvalidOperationException($"Machine information with ID {command.Id} does not exist.");

        var updatedMachineInformation = machineInformation.Update(command);

        try
        {
            machineInformationRepository.Update(updatedMachineInformation);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return updatedMachineInformation;
    }
}