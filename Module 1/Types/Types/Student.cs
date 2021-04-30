using System.Net;

namespace Types
{
    public class Student
    {
        private string name; 
        public string Name
        {
            get => name;
            set => name = value;
        }
        
        public bool Enrolled { get; set; }

        public static int Quantity; //without static constructor will be auto-initialized with 0
        public string Action()
        {
            return "I study ";
        }

        //for initializing static data or performing an action only once, implicit call
        static Student()
        {
            Quantity = 0;
        }

        public Student()
        {
            Quantity += 1;
        }
    }
}