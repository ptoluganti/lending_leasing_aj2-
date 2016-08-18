using System;
using System.Net.Http;
using LendLease.Data;
using LendLease.Models;
using LendLease.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;

namespace LendLease.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());
            Client = _server.CreateClient();

            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseInMemoryDatabase();
            //using (var context = new ApplicationDbContext(optionsBuilder.Options))
            //{
            //    context.Customers.Add(new Customer { Name = "Test Customer 1" });
            //    context.Customers.Add(new Customer { Name = "Test Customer 2" });
            //    context.Addresses.Add(new Address { Name = "Address 1", CustomerId = 1 });
            //    context.Addresses.Add(new Address { Name = "Address 2", CustomerId = 1 });
            //    context.Addresses.Add(new Address { Name = "Address 1", CustomerId = 2 });
            //    context.Payments.Add(new Payment
            //    {
            //        Name = "Payment 1",
            //        AddressId = 1,
            //        ScheduledAmount = 100,
            //        ScheduledDate = DateTime.Today.AddDays(30)
            //    });
            //    context.Payments.Add(new Payment
            //    {
            //        Name = "Payment 1",
            //        AddressId = 2,
            //        ScheduledAmount = 200,
            //        ScheduledDate = DateTime.Today.AddDays(30)
            //    });
            //    context.Payments.Add(new Payment
            //    {
            //        Name = "Payment 1",
            //        AddressId = 3,
            //        ScheduledAmount = 300,
            //        ScheduledDate = DateTime.Today.AddDays(30)
            //    });
            //    context.Payments.Add(new Payment
            //    {
            //        Name = "Payment 2",
            //        AddressId = 2,
            //        ScheduledAmount = 200,
            //        ScheduledDate = DateTime.Today.AddDays(30)
            //    });
            //    context.SaveChanges();
            //}
        }
        public void Dispose()
        {
            _server.Dispose();
            Client.Dispose();
        }

        private readonly TestServer _server;
        protected readonly HttpClient Client;
    }
}