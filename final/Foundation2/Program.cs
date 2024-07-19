using System;
class Program
{
    static void Main()
    {
        var address1 = new Address("123 Sakura St", "Kyoto", "JPKYT", "Japan");
        var address2 = new Address("456 Maple St", "Mapleton", "UT", "USA");

        var customer1 = new Customer("Makoto Fujita", address1);
        var customer2 = new Customer("Morgan Allen", address2);

        var product1 = new Product("Laptop", "L001", 999.99m, 1);
        var product2 = new Product("Mouse", "M001", 19.99m, 2);
        var product3 = new Product("Keyboard", "K001", 49.99m, 1);
        var product4 = new Product("Monitor", "MO001", 199.99m, 1);
        var product5 = new Product("Headphones", "H001", 79.99m, 1);

        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():0.00}\n");
    }
}
