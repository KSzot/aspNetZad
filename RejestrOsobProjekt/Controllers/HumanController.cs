using RejestrOsobProjekt.Models;
using RejestrOsobProjekt.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace RejestrOsobProjekt.Controllers
{
    public class HumanController : Controller
    {

        private StoreContext _context;

        public HumanController()
        {
            _context = new StoreContext();
        }


        [HttpPost]
        public ActionResult Edit(Human human, HttpPostedFileBase ImageFile)
        {
            if (!ModelState.IsValid)
            {
                var gender = _context.Genders.ToList();
                var viewModel = new HumanFormViewModel { human = human, genders = gender };
                return View("Edit", viewModel);
            }
            if (ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    human.Image = ms.ToArray();
                }
            }
            if (human.Id > 0)
            {
                var tmp = _context.Humans.SingleOrDefault(person => person.Id == human.Id);
                human.CreatedDate = tmp.CreatedDate;
                human.whichUser = tmp.whichUser;
                _context.Humans.Remove(tmp);
                _context.Humans.Add(human);
                //_context.Humans.Entry(human).State = EntityState.Modified;
                _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            var gender = _context.Genders.ToList();
            var viewModel = new HumanFormViewModel { human = new Human(), genders = gender };
            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Create(Human human, HttpPostedFileBase ImageFile)

        {
            if (!ModelState.IsValid)
            {
                var gender = _context.Genders.ToList();
                var viewModel = new HumanFormViewModel { human = human, genders = gender };
                return View("Create",viewModel);
            }
            if(ImageFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    human.Image = ms.ToArray();
                }
            }
            if(human.Id > 0)
            {
                _context.Entry(human).State = EntityState.Modified;
            }else
            {
                human.CreatedDate = DateTime.Now;
                human.whichUser = Session["UserId"].ToString();
                _context.Humans.Add(human);
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var human = _context.Humans.SingleOrDefault(person => person.Id == id);
            if (human == null) return HttpNotFound();
            var gender = _context.Genders.ToList();
            var viewModel = new HumanFormViewModel { human = human, genders = gender };

            return View( viewModel);
        }

        // GET: Human
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";
            if (Session["UserName"] != null)
            {
                if (Session["UserName"].ToString() == "User")
                {
                    if (Session["UserId"] != null)
                    {


                        string userId = Session["UserId"].ToString();
                        var human = _context.Humans.Where(el => el.whichUser == userId).Include(c => c.Gender).ToList();
                        if (!String.IsNullOrEmpty(sortOrder))
                        {
                             human = _context.Humans.Where(el => el.whichUser == userId).Include(c => c.Gender).OrderByDescending(h => h.GenderId).ToList();
                        }else
                        {
                             human = _context.Humans.Where(el => el.whichUser == userId).Include(c => c.Gender).OrderBy(h => h.GenderId).ToList();
                        }
                        

                        return View(human);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    var human = _context.Humans.Include(c => c.Gender).ToList();
                    if (!String.IsNullOrEmpty(sortOrder))
                    {
                         human = _context.Humans.Include(c => c.Gender).OrderByDescending(h => h.GenderId).ToList();
                    }else
                    {
                        human = _context.Humans.Include(c => c.Gender).OrderBy(h => h.GenderId).ToList();
                    }
                        return View(human);
                }
            }else
            {
                return View();
            }
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

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var human = _context.Humans.Include(c => c.Gender).SingleOrDefault(person => person.Id == id);
            if (human == null) return HttpNotFound();
            return View(human);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);    
        }
    }
}