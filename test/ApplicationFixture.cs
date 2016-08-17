using System;
using System.Net.Http;
using LendLease.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace LendLease.Tests
{
    public class ApplicationFixture : IDisposable
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public ApplicationFixture()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
        }

        public HttpClient Client { get; private set; }
    }
}