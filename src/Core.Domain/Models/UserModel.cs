using System;
using Core.Domain.Exceptions;

namespace Core.Domain.Models
{
    public class UserModel
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Name { get; set; }

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
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("e-mail é obrigatório");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("senha é obrigatório");
        }

        private void SetValues(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }
    }
}