namespace SOLID.ISP
{
    public class Student: IView
    {
        public string ViewStudent()
        {
            return "List of courses for student";
        }

        public string ViewAdmin()
        {
            throw new System.NotImplementedException();
        }

        public string ViewGuest()
        {
            throw new System.NotImplementedException();
        }
    }
}