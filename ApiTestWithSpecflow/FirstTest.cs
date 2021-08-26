using System.Net;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace ApiTestWithSpecflow
{
    [TestFixture]
    public class FirstTest
    {
        private const string BaseUri = "http://localhost:3000/";
        private IRestClient Client;

        [SetUp]
        public void Initialize()
        {
            Client = new RestClient(BaseUri);
        }


        [Test]
        public void AuthorTest()
        {
            var request = new RestRequest("posts/{postId}", Method.GET);
            request.AddUrlSegment("postId", 1);

            var response = Client.Execute(request);
            var result = JsonConvert.DeserializeObject<Post>(response.Content);

            Assert.That(result?.author, Is.EqualTo("typicode"), "Author isn't correct");
        }

        [Test]
        public void CreateNewPostTest()
        {
            var newPost = new Post {title = "API", author = "Stepik"};
            var request = new RestRequest("posts", Method.POST);
            request.AddJsonBody(newPost);
            var response = Client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Request failed");
        }
    }
}