using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http.Headers;

namespace CustomerBetsApi.AcceptanceTests
{
    [TestClass]
    public class CustomerBetsApiTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = new HttpClient();
        }

        [TestMethod]
        public void CustomerEndpoint_Returns_Result()
        {
            _client.BaseAddress = new Uri("http://localhost:3095/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("customer").Result;
            string stringData = response.Content.ReadAsStringAsync().Result;
            Assert.AreNotEqual(stringData, null);
        }
    }
}
