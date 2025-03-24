using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Models;

namespace UsersApp.Application.Notifications
{
    public class UserCreateNotification : INotification
    {
        private User _user;

        public UserCreateNotification(User user)
        {
            _user = user;
        }

        public User User => _user;
    }
}
