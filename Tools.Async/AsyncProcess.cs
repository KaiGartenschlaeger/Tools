using System;

namespace Tools.Async
{
    /// <summary>
    /// Stellt einen asynchronen Vorgang dar.
    /// </summary>
    public class AsyncProcess
    {
        #region Fields

        private delegate ProcessWorkerResult ProcessDelegate(object user);

        #endregion

        #region Process methods

        private ProcessWorkerResult ProcessWorker(object user)
        {
            ProcessWorkerResult result = new ProcessWorkerResult();
            result.Canceled = false;
            result.Error = null;

            try
            {
                if (ProcessStarted != null)
                {
                    AsyncProcessStartedEventArgs arguments = new AsyncProcessStartedEventArgs();
                    arguments.User = user;

                    ProcessStarted(this, arguments);

                    result.Canceled = arguments.Cancel;
                    result.Result = arguments.Result;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }

        private void ProcessCallback(IAsyncResult ar)
        {
            ProcessDelegate del = (ProcessDelegate)ar.AsyncState;

            ProcessWorkerResult result = del.EndInvoke(ar);

            if (ProcessFinished != null)
            {
                ProcessFinished(this, new AsyncProcessFinishedEventArgs()
                {
                    Canceled = result.Canceled,
                    Error = result.Error,
                    Result = result.Result
                });
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Started den asynchronen Vorgang.
        /// </summary>
        public void Start()
        {
            Start(null);
        }

        /// <summary>
        /// Started den asynchronen Vorgang.
        /// </summary>
        /// <param name="user">Benutzerdefinierter Wert, der an den Vorgang übergeben wird.</param>
        public void Start(object user)
        {
            ProcessDelegate process = new ProcessDelegate(ProcessWorker);
            process.BeginInvoke(user, new AsyncCallback(ProcessCallback), process);
        }

        #endregion

        #region Events

        /// <summary>
        /// Wird aufgerufen wenn der asynchrone Vorgang ausgeführt wird.
        /// </summary>
        public event EventHandler<AsyncProcessStartedEventArgs> ProcessStarted;

        /// <summary>
        /// Wird aufgerufen wenn der asynchrone Vorgang beendet wurde.
        /// </summary>
        public event EventHandler<AsyncProcessFinishedEventArgs> ProcessFinished;

        #endregion
    }
}