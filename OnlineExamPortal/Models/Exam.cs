using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace OnlineExamPortal.Models
{

    public class Question
    {
        public ObjectId Id { get; set; }
        public int Qno { get; set; }
        public string Que { get; set; }
        public string Op1 { get; set; }
        public string Op2 { get; set; }
        public string Op3 { get; set; }
        public string Op4 { get; set; }
        public int Answer { get; set; }
    }

    public class Exam
    {
        public ObjectId Id { get; set; }
        public string ExamId { get; set; }
        public List<Question> Question { get; set; }
    }

    public class ActiveExam
    {
        public ObjectId Id { get; set; }
        public string ActiveId { get; set; }
        public string ExamId { get; set; }
        public string ExamName { get; set; }
        public string Type { get; set; }
        public int Questions { get; set; }
        public int Time { get; set; }
        public bool IsActive { get; set; }
        public int Sem { get; set; }
        public string Branch { get; set; }
        public string Course { get; set; }
    }

}