using InputValidator;
using RejestrOsobowy.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace RejestrOsobowy.Models
{
    public class Person : ISimilarity
    {
        private string name;
        private string surname;
        private int age;
        private bool sex;
        private Address address;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        /// <summary>
        /// 0 false - woman, 1 true - man
        /// </summary>
        public bool Sex { get => sex; set => sex = value; }
        public Address Address { get => address; set => address = value; }

        [JsonConstructor]
        public Person()
        {
        }

        protected Person(string name, string surname, int age, bool sex)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.sex = sex;
            address = Address.CreateAddress();
        }

        //protected Person(string name, string surname, int age, bool sex, string postCode, string city, string street, string houseNumber) 
        //    : this(name, surname, age, sex)
        //{
        //    Address = new Address(postCode, city, street, houseNumber);
        //}

        //protected Person(string name, string surname, int age, bool sex, string postCode, string city, string street, string houseNumber, int flatNumber) 
        //    : this(name, surname, age, sex)
        //{
        //    Address = new Address(postCode, city, street, houseNumber, flatNumber);
        //}

        public static Person CreatePerson()
        {
            Text text = new();
            Integer integer = new();
            Key key = new(new ConsoleKey[] { ConsoleKey.K, ConsoleKey.M });

            string name = text.Input("Podaj imię: ");
            string surname = text.Input("Podaj nazwisko: ");
            int age = (int)integer.Input("Podaj wiek: ");
            bool sex;
            switch (key.Input("Podaj płeć: "))
            {
                case ConsoleKey.K:
                    sex = false;
                    break;
                case ConsoleKey.M:
                    sex = true;
                    break;
                default:
                    throw new Exception("Niepoprawny znak!");
            }

            return new Person(name, surname, age, sex);
        }

        public bool IsSimilar(string value)
        {
            value = value.ToLower();
            return
                Name.ToLower().Contains(value) ||
                Surname.ToLower().Contains(value) ||
                Age.ToString().Contains(value) ||
                Address.IsSimilar(value);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}
