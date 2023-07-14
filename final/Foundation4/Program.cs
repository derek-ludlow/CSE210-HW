using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a Product object
        Product product = new Product("12345", "Example Product", 9.99m);

        // Create a Customer object
        Customer customer = new Customer("John Doe", "johndoe@example.com");

        // Create an Order object
        Order order = new Order(DateTime.Now, customer);
        order.AddProduct(product, 2); // Add two products to the order

        // Calculate and display the total price
        decimal totalPrice = order.CalculateTotalPrice();
        Console.WriteLine($"Total Price: {totalPrice:C}");

        // Generate and display the packing label
        string packingLabel = order.GeneratePackingLabel();
        Console.WriteLine("Packing Label:");
        Console.WriteLine(packingLabel);

        // Generate and display the shipping label
        string shippingLabel = order.GenerateShippingLabel();
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(shippingLabel);

        Console.ReadLine();
    }
}

class Product
{
    public string ProductId { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(string productId, string name, decimal price)
    {
        ProductId = productId;
        Name = name;
        Price = price;
    }
}

class Customer
{
    public string Name { get; }
    public string Email { get; }
    public object Address { get; internal set; }

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

class Order
{
    public DateTime OrderDate { get; }
    public Customer Customer { get; }
    public decimal ShippingCost { get; }

    private readonly List<(Product product, int quantity)> items;

    public Order(DateTime orderDate, Customer customer)
    {
        OrderDate = orderDate;
        Customer = customer;
        ShippingCost = CalculateShippingCost();
        items = new List<(Product product, int quantity)>();
    }

    public void AddProduct(Product product, int quantity)
    {
        items.Add((product, quantity));
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var item in items)
        {
            totalPrice += item.product.Price * item.quantity;
        }
        totalPrice += ShippingCost;
        return totalPrice;
    }

    public string GeneratePackingLabel()
    {
        string packingLabel = $"Customer: {Customer.Name}\nOrder Date: {OrderDate}\n\nProducts:";
        foreach (var item in items)
        {
            packingLabel += $"\n- {item.product.Name} (Quantity: {item.quantity})";
        }
        return packingLabel;
    }

    public string GenerateShippingLabel()
    {
        string shippingLabel = $"Customer: {Customer.Name}\nEmail: {Customer.Email}\n\nShipping Address:\n{Customer.Address}\n\nOrder Date: {OrderDate}";
        return shippingLabel;
    }

    private decimal CalculateShippingCost()
    {
        // You can implement your own shipping cost calculation logic here
        return 5.00m;
    }
}
