using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates
{
    public class MachineFailureRate
    {
        public int Id { get; set; }
        public Guid MachineId { get; set; }
        public string MachineName { get; set; } = null!;
        public double Rate { get; set; }
    }
}


