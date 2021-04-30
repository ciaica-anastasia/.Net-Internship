namespace Classes
{
    public class OwnMath
    {
        protected virtual int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        protected string Sum(string string1, string string2)
        {
            return string1 + string2;
        }

        protected double Sum(double num1, int num2, double num3)
        {
            return num1 + num2 + num3;
        }
    }

    public class MyMath : OwnMath
    {
        protected override int Sum(int num1, int num2)
        {
            return (num1 + num2) / 2;
        }
    }
}