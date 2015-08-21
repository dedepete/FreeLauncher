using System;
using System.Linq;

namespace FreeLauncher_Launcher
{
    public static class ConsoleIO
    {
        public static string ReadPassword()
        {
            var pass = string.Empty;
            Console.Write("()");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("\b \b*)");
                }
                else
                {
                    if (key.Key != ConsoleKey.Backspace || pass.Length <= 0) continue;
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b\b \b)");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return pass;
        }

        public static int ReadChoice(string[] choices)
        {
            ConsoleKeyInfo key;
            var longest = choices.OrderByDescending(s => s.Length).First().Length;
            var i = 0;
            var smtc = false;
            Console.Write("[{0}]", choices[i] + new string(' ', longest - choices[i].ToCharArray().Length));
            do
            {
                key = Console.ReadKey(true);
                if ((key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.LeftArrow) && key.Key != ConsoleKey.Enter && i != 0)
                {
                    i--;
                    smtc = true;
                }
                else if ((key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.RightArrow) && key.Key != ConsoleKey.Enter && !(i >= choices.Length - 1))
                {
                    i++;
                    smtc = true;
                }
                if (!smtc) continue;
                Console.Write(new String(Enumerable.Range(0, longest + 2).SelectMany(x => "\b \b").ToArray()));
                Console.Write("[{0}]", choices[i] + new String(' ', longest - choices[i].ToCharArray().Length));
            }
            while (key.Key != ConsoleKey.Enter);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new String(Enumerable.Range(0, longest + 2).SelectMany(x => "\b \b").ToArray()));
            Console.Write("[{0}]", choices[i] + new String(' ', longest - choices[i].ToCharArray().Length));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            return i;
        }

        public static string ReplaceString(string s)
        {
            var a = string.Empty;
            for (var b = 0; b < s.Length; b++)
                a += "\b \b";
            a += "\b \b";
            return a;
        }

        public static void WriteColored(string text, ConsoleColor c)
        {
            var oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(text);
            Console.ForegroundColor = oldcolor;
        }

        public static void WriteColoredLine(string text, ConsoleColor c)
        {
            var oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.WriteLine(text);
            Console.ForegroundColor = oldcolor;
        }
    }
}
