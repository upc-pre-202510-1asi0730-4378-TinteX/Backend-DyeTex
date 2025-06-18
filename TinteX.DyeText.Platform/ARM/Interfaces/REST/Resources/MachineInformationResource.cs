namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

public record MachineInformationResource(
    Guid Id,
    string TimeSpent,
    string DayProgress,
    string FailureRate,
    double AmountFailure
    );
