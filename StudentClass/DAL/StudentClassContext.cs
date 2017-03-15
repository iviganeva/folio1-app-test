using StudentClass.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace StudentClass.DAL
{
    public class StudentClassContext : DbContext, IStudentClassContext
    {
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Class> Classes { get; set; }       

        public StudentClassContext()
            : base("Name=StudentClassContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.ClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>().Property(e => e.GPA).HasPrecision(3, 1);

        }
    }
}