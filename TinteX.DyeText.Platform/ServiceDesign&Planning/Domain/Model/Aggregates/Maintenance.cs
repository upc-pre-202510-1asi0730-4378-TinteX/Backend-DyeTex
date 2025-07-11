using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

public partial class Maintenance {
    public MaintenanceId Id { get; private set; }
    public string Description { get; private set; }
    public string ScheduledDate { get; private set; }
    public Guid MachineId { get; private set; }
    public ETaskStatus Status { get; private set; }

    public Maintenance(string description, string scheduledDate, Guid machineId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        
        
        MachineId = machineId;

        Id = MaintenanceId.NewId();
        Description = description;
        ScheduledDate = scheduledDate;
        Status = ETaskStatus.Pending;
    }

    public Maintenance(CreateMaintenanceCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Description))
            throw new ArgumentException("Description cannot be null or empty.", nameof(command.Description));
        
        MachineId = command.MachineId;

        Id = MaintenanceId.NewId();
        Description = command.Description;
        ScheduledDate = command.ScheduledDate;
        Status = ETaskStatus.Pending;
    }

    public void UpdateStatus(ETaskStatus newStatus)
    {
        Status = newStatus;
    }

    protected Maintenance() { }
}