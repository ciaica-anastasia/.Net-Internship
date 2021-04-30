using System;
using System.Threading;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            
            //Boxing + Unboxing
            //value types
            bool examPassed = true;
            char letter = 'a';
            int num = 1;

            //is Parse method considered to be unboxing?
            object o = num; //boxing
            int num2 = (int) o; //unboxing

            //reference types
            string lesson = "english";
            Student student = new Student()
            {
                Name = "Susan",
                Enrolled = false
            };
            
            Console.WriteLine(student.Action() + lesson);
            
            
            //Parameter modifiers
            
            //reference types
            //the value will change despite "in" modifier
            EducationProcess.Enrolled(student);
            Console.WriteLine(student.Enrolled); 
            
            //value types
            OwnMath.MultiplyNoModifier(num);
            Console.WriteLine(num); //1
            
            //OwnMath.MultiplyInModifier(in num);
            
            OwnMath.MultiplyRefModifier(ref num); 
            Console.WriteLine(num); //2
            
            int result;
            OwnMath.MultiplyOutModifier(num, out result); 
            Console.WriteLine(result); //4

            Console.WriteLine(Student.Quantity);
            
            
            //Threading
            
            Console.WriteLine("Main thread: Start a second thread.");
            Thread t = new Thread(new ThreadStart(ThreadExample.ThreadProc));
            
            t.Start();
            Thread.Sleep(1); //main thread

            for (int i = 0; i < 20; i++) {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(300);
            }

            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.");
        }
    }
}
