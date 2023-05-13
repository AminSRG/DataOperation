namespace Base.BaseEntitys.Interfaces
{
    public interface IBaseEntitys : IEntityID
    {
        public DateTime InsertDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
