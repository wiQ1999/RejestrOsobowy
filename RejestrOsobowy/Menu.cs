using InputValidator;
using RejestrOsobowy.Models;
using Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RejestrOsobowy
{
    public class Menu
    {
        private PersonList list;
        public PersonList List { get => list; }

        public Menu()
        {
            Deserialzie();
        }

        private string ShowMenu() =>
            @"1. Dodaj osobę
2. Pokaż listę osób
3. Modyfikuj osobę
4. Usuń osobę
5. Zapisz do pliku
6. Wyjdź";

        public void ProgramLoop()
        {
            while (true)
            {
                ShowMenu();
                ConsoleKey consoleKey = InsertMenuKey();
                if (consoleKey == ConsoleKey.D6 || consoleKey == ConsoleKey.NumPad6 || consoleKey == ConsoleKey.Escape)
                    break;
                ExecuteSelectedMenu(consoleKey);
            }
        }

        private ConsoleKey InsertMenuKey() => new Key(new ConsoleKey[] {
            ConsoleKey.Escape,
            ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6,
            ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.NumPad5, ConsoleKey.NumPad6
        }).Input($"{ShowMenu()}\nOpcja menu: ");

        private void ExecuteSelectedMenu(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    AddPerson();
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    ShowPersonList();
                    break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    ModifyPerson();
                    break;
                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    DeletePerson();
                    break;
                case ConsoleKey.D5 or ConsoleKey.NumPad5:
                    Save();
                    break;
                default:
                    throw new Exception("Niepoprawna wartość!");
            }
        }

        private void AddPerson() => List.Add(Person.CreatePerson());

        private void ShowPersonList()
        {
            Console.Clear();
            if (!list.Any())
                Comunicate("Brak wpisanych osób.");
            else
                Comunicate(GenerateListString(list));
        }

        private void ModifyPerson()
        {
            Console.Clear();
            Comunicate("Brak czasu aby zaprogramować :(");
        }

        private void DeletePerson()
        {
            Person person = SelectPerson();
            if (person != null)
                List.Remove(person);
        }

        private IEnumerable<Person> FindPerson()
        {
            string input = new DigitalText().Input("Wyszukaj osoby: ");
            return List.Select(input);
        }

        private Person SelectPerson()
        {
            var selectedList = FindPerson();
            Person result = null;

            if (!selectedList.Any())
                Comunicate("Nie znaleziono żadnego dopasowania.");
            else
            {
                int? inpout = new Integer(true).Input($"{GenerateListString(selectedList)}\nWybierz osobę: ");

                if (inpout != null)
                    result = selectedList.ElementAt(((int)inpout) - 1);
            }

            return result;
        }

        private void Save() => new JsonSerializator<PersonList>().Serialize(List);

        private void Deserialzie()
        {
            var jsonList = new JsonSerializator<PersonList>().Deserialize();
            if (jsonList == null)
                list = new PersonList();
            else
                list = jsonList;
        }

        private string GenerateListString(IEnumerable<Person> list)
        {
            string info = "Lista osób: \n";
            for (int i = 0; i < list.Count(); i++)
            {
                Person person = list.ElementAt(i);
                info += $"{i + 1}. {person}\n";
            }
            return info;
        }

        private void Comunicate(string comunicate)
        {
            Console.WriteLine();
            Console.WriteLine(comunicate);
            Console.WriteLine("Naciśnij klawisz aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
