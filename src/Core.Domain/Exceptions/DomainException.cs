using System;

namespace Core.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {

        }

        public static void Set(bool isValid, string message)
        {
            if (!isValid)
            {
                throw new DomainException(message);
            }
        }
    }
}