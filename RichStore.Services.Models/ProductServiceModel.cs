using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Services.Models
{
    public class ProductServiceModel
    {
        public string Model { get; set; }

        public string Categorie { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }
    }
}
