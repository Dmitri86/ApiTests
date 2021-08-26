using RestSharp;

namespace ApiTestWithSpecflow.Steps
{
    public class BaseSteps
    {
        protected readonly RestClient Client = new("http://localhost:3000/");
        protected static IRestResponse Response;
    }
}