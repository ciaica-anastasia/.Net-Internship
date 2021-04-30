using System;
using System.Diagnostics;

namespace ExceptionsDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            #region try-catch-finally block

            Console.Write("Please enter a number to divide 100: ");
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
                int result = 100 / num;
                //conditional breakpoint
                Console.WriteLine("100 / {0} = {1}", num, result);
            }
            catch (DivideByZeroException ex)
            {
                Console.Write("Cannot divide by zero. Please try again.");
                throw; //will show the line where the exception really occurred
            }
            catch (InvalidOperationException ex)
            {
                Console.Write("Invalid operation. Please try again.");
            }
            catch (FormatException ex)
            {
                Console.Write("Not a valid format. Please try again.");
                throw ex; //will change the stack information and will show line 30, not 15 
            }
            catch (Exception ex)
            {
                Console.Write("Error occurred! Please try again.");
            }
            finally
            {
                Console.WriteLine("The 'try catch' is finished.");
            }
            #endregion

            #region Custom exception

            try
            {               
                var newStudent = new Student();
                newStudent.StudentName = "James007";
                //Debug Output Window
                Debug.WriteLine("The StudentName is " + newStudent.StudentName); //in release configuration will be skipped
            
                Student.ValidateStudent(newStudent);
            }
            catch(InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message );
                throw new Exception("message", ex); //adds new info to the exception
            }

            #endregion
            
            //conditional compilation symbols
#if DEBUG
    Console.WriteLine("Debug version");
#endif
            //when clause
            try
            {
                throw new Exception("ErrorType1");
            }
            catch (Exception ex) when (ex.Message == "ErrorType1")
            {
                Console.WriteLine("Error Message : " + ex);
            }
            catch (Exception ex) when (ex.Message == "ErrorType2")
            {
                Console.WriteLine("Error Message : " + ex);
            }
            
        }
    }
}