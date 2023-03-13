using AutoMapper;
using Diff.API.Controllers;
using Diff.Application.Contracts.Persistence;
using Diff.Application.Features.Diff.Commands;
using Diff.Application.Features.Diff.Queries;
using Diff.Application.Mappings;
using Diff.Application.Models;
using Diff.Application.Services;
using Diff.Domain.Entities;
using Diff.Infrastructure.Persistence;
using Diff.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Application.Tests
{
    public class Tests
    {
        private IConfigurationProvider _configuration;
        private IMapper _mapper;

        private DiffRepository _diffRepository;

        private CreateDiffCommandCommandHandler _createDiffCommandCommandHandler;

        private GetDiffQueryHandler _getDiffQueryHandler;


        private DbContextOptions<DiffContext> _options;


        [SetUp]
        public void Setup()
        {
            _configuration = new MapperConfiguration(config =>
               config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();

            _options = new DbContextOptionsBuilder<DiffContext>()
        .UseInMemoryDatabase(databaseName: "DifferenceDb")
        .Options;

            _diffRepository = new DiffRepository(new DiffContext(_options));

            _createDiffCommandCommandHandler = new CreateDiffCommandCommandHandler(_diffRepository, _mapper, Mock.Of<ILogger<CreateDiffCommandCommandHandler>>());

            _getDiffQueryHandler = new GetDiffQueryHandler(_diffRepository, _mapper);


        }
        [Test]
        public async Task CreateDiffCommandCommandHandler_ValidInputLeft_ReturnsId()
        {
            var command = new CreateDiffCommand()
            {
                Id = 999,
                Way = "left",
                Text = "YXpGd2p2RHVXcA=="
            };
            var resp = _createDiffCommandCommandHandler.Handle(command, CancellationToken.None);
            Assert.AreEqual(999, resp.Result);
        }
        [Test]
        public async Task CreateDiffCommandCommandHandler_ValidInputRight_ReturnsId()
        {
            var command = new CreateDiffCommand()
            {
                Id = 999,
                Way = "right",
                Text = "YXpGd2p2RHVXcA=="
            };
            var resp = _createDiffCommandCommandHandler.Handle(command, CancellationToken.None);
            Assert.AreEqual(999, resp.Result);
        }

        [Test]
        public async Task CreateDiffCommandHandler_UnValidInput_EntityAlreadyCreated()
        {
            var command = new CreateDiffCommand()
            {
                Id = 999,
                Way = "right",
                Text = "YXpGd2p2RHVXcA=="
            };
            var resp = _createDiffCommandCommandHandler.Handle(command, CancellationToken.None);

            Assert.AreEqual("Entity already created", resp.Exception.InnerException.Message);
        }

        [Test]
        public async Task GetDiffQueryHandler_ValidInput_InputsWereEqual()
        {
            var leftCommand = new CreateDiffCommand()
            {
                Id = 986,
                Way = "left",
                Text = "dmluaWNpdXM="
            };
            var responseLeft = _createDiffCommandCommandHandler.Handle(leftCommand, CancellationToken.None);


            var rightCommand = new CreateDiffCommand()
            {
                Id = 986,
                Way = "right",
                Text = "dmluaWNpdXM="
            };
            var responseRight = _createDiffCommandCommandHandler.Handle(rightCommand, CancellationToken.None);


            var request = new GetDiffQuery(986);

            var response = _getDiffQueryHandler.Handle(request, CancellationToken.None);


            Assert.AreEqual("Inputs were equal", response.Result.Message);
        }


        [Test]
        public async Task GetDiffQueryHandler_ValidInput_InputsAreOfDifferentSize()
        {
            var leftCommand = new CreateDiffCommand()
            {
                Id = 987,
                Way = "left",
                Text = "dmluaWNpdXM="
            };
            var responseLeft = _createDiffCommandCommandHandler.Handle(leftCommand, CancellationToken.None);


            var rightCommand = new CreateDiffCommand()
            {
                Id = 987,
                Way = "right",
                Text = "YW5hbmRh"
            };
            var responseRight = _createDiffCommandCommandHandler.Handle(rightCommand, CancellationToken.None);


            var request = new GetDiffQuery(987);

            var response = _getDiffQueryHandler.Handle(request, CancellationToken.None);


            Assert.AreEqual("Inputs are of different size", response.Result.Message);
        }

        [Test]
        public async Task GetDiffQueryHandler_ValidInput_InputsWereCompared()
        {
            var leftCommand = new CreateDiffCommand()
            {
                Id = 985,
                Way = "left",
                Text = "dmluaWNpdXM="
            };
            var responseLeft = _createDiffCommandCommandHandler.Handle(leftCommand, CancellationToken.None);


            var rightCommand = new CreateDiffCommand()
            {
                Id = 985,
                Way = "right",
                Text = "aXNhYmVsbGU="
            };
            var responseRight = _createDiffCommandCommandHandler.Handle(rightCommand, CancellationToken.None);


            var request = new GetDiffQuery(985);

            var response = _getDiffQueryHandler.Handle(request, CancellationToken.None);


            Assert.AreEqual("Inputs were compared", response.Result.Message);
        }
    }
}