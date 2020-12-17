using SR_Luedde.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SR_Luedde.Controllers
{
    public class HomeController : Controller
    {
        //I create a new object
        private SR_StudentsEntities db = new SR_StudentsEntities();

        public ActionResult Index(string option, string search)
        {
            //I Convert it into a list

            List<Student> StudentList = db.Students.ToList();

            if (option == "Name")
            {
                return View(db.Students.Where(x => x.Name == search || search == null).ToList());
            }
            if (option == "School")
            {
                return View(db.Students.Where(x => x.School == search || search == null).ToList());
            }
            if (option == "Major")
            {
                return View(db.Students.Where(x => x.Major == search || search == null).ToList());
            }
            if (option == "Date")
            {
                return View(db.Students.Where(x => x.Date == search || search == null).ToList());
            }
            if (option == "Active")
            {
                return View(db.Students.Where(x => x.Active == search || search == null).ToList());
            }
            else
            {
                return View(db.Students.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}