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

        // This API endpoint is used to add the left input of a diff operation for a specific ID.
        // The input should be provided as a JSON object in the request body with a "Text" property.
        // If successful, the method returns an integer ID representing the diff record that was created.
        [HttpPost("left")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateLeftDiffCommandAsync(int id,[FromBody] CreateDiffVm input)
        {
            // Use Mediator to send a CreateDiffCommand with the ID and input data to the appropriate handler.

            var result = await _mediator.Send(
                   new CreateDiffCommand() { Id = id,Text = input.Text,Way = "left" }
               );           
            return Ok(result);
        }

        // This API endpoint is used to add the right input of a diff operation for a specific ID.
        // The input should be provided as a JSON object in the request body with a "Text" property.
        // If successful, the method returns an integer ID representing the diff record that was created.
        [HttpPost("right")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateRightDiffCommandAsync(int id, [FromBody] CreateDiffVm input)
        {
            // Use Mediator to send a CreateDiffCommand with the ID and input data to the appropriate handler.

            var result = await _mediator.Send(
                new CreateDiffCommand() { Id = id, Text = input.Text, Way = "right" }
            );
            return Ok(result);
        }

        // This API endpoint is used to get the diff result for a specific ID.
        // If the left and right inputs for the text are equal, the method returns a message saying "inputs were equal".
        // If the left and right inputs for the text are different sizes, the method returns a message saying "inputs are of different size".
        // If the left and right inputs for the text have the same size, the method returns a JSON object with the offsets and lengths of the differences.
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
