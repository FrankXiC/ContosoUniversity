using ContosoUniversity.Models;

namespace ContosoUniversity.Api.Interface
{
    public interface IStudentModefy
    {
        Students Modified(int id, Students student);
    }
}