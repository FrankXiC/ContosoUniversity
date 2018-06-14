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

        public List<Students> SelectAllStudent(int id)
        {
            TestContext testContext = new TestContext(conn);
            var studentList=new List<Students>();
            if (id == 0) {
                studentList = (from stu in testContext.Students select stu).ToList();
            }
            else
            {
                studentList = (from stu in testContext.Students where stu.Id == id select stu).ToList();
            }
            return studentList;
        }
    }
}
