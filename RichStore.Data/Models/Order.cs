using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime DatePlaced { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public OrderStatus Status { get; set; }

        public int Quantity { get; set; }

        public string OrdererId { get; set; }

        public RichStoreUser Orderer { get; set; }
    }
}
