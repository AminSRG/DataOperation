using FluentResults;

namespace Application.AnyModel.Command
{
    public class UpdateAnyModelCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
