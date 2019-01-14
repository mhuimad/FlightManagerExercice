using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore;
using System.Threading.Tasks;

namespace FlightManager.Tests.Controller
{
    [TestClass]
    public class FlightControllerTest : BaseTestController
    {

        private TestServer testServer;
        protected HttpClient Client { get; private set; }



        [TestInitialize]
        public void Setup()
        {
            //IWebHostBuilder
            //testServer = new TestServer(new WebHostBuilder(). .CreateDefaultBuilder(null).UseStartup<FakeStartup>());
            testServer = new TestServer(new WebHostBuilder().UseStartup<FakeStartup>()); 
            
            Client = testServer.CreateClient();

        }

        [TestMethod]
        public async Task ShouldGetFlights()
        {

            var result = await Client.GetStringAsync($"flight");
        }
    }
}
