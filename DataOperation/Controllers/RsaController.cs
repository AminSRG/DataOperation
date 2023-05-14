using Common;
using Microsoft.AspNetCore.Mvc;

namespace DataOperation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RsaController : ControllerBase
    {
        private readonly IRsaService _rsaService;
        public RsaController(IRsaService rsaService)
        {
            _rsaService = rsaService;
        }

        [HttpPost("Encryptor")]
        [ProducesResponseType(typeof(FluentResults.Result<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FluentResults.Result), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Encrypt(string command)
        {
            var resualt = new FluentResults.Result<string>();

            return Ok(resualt.WithValue(_rsaService.Encrypt(command)));
        }
    }