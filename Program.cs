using System;
using System.IO;
using System.Threading;

namespace GuidGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Log(typeof(Program).Namespace, Guid.NewGuid().ToString());
                Thread.Sleep(5000);
            }
        }

        private static void Log(string caller, string msg)
        {
            try
            {
                var output = $"{DateTime.UtcNow:s}|INFO|{msg}{Environment.NewLine}";

                Console.Write(output);
                File.AppendAllTextAsync($"{caller}.log", output);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
    }
}