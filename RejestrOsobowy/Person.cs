using InputValidator;

namespace RejestrOsobowy
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public Address Address { get; set; }

        public Person()
        {
            Validator validator = new Validator();
            
            Name = validator.Input<string>("Podaj imię: ");
            Surname = validator.Input<string>("Podaj nazwisko: ");
            Age = validator.Input<int>("Podaj wiek: ");
            Sex = validator.Input<bool>("Podaj płeć: ");
            Address = new Address();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}
