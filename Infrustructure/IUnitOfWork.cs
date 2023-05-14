using Infrustructure.DataExample;

namespace Infrustructure
{
    public interface IUnitOfWork : Base.BaseRepository.IUnitOfWork
    {
        public IDataExampleRepository _DataExampleRepository { get; }
    }
}
