using Diff.Application.Contracts.Persistence;
using Diff.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Services
{
    public class DiffService : IDiffService
    {
        private readonly IDiffRepository _diffRepository;
        public DiffService(IDiffRepository diffRepository)
        {
            _diffRepository = diffRepository;
        }

        public async Task<Difference> AddDiff(Difference difference)
        {
            var differenceExist = await _diffRepository.GetDiff(difference.Id, difference.Way);

            if (differenceExist != null)
            {
                throw new Exception("Entity already created");
            }
            var newDifference = await _diffRepository.AddAsync(difference);


            return newDifference;
        }
    }
}
