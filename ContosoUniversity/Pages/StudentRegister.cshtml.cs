using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ContosoUniversity.Pages {
    public class StudentRegisterModel : PageModel {
        public ConnnectApi ConnApi;

        public StudentRegisterModel(IOptions<ConnnectApi> options) {
            ConnApi = options.Value;
        }


        public void OnGet() {

        }

        public void OnPostFirst(string lastname,string firstname) {
            Students student = new Students() {
                FirstMidName = firstname,
                LastName = lastname
            };
            string url = string.Format("{0}/StudentCRUD", ConnApi.WebApi);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/Json");
            request.AddParameter("application/Json", Tool.getHelper().SerializeObject(student), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            ViewData["studentsNew"] = Tool.getHelper().DeserializeJsonToObject<Students>(response.Content);
        }
    }
}