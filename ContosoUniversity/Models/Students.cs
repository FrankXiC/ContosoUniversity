using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Students
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
    }
}
