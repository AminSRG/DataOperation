namespace Core.Models.SampleData
{
    public class AnyModel : BaseModel.BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
