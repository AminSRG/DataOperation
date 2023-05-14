using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Core.Models.Entity.DataExample> MyModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-PUD9TJSCPQ8;Database=DataExample;Trusted_Connection=True;");
        }
    }
}
