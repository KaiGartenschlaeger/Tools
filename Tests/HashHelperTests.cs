using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class HashHelperTests
    {
        [TestMethod]
        public void HashHelper_ToMD5()
        {
            Assert.AreEqual(HashHelper.ToMD5("1234"), "81dc9bdb52d04dc20036dbd8313ed055");
            Assert.AreEqual(HashHelper.ToMD5("carlchen"), "382868387f54224b30203131f53b2609");
            Assert.AreEqual(HashHelper.ToMD5(" "), "7215ee9c7d9dc229d2921a40e899ec5f");
        }

        [TestMethod]
        public void HashHelper_ToCRC32()
        {
            Assert.AreEqual(HashHelper.ToCRC32("1234"), "9be3e0a3");
            Assert.AreEqual(HashHelper.ToCRC32("carlchen"), "d178182e");
            Assert.AreEqual(HashHelper.ToCRC32(" "), "e96ccf45");
        }
    }
}