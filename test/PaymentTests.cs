using System;
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
            var requestUrl = string.Format("/api/payments/address/{0}", id);
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _payments = await response.Content.ReadAsAsync<Payment[]>();
            return response;
        }

        private async Task<HttpResponseMessage> GetAllPaymentForAddress(int aid, int id)
        {
            var requestUrl = string.Format("/api/payments/{0}/address/{1}", id, aid);
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            _payment = await response.Content.ReadAsAsync<Payment>();
            return response;
        }

        private async Task<HttpResponseMessage> CreatePayment(Payment payment)
        {
            var request = "/api/payments";
            var response = await Client.PostAsJsonAsync(request, payment);
            response.EnsureSuccessStatusCode();

            _payment = await response.Content.ReadAsAsync<Payment>();
            return response;
        }

        private async Task<HttpResponseMessage> UpdatePayment(Payment payment, string method)
        {
            var requestUrl = string.Format("/api/payments/{0}", payment.Id);
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
            var requestUrl = string.Format("/api/payments/{0}", id);
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), requestUrl);
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task CreatePayment()
        {
            // Arrange
            var paymentName = "Payment 2";

            // Act
            var response = await CreatePayment(new Payment
            {
                Name = paymentName,
                AddressId = 1,
                ScheduledAmount = 100,
                ScheduledDate = DateTime.Today.AddDays(30)
            });

            await GetAllPaymentesForAddress(1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(paymentName, _payment.Name);
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
            var payment = _payments[0];
            payment.Name = PaymentName;

            // Act
            var response = await UpdatePayment(payment, "PATCH");
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
            var payment = _payments[0];
            payment.Name = PaymentName;

            // Act
            var response = await UpdatePayment(payment, "PUT");
            await GetAllPaymentesForAddress(1);

            // Assert
            Assert.Equal(PaymentName, _payments[0].Name);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task RemovePayment()
        {
            // Arrange
            await CreatePayment(new Payment
            {
                Name = "Test payment",
                AddressId = 1,
                ScheduledAmount = 100,
                ScheduledDate = DateTime.Today.AddDays(30)
            });
            await GetAllPaymentesForAddress(2);
            var before = _payments.Length;

            // Act
            var response = await RemovedPayment(1);
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
            var response = await GetAllPaymentForAddress(1, 1);

            // Assert
            Assert.NotNull(response.Content);
            Assert.Equal(JsonMediaTypeFormatter.DefaultMediaType.MediaType,
                response.Content.Headers.ContentType.MediaType);
            Assert.Equal(1, _payment.Id);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}