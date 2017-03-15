namespace StudentClass.Migrations
{
    using StudentClass.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentClass.DAL.StudentClassContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentClass.DAL.StudentClassContext context)
        {
            var classes = new List<Class>
            {
                new StudentClass.Models.Class { Name = "UI/UX", TeacherName = "Johnson", Location = "Room 501"},
                new StudentClass.Models.Class { Name = "DevOps", TeacherName = "Thomson", Location = "Room 606"}
                
            };

            classes.ForEach(s => context.Classes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Packer", Age = 18, GPA = 3.2m , ClassId = 1},
                new Student { FirstName = "Peter", LastName = "Johnston", Age = 19, GPA = 2.5m, ClassId = 1},
                new Student { FirstName = "Robert", LastName = "Smith", Age = 20, GPA = 3.1m,  ClassId = 2},
                new Student { FirstName = "Louise", LastName = "Thomsen", Age = 21, GPA = 2.1m, ClassId = 2}                
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();
        }
    }
}
