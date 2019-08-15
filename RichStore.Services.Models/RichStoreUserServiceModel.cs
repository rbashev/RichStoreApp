using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RichStore.Services.Models
{
    public class RichStoreUserServiceModel : IdentityUser
    {
        public string FullName { get; set; }

        public string OrderId { get; set; }
        public List<OrderServiceModel> Orders { get; set; }

        public string ProblemId { get; set; }
        public List<ProblemServiceModel> Problems { get; set; }

        public string ReceiptId { get; set; }
        public List<ReceiptServiceModel> Receipts { get; set; }
    }
}