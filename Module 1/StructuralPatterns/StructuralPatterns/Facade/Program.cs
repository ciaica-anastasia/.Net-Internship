namespace StructuralPatterns.Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            Compiler compiller = new Compiler();
            CLR clr = new CLR();

            IDEFacade ide = new IDEFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);
        }
    }
}