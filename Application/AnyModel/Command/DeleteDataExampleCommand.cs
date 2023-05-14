using FluentResults;

namespace Application.DataExample.Command
{
    public class DeleteDataExampleCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
