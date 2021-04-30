namespace CreationalPatterns.Factory_Method
{
    //builds panel houses
    class PanelBuilder : Builder
    {
        public PanelBuilder(string name) : base(name)
        {
        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }
}