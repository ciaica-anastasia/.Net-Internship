namespace CreationalPatterns.Factory_Method
{
    //abstract class for a house builder company
    abstract class Builder
    {
        private string Name { get; set; }

        protected Builder(string name)
        {
            Name = name;
        }

        // Factory method
        public abstract House Create();
    }
}