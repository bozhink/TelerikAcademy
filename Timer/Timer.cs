namespace Timer
{
    using System;
    using System.Diagnostics;

    public class Timer
    {
        private readonly int seconds;

        public Timer(int seconds)
        {
            this.seconds = seconds;
        }

        public delegate void PrintSomething();

        public void InvokeDelegate()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var printDelegate = new PrintSomething(PrintTime);

            while (true)
            {
                if (stopwatch.Elapsed.Seconds != this.seconds)
                {
                    continue;
                }

                printDelegate.Invoke();
                stopwatch.Restart();
            }
        }

        private static void PrintTime()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
