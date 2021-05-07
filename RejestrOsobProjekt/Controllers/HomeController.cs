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

        public ActionResult Missing()
        {
            var human = _context.Humans.Include(c => c.Gender).ToList();
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