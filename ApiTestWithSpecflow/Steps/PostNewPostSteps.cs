using System.Collections.Generic;
using System.Linq;
using System.Net;
using ApiTestWithSpecflow.Steps;
using Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace ApiTestWithSpecflow
{
    [Binding]
    public class PostNewPostSteps : BaseSteps
    {
        [Given(@"I perform POST operation for ""(\w*)""")]
        public void GivenIPerformPostOperationFor(string route)
        {
            var newPost = new Post {title = "Test", author = "Test"};
            var request = new RestRequest(route, Method.POST);
            request.AddJsonBody(newPost);
            Response = Client.Execute(request);
        }

        [Then(@"The response status code ""(.*)""")]
        public void ThenTheResponseStatusCode(HttpStatusCode expectedStatusCode)
        {
           Assert.That(Response.StatusCode, Is.EqualTo(expectedStatusCode), "Response status code isn't correct");
        }

        [Given(@"I perform POST operation for ""(.*)"" with parameters title ""(.*)"" and ""(.*)""")]
        public void GivenIPerformPostOperationForWithParametersTitleAnd(string route, string title, string author)
        {
            var body = new Post {title = title, author = author};
            var request = new RestRequest(route, Method.POST);
            request.AddJsonBody(body);
            Response = Client.Execute(request);
        }

        [When(@"The response status code ""(.*)""")]
        public void WhenTheResponseStatusCode(HttpStatusCode code)
        {
            Assert.That(Response.StatusCode, Is.EqualTo(code), "Response status code isn't correct");
        }

        [Then(@"Last record for ""(.*)"" has title - ""(.*)"" and author - ""(.*)""")]
        public void ThenLastRecordForHasTitleAndAuthor(string route, string title, string author)
        {
            var request = new RestRequest(route, Method.GET);
            var resp = Client.Execute(request);
            var actualObject = JsonConvert.DeserializeObject<IList<Post>>(resp.Content);
            Assert.That(actualObject?.Last(), Is.EqualTo(new Post{title =  title, author =  author}), "Last record isn't correct");
        }
    }
}