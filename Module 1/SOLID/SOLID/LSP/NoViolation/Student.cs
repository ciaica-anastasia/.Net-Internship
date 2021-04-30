namespace SOLID.LSP.NoViolation
{
    public class Student: IViewCourse
    {
        public string ViewCourse()
        {
            return "List of courses for student";
        }
    }
}