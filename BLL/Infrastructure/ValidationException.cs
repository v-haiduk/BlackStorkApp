using System;

namespace BLL.Infrastructure
{
    /// <summary>
    /// The class generates the message with error, which will see users
    /// </summary>
    public class ValidationException : Exception
    {
        public string NameOfProperty { get; protected set; }
        public ValidationException(string message, string property) : base(message)
        {
            NameOfProperty = property;
        }
    }
}
