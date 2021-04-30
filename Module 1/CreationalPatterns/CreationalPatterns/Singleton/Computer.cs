using CreationalPatterns.Singleton;

namespace Singleton
{
    public class Computer
    {
        public OsLock OS { get; set; } //there could be just one operating system on a computer
        public void Start(string osName) //launch the operating system
        {
            OS = OsLock.GetInstance(osName);
        }
    }
}