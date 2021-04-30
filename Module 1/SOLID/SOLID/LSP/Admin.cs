using System;

namespace SOLID.LSP
{
    public class Admin: User
    {
        public override string ViewCourse()
        {
            return "List of courses for admin";
        }

        public override string EditCourse()
        {
            return "The course was edited by admin";
        }
    }
}