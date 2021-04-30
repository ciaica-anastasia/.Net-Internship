using System;
using System.Threading;

namespace Types
{
    public static class ThreadExample {
        public static void ThreadProc() {
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(400);
            }
        }
    }
}