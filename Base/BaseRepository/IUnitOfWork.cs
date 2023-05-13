namespace Base.BaseRepository
{
    public interface IUnitOfWork 
    {
        Task SaveAsync();
    }
}
