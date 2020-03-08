namespace Brewer.Domain.Entities
{
    public abstract class Customer
    {
        public string Name { get; set; }

        public Phone Phone { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public abstract PersonType Type { get; }
    }
}