using System;
using Xunit;
using Core.Domain.Models;
using Core.Domain.Exceptions;
using Bogus;
using ExpectedObjects;

namespace Core.Xunit.Core.Domain.Models
{
    public class UserModelTest
    {
        private int _id;

        private string _email;

        private string _password;

        public UserModelTest()
        {
            var faker = new Faker();
            _id = faker.Random.Number(1, 100);
            _email = faker.Person.Email;
            _password = faker.Random.AlphaNumeric(8);
        }

        [Fact]
        public void DeveCriarUmUsuario()
        {
            var userExpectedObject = new
            {
                Id = _id,
                Email = _email,
                Password = _password
            };

            var user = new UserModel(_id, _email, _password);

            userExpectedObject.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveRetornarUmDomainExceptionQuandoEmailForInvalido(string email)
        {
            const string messageExpected = "e-mail é obrigatório";
            var ex = Assert.Throws<ArgumentException>(() => new UserModel(email, _password));
            Assert.Equal(ex.Message, messageExpected);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveRetornarUmDomainExceptionQuandoPasswordForInvalido(string password)
        {
            const string messageExpected = "senha é obrigatório";
            var ex = Assert.Throws<ArgumentException>(() => new UserModel(_email, password));
            Assert.Equal(ex.Message, messageExpected);
        }
    }
}