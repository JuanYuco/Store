namespace Store.Application.DTOs.Order
{
    public class OrderRequestDTO
    {
        public string CustomerName { get; set; }
        public List<OrderItemsDTO> Items { get; set; }
    }

    public class OrderItemsDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
