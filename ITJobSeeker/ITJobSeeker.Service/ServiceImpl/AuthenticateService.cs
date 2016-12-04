using ITJobSeeker.Model.Models;
using ITJobSeeker.Repository.RepositoryInterfaces;
using ITJobSeeker.Service.Common;
using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJobSeeker.Service.ServiceImpl
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public AuthenticateService(IUserRepository _userRepository, IRoleRepository _roleRepository)
        {
            userRepository = _userRepository;
            roleRepository = _roleRepository;
        }

        public Account CreateAccountSession(User user)
        {
            return new Account(user);
        }

        public User Login(string username, string password)
        {
            User user = userRepository.Get(n => n.UserName == username);
            if (user != null)
            {
                string pass = PasswordEncrypt.ConverToMD5(password);
                if (user.Password == pass)
                {
                    Role role = roleRepository.GetById(user.RoleID);
                    user.Role = role;
                }
                else user = null;
            }
            return user;
        }
    }
}
