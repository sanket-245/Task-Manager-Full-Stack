using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class Task
{
    [Key]
    public Guid TaskId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string TaskName { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string TaskDescription { get; set; } = null!;

    [Column("UserID")]
    public Guid UserId { get; set; }

    public Guid TaskStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("TaskStatusId")]
    [InverseProperty("Tasks")]
    public virtual TaskStatus TaskStatus { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Tasks")]
    public virtual User User { get; set; } = null!;
}
