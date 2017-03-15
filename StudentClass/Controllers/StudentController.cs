using StudentClass.DAL;
using StudentClass.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StudentClass.Controllers
{
    public class StudentController : Controller
    {
        private IStudentClassContext _database;

        public StudentController(IStudentClassContext context)
        {
            _database = context;
        }

        public StudentController()
        {
            _database = new StudentClassContext();
        }          

        [HttpGet]
        public ActionResult Index(int? selectedClass)
        {
            var classes = _database.Classes.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedClass = new SelectList(classes, "ClassId", "Name", selectedClass);
            int classId = selectedClass.GetValueOrDefault();

            IQueryable<Student> students = _database.Students
                .Where(c => !selectedClass.HasValue || c.ClassId == classId)
                .OrderBy(d => d.ClassId)
                .Include(d => d.Class);

            var sql = students.ToString();

            return View(students.ToList());
        }

        public ActionResult Details(string id = null)
        {
            Student student = _database.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            
            return View(student);
        }

        public ActionResult Create()
        {
            PopulateClassesDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _database.Students.Add(student);
                _database.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public JsonResult IsStudentWithTheSameLastNameNotExists(string lastName)
        {
            return Json(!_database.Students.Any(x => x.LastName == lastName), JsonRequestBehavior.AllowGet);
        }  

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = _database.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            PopulateClassesDropDownList(student.ClassId);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                //_database.Entry(student).State = EntityState.Modified;
                _database.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            Student student = _database.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Student student = _database.Students.Find(id);
            _database.Students.Remove(student);
            _database.SaveChanges();

            return RedirectToAction("Index");
        }

        private void PopulateClassesDropDownList(object selectedClass = null)
        {
            var classesQuery = from c in _database.Classes
                                   orderby c.Name
                                   select c;
            ViewBag.ClassId = new SelectList(classesQuery, "ID", "Name", selectedClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (_database is IDisposable)
            {
                ((IDisposable)_database).Dispose();
            }

            base.Dispose(disposing);
        }
    }
}