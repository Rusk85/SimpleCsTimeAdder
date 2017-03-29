using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using TimeAdder.CommandLine;

namespace TimeAdder
{
    public static class RuntimeOrchestration
    {
        public static void Main(string[] args)
        {
            ParseCmdLine(args);
            Console.WriteLine($"{Environment.NewLine} Press any key to quit...");
            Console.ReadKey();
        }


        private static void ParseCmdLine(string[] args)
        {
            if (!args.Any())
            {
                RunInInteractiveMode();
            }
            Parser parser = new Parser();
            ParserResult<CommandLineOptions> parsingResult = parser.ParseArguments<CommandLineOptions>(args);
            parsingResult.WithParsed(commandLineOptions =>
            {
                if (commandLineOptions.InteractiveMode)
                {
                    RunInInteractiveMode();
                }
                else if (commandLineOptions.ParseTimeStringsAtOnce.Any())
                {
                    RunInBatchMode(commandLineOptions.ParseTimeStringsAtOnce);
                } else if (!String.IsNullOrEmpty(commandLineOptions.ReadTimesFromFile))
                {
                    CalculateTimesFromFile(commandLineOptions.ReadTimesFromFile);
                }
            });
        }

        private static void CalculateTimesFromFile(string filePath)
        {
            IEnumerable<string> timeStrings = new TimeFileReader(filePath).ReadFile();
            RunInBatchMode(timeStrings);
        }

        private static void RunInInteractiveMode()
        {
            InteractiveCommandLine cli = new InteractiveCommandLine();
            List<string> rawTimeStrings = cli.StartReadingFromStdIn();
            TimeParser parser = new TimeParser(rawTimeStrings);
            List<TimeSpan> parsedTimeSpans = parser.ParseTimeStrings().ToList();
            TimeAdder calculationOfTotal = new TimeAdder(parsedTimeSpans);
            Console.WriteLine(Enumerable.Range(0,80).Select(num => "-").Aggregate((a,b) => a + b));
            Console.WriteLine($"Total Time is {calculationOfTotal.ReturnTotalTime()}");
            Console.WriteLine(Enumerable.Range(0,80).Select(num => "-").Aggregate((a,b) => a + b));
        }

        private static void RunInBatchMode(IEnumerable<string> timeStrings)
        {
            List<TimeSpan> parsedTimeSpans = new TimeParser(timeStrings.ToList()).ParseTimeStrings().ToList();
            TimeCalculationResult totalTime = new TimeAdder(parsedTimeSpans).ReturnTotalTime();
            Console.WriteLine("Total Time:");
            Console.WriteLine($"In Hours:\t{totalTime.TotalTimeInHours}");
            Console.WriteLine($"In Minutes:\t{totalTime.TotalTimeInMinutes}");
            Console.WriteLine($"In Seconds:\t{totalTime.TotalTimeInSeconds}");
        }
    }
}
