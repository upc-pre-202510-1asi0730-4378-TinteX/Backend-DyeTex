using System;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

public partial class Task {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DueDate { get; private set; }
        
        public Task(string name, DateTime dueDate) {
            Id = Guid.NewGuid();
            Name = name;
            DueDate = dueDate;
        }
        
        private Task() { }
        
        public void UpdateName(string newName) {
            if (string.IsNullOrWhiteSpace(newName)) {
                throw new ArgumentException("The task name cannot be empty or null.", nameof(newName));
            }
            Name = newName;
        }
        
        public void UpdateDueDate(DateTime newDueDate) {
            if (newDueDate < DateTime.UtcNow.Date) {
                throw new ArgumentException("The expiration date cannot be in the past.", nameof(newDueDate));
            }
            DueDate = newDueDate;
        }
}