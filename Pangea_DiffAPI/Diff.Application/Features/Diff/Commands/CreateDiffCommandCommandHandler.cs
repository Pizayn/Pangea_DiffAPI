using AutoMapper;
using Diff.Application.Contracts.Persistence;
using Diff.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diff.Application.Features.Diff.Commands
{
    public class CreateDiffCommandCommandHandler : IRequestHandler<CreateDiffCommand, int>
    {

        private readonly IDiffRepository _diffRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateDiffCommandCommandHandler> _logger;

        public CreateDiffCommandCommandHandler(IDiffRepository diffRepository, IMapper mapper, ILogger<CreateDiffCommandCommandHandler> logger)
        {
            _diffRepository = diffRepository ?? throw new ArgumentNullException(nameof(diffRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateDiffCommand request, CancellationToken cancellationToken)
        {
            var differenceEntity = _mapper.Map<Difference>(request);
            var difference = await _diffRepository.GetDiff(request.Id, request.Way);

            if(difference != null)
            {
                throw new Exception("Entity already created");
            }
            var newDifference = await _diffRepository.AddAsync(differenceEntity);

            _logger.LogInformation($"Difference {newDifference.Id} is successfully created.");

            return newDifference.Id;
        }
    }
}
