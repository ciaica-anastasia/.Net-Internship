using System;

namespace CreationalPatterns.Factory_Method
{
    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("A panel house was built.");
        }
    }
}