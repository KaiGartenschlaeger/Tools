using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Async;

namespace Tests
{
    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        public void AsyncTest_AsyncCall()
        {
            AsyncProcess process = new AsyncProcess();

            process.ProcessStarted += delegate(object sender, AsyncProcessStartedEventArgs e)
            {
                Assert.AreEqual(e.User, "Test 123");

                e.Result = true;
            };

            process.ProcessFinished += delegate(object sender, AsyncProcessFinishedEventArgs e)
            {
                Assert.AreEqual(e.Canceled, false);
                Assert.AreEqual(e.Error, null);
                Assert.AreEqual(e.Result, true);
            };

            process.Start("Test 123");
        }
    }
}