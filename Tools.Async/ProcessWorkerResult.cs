using System;

namespace Tools.Async
{
    internal class ProcessWorkerResult
    {
        public object Result { get; set; }
        public bool Canceled { get; set; }
        public Exception Error { get; set; }
    }
}