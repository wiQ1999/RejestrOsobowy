using InputValidator;

namespace RejestrOsobowy
{
    public class Address
    {
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int? FlatNumber { get; set; }

        public Address()
        {
            Validator validator = new Validator();

            PostCode = validator.Input<string>("Podaj kod pocztowy: ");
            City = validator.Input<string>("Podaj miasto: ");
            Street = validator.Input<string>("Podaj ulicę: ");
            HouseNumber = validator.Input<string>("Podaj numer domu: ");
            FlatNumber = validator.Input<int?>("Podaj numer mieszkania: ", true);
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
