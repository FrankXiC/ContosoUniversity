using System.Collections.Generic;
using ContosoUniversity.Models;

namespace ContosoUniversity.Api.Interface
{
    public interface IStudentSelect
    {
        List<Students> SelectAllStudent(int id);
    }
}