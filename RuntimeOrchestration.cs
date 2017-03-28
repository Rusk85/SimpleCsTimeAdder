using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAdder
{
    public static class RuntimeOrchestration
    {
        public static void Main(string[] args)
        {
            RunStandardExecution();
        }

        private static void RunStandardExecution()
        {
            CommandLineInterface cli = new CommandLineInterface();
            List<string> rawTimeStrings = cli.StartReadingFromStdIn();
            TimeParser parser = new TimeParser(rawTimeStrings);
            List<TimeSpan> parsedTimeSpans = parser.ParseTimeStrings().ToList();
            TimeAdder calculationOfTotal = new TimeAdder(parsedTimeSpans);
            Console.WriteLine(Enumerable.Range(0,80).Select(num => "-").Aggregate((a,b) => a + b));
            Console.WriteLine($"Total Time is {calculationOfTotal.ReturnTotalTime()}");
            Console.WriteLine(Enumerable.Range(0,80).Select(num => "-").Aggregate((a,b) => a + b));
            Console.WriteLine("To terminate execution press any key.");
            Console.ReadKey();
        }
    }
}
