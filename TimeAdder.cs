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

        public string ReturnTotalTime()
        {
            long totalTimeInTicks = _discreteTimes.Sum(ts => ts.Ticks);
            TimeSpan totalTime = TimeSpan.FromTicks(totalTimeInTicks);
            string unprettyTimeFormat = totalTime.ToString("g"); // 00:10:59.000 => 00:10:50.000
            Regex regex = new Regex(@"(\.d+)$");
            string prettyTimeFormat = regex.Replace(unprettyTimeFormat, String.Empty);
            return prettyTimeFormat;
        }
    }
}
