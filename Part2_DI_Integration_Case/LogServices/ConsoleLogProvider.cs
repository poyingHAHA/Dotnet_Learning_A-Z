using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices
{
    public class ConsoleLogProvider : ILogProvider
    {
        public void LogInfo(string msg)
        {
            System.Console.WriteLine($"Info: {msg}");
        }

        public void LogError(string msg)
        {
            System.Console.WriteLine($"Error: {msg}");
        }
    }
}