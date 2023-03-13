using Diff.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Queries
{
    public class DiffVm
    {
        public string Message { get; set; }
        public List<DiffSpan> Differences { get; set; } = new List<DiffSpan>();
    }

    public class DiffSpan
    {
        public int Offset { get; set; }
        public int Length { get; set; }
    }

}
