using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LendLease.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace LendLease.Tests
{
    public class CustomersControllerTests
    {
        public CustomersControllerTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        private readonly TestServer _server;
        private readonly HttpClient _client;

        //[Fact]
        //public async Task ReturnHelloWorld()
        //{
        //    // Act
        //    var response = await _client.GetAsync("/api/Customers");
        //    response.EnsureSuccessStatusCode();

        //    var responseString = await response.Content.ReadAsStringAsync();


        //    // Assert
        //    var expectedString = JsonConvert.SerializeObject(new[] {"value1", "value2"});
        //    Assert.Equal(expectedString, responseString);
        //}


        [Fact]
        public async Task ReturnCustomers()
        {
            // Act
            var request = "/api/customers";
            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            //var customers = await response.Content.ReadAsAsync<Customer[]>();

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}