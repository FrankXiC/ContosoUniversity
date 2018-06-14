using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Interface
{
    public class StudentRegister:IStudentRegister
    {
        public static Connection conn;
        public StudentRegister(Connection connection)
        {
            conn = connection;
        }

        public Students Register(Students student)
        {
            TestContext testContext = new TestContext(conn);
            if (student.Id == 0) {
                var id = (from stu in testContext.Students select stu.Id).Max();
                student.Id = id + 1;
            }
            testContext.Add(student);
            testContext.SaveChanges();
            testContext.Dispose();
            return student;
        }
    }
}
