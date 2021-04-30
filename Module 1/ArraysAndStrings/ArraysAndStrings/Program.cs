using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringValue = "I learn C# at \"Amdaris\". And we are very happy";
            //Console.WriteLine(stringValue[2]);

            var splittedArray = stringValue.Split('.');

            var joinedString = string.Join(',', splittedArray);
            
            Console.WriteLine(joinedString);

            string newString = null; //создается копия несмотря на reference type

            //stringValue = "new string";
            
            //Console.WriteLine(stringValue); //разные значения
            //Console.WriteLine(newString);
            
            foreach (var i in splittedArray)
            {
                //Console.WriteLine(i.Trim()); //убирает пробелы          
            }

            var index = stringValue.IndexOf("C#");
            //Console.WriteLine(index);

            var substring = stringValue.Substring(8, 2);
            //Console.WriteLine(substring);

            var reversedString = stringValue.Reverse();
            foreach (var c in reversedString)
            {
                //Console.Write(c);
            }
            //verbatim strings
            var path = @"/Users/Ciaica_Anastasia/Downloads/Screen\ Shot\ 2021-02-23\ at\ 4.35.50\ PM.png";

            var formattedString = string.Format("Hello today is {0}", DateTime.UtcNow);

            var stringValue2 = "Wednesday";
            var interpolatedString = $"Hello today is {DateTime.UtcNow} and week day is {stringValue2}";
            //Console.WriteLine(interpolatedString);

            var firstString = "Hello";
            var secondString = "hello";
            
            Console.WriteLine(firstString.Equals(secondString, StringComparison.InvariantCultureIgnoreCase));

            var culture = CultureInfo.GetCultureInfo("tr-Tr"); //different culture
            var str = "i";
            
            Console.WriteLine(str.ToUpper(culture) == "I"); //false
            
            Console.WriteLine(str.ToUpper(culture)); //İ

            //stringValue = null;
            Console.WriteLine(stringValue.ToUpperInvariant()); //possible NullReferenceExcpetion

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Amdaris");
            stringBuilder.AppendLine("Amdaris"); //puts a new line after 
            stringBuilder.Append("Amdaris");

            string strValue = stringBuilder.ToString();

            var testClass = new TestClass();
            Console.WriteLine(testClass);
        }
        
        public static void ArrayMethods()
        {
            int[] intArray = {1, 9, 4, 6, 3, 7}; //default value is zero
            string[] stringArray = new string[] {"A", "B", "C"};
            bool[] boolArray = {true, false, true};

            int[] secondIntArray = new int[10];

            //static methods
            //Array.Sort(intArray); //возрастающий порядок

            int[] copyArray = new int[4];
            Array.Copy(intArray, copyArray, copyArray.Length);
            
            foreach (var i in copyArray)
            {
                //Console.WriteLine(i);
            }
            
            //intArray.CopyTo(copyArray, 0); //destination array is not long enough

            var index = Array.IndexOf(intArray, 6); //если такого value нет, то -1
            //Console.WriteLine(index);

            Array.Reverse(intArray); //в обратном порядке
            
            //extension methods

            foreach (var i in intArray)
            {
                //Console.WriteLine(i);
            }
            
            var reversed = intArray.Reverse();
            foreach (var i in reversed)
            {
                //Console.WriteLine(i);
            } 

            secondIntArray[3] = 50;

            foreach (var s in secondIntArray)
            {
                //Console.WriteLine(s);
            }
            
            //Console.WriteLine(stringArray[0]); //zero-based

            for (int i = 0; i < stringArray.Length; i++)
            {
                //Console.WriteLine(stringArray[i]);
            }

            int[,] matrix = new int[2, 2]; //multi-dimensional array == matrix
            int[,] matrix2 = new int[,] {{1, 1}, {2, 2}};
            int[,] matrix3 = {{1, 1}, {2, 3}};
            
            //Console.WriteLine(matrix3[1,1]);

            var matrixLength = matrix3.Length; //quantity of all elements in array
            //Console.WriteLine(matrixLength);
            
            // Console.WriteLine(matrix3.GetLength(0));
            // Console.WriteLine(matrix3.GetLength(1));
            //
            // Console.WriteLine();

            for (int i = 0; i < matrix3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3.GetLength(1); j++)
                {
                    //Console.WriteLine(matrix3[i, j]);
                }
            }

            int[][] jaggedArray = {new []{1, 2}, new []{1, 2, 3}}; //jagged array
        }
    }
}
