using PagedList;
using SR_Luedde.Models;
using System.Linq;
using System.Web.Mvc;

namespace SR_Luedde.Controllers
{
    public class HomeController : Controller
    {
        //I create a new object
        private SR_StudentsEntities db = new SR_StudentsEntities();

        public ActionResult Index(string option, string search, int? pageNumber, string sort)
        {
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending name" : "";

            ViewBag.SortBySchool = sort == "School" ? "descending school" : "School";

            ViewBag.SortByMajor = sort == "Major" ? "descending major" : "Major";

            ViewBag.SortByDate = sort == "Date" ? "descending date" : "Date";

            ViewBag.SortByActive = sort == "Active" ? "descending active" : "Active";

            var records = db.Students.AsQueryable();

            if (option == "Name")
            {
                records = records.Where(x => x.Name == search || search == null);
            }
            if (option == "School")
            {
                records = records.Where(x => x.School == search || search == null);
            }
            if (option == "Major")
            {
                records = records.Where(x => x.Major == search || search == null);
            }
            if (option == "Date")
            {
                records = records.Where(x => x.Date == search || search == null);
            }
            if (option == "Active")
            {
                records = records.Where(x => x.Active == search || search == null);
            }
            else
            {
                records = records.Where(x => x.Name.StartsWith(search) || search == null);
            }

            switch (sort)
            {
                case "descending name":
                    records = records.OrderByDescending(x => x.Name);
                    break;

                case "descending school":
                    records = records.OrderByDescending(x => x.School);
                    break;

                case "descending major":
                    records = records.OrderByDescending(x => x.Major);
                    break;

                case "descending date":
                    records = records.OrderByDescending(x => x.Date);
                    break;

                case "descending active":
                    records = records.OrderByDescending(x => x.Active);
                    break;

                default:
                    records = records.OrderBy(x => x.Name);
                    break;
            }
            return View(records.ToPagedList(pageNumber ?? 1, 10));
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
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