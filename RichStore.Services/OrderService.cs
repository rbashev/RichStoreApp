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
    public class OrderService : IOrderService
    {
        private readonly RichStoreDbContext dbContext;

        public OrderService(RichStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Complete(string orderId)
        {
            var orderFromDb = await this.dbContext.Orders.SingleOrDefaultAsync(x => x.Id == orderId);

            if (orderFromDb == null || orderFromDb.Status != OrderStatus.Active)
            {
                throw new ArgumentException(nameof(orderFromDb));
            }

            orderFromDb.Status = OrderStatus.Completed;

            this.dbContext.Update(orderFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Create(OrderServiceModel orderServiceModel)
        {
            Order order = new Order
            {
                Status = OrderStatus.Active,
                DatePlaced = DateTime.UtcNow,
                Quantity = orderServiceModel.Quantity
            };

            this.dbContext.Orders.Add(order);
            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return this.dbContext.Orders;
        }

        public async Task SetToReceipt(Receipt receipt)
        {
            var orderFromDb = await this.dbContext.Orders.SingleOrDefaultAsync(x => x.OrdererId == receipt.RecipientId && x.Status == OrderStatus.Active);

            receipt.Order = orderFromDb;
        }
    }
}
