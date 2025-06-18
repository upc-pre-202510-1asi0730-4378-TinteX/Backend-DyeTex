namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Entities;

public class TaskEntity {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    
    public TaskEntity(){}
    
    public TaskEntity(string name, DateTime dueDate) {
        Id = Guid.NewGuid();
        Name = name;
        DueDate = dueDate;
    }
}