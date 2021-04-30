namespace StructuralPatterns.Facade
{
    public class Programmer //client
    {
        public void CreateApplication(IDEFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}