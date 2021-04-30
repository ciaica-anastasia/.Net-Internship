using System;

namespace BehavioralPatterns.Template_Method
{
    public class Program
    {
        static void Main(string[] args)
        {
            //школа и университет реализуют примерно один и тот же алгоритм
            School school = new School();
            University university = new University();

            school.Learn();
            university.Learn();
        }
    }
}