using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentClass.Models
{
    public class Class
    {
        public int ID { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
        [StringLength(50)]

        public string Location { get; set; }
        [StringLength(50)]
        public string TeacherName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}