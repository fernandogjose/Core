using Core.Domain.Exceptions;

namespace Core.Domain.Models
{
    public class UserModel
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public UserModel(int id, string email, string password)
        {
            ValidateValues(email, password);
            SetValues(id, email, password);
        }

        public UserModel(string email, string password)
        {
            ValidateValues(email, password);
            SetValues(0, email, password);
        }

        private static void ValidateValues(string email, string password)
        {
            DomainException.Set(!string.IsNullOrEmpty(email), "e-mail é obrigatório");
            DomainException.Set(!string.IsNullOrEmpty(password), "password é obrigatório");
        }

        private void SetValues(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}