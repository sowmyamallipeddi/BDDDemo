using EmployeeDetails;
using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users?page=2");
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;
            //Console.WriteLine(content);
            var json = JsonConvert.DeserializeObject(content);
            Console.WriteLine(json);
            Console.ReadKey();
            Employee user = JsonConvert.DeserializeObject<Employee>(content);
            foreach (var item in user.data)
            {

                Console.WriteLine(item.first_name);

            }
        }
    }
}
