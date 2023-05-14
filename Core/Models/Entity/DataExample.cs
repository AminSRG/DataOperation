namespace Core.Models.Entity
{
    public class DataExample : BaseModel.BaseEntity
    {
        public string Customernumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
