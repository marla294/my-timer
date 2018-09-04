using System;

namespace MyTimer
{
    public class TimerDuration
    {
        ILogger Logger { get; set; }

        public TimerDuration(ILogger logger)
        {
            Logger = logger;
        }

        public TimeSpan CollectTimeData()
        {
            Logger.WriteLine("How long do you want to set the timer for?");

            return new TimeSpan(CollectTimeData("Hours"), CollectTimeData("Minutes"), CollectTimeData("Seconds"));
        }

        // timeType should be either Hours, Minutes, or Seconds
        int CollectTimeData(string timeType)
        {
            Logger.Write(timeType + ": ");

            bool _isValidTime = Int32.TryParse(Logger.ReadLine(), out var _time);

            while (!_isValidTime)
            {
                Logger.WriteLine("{0} must be a whole number", timeType);
                Logger.Write(timeType + ": ");
                _isValidTime = Int32.TryParse(Logger.ReadLine(), out _time);
            }

            return _time;
        }
    }
}
