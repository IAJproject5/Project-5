﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_5.Models;

public partial class Project5Context : DbContext
{
    public Project5Context()
    {
    }

    public Project5Context(DbContextOptions<Project5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetroleclaim> Aspnetroleclaims { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserclaim> Aspnetuserclaims { get; set; }

    public virtual DbSet<Aspnetuserlogin> Aspnetuserlogins { get; set; }

    public virtual DbSet<Aspnetusertoken> Aspnetusertokens { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

	public virtual DbSet<IajAdvisorAdvisee> IajAdvisorAdvisees { get; set; }
	
    public virtual DbSet<IajCatalog> IajCatalogs { get; set; }

    public virtual DbSet<IajCourse> IajCourses { get; set; }

    public virtual DbSet<IajPlan> IajPlans { get; set; }

    public virtual DbSet<IajPlanCourse> IajPlanCourses { get; set; }

    public virtual DbSet<IajPlanSubject> IajPlanSubjects { get; set; }

    public virtual DbSet<IajRequirement> IajRequirements { get; set; }

    public virtual DbSet<IajSubject> IajSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;database=\"Project 5\"", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.27-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<Aspnetroleclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetroleclaims");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.Role).WithMany(p => p.Aspnetroleclaims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetusers");

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
                    "Aspnetuserrole",
                    r => r.HasOne<Aspnetrole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<Aspnetuser>().WithMany()
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

        modelBuilder.Entity<Aspnetuserclaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aspnetuserclaims");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetuserlogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("aspnetuserlogins");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Aspnetusertoken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("aspnetusertokens");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetusertokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

		modelBuilder.Entity<IajAdvisorAdvisee>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("iaj_advisor_advisee");

			entity.Property(e => e.AdvisorId)
				.HasMaxLength(255)
				.HasColumnName("advisor_id");
			entity.Property(e => e.AdviseeId)
				.HasMaxLength(255)
				.HasColumnName("advisee_id");
		});

		modelBuilder.Entity<IajCatalog>(entity =>
        {
            entity.HasKey(e => e.Year).HasName("PRIMARY");

            entity.ToTable("iaj_catalog");

            entity.Property(e => e.Year)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("year");
        });

        modelBuilder.Entity<IajCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PRIMARY");

            entity.ToTable("iaj_course");

            entity.Property(e => e.CourseId)
                .HasMaxLength(20)
                .HasColumnName("course_id");
            entity.Property(e => e.Credits)
                .HasColumnType("int(11)")
                .HasColumnName("credits");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PrereqId)
                .HasMaxLength(20)
                .HasColumnName("prereq_id");
        });

        modelBuilder.Entity<IajPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PRIMARY");

            entity.ToTable("iaj_plan");

            entity.Property(e => e.PlanId)
                .HasColumnType("int(11)")
                .HasColumnName("plan_id");
            entity.Property(e => e.Catalog)
                .HasPrecision(4)
                .HasColumnName("catalog");
            entity.Property(e => e.DefaultPlan)
                .HasMaxLength(20)
                .HasColumnName("default_plan");
            entity.Property(e => e.PlanName)
                .HasMaxLength(20)
                .HasColumnName("plan_name");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<IajPlanCourse>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("iaj_plan_courses");

            entity.HasKey(u => new { u.CourseId, u.PlanId, u.Term, u.Year });
            entity.Property(e => e.CourseId)
                .HasMaxLength(20)
                .HasColumnName("course_id");
            entity.Property(e => e.PlanId)
                .HasColumnType("int(11)")
                .HasColumnName("plan_id");
            entity.Property(e => e.Term)
                .HasMaxLength(10)
                .HasColumnName("term");
            entity.Property(e => e.Year)
                .HasColumnType("int(11)")
                .HasColumnName("year");
        });

        modelBuilder.Entity<IajPlanSubject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("iaj_plan_subjects");

            entity.Property(e => e.PlanId)
                .HasColumnType("int(11)")
                .HasColumnName("plan_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .HasColumnName("subject");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
        });

        modelBuilder.Entity<IajRequirement>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("iaj_requirements");

            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.CourseId)
                .HasMaxLength(20)
                .HasColumnName("course_id");
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .HasColumnName("subject");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
            entity.Property(e => e.Year)
                .HasPrecision(4)
                .HasColumnName("year");
        });

        modelBuilder.Entity<IajSubject>(entity =>
        {
            entity.HasKey(e => new { e.Subject, e.Type })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("iaj_subjects");

            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .HasColumnName("subject");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
