using System;

namespace OSL4V2
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Thread ft = new Thread(delegate() { FirstThread.PrintIn(new FileInfo(@"C:\Users\Quickscoper\Documents\OS_Labs\OSL4V2\OSL4V2\result\res.dat"), -10, 1, 1000, 10); });
            Thread st = new Thread(delegate () { new SecondThread().GetSize(new FileInfo(@"C:\Users\Quickscoper\Documents\OS_Labs\OSL4V2\OSL4V2\result\res.dat")); });
            ft.Start();
            st.Start();
        }
    }
    internal class FirstThread
    {
        public static void PrintIn(FileInfo info, int startPoint, int step, int sleepTime, int count)
        {
            StreamWriter writer = new StreamWriter(info.FullName,true);
            writer.WriteLine($"Запуск от: {DateTime.Now}");
            writer.Close();
            for (int i = 1; i <+ count+1; i++)
            {
                StreamWriter fw = new StreamWriter(info.FullName, true);
                fw.WriteLineAsync($"{count}|{Math.Sin(startPoint + count * step)}");
                fw.Close();
                Thread.Sleep(sleepTime);
            }
        }
    }
    internal class SecondThread
    {
            
        void ctrlcpressed(object sender, ConsoleCancelEventArgs e) { Console.WriteLine("Завершение....."); }
        public SecondThread()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ctrlcpressed);
        }
        long lastSize;
        public void GetSize(FileInfo info)
        {
            lastSize = info.Length;
            while (true)
            {
                info.Refresh();
                if (lastSize != info.Length)
                {
                    Console.WriteLine(info.Length);
                    lastSize = info.Length;
                }
                Thread.Sleep(500);
            }
        }
    }
}