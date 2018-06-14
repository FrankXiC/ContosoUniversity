using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Api.Interface;
using ContosoUniversity.Interface;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCRUDController : ControllerBase
    {
        public Connection conn;

        public StudentCRUDController(IOptions<Connection>options)
        {
            conn = options.Value;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<Students>> Get()
        {
            IStudentSelect studentSelect = new StudentSelect(conn);
            var studentlist = studentSelect.SelectAllStudent();
            return studentlist;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Students> Get(int id)
        {
            TestContext testContext = new TestContext(conn);
            var student = (from stu in testContext.Students where stu.Id==id select stu).ToList().FirstOrDefault();
            testContext.Dispose();
            return student;
        }

        // POST api/values
        [HttpPost]
        public Students Post([FromBody] Students student)
        {
            IStudentRegister studentRegister=new StudentRegister(conn);
            var studentNew = studentRegister.Register(student);
            return studentNew;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Students student)
        {
            TestContext testContext = new TestContext(conn);
            var studentById = (from stu in testContext.Students where stu.Id == id select stu).FirstOrDefault();
            if (!studentById.Equals(student))
            {
                studentById.EnrollmentDate = student.EnrollmentDate;
                studentById.FirstMidName = student.FirstMidName;
                studentById.LastName = student.LastName;
                testContext.SaveChanges();
                testContext.Dispose();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TestContext testContext = new TestContext(conn);
            var student = (from stu in testContext.Students where stu.Id == id select stu).FirstOrDefault();
            testContext.Remove(student);
            testContext.SaveChanges();
            testContext.Dispose();
        }
    }
}
