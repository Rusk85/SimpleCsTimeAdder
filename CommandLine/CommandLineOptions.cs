using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using System.Threading.Tasks;

namespace TimeAdder.CommandLine
{
    public class CommandLineOptions
    {
        [Option('i', "interactive", SetName = "stdin", Required = false, Default = false)]
        public bool InteractiveMode { get; set; }

        [Option('p', "parse", Separator = ',', Required = false, SetName = "parsing")]
        public IEnumerable<string> ParseTimeStringsAtOnce { get; set; }

        [Option('f', "file", SetName = "file", Required = false,Default = null)]
        public string ReadTimesFromFile { get; set; }
    }
}
