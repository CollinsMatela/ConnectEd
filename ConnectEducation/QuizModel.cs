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
        public string Instructor { get; set; }
        public string SubjectName { get; set; }
        public string Section { get; set; }
        public string [] Number { get; set; }
        public string [] Question { get; set; }
        public string [] AnswerKey { get; set; }
    }
}
