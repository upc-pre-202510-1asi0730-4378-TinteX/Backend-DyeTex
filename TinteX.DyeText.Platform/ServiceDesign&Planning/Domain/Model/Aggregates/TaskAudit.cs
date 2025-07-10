using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;

public partial class TaskAudit : IEntityWithCreatedUpdatedDate  { 
        [Column("CreatedAt")]
        public DateTimeOffset? CreatedDate { get; set; }
    
        [Column("UpdatedAt")]
        public DateTimeOffset? UpdatedDate { get; set; }
}