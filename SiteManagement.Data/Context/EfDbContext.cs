﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SiteManagement.Core.Entity;
using SiteManagement.Core.System;
using SiteManagement.Data.Entity;

namespace SiteManagement.Data.Context
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        DbSet<Apartment> Apartments { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<ExpenseType> ExpenseTypes { get;set; }
        DbSet<Home> Homes { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Resident> Residents { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }


        private void TrackChanges()
        {

            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if ((entry.Entity is not IBaseEntity auditable)) continue;

                if (auditable == null) throw new ArgumentNullException(nameof(auditable));

                switch (entry.State)
                {
                    case EntityState.Added:
                        ApplyConceptsForAddedEntity(entry);
                        break;
                    case EntityState.Modified:
                        ApplyConceptsForUpdatedEntity(entry);
                        break;
                    case EntityState.Deleted:
                        ApplyConceptsForDeletedEntity(entry);
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("EntityState type is not defined.");
                }
            }
        }

        protected virtual void ApplyConceptsForAddedEntity(EntityEntry entry)
        {
            if (entry.Entity is not IBaseEntity)
            {
                return;
            }

            entry.Reload();
            entry.Entity.As<IBaseEntity>().IsDeleted = false;
            entry.Entity.As<IBaseEntity>().IsActive = true;
            entry.Entity.As<IBaseEntity>().CreatedDate = DateTime.Now;
            entry.State = EntityState.Added;
        }

        protected virtual void ApplyConceptsForUpdatedEntity(EntityEntry entry)
        {
            if (entry.Entity is not IBaseEntity)
            {
                return;
            }

            entry.Entity.As<IBaseEntity>().IsDeleted = false;
            entry.Entity.As<IBaseEntity>().IsActive = true;
            entry.Entity.As<IBaseEntity>().UpdatedDate = DateTime.Now;
            entry.State = EntityState.Modified;
        }

        protected virtual void ApplyConceptsForDeletedEntity(EntityEntry entry)
        {
          
                entry.Entity.As<IBaseEntity>().IsDeleted = true;
                entry.Entity.As<IBaseEntity>().IsActive = false;
                entry.Entity.As<IBaseEntity>().UpdatedDate = DateTime.Now;
                entry.State = EntityState.Modified;
        }
    }
}
