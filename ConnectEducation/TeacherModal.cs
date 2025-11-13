using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class ActivitySubmission
    {
        public ObjectId Id { get; set; }
        public string SubmissionId { get; set; }
        public string Subject { get; set; }
        public string Instructor {  get; set; }
        public string Student { get; set; }
        public string Section { get; set; }
        public string Handout { get; set; }
        public string TypeOfActivity { get; set;}
        public string AnswerTextField {  get; set; }
        public List<ObjectId> Files {  get; set; }
        public DateTime Time { get; set; }


    }
}
