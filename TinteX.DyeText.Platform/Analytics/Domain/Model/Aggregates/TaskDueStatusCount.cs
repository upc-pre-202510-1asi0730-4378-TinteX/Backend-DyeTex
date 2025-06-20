namespace TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates
{
    public class TaskDueStatusCount
    {
        public int Id { get; set; }
        public int OverdueCount { get; set; }
        public int UpcomingCount { get; set; }
    }
}