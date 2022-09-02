using EmployeeDetails;
using EmployeeDetails.Models;
using RestSharp;
using RestSharpDemo;
using System;
using TechTalk.SpecFlow;

namespace EmpSpecFlow.StepDefinitions
{
    [Binding]
    public class CreateEmployeesStepDefinitions
    {
        private const string Base_Url = "https://reqres.in/";
        private readonly CreateEmpReq createEmpReq;
        private RestResponse response;

        public CreateEmployeesStepDefinitions(CreateEmpReq createEmpReq)
        {
            this.createEmpReq = createEmpReq;
            
        }

        [Given(@"the name is ""([^""]*)""")]
        public void GivenTheNameIs(string name)
        {
            createEmpReq.name = name;
        }

        [Given(@"the job is ""([^""]*)""")]
        public void GivenTheJobIs(string role)
        {
            createEmpReq.job = role;
        }

        [When(@"the details are added")]
        public async void WhenTheDetailsAreAdded()
        {
            var api = new Demo();
            response = await api.CreateNewUser(Base_Url, createEmpReq);
        }

        [Then(@"Validate employee is created")]
        public void ThenValidateEmployeeIsCreated()
        {
            var content = Helper.GetContent<CreateEmpReq>(response);
            Assert.Equal(createEmpReq.name, content.name);
            Assert.Equal(createEmpReq.job, content.job);
        }
    }
}
