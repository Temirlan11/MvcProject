using StudyMeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyMeet.Controllers
{
    public class HomeController : Controller
    {
        public Models.AppContext db = new Models.AppContext();
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult Specialties()
        {
            var specialties = db.Specialties;
            return View(specialties.ToList());
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var specialties = db.Specialties;
            ViewBag.specialties = specialties;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string fname, string mname, string lname, int age, string img_url, string address, int specialty_id, string email, string password)
        {
            User newUser = new User();
            newUser.fname = fname;
            newUser.mname = mname;
            newUser.lname = lname;
            newUser.age = age;
            newUser.img_url = img_url;
            newUser.address = address;
            newUser.specialty_id = specialty_id;
            newUser.specialty = db.Specialties.Find(specialty_id);
            newUser.login = email;
            newUser.password = password;
            //db.Users.Attach(newUser);
            db.Specialties.Find(specialty_id).users.Add(newUser);

            //db.Users.Add(newUser);
            db.SaveChanges();

            return RedirectToAction("SignIn");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            if (password.Length < 6 || password.Length > 12)
            {
                ModelState.AddModelError("pass", "The password length must be between 6 and 12 characters");
            }
            if (ModelState.IsValid)
            {
                foreach (var user in db.Users)
                {
                    if (email.Equals(user.login) && password.Equals(user.password))
                    {
                        Session["current_user"] = user.Id;
                        HttpContext.Session.Add("current_user", user.Id);
                        return RedirectToAction("MainPage");
                    }
                    /*
                    else
                    {
                        return RedirectToAction("SignIn");
                    }
                    */
                }
            }
            return View();
        }

        public ActionResult MainPage()
        {
            int userid = Convert.ToInt32(Session["current_user"]);
            User user = db.Users.Find(userid);
            ViewBag.user = user;
            var teams = db.Teams.Where(i => i.user_id == userid);
            ViewBag.teams = teams;
            return View(db.Teams);
        }

        public ActionResult AllTeams()
        {
            ViewBag.users = db.Users.ToList();
            return View(db.Teams);
        }

        public ActionResult CreateSpecialty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        public JsonResult JsonSearch(string name)
        {
            var jsondata = db.Teams.Where(t => t.name.Contains(name)).ToList();
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        /*
        public ActionResult AllTeams(string name)
        {
            ViewBag.users = db.Users.ToList();
            var allteams = db.Teams.Where(t => t.name.Contains(name)).ToList();
            return View(allteams);
        }
        */
        public ActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(string name, string description, string img_url, int max_users)
        {
            int userid = Convert.ToInt32(Session["current_user"]);
            User user = db.Users.Find(userid);
            var team = new Team();
            team.name = name;
            team.description = description;
            team.img_url = img_url;
            team.max_users = max_users;
            team.user_id = userid;
            team.user = user;
            team.created_date = System.DateTime.Now;
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("AllTeams");
        }
    }
}