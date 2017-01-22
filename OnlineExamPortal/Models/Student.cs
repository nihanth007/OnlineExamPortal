using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace OnlineExamPortal.Models
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public string Pin { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int Sem { get; set; }
        public string College { get; set; }
    }
}