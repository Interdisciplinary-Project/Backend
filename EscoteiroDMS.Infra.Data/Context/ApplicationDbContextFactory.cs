using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Infra.Data.Context
{
    public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();

            optionsBuilder.UseSqlServer("Data Source=grupoescoteiro.database.windows.net;Initial Catalog=gets;Persist Security Info=True;User ID=gets;Password=grupo123@;Encrypt=True");

            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }
}
