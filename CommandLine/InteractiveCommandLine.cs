using System;
using System.Collections.Generic;

namespace TimeAdder.CommandLine
{
    public class InteractiveCommandLine
    {
        private readonly string _startMessage =
            $"Please type in a time in this format: 20:10.{Environment.NewLine}Where 20 represent hours and 10 the minutes.{Environment.NewLine}Once fínished just press <Enter>.";

        private const string NextTime = "Please add your next time span or show the sum by pressing <Enter>.";

        private readonly List<string> _timeStrings = new List<string>();

        public List<string> StartReadingFromStdIn()
        {
            Console.WriteLine(_startMessage);
            string currentTimeString = null;
            while ((currentTimeString = Console.ReadLine()) != String.Empty)
            {
                _timeStrings.Add(currentTimeString);
                Console.WriteLine(NextTime);
            }
            return _timeStrings;
        }
    }
}
