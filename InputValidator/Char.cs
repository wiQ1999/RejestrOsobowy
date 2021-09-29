using System;
using System.Collections.Generic;

namespace InputValidator
{
    class Char : AInput<ConsoleKey, char>
    {
        public List<char> AvailableChars { get; set; }

        protected override ConsoleKey UserInput() => Console.ReadKey().Key;

        public override char Convert(ConsoleKey toConvert)
        {


            return ' ';
        }

        protected override bool IsValid(ConsoleKey input)
        {
            if (!base.IsValid(input))
                return false;



            return true;
        }
    }
}
