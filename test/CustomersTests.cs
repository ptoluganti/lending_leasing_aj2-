using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using LendLease.Models;
using Xunit;

namespace LendLease.Tests
{
    public class CustomersTests : TestBase
    {
        

        
        private Customer[] _customers;
        private Customer _customer;

        private async Task<HttpResponseMessage> GetAllCustomers()
        {
            var request = "/api/customers";
            var response = await Client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            _customers = await response.Content.ReadAsAsync<Customer[]>();
            return response;
        }

        private async Task<HttpResponseMessage> CreateCustomer(Customer custome)
        {
            var request = "/api/customers";
            var response = await Client.PostAsJsonAsync(request, custome);
            response.EnsureSuccessStatusCode();

            _customer = await response.Content.ReadAsAsync<Customer>();
            return response;
        }

        private async Task<HttpResponseMessage> GetCustomer(int id)
        {
            var requestUrl = string.Format("/api/customers/{0}", id);
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _customer = await response.Content.ReadAsAsync<Customer>();
            return response;
        }

        private async Task<HttpResponseMessage> UpdateCustomer(Customer custome, string method)
        {
            var requestUrl = string.Format("/api/customers/{0}", custome.Id);
            var content = new ObjectContent<Customer>(custome, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod(method), requestUrl)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task CreateCustomer()
        {
            // Arrange
            var customerName = "Test Customer 2";

            // Act
            var response = await CreateCustomer(new Customer {Name = customerName});

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(customerName, _customer.Name);
            Assert.NotEqual(0, _customer.Id);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PatchUpdateCustomer()
        {
            // Arrange
            var customerName = "Test Customer Patch";
            await GetAllCustomers();
            var customer = _customers[0];
            customer.Name = customerName;

            // Act
            var response = await UpdateCustomer(customer, "PATCH");
            await GetAllCustomers();

            // Assert
            Assert.Equal(customerName, _customers[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task PutUpdateCustomer()
        {
            // Arrange
            var customerName = "Test Customer Put";
            await GetAllCustomers();
            var customer = _customers[0];
            customer.Name = customerName;

            // Act
            var response = await UpdateCustomer(customer, "PUT");
            await GetAllCustomers();

            // Assert
            Assert.Equal(customerName, _customers[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task ReturnCustomer()
        {
            // Act
            var response = await GetCustomer(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(1, _customer.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnCustomers()
        {
            // Act
            var response = await GetAllCustomers();

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.NotEqual(0, _customers.Length);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}