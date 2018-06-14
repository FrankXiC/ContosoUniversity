using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Api.Interface
{
    public class StudentDelete : IStudentDelete
    {
        public Connection conn;

        public StudentDelete(Connection connection)
        {
            conn = connection;
        }

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
