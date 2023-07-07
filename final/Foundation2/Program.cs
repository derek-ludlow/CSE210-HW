using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        {
            // Create products
            Product product1 = new Product("Product 1", "P001", 10.99, 2);
            Product product2 = new Product("Product 2", "P002", 15.99, 1);

            // Create customer address
            Address customerAddress = new Address("123 Main St", "City", "State", "Country");

            // Create customer
            Customer customer = new Customer("John Doe", customerAddress);

            // Create order and add products
            Order order1 = new Order(customer);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            // Calculate and display order information
            Console.WriteLine("Order 1 Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Order 1 Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine("Order 1 Total Price: $" + order1.CalculateTotalPrice());
            Console.WriteLine();

            // Create another order
            Product product3 = new Product("Product 3", "P003", 5.99, 3);

            Order order2 = new Order(customer);
            order2.AddProduct(product3);

            // Calculate and display order information
            Console.WriteLine("Order 2 Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Order 2 Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine("Order 2 Total Price: $" + order2.CalculateTotalPrice());

            Console.ReadLine();
        }
    }
    class Order
    {
        private List<Product> products;
        private Customer customer;
        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += product.Price * product.Quantity;
            }

            totalPrice += customer.Address.IsInUSA() ? 5 : 35;

            return totalPrice;
        }
        public string GetPackingLabel()
        {
            string packingLabel = "Packing Label:\n";
            foreach (Product product in products)
            {
                packingLabel += "Product: " + product.Name + " (ID: " + product.ProductId + ")\n";
            }

            return packingLabel;
        }
        public string GetShippingLabel()
        {
            string shippingLabel = "Shipping Label:\n";
            shippingLabel += "Customer Name: " + customer.Name + "\n";
            shippingLabel += "Address: " + customer.Address.GetFullAddress();

            return shippingLabel;
        }
    }
    class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public string Name { get { return name; } }
        public string ProductId { get { return productId; } }
        public double Price { get { return price; } }
        public int Quantity { get { return quantity; } }

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }
    }
    class Customer
    {
        private string name;
        private Address address;

        public string Name { get { return name; } }
        public Address Address { get { return address; } }

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }
    }

    class Address
    {
        private string streetAddress;
        private string city;
        private string stateProvince;
        private string country;

        public Address(string streetAddress, string city, string stateProvince, string country)
        {
            this.streetAddress = streetAddress;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
        }
        public bool IsInUSA()
        {
            return country == "USA";
        }
        public string GetFullAddress()
        {
            return streetAddress + "\n" + city + ", " + stateProvince + "\n" + country;
        }
    }
}
