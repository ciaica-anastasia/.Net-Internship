using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ArraysStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string padRight;
            ExtraTask.PadRight(inputString, out padRight);
            Console.WriteLine(padRight);
            
            string headline = "introduction";
            string b = headline; 
            var reversedString = ExtraTask.ReverseString(headline); //not string
            var concatString = string.Concat(reversedString); //concat
            foreach (var c in reversedString)
            {
                Console.Write(c);
            } 
            Console.WriteLine();

            string longString = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine(ExtraTask.CountSubstring(longString, "in"));
            
            ExtraTask.CreateArray();
            
            Console.WriteLine(ExtraTask.EqualArrays());

            int sumMain;
            int sumAnti;
            ExtraTask.sumDiagonals(out sumMain, out sumAnti);
            Console.WriteLine(sumMain); //21
            Console.WriteLine(sumAnti); //21
        }

        public static void Strings()
        {
            string intro = "Hello, my name is Anastasia";
            var splittedString = intro.Split(',');
            foreach (var s in splittedString)
            {
                Console.WriteLine(s.Trim());
            }

            var joinedString = string.Join('.', splittedString);
            Console.WriteLine(joinedString);
            
            Console.WriteLine(intro.Length);
            Console.WriteLine(intro.Contains("Anastasia"));

            var insertedString = intro.Insert(18, "Ciaica ");
            Console.WriteLine(insertedString);

            var replacedString = intro.Replace("Anastasia", "Olga");
            Console.WriteLine(replacedString);

            var removedString = insertedString.Remove(18, 7);
            Console.WriteLine(removedString);

            //insert specified characters to the left so that the string has totalwidth
            var padString = insertedString.PadLeft(50, '.');
            Console.WriteLine(padString);

            string greeting1 = "Hello";
            string greeting2 = "hello";
            //relative position in the sort order (0 if equal, <0 if less, >0 if more)
            //returns int
            Console.WriteLine(string.Compare(greeting1, greeting2, StringComparison.InvariantCulture));
            //returns bool
            Console.WriteLine(string.Equals(greeting1, greeting2, StringComparison.InvariantCultureIgnoreCase));

            var formattedString = string.Format("Today is the {0}st day of {1}.", DateTime.UtcNow.DayOfYear,
                DateTime.UtcNow.Year);
            Console.WriteLine(formattedString);

            var concatString = "Today " + "is the day!";
            Console.WriteLine(concatString);
            
            //verbatim string (disable processing escape characters
            var path = @"/Users/Ciaica_Anastasia/Downloads/Screen\ Shot\ 2021-02-23\ at\ 4.35.50\ PM.png";

            var stringBuilder = new StringBuilder(); 
            stringBuilder.Append("Have "); 
            stringBuilder.Append("a wonderful ");
            stringBuilder.AppendLine("Anastasia"); //перенос строки после
            stringBuilder.Append("day!");
            Console.WriteLine(stringBuilder);
        }

        public static void MultiDimension()
        {
            string[,] names = {{"Matt", "Joanne"}, {"Robert", "Karina"}};
            int[,] matrix = new int[3, 4];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = i + j;
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine(matrix.Rank); //number of dimensions = 2
            var cloneMatrix = matrix.Clone();
            
            int[,] copyMatrix = new int[3,3];
            Array.Copy(matrix, copyMatrix, 3);
            for (int i = 0; i < copyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < copyMatrix.GetLength(1); j++)
                {
                    Console.Write(copyMatrix[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();

            Console.WriteLine(matrix.GetLowerBound(0)); //almost always returns zero
            Console.WriteLine(matrix.GetUpperBound(1));
            
            matrix.SetValue(10, 1, 1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine(matrix.GetValue(2, 2));
        }
        
        public static void OneDimension()
        {
            int[] numbers = {3, 5, 9, 2, 3};

            Console.WriteLine(numbers.Length); //5
            Console.WriteLine(Array.BinarySearch(numbers, 9)); //returns index

            int[] copyNumbers = new int[5];
            Array.Copy(numbers, copyNumbers, 4);
            numbers.CopyTo(copyNumbers, 0);
            foreach (var i in copyNumbers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(numbers.GetValue(1)); //5
            Console.WriteLine(Array.IndexOf(numbers, 3)); //0
            Console.WriteLine(Array.LastIndexOf(numbers, 3)); //4

            Array.Reverse(numbers);
            numbers.SetValue(1, 0);
            Array.Sort(numbers);
            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }

        }
    }
}