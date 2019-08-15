using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Services.Models
{
    public class ProblemServiceModel
    {
        public string Description { get; set; }

        public string CustomerId { get; set; }


        public DateTime Date { get; set; }

        public bool NeedTechnician { get; set; }
    }
}
