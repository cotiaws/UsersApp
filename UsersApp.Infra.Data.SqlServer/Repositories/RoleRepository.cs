using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Interfaces.Repositories;
using UsersApp.Domain.Models;
using UsersApp.Infra.Data.SqlServer.Contexts;

namespace UsersApp.Infra.Data.SqlServer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlServerContext _context;

        public RoleRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<Role?> Find(string name)
        {
            return await _context
                            .Set<Role>()
                            .FirstOrDefaultAsync(r => r.Name.Equals(name));
        }
    }
}
