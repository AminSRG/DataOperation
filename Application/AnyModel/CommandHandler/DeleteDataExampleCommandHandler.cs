using Application.DataExample.Command;
using Common;
using FluentResults;
using Infrustructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;
using System.Text.Json;

namespace Application.DataExample.CommandHandler
{
    public class DeleteDataExampleCommandHandler : BaseCommandHandler<DeleteDataExampleCommandHandler>,
    IRequestHandler<DeleteDataExampleCommand, Result<bool>>
    {
        public DeleteDataExampleCommandHandler(ILogger<DeleteDataExampleCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<DeleteDataExampleCommand, Result<bool>>.Handle(
            DeleteDataExampleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.DataExampleDto>(data);

            try
            {
                var DataExample = await _unitOfWork._DataExampleRepository.GetByCustomerNumber(dto.CustomerNumber);
                if (DataExample == null)
                {
                    result.WithError("Model not found!");
                    return result;
                }

                await _unitOfWork._DataExampleRepository.DeleteAsync(DataExample);

                result.WithSuccess("Success!");
                result.WithValue(true);
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
