using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Helper;

namespace Tests
{
    [TestClass]
    public class ArrayHelperTests
    {
        [TestMethod]
        public void ArrayHelper_IncrementArray()
        {
            int[] arr = { 0, 3, 1 };

            ArrayHelper.IncrementArray(ref arr, 5);
            Assert.IsTrue(arr[0] == 0 && arr[1] == 3 && arr[2] == 2);

            ArrayHelper.IncrementArray(ref arr, 5);
            Assert.IsTrue(arr[0] == 0 && arr[1] == 3 && arr[2] == 3);

            ArrayHelper.IncrementArray(ref arr, 5);
            Assert.IsTrue(arr[0] == 0 && arr[1] == 3 && arr[2] == 4);

            ArrayHelper.IncrementArray(ref arr, 5);
            Assert.IsTrue(arr[0] == 0 && arr[1] == 3 && arr[2] == 5);

            ArrayHelper.IncrementArray(ref arr, 5);
            Assert.IsTrue(arr[0] == 0 && arr[1] == 4 && arr[2] == 0);
        }

        [TestMethod]
        public void ArrayHelper_Sum()
        {
            Assert.AreEqual(ArrayHelper.Sum(new int[] { 5, 0, 2 }), 7);
            Assert.AreEqual(ArrayHelper.Sum(new int[] { 15, -2, 10 }), 23);
            Assert.AreEqual(ArrayHelper.Sum(new int[] { 8, 2, 0 }), 10);
        }
    }
}