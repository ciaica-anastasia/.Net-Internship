using System.ComponentModel.Design;

namespace SOLID.DIP
{
    public class WrongTeacher //low-level class
    {
        public void Add()
        {
            //add a new teacher
        }
    }

    public class WrongAdmin //high-level class
    {
        WrongTeacher teacher;

        public void Adding(WrongTeacher t)
        {
            teacher = t;
        }

        public void manage()
        {
            teacher.Add();
        }
    }
    
    //if we want to add another low-level class, 
    //some functionality of Admin class may be affected
    public class WrongStudent //low-level class
    {
        public void Add()
        {
            //add a new student
        }
    }
    
}