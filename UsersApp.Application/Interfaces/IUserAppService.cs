using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Application.Commands;
using UsersApp.Application.Queries;

namespace UsersApp.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<string> Auth(UserAuthCommand command);

        Task<string> Create(UserCreateCommand command);

        UserDto GetByEmail(string email);
    }
}
