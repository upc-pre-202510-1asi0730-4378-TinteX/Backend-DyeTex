using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;

public class MachineInformation
{
    protected MachineInformation()
    {
        Id = Guid.NewGuid();
        TimeSpent = string.Empty;
        DayProgress = 0;
        FailureRate = 0;
        AmountFailure = 0;
        Temperature = 0;
        Vibration = 0;
        Energy = 0;
        Speed = 0;
    }

    public MachineInformation(CreateMachineInformationCommand command)
    {
        TimeSpent = command.TimeSpent;
        DayProgress = command.DayProgress;
        FailureRate = command.FailureRate;
        AmountFailure = command.AmountFailure;
        Temperature = command.Temperature;
        Vibration = command.Vibration;
        Energy = command.Energy;
        Speed = command.Speed;
    }
    
    public MachineInformation Update(UpdateMachineInformationCommand command)
    {
        Id = command.Id;
        TimeSpent = command.TimeSpent;
        DayProgress = command.DayProgress;
        FailureRate = command.FailureRate;
        AmountFailure = command.AmountFailure;
        Temperature = command.Temperature;
        Vibration = command.Vibration;
        Energy = command.Energy;
        Speed = command.Speed;

        return this;
    }
    
        
    public Guid Id { get; set; }

    public string TimeSpent { get; private set; }
    
    public double DayProgress { get; private set; }
    
    public double FailureRate { get; private set; }
    
    public double AmountFailure { get; private set; }
    
    public string UserId { get; set; } = string.Empty;
    
    public double Temperature { get; private set; }
    
    public double Vibration { get; private set; }
    
    public double Energy { get; private set; }
    
    public double Speed { get; private set; }

}