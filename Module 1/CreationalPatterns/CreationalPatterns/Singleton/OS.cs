namespace CreationalPatterns.Singleton
{
    public class OS //simple implementation, not thread-safe
    {
        private static OS _instance;

        public string Name { get; private set; }

        private OS(string name)
        {
            Name = name;
        }

        public static OS GetInstance(string name)
        {
            return _instance ?? (_instance = new OS(name));
        }
    }
}