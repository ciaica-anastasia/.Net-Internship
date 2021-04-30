using System;

namespace OverloadingAndInterfaces.Angle
{
    public class Program
    {
        static void Main()
        {
            Angle firstAngle = new Angle(3, 36, 53);
            Angle secondAngle = new Angle(4, 27, 45);
            
            Console.WriteLine(firstAngle + secondAngle);
            Console.WriteLine(secondAngle - firstAngle);
            Console.WriteLine(firstAngle * secondAngle);
            Console.WriteLine(firstAngle == secondAngle);
            Console.WriteLine(firstAngle != secondAngle);
            Console.WriteLine(firstAngle > secondAngle);
            Console.WriteLine(firstAngle < secondAngle);
        }
    }
}


