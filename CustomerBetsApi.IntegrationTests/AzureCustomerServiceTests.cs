using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CustomerBetsApi.IntegrationTests
{
    [TestClass]
    public class AzureCustomerServiceTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new HttpClient();
        }

        [TestMethod]
        public void AzureCustomerEndpoint_Returns_Result()
        {
            _client.BaseAddress = new Uri("https://whatech-customerbets.azurewebsites.net");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("/api/GetCustomers?name=Test").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Assert.AreNotEqual(stringData, null);
        }
    }
}
