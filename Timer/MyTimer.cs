using System;
using System.Timers;

namespace MyTimer
{
    public class MyTimer
    {
        public TimeSpan Duration { get; private set; }
        public DateTime EndTime { get; private set; }

        ILogger Logger { get; set; }
        TimeSpan TimeElapsed { get; set; }
        Timer SystemTimer { get; set; }
        bool IsRunning { get; set; }
        bool IsPaused { get; set; }

        public MyTimer(ILogger logger)
        {
            Duration = new TimeSpan();
            EndTime = new DateTime();

            Logger = logger;
            TimeElapsed = new TimeSpan();
            SystemTimer = new Timer(1000);
        }

        public void Start(TimerDuration timerDuration)
        {
            if (IsRunning){
                Logger.WriteLine("Timer already started");
                return;
            }

            Duration = timerDuration.CollectTimeData();
            EndTime = DateTime.Now + Duration - TimeElapsed;

            StartTimer();

            Logger.WriteLine("Starting timer.  End time is: " + EndTime);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                ResetTimer();

                Logger.WriteLine("Stopping timer");
            }
            else
            {
                Logger.WriteLine("Timer already stopped");
            }
        }

        public void Pause()
        {
            if (IsRunning && !IsPaused)
            {
                IsPaused = true;
                SystemTimer.Stop();

                Logger.WriteLine("Pausing timer");
            }
            else if (!IsRunning)
            {
                Logger.WriteLine("Timer is stopped, please restart timer");
            }
            else if (IsPaused)
            {
                Logger.WriteLine("Timer is already paused, please resume timing");
            }
        }

        public void Resume()
        {
            if (IsRunning && IsPaused)
            {
                EndTime = DateTime.Now + (Duration - TimeElapsed);
                IsPaused = false;
                SystemTimer.Start();

                Logger.WriteLine("Resuming timer.  New end time: " + EndTime);
            }
            else if (!IsRunning)
            {
                Logger.WriteLine("Timer is stopped, please restart timer");
            }
            else if (!IsPaused)
            {
                Logger.WriteLine("Timer is not paused");
            }
        }

        void StartTimer()
        {
            IsRunning = true;

            SystemTimer = new Timer(1000);
            SystemTimer.Elapsed += Alarm;
            SystemTimer.AutoReset = true;
            SystemTimer.Enabled = true;
        }

        void ResetTimer()
        {
            SystemTimer.Stop();
            SystemTimer.Dispose();

            Duration = new TimeSpan();
            EndTime = new DateTime();

            TimeElapsed = new TimeSpan();
            SystemTimer = new Timer(1000);
            IsRunning = false;
            IsPaused = false;
        }

        void Alarm(Object source, ElapsedEventArgs e)
        {
            TimeElapsed = Duration - (EndTime - DateTime.Now);

            if (DateTime.Now > EndTime)
            {
                Logger.WriteLine("buzzzzz");

                ResetTimer();
            }
        }

    }
}
