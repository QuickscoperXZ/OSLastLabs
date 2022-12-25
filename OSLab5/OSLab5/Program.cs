using System;
using System.Threading;

namespace OSLab5
{
    // -0,09353640519196606
    // 0,43143169870877246
    class Program
    {
        static void Main(string[] args)
        {
            Variables variables = new Variables();
            Thread th1 = new Thread(delegate () { variables.FirstMethod(); });
            Thread th2 = new Thread(delegate () { variables.SecondMethod(); });

            th1.Start();
            th2.Start();

            Thread.Sleep(10000);
            Console.WriteLine(variables.y);
        }
    }
    class Variables
    {
        public Variables()
        {
            x = 0;
            y = 0;
        }
        public double x, y;
        Mutex mObj = new Mutex();
        public void FirstMethod()
        {
           //await Task.Run(() => 
            //{ 
                for (int i = 0; i < 10; i++)
                {
                    //mObj.WaitOne();
                    Thread.Sleep(40);
                    y = Math.Sin(Math.Pow(x, 2) + Math.Cos(2 * y));
                    //mObj.ReleaseMutex();
                }
            //});
        }
        public void SecondMethod()
        {
            //await Task.Run(() => 
            //{ 
                for (int i = 0; i < 10; i++)
                {
                    //mObj.WaitOne();
                    Thread.Sleep(40);
                    x = Math.Sin(y);
                    //mObj.ReleaseMutex();
                }
            //});
        }
    }
}