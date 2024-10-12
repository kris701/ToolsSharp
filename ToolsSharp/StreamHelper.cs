namespace ToolsSharp
{
    /// <summary>
    /// A class intended to make it easier to work with <seealso cref="Stream"/> instances.
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// Converts a <seealso cref="Stream"/> to a <seealso cref="string"/>
        /// The <paramref name="str"/> must be readable.
        /// </summary>
        /// <param name="str">A readable stream</param>
        /// <returns>A string based on the data that is in the <paramref name="str"/> stream.</returns>
        /// <exception cref="ArgumentNullException">If the stream is closed or readonly</exception>
        public static string StreamToString(Stream str)
        {
            if (!str.CanRead)
                throw new ArgumentNullException("Cannot read a stream that is either closed or set to read only!");

            str.Position = 0;
            var memoryStream = new MemoryStream();
            str.CopyTo(memoryStream);
            memoryStream.Position = 0;
            return StreamToString(memoryStream);
        }

        /// <summary>
        /// Converts a <seealso cref="MemoryStream"/> to a <seealso cref="string"/>
        /// The <paramref name="str"/> must be readable.
        /// </summary>
        /// <param name="str">A readable stream</param>
        /// <returns>A string based on the data that is in the <paramref name="str"/> stream.</returns>
        /// <exception cref="ArgumentNullException">If the stream is closed or readonly</exception>
        public static string StreamToString(MemoryStream str)
        {
            if (!str.CanRead)
                throw new ArgumentNullException("Cannot read a stream that is either closed or set to read only!");

            str.Position = 0;
            string returnStr = "";
            using (StreamReader strr = new StreamReader(str))
                returnStr = strr.ReadToEnd();
            return returnStr;
        }

        /// <summary>
        /// Converts a <seealso cref="string"/> into a open <seealso cref="MemoryStream"/>
        /// </summary>
        /// <remarks>The output <seealso cref="MemoryStream"/> is open! So remember closing it again when you are done with it.</remarks>
        /// <param name="str">A string you want to convert</param>
        /// <returns>A new open <seealso cref="MemoryStream"/> instance with the string data written into it.</returns>
        public static MemoryStream StringToStream(string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}