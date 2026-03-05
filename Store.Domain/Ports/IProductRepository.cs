using Store.Domain.Entities;

namespace Store.Domain.Ports
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetCollectionByIdAsync(List<int> ids);
    }
}
