using System;

namespace Tools.Processing
{
    public class StartingEventArgs : EventArgs
    {
        internal StartingEventArgs(bool isFirstInstance, string[] arguments)
        {
            IsFirstInstance = isFirstInstance;
            Arguments = arguments;
        }

        public bool IsFirstInstance { get; internal set; }
        public string[] Arguments { get; internal set; }
    }
}