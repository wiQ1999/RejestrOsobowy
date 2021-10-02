using System.Collections.Generic;
using System.Linq;

namespace RejestrOsobowy.Models
{
    public class PersonList : List<Person>
    {
        public IEnumerable<Person> Select(string value) => this.Where(x => x.IsSimilar(value));
    }
}
