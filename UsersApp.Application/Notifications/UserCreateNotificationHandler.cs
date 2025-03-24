using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Infra.Data.MongoDB.Collections;
using UsersApp.Infra.Data.MongoDB.Repositories;

namespace UsersApp.Application.Notifications
{
    public class UserCreateNotificationHandler : INotificationHandler<UserCreateNotification>
    {
        private readonly UserMongoDBRepository _userMongoDBRepository;

        public UserCreateNotificationHandler(UserMongoDBRepository userMongoDBRepository)
        {
            _userMongoDBRepository = userMongoDBRepository;
        }

        public Task Handle(UserCreateNotification notification, CancellationToken cancellationToken)
        {
            var userCollection = new UserCollection
            {
                Id = notification.User.Id.Value,
                Name = notification.User.Name,
                Email = notification.User.Email,
                CreatedAt = notification.User.CreatedAt,
                Role = notification.User.Role.Name
            };

            _userMongoDBRepository.Add(userCollection);

            return Task.CompletedTask;
        }
    }
}
