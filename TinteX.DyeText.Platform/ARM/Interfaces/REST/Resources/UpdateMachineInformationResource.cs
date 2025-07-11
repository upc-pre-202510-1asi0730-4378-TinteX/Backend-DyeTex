namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record UpdateMachineInformationResource(
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