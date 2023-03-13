using Diff.Application.Features.Diff.Commands;
using Diff.Application.Features.Diff.Queries;
using Diff.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Diff.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/diff/{id}")]
    public class DiffController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DiffController> _logger;

        public DiffController(IMediator mediator, ILogger<DiffController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("left")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLeftDiffCommandAsync(int id,[FromBody] CreateDiffVm input)
        {

               var result = await _mediator.Send(
                   new CreateDiffCommand() { Id = id,Text = input.Text,Way = "left" }
               );           
            return Ok(result);
        }
        [HttpPost("right")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateRightDiffCommandAsync(int id, [FromBody] CreateDiffVm input)
        {

            var result = await _mediator.Send(
                new CreateDiffCommand() { Id = id, Text = input.Text, Way = "right" }
            );
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiffVm>>> GetDiff(int id)
        {
            var query = new GetDiffQuery(id);
            var result = await _mediator.Send(query);

            if (result.Message == null)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

    }

}
