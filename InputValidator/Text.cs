using System;
using System.Linq;

namespace InputValidator
{
    public class Text : AInput<string, string>
    {
        protected override string UserInput() => Console.ReadLine();

        protected override bool IsValid(string input) => base.IsValid(input) && !string.IsNullOrWhiteSpace(input) && !input.Any(x => char.IsDigit(x));
        
        public override string Convert(string toConvert) => toConvert;
    }
}
