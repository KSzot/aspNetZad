using RejestrOsobProjekt.Models;
using RejestrOsobProjekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RejestrOsobProjekt.Controllers
{
    public class HomeController : Controller
    {

        private StoreContext _context;

        public HomeController()
        {
            _context = new StoreContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Missing(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";
            var human = _context.Humans.Include(c => c.Gender).ToList();
            if (!String.IsNullOrEmpty(sortOrder))
            {
                human = _context.Humans.Include(c => c.Gender).OrderByDescending(h => h.GenderId).ToList();
            }
            else
            {
                human = _context.Humans.Include(c => c.Gender).OrderBy(h => h.GenderId).ToList();
            }
            return View(human);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var human = _context.Humans.Include(c => c.Gender).SingleOrDefault(person => person.Id == id);
            if (human == null) return HttpNotFound();
            return View(human);
        }
    }
}