namespace StructuralPatterns.Decorator
{
    public abstract class Pizza //component
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name {get; protected set;}
        public abstract int GetCost();
    }
}