using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.DataExample
{
    public interface IDataExampleRepository : Base.BaseRepository.IRepository<Core.Models.Entity.DataExample>
    {
        Task<Core.Models.Entity.DataExample> GetByCustomerNumber(string CustomerNumber);
    }
}
