using System;
using System.Collections.Generic;
using System.Text;

namespace RichStore.Services.Models
{
    public class CategorieServiceModel
    {
        public CategorieServiceModel()
        {
            this.Products = new List<ProductServiceModel>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public List<ProductServiceModel> Products { get; set; }
    }
}
