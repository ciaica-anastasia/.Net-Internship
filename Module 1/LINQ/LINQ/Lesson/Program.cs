// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace LINQ
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var users = new List<User>
//             {
//                 new User {Age = 10, Name = "Alex"},
//                 new User {Age = 16, Name = "Peter"},
//                 new User {Age = 11, Name = "Maria"}
//             };
//
//             var youngUsers = users
//                 .Where(user => user.Age < 12)
//                 .Where(user => user.Name.First() == 'A')
//                 .ToList();
//
//
//             var userArray = users.ToArray();
//
//             var str1 = "What";
//             string str2 = null;
//
//             //extension method
//             var shortcut = str1.GetShortcut();
//             //var shortcut2 = StringExtensions.GetShortcut(str2);
//             var shortcut3 = str2.GetShortcut();
//             var shortcut4 = str2.Length;
//
//             //BubbleSorter.Sort(userArray, new ObjectComparer(Compare));
//
//             BubbleSorter.Sort<object>(userArray, Compare);
//             //anonymous method
//             BubbleSorter.Sort(userArray, delegate(object a, object b) { return ((User) a).Age > ((User) b).Age; });
//
//             BubbleSorter.Sort(userArray, (a, b) => ((User) a).Age > ((User) b).Age);
//
//             BubbleSorter.Sort(userArray, (a, b) => ((User) a).Age > ((User) b).Age);
//
//             BubbleSorter.Sort(new int[] {1, 2, 3}, (a, b) => a > b);
//
//             BubbleSorter.Sort(userArray, (user, user1) => user.Age > user1.Age);
//
//             var userDtos = users.Select(u =>
//             {
//                 Console.WriteLine(u.Name);
//                 return new {Name = u.Name, Age = u.Age};
//             });
//
//             userDtos.ToList();
//         }
//
//         public static bool Compare(object a, object b)
//         {
//             var firstUser = (User) a;
//             var secondUser = (User) b;
//             return firstUser.Age > secondUser.Age;
//         }
//     }
//
//     public class User
//     {
//         public int Age { get; set; }
//         public string Name { get; set; }
//     }
//
//     public class AnotherUser : User
//     {
//         void Method()
//         {
//             this.Age = 20;
//         }
//     }
// }