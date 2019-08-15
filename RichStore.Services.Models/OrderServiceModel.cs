using RichStore.Data.Models;
using System;

namespace RichStore.Services.Models
{
    public class OrderServiceModel
    {
        public DateTime DatePlaced { get; set; }

        public string ProductId { get; set; }

        public ProductServiceModel Product { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }
        public string OrdererId { get; set; }

        public RichStoreUserServiceModel Orderer { get; set; }
    }
}