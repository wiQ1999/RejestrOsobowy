using System;
using System.Linq;

namespace InputValidator
{
    public class Key : AInput<ConsoleKey, ConsoleKey>
    {
        public ConsoleKey[] AvailableKeys { get; set; }

        public Key()
        {
            AvailableKeys = Array.Empty<ConsoleKey>();
        }

        public Key(params ConsoleKey[] consoleKeys)
        {
            AvailableKeys = consoleKeys;
        }

        protected override ConsoleKey UserInput() => Console.ReadKey().Key;

        protected override bool IsValid(ConsoleKey input)
        {
            if (!base.IsValid(input) || (AvailableKeys != null && AvailableKeys.Any() && !AvailableKeys.Contains(input)))
                return false;
            return true;
        }

        public override bool Convert(ConsoleKey toConvert, out ConsoleKey converted)
        {
            converted = toConvert;
            return true;
        }
    }
}
