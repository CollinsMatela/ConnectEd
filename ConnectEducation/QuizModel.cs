using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class QuizModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string QuizId { get; set; }
        public string QuizTitle { get; set; }
        public bool typeOfScoring { get; set; }
        public string InstructorId { get; set; }
        public string Instructor { get; set; }
        public string SubjectName { get; set; }
        public string Section { get; set; }
        public string [] Number { get; set; }
        public string Instruction { get; set; }
        public string [] Question { get; set; }
        public string [] AnswerKey { get; set; }
        public string Deadline { get; set; }

        public List<string> StudentsWhoTook { get; set; } = new List<string>();
    }
}
