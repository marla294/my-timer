using System;

namespace MyTimer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var timer = new MyTimerUI(new ConsoleLogger());
            timer.GetInstruction();
            Console.ReadKey();
        }
    }
}
