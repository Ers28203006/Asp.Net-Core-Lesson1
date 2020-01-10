using EmptyProject.Models;
using System.Collections.Generic;

namespace EmptyProject.MockData
{
    public class StudentInititialization
    {
        public List<Student>Studens { get; set; }
        public StudentInititialization()
        {
            Studens = new List<Student>()
            {
                new Student(){Id=1, Age=1, Name="1"},
                new Student(){Id=2, Age=2, Name="2"},
                new Student(){Id=3, Age=3, Name="3"},
                new Student(){Id=4, Age=4, Name="4"},
            };
        }
    }
}
