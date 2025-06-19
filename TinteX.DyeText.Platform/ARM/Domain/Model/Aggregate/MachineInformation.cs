using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;

public partial class MachineInformation
{
    protected MachineInformation()
    {
        Id = Guid.NewGuid();
        TimeSpent = string.Empty;
        DayProgress = string.Empty;
        FailureRate = string.Empty;
        AmountFailure = 0;
    }

    public MachineInformation(CreateMachineInformationCommand command)
    {
        TimeSpent = command.TimeSpent;
        DayProgress = command.DayProgress;
        FailureRate = command.FailureRate;
        AmountFailure = command.AmountFailure;
    }
    
    public MachineInformation Update(UpdateMachineInformationCommand command)
    {
        Id = command.Id;
        TimeSpent = command.TimeSpent;
        DayProgress = command.DayProgress;
        FailureRate = command.FailureRate;
        AmountFailure = command.AmountFailure;

        return this;
    }
    
        
    public Guid Id { get; set; }

    public string TimeSpent { get; private set; }
    
    public string DayProgress { get; private set; }
    
    public string FailureRate { get; private set; }
    
    public double AmountFailure { get; private set; }

}