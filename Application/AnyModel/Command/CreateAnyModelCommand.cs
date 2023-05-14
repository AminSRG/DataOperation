using FluentResults;

namespace Application.AnyModel.Command
{
    public class CreateAnyModelCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
