using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Application.Commands;
using UsersApp.Application.Notifications;
using UsersApp.Domain.Interfaces.Services;
using UsersApp.Domain.Models;

namespace UsersApp.Application.Handlers
{
    public class UserRequestHandler :
        IRequestHandler<UserAuthCommand, string>,
        IRequestHandler<UserCreateCommand, string>
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserRequestHandler(IUserDomainService userDomainService, IMapper mapper, IMediator mediator)
        {
            _userDomainService = userDomainService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<string> Handle(UserAuthCommand request, CancellationToken cancellationToken)
        {
            return await _userDomainService.Authenticate(request.Email, request.Password);
        }

        public async Task<string> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _userDomainService.Create(user);

            await _mediator.Publish(new UserCreateNotification(user));

            return $"Usuário {user.Name} criado com sucesso.";
        }
    }
}
