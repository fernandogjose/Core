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
            var response = new UserModel();
            response.SetAuthUser(1, "fernando.jose@viavarejo.com.br", "Fernando José", "esteéomeutoken");
            return response;
        }
    }
}