using System.Net;

namespace Types
{
    public class EducationProcess
    {
        public static void Enrolled(in Student student)
        {
            //student = new Student();

            student.Enrolled = true;
        }
    }
}