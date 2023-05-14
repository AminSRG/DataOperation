using FluentResults;

namespace Application.DataExample.Command
{
    public class ReadDataExampleCommand : MediatR.IRequest<Result<Core.Models.Dto.DataExampleDto>>
    {
        public string Data { get; set; }
    }
}
