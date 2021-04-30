namespace StructuralPatterns.Decorator
{
    public class ItalianPizza : Pizza //concrete component
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
}