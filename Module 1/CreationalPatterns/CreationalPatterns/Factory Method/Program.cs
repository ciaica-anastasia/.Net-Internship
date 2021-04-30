namespace CreationalPatterns.Factory_Method
{
    public class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new PanelBuilder("Exfactor Grup SRL");
            House house2 = builder.Create();

            builder = new WoodBuilder("Dansicons SRL");
            House house = builder.Create();
        }
    }
}