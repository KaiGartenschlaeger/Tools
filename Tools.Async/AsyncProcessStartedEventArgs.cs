using System;

namespace Tools.Async
{
    public class AsyncProcessStartedEventArgs : EventArgs
    {
        public object User { get; internal set; }
        public bool Cancel { get; set; }
        public object Result { get; set; }
    }
}