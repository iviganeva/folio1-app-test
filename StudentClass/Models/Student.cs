using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace StudentClass.Models
{
    public class Student
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [Remote("IsStudentWithTheSameLastNameNotExists", "Student", HttpMethod = "POST", ErrorMessage = "Student Last Name already in use!")]
        [StringLength(50)]
        public string LastName { get; set; }

        public int Age { get; set; }
        public int ClassId { get; set; }
        
        [Range(0, 4)]
        [DisplayFormat(DataFormatString = "{0:n1}", ApplyFormatInEditMode = true)]
        public decimal GPA { get; set; }

        [Display(Name = "Student Name")]
        public string FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }        

        public virtual Class Class { get; set; }
    }
}