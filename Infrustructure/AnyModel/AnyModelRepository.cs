using Microsoft.EntityFrameworkCore;

namespace Infrustructure.DataExample
{
    public class DataExampleRepository : EntityFramework.Repository.Repository<Core.Models.Entity.DataExample>, IDataExampleRepository
    {
        public DataExampleRepository(DataBaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<Core.Models.Entity.DataExample> GetByCustomerNumber(string CustomerNumber)
        {
            return await DbSet.Where(current => current.Customernumber == CustomerNumber).FirstAsync();
        }
    }
}
