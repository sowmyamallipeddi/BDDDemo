﻿using EmployeeDetails;
using EmployeeDetails.Models;
using Newtonsoft.Json;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }
        public async Task<RestResponse> GetEmployee(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl("api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl("api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateEmpReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
