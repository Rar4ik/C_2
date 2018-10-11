using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_1
{
    class Logger
    {
        public static Action<string> WriteMessage;
        public static void LogMessage(string msg)
        {    
            var outputMsg = $"{DateTime.Now}\t{msg}";
            WriteMessage(outputMsg);
        }

        public static void LogToConsole(string message)
        {
            Console.Error.WriteLine(message);
        }
        

    }
}
