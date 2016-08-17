using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using LendLease.Models;
using LendLease.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace LendLease.Tests
{
    public class AddressesTests : IDisposable
    {
        public AddressesTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }


        public void Dispose()
        {
            _server.Dispose();
            _client.Dispose();
        }

        private readonly TestServer _server;
        private readonly HttpClient _client;

        private Address[] _addresses;
        private Address _address;

        private async Task<HttpResponseMessage> GetAllAddressesForCustomer(int id)
        {
            var requestUrl = string.Format("/api/addresses/customer/{0}", id);
            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _addresses = await response.Content.ReadAsAsync<Address[]>();
            return response;
        }

        private async Task<HttpResponseMessage> GetAllAddressesForCustomer(int cid, int id)
        {
            var requestUrl = string.Format("/api/addresses/{0}/customer/{1}", id, cid);
            var response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _address = await response.Content.ReadAsAsync<Address>();
            return response;
        }

        private async Task<HttpResponseMessage> CreateAddress(Address address)
        {
            var request = "/api/addresses";
            var response = await _client.PostAsJsonAsync(request, address);
            response.EnsureSuccessStatusCode();

            _address = await response.Content.ReadAsAsync<Address>();
            return response;
        }

        private async Task<HttpResponseMessage> UpdateAddress(Address address, string method)
        {
            var requestUrl = string.Format("/api/addresses/{0}", address.Id);
            var content = new ObjectContent<Address>(address, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod(method), requestUrl)
            {
                Content = content
            };
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }

        private async Task<HttpResponseMessage> RemovedAddress(int id)
        {
            var requestUrl = string.Format("/api/addresses/{0}", id);
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), requestUrl);
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task CreateAddress()
        {
            // Arrange
            var addressName = "Address 2";

            // Act
            var response = await CreateAddress(new Address {Name = addressName, CustomerId = 1});

            await GetAllAddressesForCustomer(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(addressName, _address.Name);
            Assert.NotEqual(0, _address.Id);
            Assert.NotEqual(2, _addresses.Length);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PatchUpdateAddress()
        {
            // Arrange
            var addressName = "Address Put";
            await GetAllAddressesForCustomer(1);
            var address = _addresses[0];
            address.Name = addressName;

            // Act
            var response = await UpdateAddress(address, "PATCH");
            await GetAllAddressesForCustomer(1);

            // Assert
            Assert.Equal(addressName, _addresses[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task PutUpdateAddress()
        {
            // Arrange
            var addressName = "Address Put";

            await GetAllAddressesForCustomer(1);
            var address = _addresses[0];
            address.Name = addressName;

            // Act
            var response = await UpdateAddress(address, "PUT");
            await GetAllAddressesForCustomer(1);

            // Assert
            Assert.Equal(addressName, _addresses[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task RemoveAddress()
        {
            // Arrange
            await CreateAddress(new Address {Name = "Test Address", CustomerId = 1});
            await GetAllAddressesForCustomer(1);
            var before = _addresses.Length;

            // Act
            var response = await RemovedAddress(2);
            await GetAllAddressesForCustomer(1);
            var after = _addresses.Length;

            // Assert
            Assert.Equal(before -1, after);
            Assert.NotEqual(0, _addresses.Length);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task ReturnAddressesForCustomer()
        {
            // Act
            var response = await GetAllAddressesForCustomer(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.NotEqual(0, _addresses.Length);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnAddressForCustomer()
        {
            // Act
            var response = await GetAllAddressesForCustomer(1, 1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(1, _address.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}