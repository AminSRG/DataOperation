using FluentResults;

namespace Application.DataExample.Command
{
    public class UpdateDataExampleCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
