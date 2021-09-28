using Enums;
using System;

namespace RejestrOsobowy
{
    class Program
    {
        static PersonList list = new();

        static void Main(string[] args)
        {
            #region TO DELETE

            TestInsertList();

            foreach (var item in list.Select("al"))
            {
                Console.WriteLine(item.ToString());
            }
            
            Console.ReadKey();

            #endregion

            //Start();
        }

        static void Start()
        {
            Menu menu = new Menu();
            MenuField field = menu.SelectField();
            
            new Person();

            Console.ReadKey();
        }

        /// <summary>
        /// TO DELETE
        /// </summary>
        static void TestInsertList()
        {
            list.Add(new Person("Wiktor", "Szczeszek", 22, true, "64-330", "Opalenica", "Poprzeczna", "2"));
            list.Add(new Person("Julianna", "Górska", 22, false, "62-060", "Steszew", "Podgórna", "3"));
            list.Add(new Person("Hubert", "Nowak", 22, true, "64-330", "Opalcenica", "3 maja", "3a", 3));
            list.Add(new Person("Jan", "Kowalski", 45, true, "43-222", "Poznań", "Krakowska", "12", 6));
            list.Add(new Person("Janina", "Kowalczyk", 63, false, "43-222", "Poznań", "Złotowska", "15c"));
            list.Add(new Person("Krzysztof", "Górecki", 12, true, "23-100", "Kraków", "Nowa", "87"));
        }
    }
}
