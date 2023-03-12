using Diff.Application.Features.Diff.Commands;
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

        /// <summary>
        /// This method adds the new pair to left.
        /// </summary>
        /// <param name="command"> the new pair. </param>
        /// <returns></returns>
        [HttpPost("{id}/left")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Left([FromBody] CreateDiffCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
     
        ///// <summary>
        ///// This methods adds the new pair to right.
        ///// </summary>
        ///// <param name="command"> the new pair. </param>
        ///// <returns></returns>
        //[HttpPost(Name = "right")]
        //public async Task<ActionResult<int>> Right([FromBody] CreateDiffCommand command)
        //{
        //    _logger.LogInformation($"Right method is called at {DateTime.UtcNow.ToLongTimeString()}");

        //    if (!int.TryParse((string)RouteData.Values["id"], out var id))
        //        return UnprocessableEntity();

        //    var result = await _mediator.Send(
        //        new CreateDiffCommand() { Id = id, Side = "right", Data = command.Data }
        //    );
        //    return Ok(result);
        //}

        ///// <summary>
        ///// This methods produces the differences between inserted pairs from left to right.
        ///// </summary>
        ///// <param name="id"> the pair id. </param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("")]
        //public async Task<ActionResult<ResultVm>> GetDiff([Required] int id)
        //{
        //    _logger.LogInformation($"GetDiff method is called at {DateTime.UtcNow.ToLongTimeString()}");
        //    var result = await _mediator.Send(
        //        new GetDifferencesCommand() { Id = id }
        //    );
        //    return result;
        //}
    }

}
