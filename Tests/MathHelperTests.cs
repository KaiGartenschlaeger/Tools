using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class MathHelperTests
    {
        [TestMethod]
        public void MathHelper_ClampI()
        {
            Assert.AreEqual(MathHelper.Clamp(10, 1, 8), 8);
            Assert.AreEqual(MathHelper.Clamp(100, 1, 12), 12);
            Assert.AreEqual(MathHelper.Clamp(2, 3, 10), 3);
        }

        [TestMethod]
        public void MathHelper_ClampF()
        {
            Assert.AreEqual(MathHelper.Clamp(10, 1, (float)8), 8);
            Assert.AreEqual(MathHelper.Clamp(100, 1, (float)12), 12);
            Assert.AreEqual(MathHelper.Clamp(2, 3, (float)10), 3);
        }

        [TestMethod]
        public void MathHelper_ClampD()
        {
            Assert.AreEqual(MathHelper.Clamp(10, 1, (double)8), 8);
            Assert.AreEqual(MathHelper.Clamp(100, 1, (double)12), 12);
            Assert.AreEqual(MathHelper.Clamp(2, 3, (double)10), 3);
        }

        [TestMethod]
        public void MathHelper_MinI()
        {
            Assert.AreEqual(MathHelper.Min(10, 12), 10);
            Assert.AreEqual(MathHelper.Min(15, 10), 10);
            Assert.AreEqual(MathHelper.Min(2, 8), 2);
        }

        [TestMethod]
        public void MathHelper_MaxI()
        {
            Assert.AreEqual(MathHelper.Max(10, 20), 20);
            Assert.AreEqual(MathHelper.Max(15, 10), 15);
            Assert.AreEqual(MathHelper.Max(-2, 10), 10);
        }

        [TestMethod]
        public void MathHelper_MinF()
        {
            Assert.AreEqual(MathHelper.Min(10, (float)12), 10);
            Assert.AreEqual(MathHelper.Min(15, (float)10), 10);
            Assert.AreEqual(MathHelper.Min(2, (float)8), 2);
        }

        [TestMethod]
        public void MathHelper_MaxF()
        {
            Assert.AreEqual(MathHelper.Max(10, (float)20), 20);
            Assert.AreEqual(MathHelper.Max(15, (float)10), 15);
            Assert.AreEqual(MathHelper.Max(-2, (float)10), 10);
        }

        [TestMethod]
        public void MathHelper_MinD()
        {
            Assert.AreEqual(MathHelper.Min(10, (double)12), 10);
            Assert.AreEqual(MathHelper.Min(15, (double)10), 10);
            Assert.AreEqual(MathHelper.Min(2, (double)8), 2);
        }

        [TestMethod]
        public void MathHelper_MaxD()
        {
            Assert.AreEqual(MathHelper.Max(10, (double)20), 20);
            Assert.AreEqual(MathHelper.Max(15, (double)10), 15);
            Assert.AreEqual(MathHelper.Max(-2, (double)10), 10);
        }

        [TestMethod]
        public void MathHelper_FindCombinations()
        {
            int[][] combinations = MathHelper.FindCombinations(3, 2);

            Assert.IsTrue(combinations.Length == 6);

            Assert.IsTrue(combinations[0][0] == 0 && combinations[0][1] == 0 && combinations[0][2] == 2); // 0 0 2
            Assert.IsTrue(combinations[1][0] == 0 && combinations[1][1] == 1 && combinations[1][2] == 1); // 0 1 1
            Assert.IsTrue(combinations[2][0] == 0 && combinations[2][1] == 2 && combinations[2][2] == 0); // 0 2 0
            Assert.IsTrue(combinations[3][0] == 1 && combinations[3][1] == 0 && combinations[3][2] == 1); // 1 0 1
            Assert.IsTrue(combinations[4][0] == 1 && combinations[4][1] == 1 && combinations[4][2] == 0); // 1 1 0
            Assert.IsTrue(combinations[5][0] == 2 && combinations[5][1] == 0 && combinations[5][2] == 0); // 2 0 0
        }
    }
}