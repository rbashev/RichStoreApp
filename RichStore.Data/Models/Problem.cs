using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class Problem
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string CustomerId { get; set; }

        public RichStoreUser Customer { get; set; }

        public DateTime Date { get; set; }

        public bool NeedTechnician { get; set; }
    }
}
