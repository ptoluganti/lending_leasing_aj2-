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

        public ApplicationFixture()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .UseStartup<Startup>());

            Client = _server.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}