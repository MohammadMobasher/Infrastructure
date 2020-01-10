﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service;

namespace Service.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("13981012150902_add_Routine2RoleDashboard_Table")]
    partial class add_Routine2RoleDashboard_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("NewsGroupId");

                    b.Property<string>("SummeryNews")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("Tags")
                        .HasMaxLength(400);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("UserId");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("NewsGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("DataLayer.Entities.NewsComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("NewsId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsComment");
                });

            modelBuilder.Entity("DataLayer.Entities.NewsGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("NewsGroup");
                });

            modelBuilder.Entity("DataLayer.Entities.NewsTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("NewsTag");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Notice2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreateDate");

                    b.Property<int?>("CreatorUserId");

                    b.Property<int?>("EntityId");

                    b.Property<bool>("IsRead");

                    b.Property<int?>("RoutineId");

                    b.Property<int?>("ToUserId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("RoutineId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Notice2");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PkColumnName")
                        .HasMaxLength(1024);

                    b.Property<string>("TableName")
                        .HasMaxLength(1024);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Routine2");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Action", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<string>("Action")
                        .HasMaxLength(32);

                    b.Property<string>("Color")
                        .HasMaxLength(64);

                    b.Property<string>("Icon")
                        .HasMaxLength(64);

                    b.Property<bool>("IsDescriptionMultiline");

                    b.Property<bool>("IsDescriptionRequired");

                    b.Property<bool>("ShouldHideDescription");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2048);

                    b.HasKey("RoutineId", "Step", "Action");

                    b.ToTable("Routine2Action");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Autodash", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<int>("ToStep");

                    b.Property<int>("TimeoutDays");

                    b.HasKey("RoutineId", "Step", "ToStep");

                    b.ToTable("Routine2Autodash");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("ActionDate");

                    b.Property<int?>("CreatorUserId");

                    b.Property<string>("Description");

                    b.Property<int>("EntityId");

                    b.Property<int>("RoutineId");

                    b.Property<string>("RoutineRoleTitle")
                        .HasMaxLength(1024);

                    b.Property<int>("Step");

                    b.Property<int?>("ToStep");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Routine2Log");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Notice", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<int>("FromStep");

                    b.Property<int>("ToStep");

                    b.Property<string>("Key")
                        .HasMaxLength(32);

                    b.Property<string>("Body");

                    b.Property<string>("BodyEmail");

                    b.Property<string>("BodySms");

                    b.Property<string>("ModelSqlQuery");

                    b.Property<string>("Title")
                        .HasMaxLength(512);

                    b.Property<string>("UserIdsSqlQuery");

                    b.HasKey("RoutineId", "FromStep", "ToStep", "Key");

                    b.ToTable("Routine2Notice");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Reminder", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<string>("Key")
                        .HasMaxLength(32);

                    b.Property<int>("TimeoutDays");

                    b.Property<string>("Body");

                    b.Property<string>("BodyEmail");

                    b.Property<string>("BodySms");

                    b.Property<string>("ModelSqlQuery");

                    b.Property<string>("UserIdsSqlQuery");

                    b.HasKey("RoutineId", "Step", "Key", "TimeoutDays");

                    b.ToTable("Routine2Reminder");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Role", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<string>("DashboardEnum")
                        .HasMaxLength(1024);

                    b.Property<int>("Id");

                    b.Property<int>("SortOrder");

                    b.Property<string>("StepsJson")
                        .IsRequired()
                        .HasMaxLength(2048);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("RoutineId", "DashboardEnum");

                    b.ToTable("Routine2Role");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2RoleDashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DashboardEnum")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Routine2RoleDashboard");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Step", b =>
                {
                    b.Property<int>("RoutineId");

                    b.Property<int>("Step");

                    b.Property<int?>("F1");

                    b.Property<int?>("F2");

                    b.Property<int?>("F3");

                    b.Property<int?>("F4");

                    b.Property<int?>("F5");

                    b.Property<int?>("F6");

                    b.Property<int?>("F7");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2048);

                    b.HasKey("RoutineId", "Step");

                    b.ToTable("Routine2Step");
                });

            modelBuilder.Entity("DataLayer.Entities.SlideShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasMaxLength(200);

                    b.Property<string>("ImgAddress")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("URL")
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("SlideShow");
                });

            modelBuilder.Entity("DataLayer.Entities.TestRoutin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("RoutineFlownDate");

                    b.Property<bool>("RoutineIsDone");

                    b.Property<bool>("RoutineIsFlown");

                    b.Property<bool>("RoutineIsSucceeded");

                    b.Property<int>("RoutineStep");

                    b.Property<DateTime?>("RoutineStepChangeDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TestRoutin");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.RoleClams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("RoleTitle");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserClams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserRoles", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserTokens", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePic");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UsersAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actions");

                    b.Property<string>("Controller");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UsersAccess");
                });

            modelBuilder.Entity("DataLayer.Entities.News", b =>
                {
                    b.HasOne("DataLayer.Entities.NewsGroup", "NewsGroup")
                        .WithMany()
                        .HasForeignKey("NewsGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.Users.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.NewsComment", b =>
                {
                    b.HasOne("DataLayer.Entities.News", "News")
                        .WithMany()
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Notice2", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Users", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany()
                        .HasForeignKey("RoutineId");

                    b.HasOne("DataLayer.Entities.Users.Users", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Action", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Actions")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Autodash", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Autodashes")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Log", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Users", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("DataLayer.Entities.Users.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Notice", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Notices")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Reminder", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Reminders")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Role", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Roles")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2RoleDashboard", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Routine2.Routine2Step", b =>
                {
                    b.HasOne("DataLayer.Entities.Routine2.Routine2", "Routine")
                        .WithMany("Steps")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.RoleClams", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserClams", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserLogin", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserRoles", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataLayer.Entities.Users.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UserTokens", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entities.Users.UsersAccess", b =>
                {
                    b.HasOne("DataLayer.Entities.Users.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
