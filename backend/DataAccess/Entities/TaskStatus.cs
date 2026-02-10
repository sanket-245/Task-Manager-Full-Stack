using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

[Table("TaskStatus")]
public partial class TaskStatus
{
    [Key]
    public Guid TaskStatusId { get; set; }

    [Column("TaskStatus")]
    [StringLength(100)]
    [Unicode(false)]
    public string TaskStatus1 { get; set; } = null!;

    [InverseProperty("TaskStatus")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
