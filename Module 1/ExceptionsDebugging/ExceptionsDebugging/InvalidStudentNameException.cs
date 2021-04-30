using System;

namespace ExceptionsDebugging
{
    public class InvalidStudentNameException: Exception
    {
        public InvalidStudentNameException()
        {
        }

        public InvalidStudentNameException(string name) : base($"Invalid Student Name: {name}")
        {
        }

        public InvalidStudentNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}