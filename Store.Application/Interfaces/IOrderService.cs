using Store.Application.DTOs.Order;

namespace Store.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateAsync(OrderRequestDTO request);
        Task<OrderByIdResponseDTO> GetOrderByIdAsync(OrderByIdRequestDTO requestDTO);
    }
}
