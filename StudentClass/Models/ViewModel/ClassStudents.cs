using StudentClass.Models;
using System.Collections.Generic;

namespace StudentClass.ViewModel
{
    public class ClassStudents
    {
        public IEnumerable<Class> Classes { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}