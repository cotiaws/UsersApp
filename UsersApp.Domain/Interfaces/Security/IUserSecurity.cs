using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Domain.Interfaces.Security
{
    public interface IUserSecurity
    {
        string CreateToken(User user);
    }
}
