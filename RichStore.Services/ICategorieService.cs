using RichStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RichStore.Services
{
    public interface ICategorieService
    {
        Task<bool> Create(CategorieServiceModel categorieServiceModel);

        Task<bool> Edit(string id, CategorieServiceModel categorieServiceModel);

        Task<bool> Delete(string id);
    }
}
