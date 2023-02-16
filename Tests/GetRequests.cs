using Newtonsoft.Json;
using RestSharp;
using RestSharpAutomationExerciseSite.Models;

namespace RestSharpAutomationExerciseSite.Tests
{
    public class GetRequests
    {

        string url = "https://automationexercise.com";

        [Test]
        public void GetAllProductsList()
        {
            // create a new client
            var client = new RestClient(url);

            // create a new request
            var request = new RestRequest("/api/productsList", Method.GET);

            // execute the GET request using IRestResponse
            IRestResponse response = client.Execute(request);

            // deserialize the JSON response into a Root POCO
            var root = JsonConvert.DeserializeObject<Root>(response.Content);

            // convert response to an int
            int statusCode = (int)response.StatusCode;

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(200), "Status code is not 200");
                Assert.That(root, Is.Not.Null);
                Assert.That(root.products, Has.Count.EqualTo(34));
                Assert.That(root.products[2], Has.Property("name").EqualTo("Sleeveless Dress"));
                Assert.That(root.products[2].category.usertype, Has.Property("usertype").EqualTo("Women"));
                Assert.That(root.products[4], Has.Property("brand").EqualTo("Mast & Harbour"));
            });
        }
    }
}