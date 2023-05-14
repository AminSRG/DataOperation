using FluentResults;

namespace Application.AnyModel.Command
{
    public class DeleteAnyModelCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
