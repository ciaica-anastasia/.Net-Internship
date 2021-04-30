using System;
using System.Collections;
using System.Linq;

namespace ArraysStrings
{
    public class ExtraTask
    {
        public static IEnumerable ReverseString(string headline)
        {
            return headline.Reverse();
        }

        public static string PadRight(string inputString, out string padString)
        {
            padString = inputString.Length < 20 ? inputString.PadRight(20, '*') : inputString; //no need to check

            return padString;
        }

        public static int CountSubstring(string longString, string pattern)
        { 
            int quantity = 0;
            int i = 0;
            while ((i = longString.IndexOf(pattern, i, StringComparison.InvariantCultureIgnoreCase)) != -1)
            {
                i += pattern.Length;
                quantity++;
            }
            return quantity;
        }

        public static void CreateArray()
        {
            int[] intArray = new int[20];
            Console.WriteLine(intArray[2]); //default value
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i * 5;
                Console.WriteLine(intArray[i]);
            }
        }

        public static bool EqualArrays()
        {
            int firstLength = Convert.ToInt32(Console.ReadLine());
            int secondLength = Convert.ToInt32(Console.ReadLine());

            if (firstLength != secondLength)
            {
                return false;
            }
            
            int[] firstArray = new int[firstLength];
            int[] secondArray = new int[secondLength];

            for (int i = 0; i < firstLength; i++)
            {
                firstArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            for (int i = 0; i < secondLength; i++)
            {
                secondArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < firstLength; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void sumDiagonals(out int sumMain, out int sumAnti)
        {
            int[,] bidimensional =
            {
                {1, 2, 3, 4, 5, 6}, {1, 2, 3, 4, 5, 6}, {1, 2, 3, 4, 5, 6}, {1, 2, 3, 4, 5, 6},
                {1, 2, 3, 4, 5, 6}, {1, 2, 3, 4, 5, 6}, {1, 2, 3, 4, 5, 6}
            };
            sumMain = 0;
            sumAnti = 0;
            int i = 0;
            int j = bidimensional.GetUpperBound(0);
            while (i < bidimensional.GetLength(0))
            {
                sumMain += bidimensional[i, i];
                sumAnti += bidimensional[i, j];
                i++;
                j--;
            }
        }
    }
}