using System;

namespace CreationalPatterns.Singleton
{
    public class OsLock
    {
        private static OsLock _instance;
 
        public string Name { get; private set; }
        private static readonly object Padlock = new object();
        
        //static constructor is thread-safe, but it can take too much time
 
        private OsLock(string name)
        {
            Name = name;
        }
 
        public static OsLock GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (Padlock)
                {
                    if (_instance == null)
                        _instance = new OsLock(name);
                }
            }
            return _instance;
        }
    }
}