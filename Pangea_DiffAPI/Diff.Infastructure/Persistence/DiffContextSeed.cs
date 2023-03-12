using Microsoft.Extensions.Logging;
using Diff.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diff.Infrastructure.Persistence
{
    public class DiffContextSeed
    {
        public static async Task SeedAsync(DiffContext diffContext, ILogger<DiffContextSeed> logger)
        {
            if (!diffContext.Differences.Any())
            {
                diffContext.Differences.AddRange(GetPreconfiguredDifferences());
                await diffContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(DiffContext).Name);
            }
        }

        private static IEnumerable<Difference> GetPreconfiguredDifferences()
        {
            return new List<Difference>
            {
                new Difference() {Id = 123, Way = "Left", Text = "baris" }
            };
        }
    }
}