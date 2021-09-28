using System;
using System.Linq;

namespace InputValidator
{
    public class InputLine
    {
        public T Input<T>(string notification, bool allowNull = false, bool clear = true)
        {
            object result = null;
            bool isValid = false;
            do
            {
                if (clear)
                {
                    Console.Clear();
                    Console.WriteLine(notification);
                }

                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    if (allowNull)
                        return (T)(object)null;
                    continue;
                }

                if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
                    result = ParseInt(input);
                else if (typeof(T) == typeof(string))
                    result = input;
                else if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?))
                    result = ParseSex(input);

                if (result != null)
                    isValid = true;
            }
            while (!isValid);

            return (T)(object)result;
        }

        private int? ParseInt(string value)
        {
            try
            {
                return int.Parse(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string ParseString(string value)
        {
            if (value.All(x => char.IsDigit(x)))
                return null;
            return value;
        }

        private bool? ParseSex(string value)
        {
            //if (ParseString(value) == null)
            //    return null;

            switch (value.ToLower())
            {
                case "k":
                    return true;
                case "m":
                    return true;
                default:
                    return null;
            }
        }
    }
}
