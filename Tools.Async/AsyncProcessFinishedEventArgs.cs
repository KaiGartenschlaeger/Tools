using System;

namespace Tools.Async
{
    public class AsyncProcessFinishedEventArgs : EventArgs
    {
        public object Result { get; internal set; }
        public bool Canceled { get; internal set; }
        public Exception Error { get; internal set; }
    }
}