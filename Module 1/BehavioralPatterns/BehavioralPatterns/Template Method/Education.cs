using System;

namespace BehavioralPatterns.Template_Method
{
    public abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }

        public abstract void Enter();
        public abstract void Study();

        public virtual void PassExams() //реализация по умолчанию
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }

        public abstract void GetDocument();
    }
}