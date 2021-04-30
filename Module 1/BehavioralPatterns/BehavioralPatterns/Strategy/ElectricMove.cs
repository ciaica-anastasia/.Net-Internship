using System;

namespace BehavioralPatterns.Strategy
{
    public class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
}