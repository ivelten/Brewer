using System;
using System.Collections.Generic;

namespace Brewer.Domain.Entities
{
    public class Sale
    {
        public DateTime CreationDate { get; set; }

        public decimal ShipmentValue { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal TotalValue { get; set; }

        public string Comments { get; set; }

        public DateTime DeliveryDate { get; set; }

        public SaleStatus Status { get; set; }

        public Customer Customer { get; set; }

        public List<SaleItem> Items { get; set; }
    }
}
