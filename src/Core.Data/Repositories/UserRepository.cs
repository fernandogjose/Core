using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models;

namespace Core.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public int Create(UserModel request)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Login(UserModel request)
        {
            var response = new UserModel(1, "fernando.jose@viavarejo.com.br", "123456");
            return response;
        }
    }
}