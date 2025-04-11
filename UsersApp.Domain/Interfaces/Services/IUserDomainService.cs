using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Domain.Interfaces.Services
{
    public interface IUserDomainService
    {
        Task Create(User user);

        Task<string> Authenticate(string email, string password);
    }
}
