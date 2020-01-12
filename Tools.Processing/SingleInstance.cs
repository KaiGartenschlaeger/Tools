using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace Tools.Processing
{
    public abstract class SingleInstance
    {
        #region Fields

        private string m_guid;

        #endregion

        #region Constructor

        public SingleInstance(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                throw new ArgumentNullException("guid");
            }

            m_guid = guid;
        }

        #endregion

        #region Methods

        private void Connected(IAsyncResult result)
        {
            NamedPipeServerStream stream = (NamedPipeServerStream)result.AsyncState;

            stream.EndWaitForConnection(result);
            try
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    string[] args = new string[reader.ReadInt32()];
                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = reader.ReadString();
                    }

                    RaiseStarting(false, args);
                }
            }
            catch (IOException)
            {
            }

            WaitForNewClient();
        }

        private void WaitForNewClient()
        {
            NamedPipeServerStream stream = new NamedPipeServerStream(m_guid,
                PipeDirection.In, 10, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            stream.BeginWaitForConnection(new AsyncCallback(Connected), stream);
        }

        private void FirstInstance(string[] args)
        {
            WaitForNewClient();
            RaiseStarting(true, args);
        }

        private void SecondInstance(string[] args)
        {
            NamedPipeClientStream stream = new NamedPipeClientStream(".", m_guid, PipeDirection.Out);

            try
            {
                stream.Connect(1000);

                using (MemoryStream mem = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(mem, Encoding.UTF8))
                    {
                        writer.Write(args.Length);
                        foreach (string argument in args)
                        {
                            writer.Write(argument);
                        }
                    }

                    byte[] data = mem.ToArray();
                    stream.Write(data, 0, data.Length);
                }

                stream.Close();
            }
            catch (IOException)
            {
            }
        }

        private void RaiseStarting(bool isFirstInstance, string[] arguments)
        {
            if (Starting != null)
            {
                Starting(this, new StartingEventArgs(isFirstInstance, arguments));
            }

            OnStarting(new StartingArguments(isFirstInstance, arguments));
        }

        public void Run(string[] args)
        {
            bool createdNew;

            Mutex mutex = new Mutex(true, m_guid, out createdNew);
            if (createdNew)
            {
                FirstInstance(args);
            }
            else
            {
                SecondInstance(args);
            }
        }

        #endregion

        #region SingleInstance events

        public virtual void OnStarting(StartingArguments e)
        {
        }

        public event EventHandler<StartingEventArgs> Starting;

        #endregion
    }
}