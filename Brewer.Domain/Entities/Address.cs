namespace Brewer.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; }

        public short Number { get; set; }

        public string Complement { get; set; }

        public string Cep { get; set; }

        public State State { get; set; }
    }
}