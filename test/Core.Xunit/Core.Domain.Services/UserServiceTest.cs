using Bogus;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Moq;
using System;

namespace Core.Xunit.Core.Domain.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        private readonly UserService _userService;

        private readonly IServiceCollection _serviceCollection;

        private readonly Faker _faker;

        private int _id;

        private string _email;

        private string _password;

        public UserServiceTest()
        {
            //--- configuração do DI
            _serviceCollection = new ServiceCollection();
            _userRepositoryMock = new Mock<IUserRepository>();
            _serviceCollection.AddSingleton<IUserRepository>(_userRepositoryMock.Object);
            _serviceCollection.AddSingleton<UserService>();

            var services = _serviceCollection.BuildServiceProvider();
            _userService = services.GetService<UserService>();

            //--- Dados Fake
            _faker = new Faker();
            _id = _faker.Random.Number(1, 100);
            _email = _faker.Person.Email;
            _password = _faker.Random.AlphaNumeric(8);
        }

        [Fact]
        public void DeveAdicionarUmUsuario()
        {
            var request = new UserModel(0, _email, _password);

            _userRepositoryMock
                .Setup(r => r.Login(request))
                .Returns(new UserModel(_faker.Random.Number(1, 1000), _email, _password));

            var response = _userService.Login(request);

            _userRepositoryMock.Verify(r => r.Login(
                It.Is<UserModel>(
                    u => u.Email == _email
                      && u.Password == _password
                )));

            Assert.True(response.Id > 0);
        }
    }
}