using Microsoft.EntityFrameworkCore;

namespace Infrustructure.AnyModel
{
    public class AnyModelRepository : EntityFramework.Repository.Repository<Core.Models.SampleData.AnyModel>, IAnyModelRepository
    {
        public AnyModelRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
