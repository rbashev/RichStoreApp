using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class Receipt
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string RecipientId { get; set; }

        public RichStoreUser Recipient { get; set; }


    }
}
