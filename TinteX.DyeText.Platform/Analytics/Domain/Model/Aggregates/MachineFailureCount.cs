namespace TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

public class MachineFailureCount
{
 public int Id { get; set; }
    public Guid MachineId { get; set; }           //Id de la maquina textil
    public string MachineName { get; set; } = ""; // nombre de la maquina
    
    
    public int Count { get; set; }                // total de fallas
}