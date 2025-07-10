using System;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;

public class AssignUser
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public DateTime StartDate { get; private set; }
    public string Plant { get; private set; }
    public string Role { get; private set; }
    public string Permission { get; private set; }

    public AssignUser() { }
    
    public AssignUser(CreateAssignUserCommand command)
    {
        Id = Guid.NewGuid();
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        StartDate = command.StartDate;
        Plant = command.Plant;
        Role = command.Role;
        Permission = command.Permission;
    }

    public void Update(UpdateAssignUserCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        StartDate = command.StartDate;
        Plant = command.Plant;
        Role = command.Role;
        Permission = command.Permission;
    }
}