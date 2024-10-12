using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSharp
{
    public static class ConsoleHelpers
    {
        public static void WriteLineColor(string text, ConsoleColor? color = null)
        {
            if (color != null)
                Console.ForegroundColor = (ConsoleColor)color;
            else
                Console.ResetColor();
            Console.WriteLine(text);
            Console.ResetColor();
        }

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