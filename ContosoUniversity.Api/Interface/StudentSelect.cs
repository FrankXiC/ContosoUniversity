using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Interface;
using TestContext = ContosoUniversity.Models.TestContext;

namespace ContosoUniversity.Api.Interface {

    public class StudentSelect : IStudentSelect
    {
        public static Connection conn;

        public StudentSelect(Connection connection)
        {
            conn = connection;
        }

        public List<Students> SelectAllStudent()
        {
            TestContext testContext = new TestContext(conn);
            var studentList = (from stu in testContext.Students select stu).ToList();
            return studentList;
        }
    }
}
