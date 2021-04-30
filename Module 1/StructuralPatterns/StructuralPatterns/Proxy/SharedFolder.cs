using System;

namespace StructuralPatterns
{
    public class SharedFolder : ISharedFolder
    {
        public void PerformRwOperations()
        {
            Console.WriteLine("Performing Read Write operation on the Shared Folder");
        }
    }
}