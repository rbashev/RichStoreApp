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
    public class CategorieService : ICategorieService
    {
        private readonly RichStoreDbContext dbContext;

        public CategorieService(RichStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Create(CategorieServiceModel categorieServiceModel)
        {
            Categorie categorie = new Categorie
            {
                Name = categorieServiceModel.Name
            };

            this.dbContext.Categories.Add(categorie);
            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var categorieFromDb = await this.dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (categorieFromDb == null)
            {
                throw new ArgumentNullException(nameof(categorieFromDb));
            }

            this.dbContext.Categories.Remove(categorieFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }


        public async Task<bool> Edit(string id, CategorieServiceModel categorieServiceModel)
        {
            var categorieFromDb = await this.dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (categorieFromDb == null)
            {
                throw new ArgumentNullException(nameof(categorieFromDb));
            }

            categorieFromDb.Name = categorieServiceModel.Name;

            this.dbContext.Update(categorieFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
