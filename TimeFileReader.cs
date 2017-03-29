using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimeAdder
{
    public class TimeFileReader
    {
        private readonly string _filePath = null;

        public TimeFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<string> ReadFile()
        {
            List<string> timeStrings = new List<string>();
            foreach (string timeString in File.ReadAllLines(_filePath))
            {
                timeStrings.Add(new Regex(@"\s+").Replace(timeString,String.Empty));
            }
            return timeStrings;
        }
    }
}
