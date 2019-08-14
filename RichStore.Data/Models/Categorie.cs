using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class Categorie
    {
        public Categorie()
        {
            this.Products = new List<Product>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
