using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Domain.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> Find(string name);
    }
}
