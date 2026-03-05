using Store.Application.DTOs.Product;
using Store.Application.Interfaces;
using Store.Domain.Ports;

namespace Store.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<ProductCollectionResponseDTO> GetAllAsync(ProductCollectionRequestDTO request)
        {
            var response = new ProductCollectionResponseDTO() { Successful = false };

            try
            {
                var products = await productRepository.GetAllAsync();
                foreach (var product in products)
                {
                    response.Products.Add(new ProductDTO
                    {
                        Id = product.Id, 
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    });
                }

                response.Successful = true;
            } catch (Exception ex)
            {
                response.UserMessage = "Ocurrió un error consultando los productos.";
                response.HttpCode = 500;
                response.InternalError = ex.Message;
            }

            return response;
        }
    }
}
