using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeAdder
{
    public class TimeParser
    {
        private readonly List<string> _unparsedTimeStrings;

        private const string TimeStringPattern = @"(^[0-9]{1,2})(:)([0-9]{1,2}$)";

        private readonly Regex _regex = new Regex(TimeStringPattern);

        public TimeParser(List<string> unparsedTimeStrings)
        {
            _unparsedTimeStrings = unparsedTimeStrings;
        }


        public IList<TimeSpan> ParseTimeStrings()
        {
            IList<Tuple<int,int>> intermediaryResult = new List<Tuple<int, int>>();

            foreach (string unparseTimeString in _unparsedTimeStrings)
            {
                intermediaryResult.Add(ParseSingleTimeString(unparseTimeString));
            }
            return ParseHourMinuteTuples(intermediaryResult);
        }

        private Tuple<int, int> ParseSingleTimeString(string timeString)
        {
            Match match = _regex.Match(timeString);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                int hours = Convert.ToInt32(groups[1].Value);
                int minutes = Convert.ToInt32(groups[3].Value);
                return Tuple.Create(hours, minutes);
            }
            throw new RegexInvalidTimeStringFormat(timeString);
        }

        private IList<TimeSpan> ParseHourMinuteTuples(IList<Tuple<int, int>>  hourMinuteTuples)
        {
            List<TimeSpan> parsedTimeTuples = new List<TimeSpan>();

            foreach (Tuple<int, int> hourMinuteTuple in hourMinuteTuples)
            {
                parsedTimeTuples.Add(new TimeSpan(hourMinuteTuple.Item1, hourMinuteTuple.Item2, Configuration.SECONDS));
            }
            return parsedTimeTuples;
        }

    }
}
