namespace Brewer.Domain.Entities
{
    public class LegalPersonCustomer : Customer
    {
        public string Cnpj { get; set; }

        public override PersonType Type => PersonType.Legal;
    }
}
