using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Importing the necessary logging namespace
using RAD302Week3Lab12025CL.S00233992.DataModel;
using System;
using Tracker.WebAPIClient;

namespace RAD302Week3Lab12025CL.S00233992
{
    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Commented out previous activity message
            // ActivityAPIClient.Track(
            //     StudentID: "S00233992", 
            //     StudentName: "Your Name", 
            //     activityName: "Rad302 Week 3 Lab 1", 
            //     Task: "Creating Customer DB Schema"
            // );

            // Add the new Activity message with your ID and Name
            ActivityAPIClient.Track(
                StudentID: "S00233992", // Substitute your student ID here
                StudentName: "Vlad khokha", // Substitute your name here
                activityName: "Rad302 Week 3 Lab 1",
                Task: "Seeding Customer Data"
            );

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CustomerCoreDB-S00233992";
            optionsBuilder.UseSqlServer(myconnectionstring)
                          .LogTo(Console.WriteLine,
                              new[] { DbLoggerCategory.Database.Command.Name },
                              LogLevel.Information);
        }

        // Override OnModelCreating to seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { ID = 1, Name = "Patricia McKenna", Address = "8 Johnstown Road, Cork", CreditRating = 200.00F },
                new Customer { ID = 2, Name = "Helen Bennett", Address = "Garden House Crowther Way, Dublin", CreditRating = 400.00F },
                new Customer { ID = 3, Name = "Yoshi Tanami", Address = "1900 Oak St., Vancouver", CreditRating = 2000.00F },
                new Customer { ID = 4, Name = "John Steel", Address = "12 Orchestra Terrace, Dublin 20", CreditRating = 800.00F },
                new Customer { ID = 5, Name = "Catherine Dewey", Address = "Rue Joseph-Bens 532, Brussels", CreditRating = 600.00F }
            );
        }
    }
}
