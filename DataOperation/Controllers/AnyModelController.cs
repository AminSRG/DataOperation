using Application.AnyModel.Command;
using Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataOperation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnyModelController : BaseController<AnyModelController>
    {
        private readonly IRsaService _rsaService;
        public AnyModelController(ILogger<AnyModelController> logger, IMediator mediator, IRsaService rsaService) : base(logger, mediator)
        {
            _rsaService = rsaService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateAnyModel([FromBody] CreateAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Read")]
        [ProducesResponseType(typeof(FluentResults.Result<Core.Models.Dto.AnyModelDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> ReadAnyModel([FromBody] ReadAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAnyModel([FromBody] UpdateAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Delete")]
        [ProducesResponseType(typeof(FluentResults.Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAnyModel([FromBody] DeleteAnyModelCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("StringEncrypt")]
        [ProducesResponseType(typeof(FluentResults.Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> DecryptedAnyModel(string command)
        {
            var resualt = new FluentResults.Result<string>();

            return Ok(resualt.WithValue(_rsaService.Encrypt(command)));
        }
    }
}