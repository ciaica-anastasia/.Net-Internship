namespace BehavioralPatterns.Strategy
{
    public class Program
    {
        static void Main(string[] args)
        {
            //существуют машины с различными источниками энергии 
            //благодаря стратегии можем менять источник энергии
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }
}