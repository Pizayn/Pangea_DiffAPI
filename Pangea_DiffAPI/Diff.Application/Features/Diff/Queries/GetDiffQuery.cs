using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Queries
{
    public class GetDiffQuery : IRequest<DiffVm>
    {
        public int Id { get; set; }

        public GetDiffQuery(int id)
        {
            Id = id;
        }
    }
}
