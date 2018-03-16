using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Login(UserModel request)
        {
            var response = _userRepository.Login(request);
            return response;
        }
    }
}