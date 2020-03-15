namespace Brewer.Domain.Entities
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public short Number { get; set; }

        public string Complement { get; set; }

        public string Cep { get; set; }

        public int StateId { get; set; }
    }
}