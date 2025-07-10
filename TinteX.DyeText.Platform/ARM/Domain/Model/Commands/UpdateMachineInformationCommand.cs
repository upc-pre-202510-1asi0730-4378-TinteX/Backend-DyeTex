namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record UpdateMachineInformationCommand(
    Guid Id,
    string TimeSpent,
    double DayProgress,
    double FailureRate,
    double AmountFailure,
    string UserId,
    double Temperature,
    double Vibration,
    double Energy,
    double Speed
    );