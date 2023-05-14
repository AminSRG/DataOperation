using Application.DataExample.Command;
using Common;
using FluentResults;
using Infrustructure;
using Mapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;

namespace Application.DataExample.CommandHandler
{
    public class ReadDataExampleCommandHandler : BaseCommandHandler<ReadDataExampleCommandHandler>,
    IRequestHandler<ReadDataExampleCommand, Result<Core.Models.Dto.DataExampleDto>>
    {
        public ReadDataExampleCommandHandler(ILogger<ReadDataExampleCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<Core.Models.Dto.DataExampleDto>> IRequestHandler<ReadDataExampleCommand, Result<Core.Models.Dto.DataExampleDto>>.Handle(
            ReadDataExampleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<Core.Models.Dto.DataExampleDto>();

            var customerNumber = _rsaService.Decrypt(request.Data);
       
            try
            {
                var DataExample = await _unitOfWork._DataExampleRepository.GetByCustomerNumber(customerNumber);

                if (DataExample != null)
                {
                    var dto = new MapHelper().DynamicMap<Core.Models.Entity.DataExample, Core.Models.Dto.DataExampleDto>(DataExample);
                    result.WithSuccess("Success!");
                    result.WithValue(dto);
                }
                else
                {
                    result.WithError("Record not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.WithError("Operation Failed!");
            }

            return result;
        }
    }

}
