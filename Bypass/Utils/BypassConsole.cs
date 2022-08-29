using System;
namespace Bypass.Utils
{
    // Override of the normal console

    public class BypassConsole
    {
        private static readonly BypassConsole instance = new BypassConsole();

        static BypassConsole()
        {
        }

        private BypassConsole()
        {
        }

        public static BypassConsole Instance
        {
            get
            {
                return instance;
            }
        }

        public void LogNote(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Line()
        {
            Console.WriteLine("--------------------------------------");
        }
    }
}

