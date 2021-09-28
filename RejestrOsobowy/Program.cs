using Enums;
using System;

namespace RejestrOsobowy
{
    class Program
    {
        static PersonList<Person> list = new PersonList<Person>();

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Menu menu = new Menu();
            MenuField field = menu.SelectField();

            new Person();

            Console.ReadKey();
        }
    }
}
