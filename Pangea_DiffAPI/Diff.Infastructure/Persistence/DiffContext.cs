using Microsoft.EntityFrameworkCore;
using Diff.Domain.Common;
using Diff.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Diff.Infrastructure.Persistence
{
    public class DiffContext : DbContext
    {
        public DiffContext(DbContextOptions<DiffContext> options) : base(options)
        {
        }

        public DbSet<Difference> Differences { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "swn";
                        break;                  
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}