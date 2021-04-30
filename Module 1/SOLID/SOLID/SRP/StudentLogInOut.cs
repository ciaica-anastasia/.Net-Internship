namespace SOLID
{
    public interface StudentLogInOut
    {
        void Login(string username, string password);

        void Logout(string authToken);
    }
}