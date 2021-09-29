using System;

namespace InputValidator
{
    public abstract class AInput<inbound, outbound>
    {
        public outbound Input(string information)
        {
            inbound result;
            bool isValid;

            do
            {
                Console.Clear();
                Console.Write(information);

                result = UserInput();

                isValid = IsValid(result);
            }
            while (!isValid);

            return Convert(result);
        }

        protected abstract inbound UserInput();

        public abstract outbound Convert(inbound toConvert);

        protected virtual bool IsValid(inbound input)
        {
            if (input == null)
                return false;
            return true;
        }
    }
}
