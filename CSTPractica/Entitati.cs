namespace CalotescuPractica.DataLayer.CSTPractica
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }

    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MenuItem> ProductCategory { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Courier { get; set; }
        public decimal Tip { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Rating { get; set; } // Rating pe o scară de la 1 la 5
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
    public class Courier
    {
        public int CourierId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public enum OrderStatus
    {
        Placed,
        Cancelled,
        Completed
    }

}
