using Tracker.WebAPIClient;

namespace Console.s00233992;

using RAD302Week3Lab12025CL.S00233992;
using RAD302Week3Lab12025CL.S00233992.DataModel;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Track the activity
        ActivityAPIClient.Track(
            StudentID: "S00233992",
            StudentName: "Vlad khokha",
            activityName: "Rad302 Week 3 Lab 1",
            Task: "Testing Console Queries against the DB Model"
        );

        // Create DbContext instance
        using var context = new CustomerDBContext();

        
        var allCustomers = context.Customers.ToList();
        Console.WriteLine("All Customers in Database:");
        foreach (var customer in allCustomers)
        {
            Console.WriteLine($"{customer.ID}: {customer.Name}, {customer.Address}, Credit Rating: {customer.CreditRating}");
        }

     
        var customersOver400 = context.Customers.Where(c => c.CreditRating > 400).ToList();
        Console.WriteLine("\nCustomers with Credit Rating > 400:");
        foreach (var customer in customersOver400)
        {
            Console.WriteLine($"{customer.Name}: {customer.CreditRating}");
        }


     
        var newCustomer = new Customer
        {
            Name = "test customer",
            Address = "ATU SLIGO",
            CreditRating = 500.00F
        };

        // Add and save the new customer
        context.Customers.Add(newCustomer);
        context.SaveChanges();

        Console.WriteLine("\nNew Customer added to the squad!");
    }
}