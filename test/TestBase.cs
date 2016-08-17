using System;
using System.Net.Http;
using LendLease.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

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