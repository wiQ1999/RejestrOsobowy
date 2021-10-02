using System;

namespace InputValidator
{
    public class DigitalText : AInput<string, string>
    {
        protected override string UserInput() => Console.ReadLine();

        protected override bool IsValid(string input) => base.IsValid(input) && !string.IsNullOrWhiteSpace(input);

        public override bool Convert(string toConvert, out string converted)
        {
            converted = toConvert;
            return true;
        }
    }
}
