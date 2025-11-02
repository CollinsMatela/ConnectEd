using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class TeacherModal
    {
        public ObjectId Id { get; set; }
        public string Student { get; set; }

        public string Handout { get; set; }
        public string TypeOfActivity { get; set;}
        public string AnswerTextField {  get; set; }
        public List<ObjectId> Files {  get; set; }

        public DateTime Time { get; set; }


    }
}
