using Application.DataExample.Command;
using Azure.Core;
using Base.BaseRepository;
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
    public class CreateDataExampleCommandHandler : BaseCommandHandler<CreateDataExampleCommandHandler>,
    IRequestHandler<CreateDataExampleCommand, Result<bool>>
    {
        public CreateDataExampleCommandHandler(ILogger<CreateDataExampleCommandHandler> logger,
            IHttpContextAccessor context, Infrustructure.IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<CreateDataExampleCommand, Result<bool>>.Handle(
            CreateDataExampleCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.DataExampleDto>(data);
            var DataExample = new MapHelper().DynamicMap<Core.Models.Dto.DataExampleDto, Core.Models.Entity.DataExample>(dto);

            try
            {
                var insertRes = await _unitOfWork._DataExampleRepository.InsertAsync(DataExample);

                if (insertRes)
                {
                    result.WithSuccess("Success!");
                    result.WithValue(insertRes);
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
