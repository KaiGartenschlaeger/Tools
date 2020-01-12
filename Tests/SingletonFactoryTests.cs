using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class SingletonFactoryTests
    {
        class MyTestClass
        {
            public MyTestClass()
            {
                Counter++;
            }

            public static int Counter { get; private set; }
        }

        [TestMethod]
        public void SingletonFactory_GetInstance()
        {
            MyTestClass tc = SingletonFactory.GetInstance<MyTestClass>();

            Assert.IsNotNull(tc);
            Assert.IsTrue(MyTestClass.Counter == 1);

            MyTestClass tc2 = SingletonFactory.GetInstance<MyTestClass>();

            Assert.IsNotNull(tc2);
            Assert.IsTrue(MyTestClass.Counter == 1);
        }

        [TestMethod]
        public void SingletonFactory_RemoveInstance()
        {
            MyTestClass tc = SingletonFactory.GetInstance<MyTestClass>();

            Assert.IsNotNull(tc);
            Assert.IsTrue(MyTestClass.Counter == 1);

            SingletonFactory.RemoveInstance<MyTestClass>();

            MyTestClass tc2 = SingletonFactory.GetInstance<MyTestClass>();

            Assert.IsNotNull(tc2);
            Assert.IsTrue(MyTestClass.Counter == 2);
        }
    }
}