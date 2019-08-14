using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Data.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string CategorieId { get; set; }
        public Categorie Categorie { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

    }
}
