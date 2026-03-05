using Store.Application.DTOs.Common;

namespace Store.Application.DTOs.Order
{
    public class OrderByIdResponseDTO : CommonResponse
    {
        public OrderDTO Order { get; set; }
    }
}
