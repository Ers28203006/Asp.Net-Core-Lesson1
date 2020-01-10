using EmptyProject.Models;
using System.Collections.Generic;

namespace EmptyProject.MockData
{
    public class StudentList
    {
        public List<Student> Students { get; set; }
        public StudentList()
        {
            StudentInititialization studentInititialization = new StudentInititialization();
            Students = studentInititialization.Studens;
        }
    }
}
