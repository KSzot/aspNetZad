using RejestrOsobProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RejestrOsobProjekt.Controllers
{
    public class AccountController : Controller
    {
        private StoreContext _context;

        public AccountController()
        {
            _context = new StoreContext();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
           if(!ModelState.IsValid)
            {
                return View("Register", user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Content("Your registration is performed successfully, please login");
        }
    }
}