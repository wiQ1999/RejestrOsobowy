using System;

namespace InputValidator
{
    public class Integer : AInput<string, int?>
    {
        private bool allowEmpty;

        public bool AllowEmpty { get => allowEmpty; set => allowEmpty = value; }

        public Integer(bool allowEmpty = false, bool clearScreen = true) : base (clearScreen)
        {
            this.allowEmpty = allowEmpty;
        }

        protected override string UserInput() => Console.ReadLine();

        protected override bool IsValid(string input)
        {
            if (!base.IsValid(input))
                return false;

            if (!allowEmpty && string.IsNullOrWhiteSpace(input))
                return false;

            return Convert(input, out int? _);
        }

        public override bool Convert(string toConvert, out int? converted)
        {
            try
            {
                if (allowEmpty && string.IsNullOrWhiteSpace(toConvert))
                    converted = null;
                else
                    converted = int.Parse(toConvert);
                return true;
            }
            catch (Exception)
            {
                converted = 0;
                return false;
            }
        }
    }
}
