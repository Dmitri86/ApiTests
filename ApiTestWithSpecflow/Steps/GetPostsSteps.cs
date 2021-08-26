using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace ApiTestWithSpecflow.Steps
{
    [Binding]
    public class GetPostsSteps : BaseSteps
    {
        public RestRequest Request;
        private IDictionary<string, string> _actualPost;

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string uri)
        {
            Request = new RestRequest(uri, Method.GET);
        }
        
        
        [Given(@"I perform operation ""(.*)"" for post ""(.*)""")]
        public void GivenIPerformOperationForPost(string rout, string value)
        {
            Request.AddUrlSegment(rout, value);
            var response = Client.Execute(Request);
            _actualPost = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }
        

        [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
        public void ThenIShouldSeeTheNameAs(string key, string value)
        {
            Assert.That(_actualPost[key], Is.EqualTo(value), "Author isn't correct");
        }
    }
}