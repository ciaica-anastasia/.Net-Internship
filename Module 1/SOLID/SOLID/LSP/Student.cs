using System;

namespace SOLID.LSP
{
    public class Student: User
    {
        public override string ViewCourse()
        {
            return "List of courses for student";
        }

        public override string EditCourse()
        {
            throw new NotImplementedException();
        }
    }
}