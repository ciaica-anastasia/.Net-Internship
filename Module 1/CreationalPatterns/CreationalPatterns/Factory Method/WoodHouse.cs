using System;

namespace CreationalPatterns.Factory_Method
{
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("A wooden house was built.");
        }
    }
}