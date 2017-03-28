using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAdder
{
    public class RegexInvalidTimeStringFormat : Exception
    {
        private static string formatInput = "The time string {0} could not be matached";

        private static string DisplayInvalidVariableWithContext(string message)
        {
            return String.Format(formatInput, message);
        }

        public RegexInvalidTimeStringFormat(string invalidTimeString) : base(String.Format(formatInput, invalidTimeString))
        {
        }

        public RegexInvalidTimeStringFormat(string invalidTimeString, Exception innerException) : base(String.Format(formatInput, invalidTimeString), innerException)
        {
        }
    }
}
