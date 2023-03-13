using Diff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Contracts.Persistence
{
     public interface IDiffService
    {
        Task<Difference> AddDiff(Difference difference);
    }
}
