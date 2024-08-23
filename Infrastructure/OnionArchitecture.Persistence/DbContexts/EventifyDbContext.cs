using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Common;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.DbContexts
{
    public class EventifyDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsOne(x => x.Location);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EventifyDb");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<EntityBase>();

            foreach (var entry in data)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedDate = DateTime.UtcNow;

                else if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedDate = DateTime.UtcNow;

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
