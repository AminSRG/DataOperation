using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataOperation.Controllers.Base
{
    public class BaseController<TObject> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<TObject> _logger;

        public BaseController(ILogger<TObject> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
    }
}