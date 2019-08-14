using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class RichStoreUser : IdentityUser
    {
        public RichStoreUser()
        {
            this.Orders = new List<Order>();
            this.Receipts = new List<Receipt>();
            this.Problems = new List<Problem>();
        }
        public string FullName { get; set; }

        public string OrderId { get; set; }
        public List<Order> Orders { get; set; }

        public string ProblemId { get; set; }
        public List<Problem> Problems { get; set; }

        public string ReceiptId { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
