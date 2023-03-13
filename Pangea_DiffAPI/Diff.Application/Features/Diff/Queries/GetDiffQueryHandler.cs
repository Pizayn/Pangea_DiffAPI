using AutoMapper;
using Diff.Application.Contracts.Persistence;
using Diff.Application.Exceptions;
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
        public async Task<DiffVm> Handle(GetDiffQuery request, CancellationToken cancellationToken)
        {
            var differenceList = await _diffRepository.GetAsync(x => x.Id == request.Id);

            if (differenceList.Count != 2)
            {
                throw new Exception("Difference list not found");
            }

            var left = differenceList.SingleOrDefault(x => x.Way == "left");
            var right = differenceList.SingleOrDefault(x => x.Way == "right");

            if (left == null || right == null)
            {
                return new DiffVm { Message = "Left and right inputs are not both available" };
            }

            DiffVm diffVm = new DiffVm();
            var leftData = Convert.FromBase64String(left.Text);
            var rightData = Convert.FromBase64String(right.Text);

            if (leftData.Length != rightData.Length)
            {
                diffVm.Message = "Inputs are of different size";
                return diffVm;
            }

            int differencesCount = 0;
            for (int i = 0; i < leftData.Length; i++)
            {
                if (leftData[i] != rightData[i])
                {
                    differencesCount++;
                    int length = 0;
                    int diff = leftData[i] ^ rightData[i];
                    while (diff != 0)
                    {
                        length++;
                        diff &= diff - 1;
                    }
                    diffVm.Differences.Add(new DiffSpan() { Length = length, Offset = i });
                }
            }

            diffVm.Message = differencesCount == 0 ? "Inputs were equal" : "Inputs were compared";
            return diffVm;
        }

       

    }
}
