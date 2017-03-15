using StudentClass.DAL;
using StudentClass.Models;
using StudentClass.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StudentClass.Controllers
{
    public class ClassController : Controller
    {
        private IStudentClassContext _database;

        public ClassController(IStudentClassContext context)
        {
            _database = context;
        }

        public ClassController()
        {
            _database = new StudentClassContext();
        }       
        
        public ActionResult Index(int? id)
        {
            var viewModel = new ClassStudents();

            viewModel.Classes = _database.Classes.ToList();

            if (id != null)
            {
                ViewBag.ClassId = id.Value;
                viewModel.Students = viewModel.Classes.Where(
                    i => i.ID == id.Value).Single().Students;
            }

            return View(viewModel);
        }

        public ActionResult Details(string id = null)
        {
            Class aclass = _database.Classes.Find(id);

            if (aclass == null)
            {
                return HttpNotFound();
            }

            return View(aclass);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class aclass)
        {
            if (ModelState.IsValid)
            {
                _database.Classes.Add(aclass);
                _database.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(aclass);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Class aclass = _database.Classes.Find(id);

            if (aclass == null)
            {
                return HttpNotFound();
            }

            return View(aclass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Class aclass)
        {            
            if (ModelState.IsValid)
            {
                //_database.Entry(aclass).State = EntityState.Modified;
                _database.SaveChanges();

                return RedirectToAction("Index");
            }           

            return View(aclass);
        }       

        public ActionResult Delete(int? id)
        {
            Class aclass = _database.Classes.Find(id);

            if (aclass == null)
            {
                return HttpNotFound();
            }

            return View(aclass);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Class aclass = _database.Classes.Find(id);
            _database.Classes.Remove(aclass);
            _database.SaveChanges();

            return RedirectToAction("Index");
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