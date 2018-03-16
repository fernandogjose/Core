using Bogus;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Core.Xunit.Core.Domain.Services
{
    public class UserServiceTest
    {
        private int _id;

        private string _email;

        private string _password;

        public UserServiceTest()
        {
            var faker = new Faker();
            _id = faker.Random.Number(1, 100);
            _email = faker.Person.Email;
            _password = faker.Random.AlphaNumeric(8);
        }

        [Fact]
        public void DeveAdicionarUmUsuario()
        {
            var user = new UserModel(0, _email, _password);

            // IServiceCollection services = new IServiceCollection();
            // services.AddSingleton<IUserRepository, UserRepository>();
            // services.AddSingleton<UserService, UserService>();            
        }
    }
}