using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaoCao.DAL.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssigneeDepartments> AssigneeDepartments { get; set; }
        public virtual DbSet<AssigneeTasks> AssigneeTasks { get; set; }
        public virtual DbSet<Assignees> Assignees { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\DTHANHBINH;Initial Catalog=Data;Persist Security Info=True;User ID=sa;Password=0706;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssigneeDepartments>(entity =>
            {
                entity.HasKey(e => e.AssigneeDepartmentId)
                    .HasName("PK__Assignee__AD1CB1953EC72232");

                entity.Property(e => e.AssigneeDepartmentId).ValueGeneratedNever();

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.AssigneeDepartments)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK_AssigneeDepartments_Assignees");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AssigneeDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_AssigneeDepartments_Departments");
            });

            modelBuilder.Entity<AssigneeTasks>(entity =>
            {
                entity.HasKey(e => e.AssigneeTaskId)
                    .HasName("AT_st");

                entity.Property(e => e.AssigneeTaskId).ValueGeneratedNever();

                entity.Property(e => e.Schedule).HasColumnType("datetime");

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.AssigneeTasks)
                    .HasForeignKey(d => d.AssigneeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AT_A");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.AssigneeTasks)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ATS");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AssigneeTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AT_T");
            });

            modelBuilder.Entity<Assignees>(entity =>
            {
                entity.HasKey(e => e.AssigneeId);

                entity.Property(e => e.AssigneeId).ValueGeneratedNever();

                entity.Property(e => e.AssigneeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK_Reports_1");

                entity.Property(e => e.StateId).ValueGeneratedNever();

                entity.HasOne(d => d.State)
                    .WithOne(p => p.Reports)
                    .HasForeignKey<Reports>(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_S");
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("AS_st");

                entity.Property(e => e.StateId).ValueGeneratedNever();

                entity.Property(e => e.StateName).HasMaxLength(50);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).ValueGeneratedNever();

                entity.Property(e => e.TaskName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
