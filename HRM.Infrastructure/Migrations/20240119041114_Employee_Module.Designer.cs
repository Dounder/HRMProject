﻿// <auto-generated />
using System;
using HRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRM.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119041114_Employee_Module")]
    partial class Employee_Module
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Id", "Name");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7658),
                            Name = "Human Resource"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7661),
                            Name = "Information Technology (IT)"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7662),
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7663),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7663),
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7664),
                            Name = "Operations"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7665),
                            Name = "Customer Service"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7666),
                            Name = "Research and Development (R&D)"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7666),
                            Name = "Legal"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7667),
                            Name = "Executive"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7668),
                            Name = "None"
                        });
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateHired")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("ExtraHourRate")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Id", "Name");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7829),
                            DepartmentId = 1,
                            Name = "HR Manager"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7831),
                            DepartmentId = 1,
                            Name = "HR Coordinator"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7832),
                            DepartmentId = 1,
                            Name = "HR Assistant"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7833),
                            DepartmentId = 1,
                            Name = "Recruitment Specialist"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7834),
                            DepartmentId = 2,
                            Name = "IT Manager"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7834),
                            DepartmentId = 2,
                            Name = "Network Administrator"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7836),
                            DepartmentId = 2,
                            Name = "Software Developer"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7836),
                            DepartmentId = 2,
                            Name = "Help Desk Technician"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7837),
                            DepartmentId = 3,
                            Name = "Finance Manager"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7838),
                            DepartmentId = 3,
                            Name = "Accountant"
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7839),
                            DepartmentId = 3,
                            Name = "Financial Analyst"
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7840),
                            DepartmentId = 3,
                            Name = "Payroll Specialist"
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7841),
                            DepartmentId = 4,
                            Name = "Sales Manager"
                        },
                        new
                        {
                            Id = 14,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7842),
                            DepartmentId = 4,
                            Name = "Sales Representative"
                        },
                        new
                        {
                            Id = 15,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7843),
                            DepartmentId = 4,
                            Name = "Account Executive"
                        },
                        new
                        {
                            Id = 16,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7844),
                            DepartmentId = 4,
                            Name = "Sales Analyst"
                        },
                        new
                        {
                            Id = 17,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7845),
                            DepartmentId = 5,
                            Name = "Marketing Manager"
                        },
                        new
                        {
                            Id = 18,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7845),
                            DepartmentId = 5,
                            Name = "Marketing Coordinator"
                        },
                        new
                        {
                            Id = 19,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7846),
                            DepartmentId = 5,
                            Name = "Content Strategist"
                        },
                        new
                        {
                            Id = 20,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7847),
                            DepartmentId = 5,
                            Name = "SEO Specialist"
                        },
                        new
                        {
                            Id = 21,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7847),
                            DepartmentId = 6,
                            Name = "Operations Manager"
                        },
                        new
                        {
                            Id = 22,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7848),
                            DepartmentId = 6,
                            Name = "Logistics Coordinator"
                        },
                        new
                        {
                            Id = 23,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7849),
                            DepartmentId = 6,
                            Name = "Supply Chain Analyst"
                        },
                        new
                        {
                            Id = 24,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7850),
                            DepartmentId = 6,
                            Name = "Production Planner"
                        },
                        new
                        {
                            Id = 25,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7850),
                            DepartmentId = 7,
                            Name = "Customer Service Manager"
                        },
                        new
                        {
                            Id = 26,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7851),
                            DepartmentId = 7,
                            Name = "Customer Service Representative"
                        },
                        new
                        {
                            Id = 27,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7852),
                            DepartmentId = 7,
                            Name = "Support Specialist"
                        },
                        new
                        {
                            Id = 28,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7853),
                            DepartmentId = 8,
                            Name = "R&D Manager"
                        },
                        new
                        {
                            Id = 29,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7853),
                            DepartmentId = 8,
                            Name = "Product Developer"
                        },
                        new
                        {
                            Id = 30,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7854),
                            DepartmentId = 8,
                            Name = "Research Scientist"
                        },
                        new
                        {
                            Id = 31,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7855),
                            DepartmentId = 8,
                            Name = "R&D Engineer"
                        },
                        new
                        {
                            Id = 32,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7856),
                            DepartmentId = 9,
                            Name = "Legal Counsel"
                        },
                        new
                        {
                            Id = 33,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7856),
                            DepartmentId = 9,
                            Name = "Paralegal"
                        },
                        new
                        {
                            Id = 34,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7857),
                            DepartmentId = 9,
                            Name = "Legal Assistant"
                        },
                        new
                        {
                            Id = 35,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7858),
                            DepartmentId = 9,
                            Name = "Compliance Officer"
                        },
                        new
                        {
                            Id = 36,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7859),
                            DepartmentId = 10,
                            Name = "CEO (Chief Executive Officer)"
                        },
                        new
                        {
                            Id = 37,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7859),
                            DepartmentId = 10,
                            Name = "CFO (Chief Financial Officer)"
                        },
                        new
                        {
                            Id = 38,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7860),
                            DepartmentId = 10,
                            Name = "CTO (Chief Technology Officer)"
                        },
                        new
                        {
                            Id = 39,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7861),
                            DepartmentId = 10,
                            Name = "COO (Chief Operating Officer)"
                        },
                        new
                        {
                            Id = 40,
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7862),
                            DepartmentId = 11,
                            Name = "None"
                        });
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.TimeTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeIn")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeOut")
                        .HasColumnType("time");

                    b.Property<double>("TotalExtraHours")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5, 2)
                        .HasColumnType("float(5)")
                        .HasDefaultValue(0.0);

                    b.Property<double>("TotalHours")
                        .HasPrecision(5, 2)
                        .HasColumnType("float(5)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeTrackings");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a9c124b-09d1-40e9-bd81-47d4ae58a016",
                            CreatedAt = new DateTime(2024, 1, 19, 4, 11, 14, 406, DateTimeKind.Utc).AddTicks(9288),
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEDT3FSInfiwXnn0qodmGjgWfPVdI8IvR3Rs150lJrAOmifMUD5X4YYITmdAdagnq8g==",
                            PhoneNumberConfirmed = false,
                            RefreshToken = "16a4e3be-6976-4acd-9af9-d1e5af199c0f",
                            RefreshTokenExpiryTime = new DateTime(2024, 1, 18, 4, 11, 14, 473, DateTimeKind.Utc).AddTicks(7230),
                            SecurityStamp = "37350b27-f5cc-4966-b83e-71df3ee638a9",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("HRM.Domain.Entities.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Guest",
                            NormalizedName = "GUEST"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Employee", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Employees.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HRM.Domain.Entities.Employees.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Position", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Employees.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.TimeTracking", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Employees.Employee", "Employee")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Users.UserRole", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("HRM.Domain.Entities.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Employee", b =>
                {
                    b.Navigation("TimeTrackings");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Employees.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRM.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
