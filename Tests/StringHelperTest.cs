using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void StringHelper_ParseInt()
        {
            Assert.AreEqual(StringHelper.ParseInt("120", -1), 120);
            Assert.AreEqual(StringHelper.ParseInt("-10", -1), -10);
            Assert.AreEqual(StringHelper.ParseInt("22000", -1), 22000);
            Assert.AreEqual(StringHelper.ParseInt("abc", -1), -1);
        }

        [TestMethod]
        public void StringHelper_ParseIntNullable()
        {
            Assert.IsNull(StringHelper.ParseInt("100a"));
            Assert.IsNotNull(StringHelper.ParseInt("100"));
        }

        [TestMethod]
        public void StringHelper_ParseFloat()
        {
            Assert.AreEqual(StringHelper.ParseFloat("12.225", -1), 12.225f);
            Assert.AreEqual(StringHelper.ParseFloat("1.50", -1), 1.50);
            Assert.AreEqual(StringHelper.ParseFloat("-120", -1), -120);
            Assert.AreEqual(StringHelper.ParseFloat("abc", -1), -1);
        }
    }
}