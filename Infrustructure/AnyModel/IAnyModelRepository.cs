using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.AnyModel
{
    public interface IAnyModelRepository : Base.BaseRepository.IRepository<Core.Models.Entity.AnyModel>
    {
        Task<Core.Models.Entity.AnyModel> GetByCustomerNumber(string CustomerNumber);
    }
}
