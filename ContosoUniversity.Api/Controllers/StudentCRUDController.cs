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
            var studentlist = studentSelect.SelectAllStudent(0);
            return studentlist;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Students> Get(int id)
        {
            IStudentSelect studentSelect = new StudentSelect(conn);
            var student = studentSelect.SelectAllStudent(id).FirstOrDefault();
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
        public Students Put(int id, [FromBody] Students student)
        {
            IStudentModefy studentModefy=new StudentModefy(conn);
            var studentNew= studentModefy.Modified(id, student);
            return studentNew;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IStudentDelete studentDelete=new StudentDelete(conn);
            studentDelete.Delete(id);
        }
    }
}
