namespace ToolsSharp.Tests
{
    [TestClass]
    public class ListHelperTests
    {
        #region Shuffle

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { -732, 1024, 6, 12141, 2141532523, 1, 63 })]
        public void Can_Shuffle_Int(int[] data)
        {
            // ARRANGE
            int[] shuffledData = new int[data.Length];
            Array.Copy(data, shuffledData, data.Length);

            // ACT
            shuffledData.Shuffle();

            // ASSERT
            Assert.AreEqual(data.Length, shuffledData.Length);
            int equals = 0;
            for (int i = 0; i < data.Length; i++)
                if (shuffledData[i] == data[i])
                    equals++;
            Assert.AreNotEqual(data.Length, equals);
        }

        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { -732 })]
        public void Can_Shuffle_DoesNothingOnSingleItem(int[] data)
        {
            // ARRANGE
            int[] shuffledData = new int[data.Length];
            Array.Copy(data, shuffledData, data.Length);

            // ACT
            shuffledData.Shuffle();

            // ASSERT
            Assert.AreEqual(data.Length, shuffledData.Length);
            int equals = 0;
            for (int i = 0; i < data.Length; i++)
                if (shuffledData[i] == data[i])
                    equals++;
            Assert.AreEqual(data.Length, equals);
        }

        [TestMethod]
        [DataRow(new int[] { })]
        public void Can_Shuffle_DoesNothingOnNoItem(int[] data)
        {
            // ARRANGE
            int[] shuffledData = new int[data.Length];
            Array.Copy(data, shuffledData, data.Length);

            // ACT
            shuffledData.Shuffle();

            // ASSERT
            Assert.AreEqual(data.Length, 0);
            Assert.AreEqual(shuffledData.Length, 0);
        }

        #endregion Shuffle
    }
}