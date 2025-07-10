using System;
using System.Threading.Tasks;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Domain.Repositories;
using TinteX.DyeText.Platform.Profiles.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.Profiles.Application.Internal.CommandServices;

public class AssignUserCommandService(
    IAssignUserRepository assignUserRepository,
    IUnitOfWork unitOfWork
) : IAssignUserCommandService
{
    public async Task<AssignUser?> Handle(CreateAssignUserCommand command)
    {
        var assignUser = new AssignUser(command);
        await assignUserRepository.AddAsync(assignUser);
        await unitOfWork.CompleteAsync();
        return assignUser;
    }

    public async Task<AssignUser?> Handle(UpdateAssignUserCommand command)
    {
        var assignUser = await assignUserRepository.FindAssignUserByIdAsync(command.Id);
        if (assignUser == null)
            throw new InvalidOperationException($"AssignUser with Id {command.Id} does not exist.");

        assignUser.Update(command);

        try
        {
            assignUserRepository.Update(assignUser);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return assignUser;
    }
}