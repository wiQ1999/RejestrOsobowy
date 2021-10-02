using InputValidator;
using RejestrOsobowy.Interfaces;
using System.Text.Json.Serialization;

namespace RejestrOsobowy.Models
{
    public class Address : ISimilarity
    {
        private string postCode;
        private string city;
        private string street;
        private string houseNumber;
        private int? flatNumber;

        public string PostCode { get => postCode; set => postCode = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public int? FlatNumber { get => flatNumber; set => flatNumber = value; }

        [JsonConstructor]
        public Address()
        {
        }

        protected Address(string postCode, string city, string street, string houseNumber)
        {
            PostCode = postCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        protected Address(string postCode, string city, string street, string houseNumber, int flatNumber) 
            : this(postCode, city, street, houseNumber)
        {
            FlatNumber = flatNumber;
        }

        public static Address CreateAddress()
        {
            DigitalText digitalText = new();
            Text text = new();
            Integer integer = new(true);

            string postCode = digitalText.Input("Podaj kod pocztowy: ");
            string city = text.Input("Podaj miasto: ");
            string street = digitalText.Input("Podaj ulicę: ");
            string houseNumber = digitalText.Input("Podaj numer domu: ");
            int? flatNumber = integer.Input("Podaj numer mieszkania: ");

            if (flatNumber == null)
                return new Address(postCode, city, street, houseNumber);
            else
                return new Address(postCode, city, street, houseNumber, (int)flatNumber);
        }

        public void Modify()
        {
            DigitalText digitalText = new();
            Text text = new();
            Integer integer = new(true);

            postCode = digitalText.Input($"Modyfikuj kod pocztowy ({postCode}): ");
            city = text.Input($"Modyfikuj miasto ({city}): ");
            street = digitalText.Input($"Modyfikuj ulicę ({street}): ");
            houseNumber = digitalText.Input($"Modyfikuj numer domu ({houseNumber}): ");
            if (flatNumber == null)
                flatNumber = integer.Input("Podaj numer mieszkania: ");
            else
                flatNumber = integer.Input($"Modyfikuj numer mieszkania ({flatNumber}): ");

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

        public string ShowAll()
        {
            if (flatNumber != null)
                return $"{street} {houseNumber}/{flatNumber}, {postCode} {city}";
            else
                return $"{street} {houseNumber}, {postCode} {city}";
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
