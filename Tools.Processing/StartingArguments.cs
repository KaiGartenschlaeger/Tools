namespace Tools.Processing
{
    public class StartingArguments
    {
        internal StartingArguments(bool isFirstInstance, string[] arguments)
        {
            IsFirstInstance = isFirstInstance;
            Arguments = arguments;
        }

        public bool IsFirstInstance { get; internal set; }
        public string[] Arguments { get; internal set; }
    }
}