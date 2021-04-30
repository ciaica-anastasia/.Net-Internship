using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamModule1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            a = new B(3);
            a.Method();

            var words = new List<string> {"abc", "abcde", "acbdef", "abcdefg"};
            bool tmpValue = words.Any(x => x.Contains("cb"));
            Console.WriteLine(tmpValue);
            
            try
            {
                Console.WriteLine("TRY");
                throw new Exception("EXCEPTION");
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH");
            }
        }

        public class A
        {
            static A()
            {
                Console.WriteLine("Static A. ");
            }

            public A()
            {
                Console.WriteLine("A. ");
            }

            public A(int m)
            {
                Console.WriteLine("Am. ");
            }

            public virtual void Method()
            {
                Console.WriteLine("Method A. ");
            }
        }

        public class B : A
        {
            static B()
            {
                Console.WriteLine("Static B. ");
            }

            public B()
            {
                Console.WriteLine("B. ");
            }

            public B(int m)
            {
                Console.WriteLine("Bm. ");
            }

            public override void Method()
            {
                Console.WriteLine("Method B. ");
                base.Method();
            }
        }
    }
}