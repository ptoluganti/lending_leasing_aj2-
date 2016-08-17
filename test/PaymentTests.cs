using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using LendLease.Models;
using Xunit;

namespace LendLease.Tests
{
    public class PaymentTests : TestBase
    {
        private Payment[] _payments;
        private Payment _payment;

        private async Task<HttpResponseMessage> GetAllPaymentesForAddress(int id)
        {
            var requestUrl = string.Format("/api/Paymentes/Address/{0}", id);
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _payments = await response.Content.ReadAsAsync<Payment[]>();
            return response;
        }

        private async Task<HttpResponseMessage> GetAllPaymentesForAddress(int cid, int id)
        {
            var requestUrl = string.Format("/api/Paymentes/{0}/Address/{1}", id, cid);
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _payment = await response.Content.ReadAsAsync<Payment>();
            return response;
        }

        private async Task<HttpResponseMessage> CreatePayment(Payment payment)
        {
            var request = "/api/Paymentes";
            var response = await Client.PostAsJsonAsync(request, payment);
            response.EnsureSuccessStatusCode();

            _payment = await response.Content.ReadAsAsync<Payment>();
            return response;
        }

        private async Task<HttpResponseMessage> UpdatePayment(Payment payment, string method)
        {
            var requestUrl = string.Format("/api/Paymentes/{0}", payment.Id);
            var content = new ObjectContent<Payment>(payment, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod(method), requestUrl)
            {
                Content = content
            };
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }

        private async Task<HttpResponseMessage> RemovedPayment(int id)
        {
            var requestUrl = string.Format("/api/Paymentes/{0}", id);
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), requestUrl);
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task CreatePayment()
        {
            // Arrange
            var PaymentName = "Payment 2";

            // Act
            var response = await CreatePayment(new Payment { Name = PaymentName, AddressId = 1 });

            await GetAllPaymentesForAddress(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(PaymentName, _payment.Name);
            Assert.NotEqual(0, _payment.Id);
            Assert.NotEqual(2, _payments.Length);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task PatchUpdatePayment()
        {
            // Arrange
            var PaymentName = "Payment Put";
            await GetAllPaymentesForAddress(1);
            var Payment = _payments[0];
            Payment.Name = PaymentName;

            // Act
            var response = await UpdatePayment(Payment, "PATCH");
            await GetAllPaymentesForAddress(1);

            // Assert
            Assert.Equal(PaymentName, _payments[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task PutUpdatePayment()
        {
            // Arrange
            var PaymentName = "Payment Put";

            await GetAllPaymentesForAddress(1);
            var Payment = _payments[0];
            Payment.Name = PaymentName;

            // Act
            var response = await UpdatePayment(Payment, "PUT");
            await GetAllPaymentesForAddress(1);

            // Assert
            Assert.Equal(PaymentName, _payments[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task RemovePayment()
        {
            // Arrange
            await CreatePayment(new Payment { Name = "Test Payment", AddressId = 1 });
            await GetAllPaymentesForAddress(1);
            var before = _payments.Length;

            // Act
            var response = await RemovedPayment(2);
            await GetAllPaymentesForAddress(1);
            var after = _payments.Length;

            // Assert
            Assert.Equal(before - 1, after);
            Assert.NotEqual(0, _payments.Length);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }


        [Fact]
        public async Task ReturnPaymentesForAddress()
        {
            // Act
            var response = await GetAllPaymentesForAddress(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.NotEqual(0, _payments.Length);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnPaymentForAddress()
        {
            // Act
            var response = await GetAllPaymentesForAddress(1, 1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(1, _payment.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}