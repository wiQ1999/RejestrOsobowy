using System;
using System.Collections.Generic;

namespace InputValidator
{
    class Char : AInput<ConsoleKey, char>//TODO
    {
        public List<char> AvailableChars { get; set; }

        protected override ConsoleKey UserInput() => Console.ReadKey().Key;

        protected override bool IsValid(ConsoleKey input)
        {
            if (!base.IsValid(input))
                return false;



            return true;
        }

        public override bool Convert(ConsoleKey toConvert, out char converted)
        {
            converted = ' ';
            return true;
        }


    }
}
