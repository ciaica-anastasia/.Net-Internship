using System.ComponentModel.Design;

namespace SOLID.DIP
{
    public interface IAdd
    {
        public void Add();
    }

    public class Teacher : IAdd
    {
        public void Add()
        {
            //add a new teacher
        }
    }

    public class Student : IAdd
    {
        public void Add()
        {
            //add a new student
        }
    }

    public class Admin
    {
        public IAdd Add { get; set; }

        //через property

        public Admin(IAdd a) //через конcтруктор injection
        {
            Add = a;
        }

        public void Adding(IAdd a)//через метод
        {
            Add = a;
            // add.Add();
        }

        public void manage()
        {
            Add.Add();
        }
    }
}