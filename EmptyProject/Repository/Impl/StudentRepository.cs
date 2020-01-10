using System.Collections.Generic;
using System.Linq;
using EmptyProject.MockData;
using EmptyProject.Models;

namespace EmptyProject.Repository.Impl
{
    public class StudentRepository : IStudentRepository
    {
        StudentList db = new StudentList();
        public void Create(Student item)
        {
            db.Students.Add(item);
        }

        public void Delete(Student item)
        {
            db.Students.Remove(item);
        }

        public void Edit(Student item)
        {
            db.Students.FirstOrDefault(s => s.Id == item.Id).Name = item.Name;
            db.Students.FirstOrDefault(s => s.Id == item.Id).Age = item.Age;
        }

        public Student GetEntity(int id)
        {
            return db.Students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetEntitysList()
        {
            return db.Students;
        }
    }
}
