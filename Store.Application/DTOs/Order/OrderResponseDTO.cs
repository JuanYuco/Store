using Store.Application.DTOs.Common;

namespace Store.Application.DTOs.Order
{
    public class OrderResponseDTO : CommonResponse
    {
        public int OrderId { get; set; }
    }
}
