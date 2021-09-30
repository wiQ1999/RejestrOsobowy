using System;

namespace InputValidator
{
    public class Integer : AInput<string, int>
    {
        protected override string UserInput()
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(string input)
        {
            return base.IsValid(input);
        }

        public override int Convert(string toConvert)
        {
            throw new NotImplementedException();
        }
    }
}
