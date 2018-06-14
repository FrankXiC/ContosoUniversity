using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public partial class Courses
    {
        public int CourseId { get; set; }
        public int Credits { get; set; }
        public string Title { get; set; }
    }
}
