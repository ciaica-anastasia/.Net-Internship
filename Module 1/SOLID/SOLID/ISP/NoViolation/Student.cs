namespace SOLID.ISP.NoViolation
{
    public class Student: IViewStudent
    {
        public string ViewStudent()
        {
            return "List of courses for student";
        }
    }
}