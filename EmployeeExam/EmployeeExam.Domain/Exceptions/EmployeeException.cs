using System.Runtime.Serialization;

namespace EmployeeExam.Domain.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException() { }
        public EmployeeException(string message) : base(message) { }
        public EmployeeException(string message, Exception inner) : base(message, inner) { }
        protected EmployeeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
