namespace SOLID
{
    public class Student: StudentEligibility, StudentLogInOut
    {
        private string username;
        private string password;
        private string studentId;

        public void Login(string username, string password)
        {
            //login student
        }

        public void Logout(string authToken)
        {
            //logout student
        }

        public bool IsEligibleToEnroll(string studentId, string classId)
        {
            bool eligible = true;
            //check, if student is eligible to enroll in corresponding class
            return eligible;
        } 
    }
}


