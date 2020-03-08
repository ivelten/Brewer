namespace Brewer.Domain.Entities
{
    public class Beer
    {
        public string Sku { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Value { get; set; }

        public decimal AlchoolContent { get; set; }

        public decimal Commission { get; set; }

        public int StockQuantity { get; set; }

        public Taste Taste { get; set; }
    }
}
