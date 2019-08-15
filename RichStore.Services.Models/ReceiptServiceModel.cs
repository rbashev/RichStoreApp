using System;

namespace RichStore.Services.Models
{
    public class ReceiptServiceModel
    {
        public DateTime IssuedOn { get; set; }

        public string OrderId { get; set; }

        public string RecipientId { get; set; }
    }
}