using RichStore.Data.Models;
using RichStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichStore.Services
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts();

        Task<ProductServiceModel> GetProductById(string id);

        Task<bool> Create(ProductServiceModel productServiceModel);

        Task<bool> Edit(string id, ProductServiceModel productServiceModel);

        Task<bool> Delete(string id);
    }
}
