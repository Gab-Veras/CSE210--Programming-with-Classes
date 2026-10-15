using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // First order: the customer lives in the USA, so shipping is $5.
        Address address1 = new Address("123 Main Street", "Provo", "Utah", "USA");
        Customer customer1 = new Customer("Alex Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "N100", 3.50, 2));
        order1.AddProduct(new Product("Pen", "P205", 1.25, 4));

        // Second order: this customer lives outside the USA, so shipping is $35.
        Address address2 = new Address("45 Maple Road", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Jamie Lee", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Backpack", "B310", 28.00, 1));
        order2.AddProduct(new Product("Water Bottle", "W415", 12.50, 2));
        order2.AddProduct(new Product("Lunch Box", "L520", 9.00, 1));

        // Show labels and totals for both orders.
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total price: $" + order1.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture));

        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total price: $" + order2.GetTotalCost().ToString("F2", CultureInfo.InvariantCulture));
    }
}
