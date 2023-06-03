﻿// <auto-generated />
using System;
using Artemis_Issue_Tracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Artemis_Issue_Tracker.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230602190618_TaskUpdateMigration")]
    partial class TaskUpdateMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("task_id")
                        .HasColumnType("int");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("task_id");

                    b.HasIndex("user_id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Log", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("log")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("task_id")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("task_id");

                    b.HasIndex("user_id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("favorite")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("sprint_length")
                        .HasColumnType("datetime2");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Resource", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("comment_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("option")
                        .HasColumnType("int");

                    b.Property<int?>("task_id")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("comment_id");

                    b.HasIndex("task_id");

                    b.HasIndex("user_id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Sprint", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("project_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("project_id");

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("parent_id")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.Property<int>("progress")
                        .HasColumnType("int");

                    b.Property<int?>("project_id")
                        .HasColumnType("int");

                    b.Property<int?>("sprint_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("time_estimate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("time_log")
                        .HasColumnType("datetime2");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("parent_id");

                    b.HasIndex("project_id");

                    b.HasIndex("sprint_id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.UserProject", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("project_id")
                        .HasColumnType("int");

                    b.HasKey("user_id");

                    b.ToTable("UserProject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Comment", b =>
                {
                    b.HasOne("Artemis_Issue_Tracker.Models.Task", "task")
                        .WithMany("comments")
                        .HasForeignKey("task_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("task");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Log", b =>
                {
                    b.HasOne("Artemis_Issue_Tracker.Models.Task", "task")
                        .WithMany("logs")
                        .HasForeignKey("task_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("task");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Resource", b =>
                {
                    b.HasOne("Artemis_Issue_Tracker.Models.Comment", "comment")
                        .WithMany("resources")
                        .HasForeignKey("comment_id");

                    b.HasOne("Artemis_Issue_Tracker.Models.Task", "task")
                        .WithMany("resources")
                        .HasForeignKey("task_id");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "user")
                        .WithMany()
                        .HasForeignKey("user_id");

                    b.Navigation("comment");

                    b.Navigation("task");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Sprint", b =>
                {
                    b.HasOne("Artemis_Issue_Tracker.Models.Project", "project")
                        .WithMany("sprints")
                        .HasForeignKey("project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("project");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Task", b =>
                {
                    b.HasOne("Artemis_Issue_Tracker.Models.Task", "parent")
                        .WithMany("sub_tasks")
                        .HasForeignKey("parent_id");

                    b.HasOne("Artemis_Issue_Tracker.Models.Project", "project")
                        .WithMany("tasks")
                        .HasForeignKey("project_id");

                    b.HasOne("Artemis_Issue_Tracker.Models.Sprint", "sprint")
                        .WithMany("tasks")
                        .HasForeignKey("sprint_id");

                    b.Navigation("parent");

                    b.Navigation("project");

                    b.Navigation("sprint");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Comment", b =>
                {
                    b.Navigation("resources");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Project", b =>
                {
                    b.Navigation("sprints");

                    b.Navigation("tasks");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Sprint", b =>
                {
                    b.Navigation("tasks");
                });

            modelBuilder.Entity("Artemis_Issue_Tracker.Models.Task", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("logs");

                    b.Navigation("resources");

                    b.Navigation("sub_tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
