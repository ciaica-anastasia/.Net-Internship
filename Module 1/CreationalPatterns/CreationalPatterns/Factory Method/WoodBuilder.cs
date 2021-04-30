namespace CreationalPatterns.Factory_Method
{
    //builds wooden houses
    class WoodBuilder : Builder
    {
        public WoodBuilder(string name) : base(name)
        {
        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }
}