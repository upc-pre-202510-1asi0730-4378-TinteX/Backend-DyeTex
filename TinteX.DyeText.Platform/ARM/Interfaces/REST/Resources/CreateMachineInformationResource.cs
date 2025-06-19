namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record CreateMachineInformationResource(
    string TimeSpent,
    string DayProgress,
    string FailureRate,
    double AmountFailure
    );