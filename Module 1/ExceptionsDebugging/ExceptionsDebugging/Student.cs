using System.Text.RegularExpressions;

namespace ExceptionsDebugging
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        public static void ValidateStudent(Student std)
        {
            Regex regex = new Regex("^[a-zA-Z]+$"); //StudentName cannot contain special characters or numbers

            if (!regex.IsMatch(std.StudentName))
                throw new InvalidStudentNameException(std.StudentName);
            
        }
    }
}