namespace CalotescuPractica.DataLayer.CSTPractica.Controllere
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public CartController(IRepository<Order> orderRepository, IRepository<MenuItem> menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
        }

        [HttpPost("AddToCart/{orderId}")]
        public IActionResult AddToCart(int orderId, [FromBody] OrderItem orderItem)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            var menuItem = _menuItemRepository.GetById(orderItem.MenuItemId);
            if (menuItem == null)
            {
                return NotFound("Menu item not found.");
            }

            orderItem.OrderId = orderId;
            orderItem.MenuItem = menuItem;
            order.OrderItems.Add(orderItem);
            _orderRepository.Update(order);
            _orderRepository.Save();
            return Ok("Item added to cart.");
        }

        [HttpDelete("RemoveFromCart/{orderItemId}")]
        public IActionResult RemoveFromCart(int orderItemId)
        {
            var orderItem = _orderRepository.GetAll().SelectMany(o => o.OrderItems).FirstOrDefault(oi => oi.OrderItemId == orderItemId);
            if (orderItem == null)
            {
                return NotFound("Order item not found.");
            }

            var order = _orderRepository.GetById(orderItem.OrderId);
            order.OrderItems.Remove(orderItem);
            _orderRepository.Save();
            return Ok("Item removed from cart.");
        }

        [HttpGet("GetCart/{orderId}")]
        public IActionResult GetCart(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order.OrderItems);
        }
    }

}
