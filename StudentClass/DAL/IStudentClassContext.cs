using StudentClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass.DAL
{
    public interface IStudentClassContext : IDisposable
    {
        IDbSet<Student> Students { get; set; }
        IDbSet<Class> Classes { get; set; }

        int SaveChanges();
    }
}
