using System;
using System.Threading;

namespace OSL8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runThreads = true;
            Queue queue = new Queue(10);
            for (int i = 0; i <= 2; i++)
            {
                Thread wr = new Thread(() =>
                {
                    Random rnd = new Random();
                    int val;
                    while (runThreads)
                    {
                        val = rnd.Next(-500, 500);
                        queue.Enqueue(val);
                        Console.WriteLine($"{Thread.CurrentThread.Name}: Добавлено: {val} ");
                    }
                });
                wr.Name = $"WRITER-{i}";
                wr.Start();
            }
            for (int i = 0; i <= 2; i++)
            {
                Thread rd = new Thread(() =>
                {
                    while (runThreads)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: Изъято: {queue.queueFirst()}");
                        queue.Dequeue();
                    }
                });
                rd.Name = $"READER-{i}";
                rd.Start();
            }
            Console.ReadKey();
            runThreads = false;
        }
    }
}