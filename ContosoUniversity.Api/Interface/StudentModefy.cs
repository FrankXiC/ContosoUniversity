using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Api.Interface
{
    public class StudentModefy : IStudentModefy
    {
        public Connection conn;
        public StudentModefy(Connection options)
        {
            conn = options;
        }

        public Students Modified(int id, Students student)
        {
            TestContext testContext = new TestContext(conn);
            var studentById = (from stu in testContext.Students where stu.Id == id select stu).FirstOrDefault();
            if (!studentById.Equals(student)) {
                studentById.EnrollmentDate = student.EnrollmentDate;
                studentById.FirstMidName = student.FirstMidName;
                studentById.LastName = student.LastName;
                testContext.SaveChanges();
                testContext.Dispose();
            }

            return studentById;
        }
    }
}
