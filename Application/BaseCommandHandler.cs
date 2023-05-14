using Common;
using Infrustructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace oc.Application
{
    public class BaseCommandHandler<TObject> : object where TObject : class
    {
        public readonly IRsaService _rsaService;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly ILogger<TObject> _logger;

        public BaseCommandHandler(IRsaService rsaService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ILogger<TObject> logger)
        {
            _unitOfWork = unitOfWork;
            _rsaService = rsaService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }
    }
}
