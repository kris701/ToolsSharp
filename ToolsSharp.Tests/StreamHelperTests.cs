namespace ToolsSharp.Tests
{
    [TestClass]
    public class StreamHelperTests
    {
        #region StreamToString, Stream

        [TestMethod]
        [DataRow("abccda")]
        [DataRow("a   sfe  2154   a")]
        [DataRow("")]
        public void Can_StreamToString(string data)
        {
            // ARRANGE
            Stream str = new MemoryStream();
            StreamWriter writer = new StreamWriter(str);
            writer.Write(data);
            writer.Flush();
            str.Position = 0;

            // ACT
            var result = StreamHelper.StreamToString(str);

            // ASSERT
            Assert.AreEqual(data, result);

            writer.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cant_StreamToString_IfStreamClosed()
        {
            // ARRANGE
            Stream str = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(str))
                writer.Write("abc");

            // ACT
            StreamHelper.StreamToString(str);
        }

        #endregion StreamToString, Stream

        #region StreamToString, MemoryStream

        [TestMethod]
        [DataRow("abccda")]
        [DataRow("a   sfe  2154   a")]
        [DataRow("")]
        public void Can_StreamToString_MemoryStream(string data)
        {
            // ARRANGE
            MemoryStream str = new MemoryStream();
            StreamWriter writer = new StreamWriter(str);
            writer.Write(data);
            writer.Flush();
            str.Position = 0;

            // ACT
            var result = StreamHelper.StreamToString(str);

            // ASSERT
            Assert.AreEqual(data, result);

            writer.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Cant_StreamToString_MemoryStream_IfStreamClosed()
        {
            // ARRANGE
            MemoryStream str = new MemoryStream();
            using (StreamWriter writer = new StreamWriter(str))
                writer.Write("abc");

            // ACT
            StreamHelper.StreamToString(str);
        }

        #endregion StreamToString, MemoryStream

        #region StringToStream

        [TestMethod]
        [DataRow("abccda")]
        [DataRow("a   sfe  2154   a")]
        [DataRow("")]
        public void Can_StringToStream_MemoryStream(string data)
        {
            // ARRANGE
            // ACT
            var result = StreamHelper.StringToStream(data);

            // ASSERT
            Assert.AreEqual(data, StreamHelper.StreamToString(result));
        }

        #endregion StringToStream
    }
}