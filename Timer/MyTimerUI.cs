using System;

namespace MyTimer
{
    public class MyTimerUI
    {
        MyTimer MyTimer { get; set; }
        ILogger Logger { get; set; }

        public MyTimerUI(ILogger logger)
        {
            MyTimer = new MyTimer(logger);
            Logger = logger;
            Logger.WriteLine("Please enter an instruction for the timer: Stop/Start/Pause/Resume");
        }

        public void GetInstruction()
        {
            ExecuteInstruction(Logger.ReadLine().ToLower());
        }

        void ExecuteInstruction(string instruction)
        {
            switch (instruction)
            {
                case "start":
                    MyTimer.Start(new TimerDuration(Logger));
                    break;
                case "stop":
                    MyTimer.Stop();
                    break;
                case "pause":
                    MyTimer.Pause();
                    break;
                case "resume":
                    MyTimer.Resume();
                    break;
                default:
                    Logger.WriteLine("Please enter instruction: Stop/Start/Pause/Resume.");
                    break;
            }

            GetInstruction();
        }
            
    }
}
 