using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineExamPortal.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace OnlineExamPortal.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            if (TempData["isLogged"] == null)
            {
                TempData["doesErrorExist"] = 1;
                TempData["error"] = "Please do not refresh. If You Refresh, You will be Logged Out. Please Login again to Continue ";
                return Redirect("/Login/Index");
            }
            bool isLogged = (bool)TempData["isLogged"];
            if (isLogged == true)
            {
                ViewBag.st = (Student)TempData["st"];
                return View();
            }
            else
            {
                return Redirect("/Login/Index");
            }
        }
    }
}