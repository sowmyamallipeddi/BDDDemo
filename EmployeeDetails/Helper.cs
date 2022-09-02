using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;
        private const string baseUrl = "https://reqres.in/";

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            //client.ClientCertificates = new X509CertificateCollection() { certificate };
            //client.Proxy = new WebProxy();
            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("Accept", "application/json");
            return request;

        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }

        public static T GetContent<T>(RestResponse response)
        {
            var content= response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

    }
}
