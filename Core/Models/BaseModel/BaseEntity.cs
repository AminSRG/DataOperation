using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.BaseModel
{
    public class BaseEntity : Base.BaseEntitys.Interfaces.IBaseEntitys
    {
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
