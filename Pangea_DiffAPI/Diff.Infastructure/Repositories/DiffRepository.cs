using Microsoft.EntityFrameworkCore;
using Diff.Application.Contracts.Persistence;
using Diff.Domain.Entities;
using Diff.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EllipticCurve.Utils;

namespace Diff.Infrastructure.Repositories
{
    public class DiffRepository : RepositoryBase<Difference>, IDiffRepository
    {
        public DiffRepository(DiffContext dbContext) : base(dbContext)
        {
        }

        public async Task<Difference> GetDiff(int id, string way)
        {
            var difference = await _dbContext.Differences
                                    .Where(o => o.Id == id && o.Way.Equals(way))
                                    .FirstOrDefaultAsync();
            return difference;
        }

        public async Task<List<Difference>> GetDiffById(int Id)
        {
            var diffList = await _dbContext.Differences
                                    .Where(o => o.Id == Id)
                                    .ToListAsync();
            return diffList;
        }
    }
}