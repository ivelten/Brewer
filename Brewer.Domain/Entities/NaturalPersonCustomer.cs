namespace Brewer.Domain.Entities
{
    public class NaturalPersonCustomer : Customer
    {
        public string Cpf { get; set; }

        public override PersonType Type => PersonType.Natural;
    }
}
