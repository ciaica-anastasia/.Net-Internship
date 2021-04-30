using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Homework
{
    public static class ListExtensions
    {
        public static T GetFirstElement<T>(this List<T> collectionOfObjects)
        {
            return collectionOfObjects[0];
        }
    }
}