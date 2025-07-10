namespace TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

public record UpdateMachineInformationCommand(
    Guid Id,
    string TimeSpent,
    string DayProgress,
    string FailureRate,
    double AmountFailure,
    string UserId,
    double Temperature,
    double Vibration,
    double Energy,
    double Speed
    );