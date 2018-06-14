using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoUniversity
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpPost ("setSession/{firstname}/{lastname}")]
        // GET: /<controller>/
        public IActionResult Index(string firstname, string lastname)
        {
            var user = new Students() {FirstMidName = "111111", LastName = "22222" };
            HttpContext.Session.SetObject("studentinfo",user);
            ;
            return new JsonResult(HttpContext.Session.GetObject<Students>("studentinfo"));
        }

        [HttpGet("getSession")]
        public IActionResult getSession()
        {
            return new JsonResult(HttpContext.Session.GetObject<Students>("studentinfo"));
        }
    }
}
