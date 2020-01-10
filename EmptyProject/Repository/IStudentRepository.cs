using EmptyProject.Models;
using System.Collections.Generic;

namespace EmptyProject.Repository
{
    public interface IStudentRepository
    {
        void Create(Student item);
        Student GetEntity(int id);
        IEnumerable<Student> GetEntitysList();
        void Delete(Student item);
        void Edit(Student item);
    }
}
