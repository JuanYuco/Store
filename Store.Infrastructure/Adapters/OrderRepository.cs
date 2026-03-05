using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Ports;

namespace Store.Infrastructure.Adapters
{
    public class OrderRepository(AppDbContext dbContext) : IOrderRepository
    {
        public async Task<Order> CreateAsync(Order order)
        {
            var orderEntry = await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return orderEntry.Entity;
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await dbContext.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
