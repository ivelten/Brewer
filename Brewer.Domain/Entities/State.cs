using System.Collections.Generic;

namespace Brewer.Domain.Entities
{
    public class State
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}