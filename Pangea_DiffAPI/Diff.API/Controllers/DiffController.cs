using Diff.Application.Features.Diff.Commands;
using Diff.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Diff.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiffController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DiffController> _logger;

        public DiffController(IMediator mediator, ILogger<DiffController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("{id}/left")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLeftDiffCommandAsync(int id,[FromBody] CreateDiffVm input)
        {

               var result = await _mediator.Send(
                   new CreateDiffCommand() { Id = id,Text = input.Text,Way = "left" }
               );           
            return Ok(result);
        }
        [HttpPost("{id}/right")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateRightDiffCommandAsync(int id, [FromBody] CreateDiffVm input)
        {

            var result = await _mediator.Send(
                new CreateDiffCommand() { Id = id, Text = input.Text, Way = "right" }
            );
            return Ok(result);
        }
     
    }

}
