using System;

namespace Types
{
    public class OwnMath
    {
        public static void MultiplyNoModifier(int num)
        {
            num = num * 2;
        }

        public static void MultiplyInModifier(in int num)
        {
            //error [CS8331] readonly variable
            //num *= 2; 
        }
        
        public static void MultiplyRefModifier(ref int num)
        {
            num *= 2;
        }
        
        public static void MultiplyOutModifier(in int num, out int result)
        {
            result = num * 2;
        }
    }
}