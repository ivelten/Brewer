namespace Brewer.Domain.Entities
{
    public class SaleItem
    {
        public int Quantity { get; set; }

        public decimal UnitValue { get; set; }

        public Sale Sale { get; set; }
    }
}
