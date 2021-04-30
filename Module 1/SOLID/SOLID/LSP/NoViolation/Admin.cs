namespace SOLID.LSP.NoViolation
{
    public class Admin: IEditCourse, IViewCourse
    {
        public string ViewCourse()
        {
            return "List of courses for admin";
        }

        public string EditCourse()
        {
            return "The course was edited by admin";
        }
    }
}