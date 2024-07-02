using Microsoft.AspNetCore.Mvc;

namespace CalotescuPractica.DataLayer.CSTPractica.Controllere
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;

        public OrdersController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart([FromBody] OrderItem orderItem)
        {
            // Add logic to add item to cart
            var order = _orderRepository.GetById(orderItem.OrderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.OrderItems.Add(orderItem);
            _orderRepository.Update(order);
            _orderRepository.Save();
            return Ok("Item added to cart.");
        }

        [HttpPost("RemoveFromCart")]
        public IActionResult RemoveFromCart(int orderItemId)
        {
            // Add logic to remove item from cart
            var orderItem = _orderRepository.GetAll().SelectMany(o => o.OrderItems).FirstOrDefault(oi => oi.OrderItemId == orderItemId);
            if (orderItem == null)
            {
                return NotFound("Order item not found.");
            }

            _orderRepository.GetById(orderItem.OrderId).OrderItems.Remove(orderItem);
            _orderRepository.Save();
            return Ok("Item removed from cart.");
        }

        [HttpPost("PlaceOrder")]
        public IActionResult PlaceOrder(int orderId)
        {
            // Add logic to place order
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.Status = OrderStatus.Placed;
            _orderRepository.Update(order);
            _orderRepository.Save();
            return Ok("Order placed successfully.");
        }

        [HttpPost("CancelOrder")]
        public IActionResult CancelOrder(int orderId)
        {
            // Add logic to cancel order
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.Status = OrderStatus.Cancelled;
            _orderRepository.Update(order);
            _orderRepository.Save();
            return Ok("Order cancelled successfully.");
        }

        [HttpGet("GetOrdersHistory")]
        public IActionResult GetOrdersHistory(int userId)
        {
            // Add logic to get order history
            var orders = _orderRepository.GetAll().Where(o => o.UserId == userId).ToList();
            return Ok(orders);
        }

        [HttpPost("ReinitiateOrder")]
        public IActionResult ReinitiateOrder(int orderId)
        {
            // Add logic to reinitiate order
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            var newOrder = new Order
            {
                UserId = order.UserId,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Placed,
                OrderItems = order.OrderItems.Select(oi => new OrderItem
                {
                    MenuItemId = oi.MenuItemId,
                    Quantity = oi.Quantity
                }).ToList()
            };

            _orderRepository.Insert(newOrder);
            _orderRepository.Save();
            return Ok("Order reinitiated successfully.");
        }

        [HttpPost("GiveTip")]
        public IActionResult GiveTip(int orderId, decimal tip)
        {
            // Add logic to give tip
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            order.Tip = tip;
            _orderRepository.Update(order);
            _orderRepository.Save();
            return Ok("Tip given successfully.");
        }
    }

}
