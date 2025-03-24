using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Infra.Data.SqlServer.Mappings;

namespace UsersApp.Infra.Data.SqlServer.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
        }
    }
}
