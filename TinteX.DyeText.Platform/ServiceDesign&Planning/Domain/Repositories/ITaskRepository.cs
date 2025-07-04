using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskEntity = TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates.Task;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;

public interface ITaskRepository  {
     Task<IEnumerable<TaskEntity>> GetAllAsync();
     Task<TaskEntity?> GetByIdAsync(Guid id);
     Task AddAsync(TaskEntity task);
     Task UpdateAsync(TaskEntity task);
     Task DeleteAsync(TaskEntity task);
     Task<bool> ExistsAsync(Guid id);
}