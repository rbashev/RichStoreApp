using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichStore.Data;
using RichStore.Data.Models;

namespace RichStore.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly RichStoreDbContext dbContext;
        private readonly IOrderService orderService;

        public ReceiptService(RichStoreDbContext dbContext, IOrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }
        public async Task<bool> Create(string id)
        {
            Receipt receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                RecipientId = id
            };

            await this.orderService.SetToReceipt(receipt);

            await this.orderService.Complete(receipt.OrderId);

            this.dbContext.Receipts.Add(receipt);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.dbContext.Receipts;
        }

        public IQueryable<Receipt> GetAllForSingleRecipient(string id)
        {
            return this.dbContext.Receipts.Where(x => x.RecipientId == id);
        }
    }
}
