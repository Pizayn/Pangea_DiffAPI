using AutoMapper;
using Diff.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Queries
{
    public class GetDiffQueryHandler : IRequestHandler<GetDiffQuery, DiffVm>
    {
         private readonly IDiffRepository _diffRepository;
        private readonly IMapper _mapper;

        public GetDiffQueryHandler(IDiffRepository diffRepository, IMapper mapper)
        {
            _diffRepository = diffRepository ?? throw new ArgumentNullException(nameof(diffRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public Task<DiffVm> Handle(GetDiffQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
