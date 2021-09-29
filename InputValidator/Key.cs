using System;

namespace InputValidator
{
    public class Key : AInput<ConsoleKey, ConsoleKey>
    {
        protected override ConsoleKey UserInput() => Console.ReadKey().Key;

        protected override bool IsValid(ConsoleKey input)
        {
            if (!base.IsValid(input))
                return false;



            return true;
        }

        public override ConsoleKey Convert(ConsoleKey toConvert)
        {
            throw new NotImplementedException();
        }
    }
}
