using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>()
            {
                new Book("Les Miserables", "Victor Hugo", 1862),
                new Book("L'Etranger", "Albert Camus", 1942),
                new Book("Madame Bovary", "Gustave Flaubert", 1857),
                new Book("Le Comte de Monte-Cristo", "Alexandre Dumas", 1844),
                new Book("Les Trois Mousquetaires", "Alexandre Dumas", 1844),
                new Book("Candide", "Voltaire", 1759),
                new Book("Notre-Dame de Paris", "Victor Hugo", 1831),
                new Book("Vingt mille lieues sous les mers", "Jules Verne", 1872),
                new Book("Le Tour du monde en quatre-vingts jours", "Jules Verne", 1869),
                new Book("Voyage au centre de la Terre", "Jules Verne", 1864)
            };

            var chooseList = bookList
                .Where(book => book.Author == "Jules Verne")
                .Average(book => book.PubDate);

            var chooseList2 = bookList
                .OrderByDescending(book => book.Title)
                .ThenBy(book => book.Author);
            
            //filtering
            var subList = bookList.Where(p => p.Author == "Jules Verne" || p.Author == "Victor Hugo")
                .OrderBy(p => p.Author)
                .ThenBy(p => p.PubDate) //if put orderby, it will re-sort
                .ToList();

            Console.WriteLine($"{subList.Count()} books match your search criteria:");
            subList.ForEach(p => Console.WriteLine($"   {p.Author} - {p.Title} ({p.PubDate})"));

            var distinctAuthors = bookList.Select(book => book.Author).Distinct().ToList();
            Console.WriteLine("List of distinct authors:");
            distinctAuthors.ForEach(Console.WriteLine);

            var nineteethCenturyBooks = bookList.TakeWhile(book => book.PubDate < 1900).ToList();
            Console.WriteLine("First 19th century books:");
            nineteethCenturyBooks.ForEach(book => Console.WriteLine(book.Title));

            List<string> allProgrammingLanguages = Student.GetStudents().SelectMany(std => std.Programming).ToList();
            Console.WriteLine("All programming languages:");
            allProgrammingLanguages.ForEach(Console.WriteLine);

            var newList = Student.GetStudents()
                .SelectMany(x => x.Programming, (student, s) => new {student.Name, s}).ToList();

            //quantifiers
            bool allResult = bookList.All(u => u.PubDate > 1800); //true
            if (allResult)
                Console.WriteLine("Все книги были изданы позже 1800 года"); 
            else
                Console.WriteLine("Есть книги, изданные раньше 1800 года");
 
            bool anyResult = bookList.Any(u => u.Title.StartsWith("L")); //true
            if (anyResult)
                Console.WriteLine("Есть книги, у которых название начинается с L");
            else
                Console.WriteLine("Отсутствуют книги, у которых имя начинается с L");

            List<Team> teams = new List<Team>()
            {
                new Team {Name = "Бавария", Country = "Германия"},
                new Team {Name = "Барселона", Country = "Испания"}
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name = "Месси", Team = "Барселона"},
                new Player {Name = "Неймар", Team = "Барселона"},
                new Player {Name = "Роббен", Team = "Бавария"}
            };

            //joining
            var result = players.Join(teams,
                p => p.Team,
                t => t.Name,
                (p, t) => new {Name = p.Name, Team = p.Team, Country = t.Country});
            Console.WriteLine("List of players and corresponding teams (countries):");
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

            //groupjoin by team
            var result2 = teams.GroupJoin(players,
                t => t.Name,
                pl => pl.Team,
                (team, pls) => new
                {
                    Name = team.Name,
                    Country = team.Country,
                    Players = pls.Select(p => p.Name)
                });
            foreach (var team in result2)
            {
                Console.WriteLine(team.Name);
                foreach (string player in team.Players)
                {
                    Console.WriteLine(player);
                }

                Console.WriteLine();
            }

            var result3 = players.Zip(teams,
                (player, team) => new
                {
                    Name = player.Name,
                    Team = team.Name, 
                    Country = team.Country
                });
            foreach (var player in result3)
            {
                Console.WriteLine($"{player.Name} - {player.Team} ({player.Country})");

                Console.WriteLine();
            }
            
            //grouping + aggregation method Count
            var groupPlayersByTeams = players.GroupBy(p => p.Team)
                .Select(g => new {Team = g.Key, Count = g.Count()}).ToList();
            groupPlayersByTeams.ForEach(Console.WriteLine);
            
            //set operators
            string[] soft = { "Microsoft", "Google", "Apple"};
            string[] hard = { "Apple", "IBM", "Samsung"};

            var result4 = soft.Except(hard);
            var result5 = soft.Intersect(hard);
            var result6 = soft.Union(hard);
            var result7 = soft.Concat(hard).Distinct(); //same effect as Union, without distinct will include duplicates
            foreach (string s in result4)
                Console.WriteLine(s);
            
            //element operators
            string SoftFirstElement = soft.ElementAt(0);
            string HardFirstElement = hard.First();
            Console.WriteLine(SoftFirstElement);
            Console.WriteLine(HardFirstElement);

            //generation methods
            IEnumerable<int> numberSequence = Enumerable.Range(1, 10);
            foreach (int i in numberSequence)
            {
                Console.WriteLine(i);
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PubDate { get; set; }

        public Book(string title, string author, int pubDate)
        {
            Title = title;
            Author = author;
            PubDate = pubDate;
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }

        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    ID = 1, Name = "James", Email = "James@j.com",
                    Programming = new List<string>() {"C#", "Jave", "C++"}
                },
                new Student()
                {
                    ID = 2, Name = "Sam", Email = "Sara@j.com",
                    Programming = new List<string>() {"WCF", "SQL Server", "C#"}
                },
                new Student()
                {
                    ID = 3, Name = "Patrik", Email = "Patrik@j.com",
                    Programming = new List<string>() {"MVC", "Jave", "LINQ"}
                },
                new Student()
                {
                    ID = 4, Name = "Sara", Email = "Sara@j.com",
                    Programming = new List<string>() {"ADO.NET", "C#", "LINQ"}
                }
            };
        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }

    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}