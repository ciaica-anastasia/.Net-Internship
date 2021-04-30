using System;
using SOLID.LSP;

namespace SOLID
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            //SRP
            
            string studentId = " ";
            string classId = " ";
            StudentEligibility student1 = new Student(); //вместо Student может быть другой класс, который имплементирует нужный интерфейс
            student1.IsEligibleToEnroll(studentId, classId); //закрываю доступ к другим методам класса Student
            
            
            //LSP
            User admin = new Admin();
            User student = new LSP.Student();

            admin.EditCourse();
            student.EditCourse();
        }
    }
}