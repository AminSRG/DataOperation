using Application.AnyModel.Command;
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

namespace Application.AnyModel.CommandHandler
{
    public class CreateAnyModelCommandHandler : BaseCommandHandler<CreateAnyModelCommandHandler>,
    IRequestHandler<CreateAnyModelCommand, Result<bool>>
    {
        public CreateAnyModelCommandHandler(ILogger<CreateAnyModelCommandHandler> logger,
            IHttpContextAccessor context, Infrustructure.IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<CreateAnyModelCommand, Result<bool>>.Handle(
            CreateAnyModelCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.AnyModelDto>(data);
            var anyModel = new MapHelper().DynamicMap<Core.Models.Dto.AnyModelDto, Core.Models.Entity.AnyModel>(dto);

            try
            {
                var insertRes = await _unitOfWork._anyModelRepository.InsertAsync(anyModel);

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
