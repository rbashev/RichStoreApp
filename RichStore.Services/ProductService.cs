using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RichStore.Data;
using RichStore.Data.Models;
using RichStore.Services.Models;

namespace RichStore.Services
{
    public class ProductService : IProductService
    {
        private readonly RichStoreDbContext dbContext;

        public ProductService(RichStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(ProductServiceModel productServiceModel)
        {
            var categorieFromDb = this.dbContext.Categories.FirstOrDefault(x => x.Name == productServiceModel.Categorie);

            if (categorieFromDb == null)
            {
                throw new ArgumentNullException(nameof(categorieFromDb));
            }

            Product product = new Product
            {
                Model = productServiceModel.Model,
                Description = productServiceModel.Description,
                Price = productServiceModel.Price,
                Picture = productServiceModel.Picture

            };

            product.Categorie = categorieFromDb;
            dbContext.Products.Add(product);

            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            Product productFromDb = await this.dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (productFromDb == null)
            {
                throw new ArgumentNullException(nameof(productFromDb));
            }

            this.dbContext.Products.Remove(productFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Edit(string id, ProductServiceModel product)
        {
            Categorie categorieFromDb = await this.dbContext.Categories.FirstOrDefaultAsync(x => x.Name == product.Categorie);

            if (categorieFromDb == null)
            {
                throw new ArgumentNullException(nameof(categorieFromDb));
            }

            Product productFromDb = await this.dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (productFromDb == null)
            {
                throw new ArgumentNullException(nameof(productFromDb));
            }

            productFromDb.Model = product.Model;
            productFromDb.Price = product.Price;
            productFromDb.Picture = product.Picture;

            productFromDb.Categorie = categorieFromDb;

            this.dbContext.Products.Update(productFromDb);

            int result = await dbContext.SaveChangesAsync();

            return result > 0;

        }

        public  IQueryable<Product> GetAllProducts()
        {
            return this.dbContext.Products;
        }

        public async Task<ProductServiceModel> GetProductById(string id)
        {
            var productFromDb = await this.dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (productFromDb == null)
            {
                throw new ArgumentNullException(nameof(productFromDb));
            }
            ProductServiceModel product = new ProductServiceModel
            {
                Description = productFromDb.Description,
                Model = productFromDb.Model,
                Picture = productFromDb.Picture,
                Price = productFromDb.Price,
                Categorie = productFromDb.Categorie.Name
            };

            return product;
        }
    }
}
