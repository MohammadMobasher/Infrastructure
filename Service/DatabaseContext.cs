using Core.Utilities;
using DataLayer.Entities;
using DataLayer.Entities.Common;
using DataLayer.Entities.ExireRoutine;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{
    public class DatabaseContext : IdentityDbContext<Users, Roles, int, UserClams, UserRoles, UserLogin, RoleClams, UserTokens>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables

        public DbSet<TestRoutin> TestRoutin { get; set; }
        public DbSet<mohammadTest> mohammadTest { get; set; }
        
        public DbSet<UsersAccess> UsersAccess { get; set; }

        #region News

        public DbSet<News> News { get; set; }
        public DbSet<NewsComment> NewsComment { get; set; }
        public DbSet<NewsGroup> NewsGroup { get; set; }
        public DbSet<NewsTag> NewsTag { get; set; }

        #endregion


        #region Routin2

        public virtual DbSet<Routine2> Routine2 { get; set; }
        public virtual DbSet<Routine2Log> Routine2Log { get; set; }
        public virtual DbSet<Routine2Role> Routine2Role { get; set; }
        public virtual DbSet<Routine2RoleDashboard> Routine2RoleDashboard { get; set; }
        public virtual DbSet<Routine2Step> Routine2Step { get; set; }
        public virtual DbSet<Routine2Action> Routine2Action { get; set; }
        public virtual DbSet<Routine2Notice> Routine2Notice { get; set; }
        public virtual DbSet<Routine2Autodash> Routine2Autodash { get; set; }
        public virtual DbSet<Routine2Reminder> Routine2Reminder { get; set; }
        public virtual DbSet<Notice2> Notice2 { get; set; }

        #endregion

        public DbSet<SlideShow> SlideShow { get; set; }

        
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            var entitiesAssembly = typeof(IEntity).Assembly;


            #region FluentApi

            #region Routine2

            builder.Entity<Routine2Role>()
                .HasKey(c => new { c.RoutineId, c.DashboardEnum });

            builder.Entity<Routine2Step>()
                .HasKey(c => new { c.RoutineId, c.Step });

            builder.Entity<Routine2Action>()
                .HasKey(c => new { c.RoutineId, c.Step, c.Action });

            builder.Entity<Routine2Notice>()
                .HasKey(c => new { c.RoutineId, c.FromStep, c.ToStep, c.Key });

            builder.Entity<Routine2Autodash>()
                .HasKey(c => new { c.RoutineId, c.Step, c.ToStep });

            builder.Entity<Routine2Reminder>()
                .HasKey(c => new { c.RoutineId, c.Step, c.Key, c.TimeoutDays });

            builder.Entity<Routine2Role>().HasOne(p => p.Routine).WithMany(b => b.Roles).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Routine2Step>().HasOne(p => p.Routine).WithMany(b => b.Steps).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Routine2Action>().HasOne(p => p.Routine).WithMany(b => b.Actions).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Routine2Notice>().HasOne(p => p.Routine).WithMany(b => b.Notices).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Routine2Reminder>().HasOne(p => p.Routine).WithMany(b => b.Reminders).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Routine2Autodash>().HasOne(p => p.Routine).WithMany(b => b.Autodashes).OnDelete(DeleteBehavior.Cascade);

            #endregion


            #endregion


            //modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            //modelBuilder.AddRestrictDeleteBehaviorConvention();

            builder.RegisterEntityTypeConfiguration(entitiesAssembly);
            builder.AddSequentialGuidForIdConvention();

            
        }

        #region CleanString
        // این بخش برای یکپارچه سازی کاراکتر ها می باشد به صورتی که اگر کاربری 
        // ی عربی وارد کرد تبدیل به ی فارسی و ....

        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }

        #endregion
    }
}
