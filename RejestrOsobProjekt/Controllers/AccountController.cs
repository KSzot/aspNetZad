using RejestrOsobProjekt.Models;
using RejestrOsobProjekt.ViewModel;
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

           if(_context.Users.Where(u => u.Email == user.Email).Any())
            {
                ModelState.AddModelError("Email", "This email already exists");
                return View("Register", user);
            }
            user.RoleId = 2;
            _context.Users.Add(user);
            _context.SaveChanges();

            return Content("Your registration is performed successfully, please login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loginUser = _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if(loginUser == null)
            {
                ModelState.AddModelError("Email", "Email or Password is incorrect");
                return View("Login", user);
            }
            else
            {
                var tmp = _context.Roles.Find(loginUser.RoleId).Title; 
                Session["UserName"] = _context.Roles.Find(loginUser.RoleId).Title;
                Session["UserId"] = loginUser.Id;
                return RedirectToAction("Index", "Home");
            }
       
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}