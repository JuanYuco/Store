using Store.Application.DTOs.Order;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Ports;

namespace Store.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IProductRepository productRepository) : IOrderService
    {
        public async Task<OrderByIdResponseDTO> GetOrderByIdAsync(OrderByIdRequestDTO requestDTO) {
            var response = new OrderByIdResponseDTO() { Successful = false };

            try
            {
                var order = await orderRepository.GetByIdAsync(requestDTO.OrderId);
                if (order == null)
                {
                    response.UserMessage = "La orden enviada no existe.";
                    response.HttpCode = 404;
                    return response;
                }

                response.Order = new OrderDTO
                {
                    CustomerName = order.CustomerName,
                    CreatedAt = order.CreatedAt,
                };

                foreach (var orderItem in order.OrderItems)
                {
                    response.Order.OrderItems.Add(new OrderItemInformationDTO
                    {
                        ProductId = orderItem.ProductId,
                        Price = orderItem.UnitPrice,
                        Quantity = orderItem.Quantity
                    });
                }

                response.Successful = true;
            }
            catch (Exception ex)
            {
                response.UserMessage = "Ocurrió un error consultando los productos.";
                response.HttpCode = 500;
                response.InternalError = ex.Message;
            }

            return response;
        }
        public async Task<OrderResponseDTO> CreateAsync(OrderRequestDTO request)
        {
            var response = new OrderResponseDTO() { Successful = false };

            try
            {
                var validationMessage = OrderValidation(request);
                if (!string.IsNullOrEmpty(validationMessage))
                {
                    response.UserMessage = validationMessage;
                    response.HttpCode = 400;
                    return response;
                }

                var productsIds = request.Items.Select(x => x.ProductId).Distinct().ToList();
                var products = await productRepository.GetCollectionByIdAsync(productsIds);
                if (products.Count != request.Items.Count)
                {
                    response.UserMessage = "Uno de los productos enviados no existe";
                    response.HttpCode = 400;
                    return response;
                }

                var dtNow = DateTime.Now;
                var order = new Domain.Entities.Order
                {
                    CustomerName = request.CustomerName,
                    CreatedAt = dtNow,
                };
                List<OrderItem> orderItems = new List<OrderItem>();
                foreach(var product in products)
                {
                    var totalQuantity = request.Items.Where(p => p.ProductId == product.Id).Sum(p => p.Quantity);
                    if (totalQuantity > product.Stock)
                    {
                        response.UserMessage = $"No hay stock suficiente para el producto {product.Name}";
                        response.HttpCode = 400;
                        return response;
                    }

                    orderItems.Add(new OrderItem
                    {
                        ProductId = product.Id,
                        Order = order,
                        Quantity = totalQuantity,
                        UnitPrice = product.Price
                    });
                }

                order.OrderItems = orderItems;
                var orderSaved = await orderRepository.CreateAsync(order);

                response.OrderId = orderSaved.Id;
                response.UserMessage = "El autor se creó correctamente.";
                response.Successful = true;
            }
            catch (Exception ex)
            {
                response.UserMessage = "Ocurrió un error al intentar crear el autor.";
                response.InternalError = ex.Message;
                response.HttpCode = 500;
            }

            return response;
        }

        private string OrderValidation(OrderRequestDTO order)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(order.CustomerName) || order.CustomerName.Length > 150)
            {
                errors.Add("El nombre del cliente es obligatorio y debe tener menos de 150 carácteres.");
            }

            if (order.Items.Count == 0)
            {
                errors.Add("La orden debe contener productos");
            }
            
            if (order.Items.Where(x => x.Quantity < 1).Any()){
                errors.Add("La cantidad de productos debe ser mayor a 0");
            }
            
            string message = "";
            if (errors.Count > 0)
            {
                message = string.Join(", ", errors);
            }

            return message;
        }
    }
}
