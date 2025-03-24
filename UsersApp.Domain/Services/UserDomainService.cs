using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Helpers;
using UsersApp.Domain.Interfaces.Repositories;
using UsersApp.Domain.Interfaces.Security;
using UsersApp.Domain.Interfaces.Services;
using UsersApp.Domain.Models;

namespace UsersApp.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserSecurity _userSecurity;
        private readonly SHA256Helper _sha256Helper;

        public UserDomainService(IUserRepository userRepository, IRoleRepository roleRepository, IUserSecurity userSecurity, SHA256Helper sha256Helper)
        {
            _userRepository = userRepository;
            _sha256Helper = sha256Helper;
            _userSecurity = userSecurity;
            _roleRepository = roleRepository;
        }

        public async Task Create(User user)
        {
            #region Verificar se o email já está cadastrado no banco de dados

            if (await _userRepository.Any(user.Email))
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");

            #endregion

            #region Criptografar a senha

            user.Password = _sha256Helper.Encrypt(user.Password);

            #endregion

            #region Definir o perfil do usuário

            var role = await _roleRepository.Find("Operador");
            user.RoleId = role?.Id;

            #endregion

            #region Gravar o usuário no banco de dados

            _userRepository?.Add(user);

            #endregion
        }

        public async Task<string> Authenticate(string email, string password)
        {
            #region Buscar o usuário no banco de dados através do email e da senha

            var user = await _userRepository.Find(email, _sha256Helper.Encrypt(password));
            if (user == null)
                throw new ApplicationException("Usuário não encontrado. Verifique o ID informado.");

            #endregion

            #region Gerando e retornando o TOKEN JWT do usuário

            return _userSecurity.CreateToken(user);

            #endregion
        }
    }
}
