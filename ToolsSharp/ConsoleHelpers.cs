namespace ToolsSharp
{
    /// <summary>
    /// Helper methods for CLI applications
    /// </summary>
    public static class ConsoleHelpers
    {
        /// <summary>
        /// Print a line of text in a color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void WriteLineColor(string text, ConsoleColor? color = null)
        {
            if (color != null)
                Console.ForegroundColor = (ConsoleColor)color;
            else
                Console.ResetColor();
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Print text in a color
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void WriteColor(string text, ConsoleColor? color = null)
        {
            if (color != null)
                Console.ForegroundColor = (ConsoleColor)color;
            else
                Console.ResetColor();
            Console.Write(text);
            Console.ResetColor();
        }
    }
}