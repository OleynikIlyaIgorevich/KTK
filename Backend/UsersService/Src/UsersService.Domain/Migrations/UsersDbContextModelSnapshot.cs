﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UsersService.Domain;

#nullable disable

namespace UsersService.Domain.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UsersService.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("'IsDeleted' IS NULL");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(590),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Get",
                            IsDeleted = false,
                            Title = "Permission.Users.Get"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(1203),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Create",
                            IsDeleted = false,
                            Title = "Permission.Users.Create"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(1205),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Update",
                            IsDeleted = false,
                            Title = "Permission.Users.Update"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(1206),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Delete",
                            IsDeleted = false,
                            Title = "Permission.Users.Delete"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(1208),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Export",
                            IsDeleted = false,
                            Title = "Permission.Users.Export"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 723, DateTimeKind.Utc).AddTicks(1209),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Permission.Users.Import",
                            IsDeleted = false,
                            Title = "Permission.Users.Import"
                        });
                });

            modelBuilder.Entity("UsersService.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasFilter("'IsDeleted' IS NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 727, DateTimeKind.Utc).AddTicks(2408),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Супер пользователь",
                            IsDeleted = false,
                            Title = "Супер пользователь"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 727, DateTimeKind.Utc).AddTicks(3120),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Оператор расписания",
                            IsDeleted = false,
                            Title = "Оператор расписания"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 727, DateTimeKind.Utc).AddTicks(3122),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Преподаватель",
                            IsDeleted = false,
                            Title = "Преподаватель"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 12, 727, DateTimeKind.Utc).AddTicks(3123),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Студент",
                            IsDeleted = false,
                            Title = "Студент"
                        });
                });

            modelBuilder.Entity("UsersService.Domain.Entities.RolePermissions", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 6,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("UsersService.Domain.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("'IsDeleted' IS NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 13, 90, DateTimeKind.Utc).AddTicks(6095),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            PasswordHash = "$2a$11$/Ob.ZAZKdX8.qawI0tLWNe5SNkPpNex8NiRlauRs29m6LLT2XlI6O",
                            Username = "ilya1203"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 6, 13, 29, 13, 240, DateTimeKind.Utc).AddTicks(7535),
                            DeletedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            PasswordHash = "$2a$11$vMa.nWe34.S0W5fGIbEdfefqG0BtZ8vchv.4mRCU2AZ9L3oT1.ZJm",
                            Username = "gabitov123"
                        });
                });

            modelBuilder.Entity("UsersService.Domain.Entities.UserRoles", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            RoleId = 3,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("UsersService.Domain.Entities.RolePermissions", b =>
                {
                    b.HasOne("UsersService.Domain.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsersService.Domain.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.Session", b =>
                {
                    b.HasOne("UsersService.Domain.Entities.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.UserRoles", b =>
                {
                    b.HasOne("UsersService.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsersService.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("UsersService.Domain.Entities.User", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
