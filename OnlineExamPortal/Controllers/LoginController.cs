using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamPortal.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace OnlineExamPortal.Controllers
{
    public class LoginController : Controller
    {
        static string connectionString = @"mongodb://nihanth007:Lyvin##421@ds056009.mlab.com:56009/nihanth";
        static MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionString)
        );
        MongoClient mongoClient = new MongoClient(settings);
        
        public ActionResult Index()
        {
            if(TempData["doesErrorExist"] != null)
            {
                ViewBag.doesErrorExist = TempData["doesErrorExist"];
                ViewBag.error = TempData["error"];
            }
            Login login = new Login();
            return View(login);
        }

        [HttpPost]
        public ActionResult Student(Login l)
        {
            var db = mongoClient.GetDatabase("nihanth");
            var students = db.GetCollection<Student>("students");
            var filter = new BsonDocument("Pin" , l.Username);
            var st = students.Find(filter).ToList();
            string Password = null;
            if (st.Count > 0)
            {
                Password = st[0].Password;
            }
            if (Password == l.Password)
            {
                Session["st"] = st[0];
                Session["isLogged"] = true;
                return Redirect("/Student/Index");
            }
            else
            {
                ViewBag.doesErrorExist = 1;
                ViewBag.error = "You Have Entered an Incorrect Password";
                ViewBag.errorLocation = "Student";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Faculty(Login l)
        {
            var db = mongoClient.GetDatabase("nihanth");
            var faculty = db.GetCollection<Student>("faculty");
            var filter = new BsonDocument("EmpId", l.Username);
            var st = faculty.Find(filter).ToList();
            string Password = null;
            if (st.Count > 0)
            {
                Password = st[0].Password;
            }
            if (Password == l.Password)
            {
                Session["st"] = st[0];
                Session["isLogged"] = true;
                return Redirect("/Faculty/Index");
            }
            else
            {
                ViewBag.doesErrorExist = 1;
                ViewBag.error = "You Have Entered an Incorrect Password";
                ViewBag.errorLocation = "Faculty";
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Examiner(Login l)
        {
            var db = mongoClient.GetDatabase("nihanth");
            var examiner = db.GetCollection<Student>("examiner");
            var filter = new BsonDocument("EmpId", l.Username);
            var st = examiner.Find(filter).ToList();
            string Password = null;
            if (st.Count > 0)
            {
                Password = st[0].Password;
            }
            if (Password == l.Password)
            {
                Session["st"] = st[0];
                Session["isLogged"] = true;
                return Redirect("/Examiner/Index");
            }
            else
            {
                ViewBag.doesErrorExist = 1;
                ViewBag.error = "You Have Entered an Incorrect Password";
                ViewBag.errorLocation = "Examiner";
                return View("Index");
            }
        }
    }
}