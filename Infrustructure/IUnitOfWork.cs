using Infrustructure.AnyModel;

namespace Infrustructure
{
    public interface IUnitOfWork : Base.BaseRepository.IUnitOfWork
    {
        public IAnyModelRepository _anyModelRepository { get; }
    }
}
