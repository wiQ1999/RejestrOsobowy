using InputValidator;
using RejestrOsobowy.Interfaces;

namespace RejestrOsobowy.Models
{
    public class Person : ISimilarity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        /// <summary>
        /// 0 - woman, 1 - man
        /// </summary>
        public bool Sex { get; set; }
        public Address Address { get; set; }

        public Person()
        {
            //InputLine validator = new();
            
            //Name = validator.Input<string>("Podaj imię: ");
            //Surname = validator.Input<string>("Podaj nazwisko: ");
            //Age = validator.Input<int>("Podaj wiek: ");
            //Sex = validator.Input<bool>("Podaj płeć: ");
            //Address = new Address();
        }

        private Person(string name, string surname, int age, bool sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        internal Person(string name, string surname, int age, bool sex, string postCode, string city, string street, string houseNumber) 
            : this(name, surname, age, sex)
        {
            Address = new Address(postCode, city, street, houseNumber);
        }

        internal Person(string name, string surname, int age, bool sex, string postCode, string city, string street, string houseNumber, int flatNumber) 
            : this(name, surname, age, sex)
        {
            Address = new Address(postCode, city, street, houseNumber, flatNumber);
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
