using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RestSharp;

namespace ContosoUniversity
{
    public class StudentModel : PageModel
    {
        public ConnnectApi ConnApi;
        public StudentModel(IOptions<ConnnectApi> option) {
            ConnApi = option.Value;
        }
        public void OnGet()
        {
            string url = string.Format("{0}/StudentCRUD", ConnApi.WebApi);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<Students> studentList = Tool.getHelper().DeserializeJsonToList<Students>(response.Content);
            ViewData["studentList"] = studentList;
        }
    }
}
