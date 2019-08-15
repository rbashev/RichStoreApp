using RichStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichStore.Services
{
    public interface IReceiptService
    {
        Task<bool> Create(string id);

        IQueryable<Receipt> GetAll();

        IQueryable<Receipt> GetAllForSingleRecipient(string id);
    }
}
