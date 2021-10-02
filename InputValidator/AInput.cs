using System;

namespace InputValidator
{
    public abstract class AInput<inbound, outbound>
    {
        private bool clearScreen;

        public bool ClearScreen { get => clearScreen; set => clearScreen = value; }

        public AInput(bool clearScreen = true)
        {
            this.clearScreen = clearScreen;
        }

        public outbound Input(string information)
        {
            inbound input;
            bool isValid;

            do
            {
                if (clearScreen)
                    Console.Clear();
                else
                    Console.WriteLine();

                Console.Write(information);
                input = UserInput();

                

                isValid = IsValid(input);
            }
            while (!isValid);

            Convert(input, out outbound result);
            return result;
        }

        protected abstract inbound UserInput();

        protected virtual bool IsValid(inbound input) => input != null;

        public abstract bool Convert(inbound toConvert, out outbound converted);
    }
}
