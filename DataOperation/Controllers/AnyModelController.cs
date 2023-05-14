using Application.DataExample.Command;
using DataOperation.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataOperation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataExampleController : BaseController<DataExampleController>
    {
        public DataExampleController(ILogger<DataExampleController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateDataExample([FromBody] CreateDataExampleCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Read")]
        [ProducesResponseType(typeof(FluentResults.Result<Core.Models.Dto.DataExampleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> ReadDataExample([FromBody] ReadDataExampleCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateDataExample([FromBody] UpdateDataExampleCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Delete")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteDataExample([FromBody] DeleteDataExampleCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }
    }
