using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Ports;

namespace Store.Infrastructure.Adapters
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetCollectionByIdAsync(List<int> ids)
        {
            return await dbContext.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }
    }
}
