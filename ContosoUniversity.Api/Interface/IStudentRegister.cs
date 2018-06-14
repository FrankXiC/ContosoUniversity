using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;

namespace ContosoUniversity.Interface
{
    public interface IStudentRegister
    {
        Students Register(Students student);
    }
}
