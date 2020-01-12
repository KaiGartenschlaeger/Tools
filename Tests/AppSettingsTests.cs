using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class AppSettingsTests
    {
        [TestMethod]
        public void AppSettings_Boolean()
        {
            bool test1 = AppSettings.ReadBool("test_bool", false);
            Assert.IsTrue(test1);

            bool test2 = AppSettings.ReadBool("invalid_key", true);
            Assert.IsTrue(test2);
        }

        [TestMethod]
        public void AppSettings_Int()
        {
            int test1 = AppSettings.ReadInt("test_int", -1);
            Assert.AreEqual<int>(test1, 120000);

            int test2 = AppSettings.ReadInt("invalid_key", -1);
            Assert.AreEqual<int>(test2, -1);
        }

        [TestMethod]
        public void AppSettings_String()
        {
            string test1 = AppSettings.ReadString("test_string", null);
            Assert.AreEqual<string>(test1, "test 123");

            string test2 = AppSettings.ReadString("test_string", "test 123");
            Assert.AreEqual<string>(test2, "test 123");
        }

        [TestMethod]
        public void AppSettings_HasKey()
        {
            bool test1 = AppSettings.HasKey("test_string");
            Assert.IsTrue(test1);

            bool test2 = AppSettings.HasKey("invalid_key");
            Assert.IsFalse(test2);
        }
    }
}