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
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _context;

        public UserRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Any(string email)
        {
            return await _context
                            .Set<User>()
                            .Where(u => u.Email.Equals(email))
                            .AnyAsync();
        }

        public async Task<User?> Find(string email, string password)
        {
            return await _context
                            .Set<User>()
                            .Include(u => u.Role) //JOIN
                            .FirstOrDefaultAsync(
                                    u => u.Email.Equals(email)
                                 && u.Password.Equals(password));
        }
    }
}
