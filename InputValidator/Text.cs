using System;
using System.Linq;

namespace InputValidator
{
    public class Text : AInput<string, string>
    {
        protected override string UserInput() => Console.ReadLine();

        protected override bool IsValid(string input)
        {
            if (!base.IsValid(input) || string.IsNullOrEmpty(input) || input.Any(x => char.IsDigit(x)))
                return false;
            return true;
        }

        public override string Convert(string toConvert) => toConvert;
    }
}
