using InputValidator;
using RejestrOsobowy.Interfaces;

namespace RejestrOsobowy
{
    public class Address : ISimilarity
    {
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int? FlatNumber { get; set; }

        public Address()
        {
            InputLine validator = new InputLine();

            PostCode = validator.Input<string>("Podaj kod pocztowy: ");
            City = validator.Input<string>("Podaj miasto: ");
            Street = validator.Input<string>("Podaj ulicę: ");
            HouseNumber = validator.Input<string>("Podaj numer domu: ");
            FlatNumber = validator.Input<int?>("Podaj numer mieszkania: ", true);
        }

        internal Address(string postCode, string city, string street, string houseNumber)
        {
            PostCode = postCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        internal Address(string postCode, string city, string street, string houseNumber, int flatNumber) 
            : this(postCode, city, street, houseNumber)
        {
            FlatNumber = flatNumber;
        }

        public bool IsSimilar(string value)
        {
            value = value.ToLower();
            return
                PostCode.ToLower().Contains(value) ||
                City.ToLower().Contains(value) ||
                Street.ToLower().Contains(value) ||
                HouseNumber.ToLower().Contains(value) ||
                (FlatNumber != null && FlatNumber.ToString().Contains(value));
        }

        public override string ToString()
        {
            string result = string.Format("{0}, ul. {1} {2}", City, Street, HouseNumber);
            if (FlatNumber != null)
                result += "/" + FlatNumber;
            return result;
        }
    }
}
