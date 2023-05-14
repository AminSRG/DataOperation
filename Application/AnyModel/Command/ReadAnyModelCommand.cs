using FluentResults;

namespace Application.AnyModel.Command
{
    public class ReadAnyModelCommand : MediatR.IRequest<Result<Core.Models.Dto.AnyModelDto>>
    {
        public string Data { get; set; }
    }
}
