using System.Collections.Generic;
using ApiTestWithSpecflow.Steps;
using Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace ApiTestWithSpecflow
{
    [Binding]
    public class DeletePostSteps : BaseSteps
    {
        [Given(@"I perform DELETE operation for ""(.*)"" and id - ""(.*)""")]
        public void GivenIPerformDeleteOperationForAndId(string route, string id)
        {
            var request = new RestRequest($"{route}/{id}", Method.DELETE);
            Response = Client.Execute(request);
        }

        [Then(@"No records for ""(.*)"" with id ""(.*)"" exists")]
        public void ThenNoRecordsForWithIdExists(string route, string id)
        {
            var request = new RestRequest(route, Method.GET);
            var resp = Client.Execute(request);
            var posts = JsonConvert.DeserializeObject<IList<Post>>(resp.Content);
            if (posts == null) return;
            foreach (var post in posts)
            {
                Assert.That(post.id, Is.Not.EqualTo(int.Parse(id)), $"Record with {id} exists");
            }
        }
    }
}