using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Enrollments
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
        public int StudentId { get; set; }
    }
}
