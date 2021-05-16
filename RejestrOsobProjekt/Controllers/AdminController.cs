using RejestrOsobProjekt.Models;
using RejestrOsobProjekt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace RejestrOsobProjekt.Controllers
{
    public class AdminController : Controller
    {

        private StoreContext _context;

        public AdminController()
        {
            _context = new StoreContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            var users = _context.Users.Include(u => u.Role).ToList();
            return View(users);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _context.Users.Find(id);
            if (user == null) return HttpNotFound();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = _context.Users.SingleOrDefault(person => person.Id == id);
            if (user == null) return HttpNotFound();
            var role = _context.Roles.ToList();
            var viewModel = new UserFormViewModel { users = user, roles = role };

            return View( viewModel);
        }

        [HttpPost]
        public ActionResult Edit(User users)

        {
            if (!ModelState.IsValid)
            {
                var role = _context.Roles.ToList();
                var viewModel = new UserFormViewModel { users = users, roles = role };
                return View("Edit", viewModel);
            }

            var tmp = _context.Users.SingleOrDefault(person => person.Id == users.Id);
            _context.Users.Remove(tmp);
            _context.Users.Add(users);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            var role = _context.Roles.ToList();
            var viewModel = new UserFormViewModel { users = new User(), roles = role };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(User users)

        {
            if (!ModelState.IsValid)
            {
                var role = _context.Roles.ToList();
                var viewModel = new UserFormViewModel { users = users, roles = role };
                return View("Create", viewModel);
            }


            _context.Users.Add(users);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Missing()
        {

            var human = _context.Humans.Include(c => c.Gender).ToList();
            return View("~/Views/Human/Index.cshtml",human );
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}