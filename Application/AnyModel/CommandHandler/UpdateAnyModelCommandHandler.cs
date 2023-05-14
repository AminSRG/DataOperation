using Application.AnyModel.Command;
using Common;
using FluentResults;
using Infrustructure;
using Mapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;
using System.Text.Json;

namespace Application.AnyModel.CommandHandler
{
    public class UpdateAnyModelCommandHandler : BaseCommandHandler<UpdateAnyModelCommandHandler>,
    IRequestHandler<UpdateAnyModelCommand, Result<bool>>
    {
        public UpdateAnyModelCommandHandler(ILogger<UpdateAnyModelCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<UpdateAnyModelCommand, Result<bool>>.Handle(
            UpdateAnyModelCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.AnyModelDto>(data);
            var anyModel = new MapHelper().DynamicMap<Core.Models.Dto.AnyModelDto, Core.Models.Entity.AnyModel>(dto);

            try
            {
                var updateRes = await _unitOfWork._anyModelRepository.UpdateAsync(anyModel);

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
