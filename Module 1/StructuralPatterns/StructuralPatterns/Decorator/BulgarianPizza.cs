namespace StructuralPatterns.Decorator
{
    public class BulgarianPizza : Pizza //concrete component
    {
        public BulgarianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }
}