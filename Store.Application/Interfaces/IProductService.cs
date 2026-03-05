using Store.Application.DTOs.Product;

namespace Store.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductCollectionResponseDTO> GetAllAsync(ProductCollectionRequestDTO request);
    }
}
