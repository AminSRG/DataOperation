using Application.AnyModel.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataOperation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnyModelController : BaseController<AnyModelController>
    {
        public AnyModelController(ILogger<AnyModelController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("CreateAnyModel")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateAnyModel([FromBody] CreateAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("ReadAnyModel")]
        [ProducesResponseType(typeof(FluentResults.Result<Core.Models.Dto.AnyModelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> ReadAnyModel([FromBody] ReadAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("UpdateAnyModel")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAnyModel([FromBody] UpdateAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("DeleteAnyModel")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAnyModel([FromBody] DeleteAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }
    }
}