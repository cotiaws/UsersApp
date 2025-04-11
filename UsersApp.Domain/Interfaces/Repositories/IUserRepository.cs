using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<bool> Any(string email);

        Task<User?> Find(string email, string password);
    }
}
