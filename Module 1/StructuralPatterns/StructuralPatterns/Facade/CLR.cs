using System;

namespace StructuralPatterns.Facade
{
    public class CLR //Common Language Runtime aka virtual machine
    { 
        public void Execute()
        {
            Console.WriteLine("Выполнение приложения");
        }

        public void Finish()
        {
            Console.WriteLine("Завершение работы приложения");
        }
    }
}