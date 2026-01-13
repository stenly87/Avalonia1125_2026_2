using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Avalonia1132_2026_2.DB;

// команда для выполнения scaffold:
//выполняется в папке с файлом csproj
/*
dotnet ef dbcontext scaffold "server=192.168.200.13;user=student;password=student;database=12pupupu" Pomelo.EntityFrameworkCore.Mysql -o DB
*/
public partial class _12pupupuContext : DbContext
{
    public _12pupupuContext()
    {
    }

    public _12pupupuContext(DbContextOptions<_12pupupuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BookingRequest> BookingRequests { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.200.13;user=student;password=student;database=12pupupu", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Login, "Login").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(50);
        });

        modelBuilder.Entity<BookingRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClassroomId, "ClassroomId");

            entity.HasIndex(e => e.TeacherId, "TeacherId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AdminComment).HasMaxLength(500);
            entity.Property(e => e.ClassroomId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("time");
            entity.Property(e => e.StartTime).HasColumnType("time");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'на рассмотрении'");
            entity.Property(e => e.StudentsCount).HasColumnType("int(11)");
            entity.Property(e => e.TeacherId).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Classroom).WithMany(p => p.BookingRequests)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("BookingRequests_ibfk_2");

            entity.HasOne(d => d.Teacher).WithMany(p => p.BookingRequests)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("BookingRequests_ibfk_1");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Building).HasMaxLength(50);
            entity.Property(e => e.Capacity).HasColumnType("int(11)");
            entity.Property(e => e.Number).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'доступна'");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasMany(d => d.Equipment).WithMany(p => p.Classrooms)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassroomEquipment",
                    r => r.HasOne<Equipment>().WithMany()
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("ClassroomEquipment_ibfk_2"),
                    l => l.HasOne<Classroom>().WithMany()
                        .HasForeignKey("ClassroomId")
                        .HasConstraintName("ClassroomEquipment_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ClassroomId", "EquipmentId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("ClassroomEquipment");
                        j.HasIndex(new[] { "EquipmentId" }, "EquipmentId");
                        j.IndexerProperty<int>("ClassroomId").HasColumnType("int(11)");
                        j.IndexerProperty<int>("EquipmentId").HasColumnType("int(11)");
                    });
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Name, "Name").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.TeacherId, "TeacherId");

            entity.HasIndex(e => new { e.ClassroomId, e.Date, e.StartTime }, "UQ_Schedule").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClassroomId).HasColumnType("int(11)");
            entity.Property(e => e.Discipline).HasMaxLength(100);
            entity.Property(e => e.EndTime).HasColumnType("time");
            entity.Property(e => e.StartTime).HasColumnType("time");
            entity.Property(e => e.TeacherId).HasColumnType("int(11)");

            entity.HasOne(d => d.Classroom).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("Schedules_ibfk_1");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("Schedules_ibfk_2");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fio)
                .HasMaxLength(100)
                .HasColumnName("FIO");
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
