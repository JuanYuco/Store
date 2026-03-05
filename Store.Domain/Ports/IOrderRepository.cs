using Store.Domain.Entities;

namespace Store.Domain.Ports
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<Order?> GetByIdAsync(int id);
    }
}
