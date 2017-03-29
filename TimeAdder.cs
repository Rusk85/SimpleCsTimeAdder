using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeAdder
{
    public class TimeAdder
    {
        private readonly List<TimeSpan> _discreteTimes;

        public TimeAdder(List<TimeSpan> discreteTimes)
        {
            _discreteTimes = discreteTimes;
        }

        public TimeCalculationResult ReturnTotalTime()
        {
            long totalTimeInTicks = _discreteTimes.Sum(ts => ts.Ticks);
            TimeSpan totalTime = TimeSpan.FromTicks(totalTimeInTicks);
            double totalTimeInHours = totalTime.TotalHours;
            double totalTimeInMinutes = totalTime.TotalMinutes;
            double totalTimeinSeconds = totalTime.TotalSeconds;
            Func<double, string> c = Convert.ToString;
            return new TimeCalculationResult
            {
                TotalTimeInHours = totalTimeInHours,
                TotalTimeInMinutes = totalTimeInMinutes,
                TotalTimeInSeconds = totalTimeinSeconds
            };
        }
    }

}
