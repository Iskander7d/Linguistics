using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Linguistics
{
    class Logger
    {
        public static string logFilePath = "C:\\Users\\Obivan\\source\\repos\\Linguistics\\Linguistics\\log.log";

        public Logger()
        {
            File.WriteAllText(logFilePath, string.Empty);
        }

        public void LoggingNotify(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();

            File.AppendAllText(logFilePath, message + Environment.NewLine);

        }
    }
}
