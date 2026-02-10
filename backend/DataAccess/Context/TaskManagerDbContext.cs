using System;
using System.Collections.Generic;
using DAENT = DataAccess.Entities ;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;

namespace DataAccess.Context;

public partial class TaskManagerDbContext : DbContext
{
    public TaskManagerDbContext()
    {
    }

    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DAENT.Task> Tasks { get; set; }

    public virtual DbSet<DAENT.TaskStatus> TaskStatuses { get; set; }

    public virtual DbSet<DAENT.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Task-ManagerDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DAENT.Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B1F552F486");

            entity.Property(e => e.TaskId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskStatus");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID");
        });

        modelBuilder.Entity<DAENT.TaskStatus>(entity =>
        {
            entity.HasKey(e => e.TaskStatusId).HasName("PK__TaskStat__C023DD6CA4A8A134");

            entity.Property(e => e.TaskStatusId).HasDefaultValueSql("(newsequentialid())");
        });

        modelBuilder.Entity<DAENT.User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C562F7358");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
