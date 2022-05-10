using System;

namespace mvc.vuejs.infrastructure
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException() : base() { }

        public CommandValidationException(string message) : base(message) { }

        public CommandValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
