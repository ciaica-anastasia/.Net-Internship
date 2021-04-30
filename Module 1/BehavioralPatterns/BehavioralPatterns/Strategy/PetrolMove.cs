using System;

namespace BehavioralPatterns.Strategy
{
    public class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }
}