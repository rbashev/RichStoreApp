
using RichStore.Data.Models;
using RichStore.Services.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RichStore.Services
{
    public interface IOrderService
    {
        Task<bool> Create(OrderServiceModel orderServiceModel);

        IQueryable<Order> GetAllOrders();

        Task SetToReceipt(Receipt receipt);

        Task<bool> Complete(string orderId);

    }
}
