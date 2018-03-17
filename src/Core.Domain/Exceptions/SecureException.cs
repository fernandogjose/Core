using System;

namespace Core.Domain.Exceptions
{
    public class SecureException : Exception
    {
        public SecureException(string message)
            : base(message)
        {

        }

        public static void IsValid(bool isValid, string message)
        {
            if (!isValid)
            {
                throw new SecureException(message);
            }
        }
    }
}