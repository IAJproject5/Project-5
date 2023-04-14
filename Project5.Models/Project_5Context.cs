using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_5.Project5.Models;

public partial class Project_5Context : DbContext
{
    public Project_5Context()
    {
    }

    public Project_5Context(DbContextOptions<Project_5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<__efmigrationshistory> __efmigrationshistories { get; set; }

    public virtual DbSet<aspnetrole> aspnetroles { get; set; }

    public virtual DbSet<aspnetroleclaim> aspnetroleclaims { get; set; }

    public virtual DbSet<aspnetuser> aspnetusers { get; set; }

    public virtual DbSet<aspnetuserclaim> aspnetuserclaims { get; set; }

    public virtual DbSet<aspnetuserlogin> aspnetuserlogins { get; set; }

    public virtual DbSet<aspnetusertoken> aspnetusertokens { get; set; }

    public virtual DbSet<iaj_catalog> iaj_catalogs { get; set; }

    public virtual DbSet<iaj_course> iaj_courses { get; set; }

    public virtual DbSet<iaj_plan> iaj_plans { get; set; }

    public virtual DbSet<iaj_plan_course> iaj_plan_courses { get; set; }

    public virtual DbSet<iaj_plan_subject> iaj_plan_subjects { get; set; }

    public virtual DbSet<iaj_requirement> iaj_requirements { get; set; }

    public virtual DbSet<iaj_subject> iaj_subjects { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
		var connectionString = config.GetConnectionString("Project_5ContextConnection");

		optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<__efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.aspnetroleclaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "aspnetuserrole",
                    r => r.HasOne<aspnetrole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<aspnetuser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("aspnetuserroles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.aspnetusertokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<iaj_catalog>(entity =>
        {
            entity.HasKey(e => e.year).HasName("PRIMARY");

            entity.ToTable("iaj_catalog");

            entity.Property(e => e.year)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
        });

        modelBuilder.Entity<iaj_course>(entity =>
        {
            entity.HasKey(e => e.course_id).HasName("PRIMARY");

            entity.ToTable("iaj_course");

            entity.Property(e => e.course_id).HasMaxLength(20);
            entity.Property(e => e.credits).HasColumnType("int(11)");
            entity.Property(e => e.description).HasMaxLength(200);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.prereq_id).HasMaxLength(20);
        });

        modelBuilder.Entity<iaj_plan>(entity =>
        {
            entity.HasKey(e => e.plan_id).HasName("PRIMARY");

            entity.ToTable("iaj_plan");

            entity.Property(e => e.plan_id).HasMaxLength(20);
            entity.Property(e => e.catalog).HasPrecision(4);
            entity.Property(e => e.default_plan).HasMaxLength(20);
            entity.Property(e => e.plan_name).HasMaxLength(20);
            entity.Property(e => e.user_id).HasMaxLength(255);
        });

        modelBuilder.Entity<iaj_plan_course>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.course_id).HasMaxLength(20);
            entity.Property(e => e.plan_id).HasMaxLength(20);
            entity.Property(e => e.term).HasMaxLength(10);
            entity.Property(e => e.year).HasColumnType("int(11)");
        });

        modelBuilder.Entity<iaj_plan_subject>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.plan_id).HasColumnType("int(11)");
            entity.Property(e => e.subject).HasMaxLength(50);
            entity.Property(e => e.type).HasMaxLength(10);
        });

        modelBuilder.Entity<iaj_requirement>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.category).HasMaxLength(20);
            entity.Property(e => e.course_id).HasMaxLength(20);
            entity.Property(e => e.subject).HasMaxLength(50);
            entity.Property(e => e.type).HasMaxLength(10);
            entity.Property(e => e.year).HasPrecision(4);
        });

        modelBuilder.Entity<iaj_subject>(entity =>
        {
            entity.HasKey(e => new { e.subject, e.type })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.subject).HasMaxLength(50);
            entity.Property(e => e.type).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
