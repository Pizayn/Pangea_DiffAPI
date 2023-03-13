using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diff.Domain.Entities;

namespace Diff.Application.Contracts.Persistence
{
    public interface IDiffRepository : IAsyncRepository<Difference>
    {
        Task<Difference> GetDiff(int id, string way);

        Task<List<Difference>> GetDiffById(int Id);

    }
}
