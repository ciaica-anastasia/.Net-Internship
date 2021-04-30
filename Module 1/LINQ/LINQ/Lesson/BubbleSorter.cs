using System;

namespace LINQ
{
    public static class BubbleSorter
    {
        //generics are better because it is more type-safe
        public static void Sort<T>(T[] values, Func<T, T, bool> comparer)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < values.Length - 1; i++)
                {
                    if (comparer(values[i], values[i + 1]))
                    {
                        T temp = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }

    public delegate bool ObjectComparer(object a, object b);
}