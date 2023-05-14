using Microsoft.EntityFrameworkCore;

namespace Infrustructure.AnyModel
{
    public class AnyModelRepository : EntityFramework.Repository.Repository<Core.Models.Entity.AnyModel>, IAnyModelRepository
    {
        public AnyModelRepository(DataBaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Core.Models.Entity.AnyModel> GetByCustomerNumber(string CustomerNumber)
        {
            return await DbSet.Where(current => current.Customernumber == CustomerNumber).FirstAsync();
        }
    }
}
