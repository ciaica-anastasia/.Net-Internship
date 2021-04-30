using System;
using System.Threading;
using CreationalPatterns.Singleton;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Start("macOS Big Sur");
            Console.WriteLine(comp.OS.Name);
            
            //we can't change OS, because the object has been already created   
            comp.OS = OS.GetInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);
            
            //Before: macOS Big Sur, Windows 10
            
            (new Thread(() =>
            {
                Computer comp2 = new Computer();
                comp2.OS = OsLock.GetInstance("Windows 10");
                Console.WriteLine(comp2.OS.Name);
 
            })).Start();
 
            Computer comp = new Computer();
            comp.Start("macOS Big Sur");
            Console.WriteLine(comp.OS.Name);
            
            //After: macOS Big Sur, macOS Big Sur
        }
    }
}