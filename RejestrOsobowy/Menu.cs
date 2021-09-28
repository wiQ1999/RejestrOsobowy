using Enums;
using System;

namespace RejestrOsobowy
{
    public class Menu
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Dodaj osobę");
            Console.WriteLine("2. Usuń osobę");
            Console.WriteLine("3. Modyfikuj osobę");
            Console.WriteLine("4. Zapisz do pliku");
            Console.WriteLine("5. Wyjdź");
        }

        public MenuField SelectField()
        {
            ConsoleKeyInfo keyInfo;
            bool isValid;
            do
            {
                ShowMenu();
                keyInfo = Console.ReadKey();
                isValid = ValidateInput(keyInfo.Key);
            }
            while (!isValid);

            return GetField(keyInfo.Key);
        }

        private bool ValidateInput(ConsoleKey key)
        {
            if (
                key == ConsoleKey.D1 ||
                key == ConsoleKey.D2 ||
                key == ConsoleKey.D3 ||
                key == ConsoleKey.D4 ||
                key == ConsoleKey.D5 ||
                key == ConsoleKey.NumPad1 ||
                key == ConsoleKey.NumPad2 ||
                key == ConsoleKey.NumPad3 ||
                key == ConsoleKey.NumPad4 ||
                key == ConsoleKey.NumPad5
                )
                return true;
            return false;
        }

        private MenuField GetField(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    return MenuField.Add;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    return MenuField.Remove;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    return MenuField.Modify;
                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    return MenuField.Save;
                case ConsoleKey.D5 or ConsoleKey.NumPad5:
                    return MenuField.Exit;
                default:
                    throw new Exception("Niepoprawna wartość!");
            }
        }
    }
}
