using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Application.Commands;
using UsersApp.Application.Interfaces;
using UsersApp.Application.Queries;
using UsersApp.Infra.Data.MongoDB.Repositories;

namespace UsersApp.Application.Services
{
    public class UserAppService : IUserAppService
    {        
        private readonly UserMongoDBRepository _userRepository;
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        public UserAppService(UserMongoDBRepository userRepository, IMediator mediatR, IMapper mapper)
        {
            _userRepository = userRepository;
            _mediatR = mediatR;
            _mapper = mapper;
        }

        public async Task<string> Auth(UserAuthCommand command)
        {
            return await _mediatR.Send(command);
        }

        public async Task<string> Create(UserCreateCommand command)
        {            
            return await _mediatR.Send(command);
        }

        public UserDto GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return _mapper.Map<UserDto>(user);
        }
    }
}
