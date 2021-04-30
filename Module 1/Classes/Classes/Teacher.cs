namespace Classes
{
    public class Teacher: User
    {
        protected sealed override string Action()
        {
            return "I am a teacher.";
        }
    }
}