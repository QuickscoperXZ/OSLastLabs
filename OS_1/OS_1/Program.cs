using System;
using System.Diagnostics;

namespace OS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Quickscoper\Documents\OS_1\OS_1\OSl1.docx";
            Process process = new Process();

            process.StartInfo.FileName = path;
            process.StartInfo.UseShellExecute = true;

            if (process.Start())
            { Console.WriteLine("Процесс запущен успешно."); }
            else
            { Console.WriteLine("Процесс не запущен."); }

            process.WaitForExit();

            Console.WriteLine("Процесс завершён.");

        }
    }
}
