﻿using System;
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
        static string connectionString = @"mongodb://nihanth007:Lyvin##421@ds056009.mlab.com:56009/nihanth";
        static MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionString)
        );
        MongoClient mongoClient = new MongoClient(settings);
        
        public ActionResult Index()
        {
            if (Session["isLogged"] == null)
            {
                TempData["doesErrorExist"] = 1;
                TempData["error"] = "Please Login again to Access this Page";
                return Redirect("/Login/Index");
            }
            if ((bool)Session["isLogged"] == true)
            {
                ViewBag.st = (Student)Session["st"];
                return View();
            }
            else
            {
                return Redirect("/Login/Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            return Redirect("/Login/Index");
        }

        public ActionResult ChangePassword()
        {
            return Redirect("Index");
        }
        
        [HttpPost]
        public ActionResult ExamStart(string ExamId)
        {
            ExamId = "nwp";
            if (Session["isLogged"] == null)
            {
                TempData["doesErrorExist"] = 1;
                TempData["error"] = "Please Login again to Access this Page";
                return Redirect("/Login/Index");
            }
            if ((bool)Session["isLogged"] == true)
            {
                ViewBag.st = (Student)Session["st"];

                var db = mongoClient.GetDatabase("nihanth");

                //Query to ActiveExams Collection About The String Value That is Passed
                var ActiveExam = db.GetCollection<ActiveExam>("activeexams");
                var filter = new BsonDocument("ExamId", ExamId);
                var activeExamResult = ActiveExam.Find(filter).ToList();

                // Query that brings all the Questions in Exam COllection
                var QuestionCollection = db.GetCollection<Question>(ExamId);
                var questions = QuestionCollection.Find(_ => true).ToList();

                //Assigning the Values fetched from Database to local variables
                ActiveExam exam = new ActiveExam()
                {
                    ExamId = activeExamResult[0].ExamId,
                    ExamName = activeExamResult[0].ExamName,
                    Branch = activeExamResult[0].Branch,
                    Course = activeExamResult[0].Course,
                    Questions = activeExamResult[0].Questions,
                    Time = activeExamResult[0].Time
                };
                ViewBag.examData = exam;
                Session["Questions"] = questions;
                return View();
            }
            else
            {
                return Redirect("/Login/Index");
            }
        }
    }
}