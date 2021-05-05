using RejestrOsobProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RejestrOsobProjekt.Controllers
{
    public class HumanController : Controller
    {

        private StoreContext _context;

        public HumanController()
        {
            _context = new StoreContext();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChanges();

            return Content("Human is saved");
        }

        public ActionResult Edit(int? id)
        {
            if(id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var human = _context.Humans.SingleOrDefault(person => person.Id == id);
            if (human == null) return HttpNotFound();

            return View("Create",human);
        }
        // GET: Human
        public ActionResult Index()
        {
            var human = _context.Humans.ToList();
            return View(human);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Human human = _context.Humans.Find(id);
            if (human == null) return HttpNotFound();
            _context.Humans.Remove(human);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);    
        }
    }
}