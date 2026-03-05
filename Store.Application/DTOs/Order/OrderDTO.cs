namespace Store.Application.DTOs.Order
{
    public class OrderDTO
    {
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemInformationDTO> OrderItems { get; set; } = new List<OrderItemInformationDTO>();

    }

    public class OrderItemInformationDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
