using Application.AnyModel.Command;
using Common;
using FluentResults;
using Infrustructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using oc.Application;
using System.Text.Json;

namespace Application.AnyModel.CommandHandler
{
    public class DeleteAnyModelCommandHandler : BaseCommandHandler<DeleteAnyModelCommandHandler>,
    IRequestHandler<DeleteAnyModelCommand, Result<bool>>
    {
        public DeleteAnyModelCommandHandler(ILogger<DeleteAnyModelCommandHandler> logger,
            IHttpContextAccessor context, IUnitOfWork unitOfWork, IRsaService rsaService) : base(rsaService, unitOfWork, context, logger)
        {
        }

        async Task<Result<bool>> IRequestHandler<DeleteAnyModelCommand, Result<bool>>.Handle(
            DeleteAnyModelCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<bool>();

            var data = _rsaService.Decrypt(request.Data);
            var dto = JsonSerializer.Deserialize<Core.Models.Dto.AnyModelDto>(data);

            try
            {
                var anyModel = await _unitOfWork._anyModelRepository.GetByCustomerNumber(dto.CustomerNumber);
                if (anyModel == null)
                {
                    result.WithError("Model not found!");
                    return result;
                }

                await _unitOfWork._anyModelRepository.DeleteAsync(anyModel);

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
