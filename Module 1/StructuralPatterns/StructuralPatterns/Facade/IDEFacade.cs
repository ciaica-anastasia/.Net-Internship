namespace StructuralPatterns.Facade
{
    public class IDEFacade //facade delegates the execution of work to the components and its methods
    {
        TextEditor textEditor;
        Compiler compiller;
        CLR clr;
        public IDEFacade(TextEditor te, Compiler compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }
}