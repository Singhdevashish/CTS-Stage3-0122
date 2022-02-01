using System;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var log1 = new Logger();
            //var log2 = new Logger();
            //var log3 = new Logger();

            var log1 = Logger.Instance;
            var log2 = Logger.Instance;
            var log3 = Logger.Instance;

            log1.Log("Message 1");
            log2.Log("Message 2");
            log3.Log("Message 3");
        }
    }
}
