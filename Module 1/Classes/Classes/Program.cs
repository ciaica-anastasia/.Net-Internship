using System;

namespace Classes
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            User user = new User()
            {
                //only accessible fields or properties 
                Experience = 10
            };
            Console.WriteLine(user.Experience); //10
            user.Experience = 21;
            Console.WriteLine(user.Experience); //21

            //User.Users = new List<User>();  compile time error because readonly
            User.ListOfUsers.Add(user);
            //User.quantity++;  compile time error because readonly
            Console.WriteLine(User.ListOfUsers.Count);
        }
    }

    
}