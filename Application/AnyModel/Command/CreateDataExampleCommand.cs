using FluentResults;

namespace Application.DataExample.Command
{
    public class CreateDataExampleCommand : MediatR.IRequest<Result<bool>>
    {
        public string Data { get; set; }
    }
}
