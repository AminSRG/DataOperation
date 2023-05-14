using Application.AnyModel.Command;
using Common;
using FluentResults;
using Infrustructure;
using Mapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;

namespace Application.AnyModel.CommandHandler
{
    public class ReadAnyModelCommandHandler : BaseCommandHandler<ReadAnyModelCommandHandler>,
    IRequestHandler<ReadAnyModelCommand, Result<Core.Models.Dto.AnyModelDto>>
    {
        public ReadAnyModelCommandHandler(ILogger<ReadAnyModelCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<Core.Models.Dto.AnyModelDto>> IRequestHandler<ReadAnyModelCommand, Result<Core.Models.Dto.AnyModelDto>>.Handle(
            ReadAnyModelCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<Core.Models.Dto.AnyModelDto>();

            var customerNumber = _rsaService.Decrypt(request.Data);
       
            try
            {
                var anyModel = await _unitOfWork._anyModelRepository.GetByCustomerNumber(customerNumber);

                if (anyModel != null)
                {
                    var dto = new MapHelper().DynamicMap<Core.Models.Entity.AnyModel, Core.Models.Dto.AnyModelDto>(anyModel);
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
