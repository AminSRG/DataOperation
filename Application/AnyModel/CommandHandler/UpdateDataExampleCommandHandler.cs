using Application.DataExample.Command;
using Common;
using FluentResults;
using Infrustructure;
using Mapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;
using System.Text.Json;

namespace Application.DataExample.CommandHandler
{
    public class UpdateDataExampleCommandHandler : BaseCommandHandler<UpdateDataExampleCommandHandler>,
    IRequestHandler<UpdateDataExampleCommand, Result<bool>>
    {
        public UpdateDataExampleCommandHandler(ILogger<UpdateDataExampleCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<UpdateDataExampleCommand, Result<bool>>.Handle(
            UpdateDataExampleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.DataExampleDto>(data);
            var DataExample = new MapHelper().DynamicMap<Core.Models.Dto.DataExampleDto, Core.Models.Entity.DataExample>(dto);

            try
            {
                var updateRes = await _unitOfWork._DataExampleRepository.UpdateAsync(DataExample);

                if (updateRes)
                {
                    result.WithSuccess("Success!");
                    result.WithValue(updateRes);
                }
                else
                {
                    result.WithError("Operation Failed!");
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
