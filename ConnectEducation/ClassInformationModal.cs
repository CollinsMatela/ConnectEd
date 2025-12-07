using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    [BsonIgnoreExtraElements] // To catch or throw extra elements (SemesterCb)
    internal class ClassInformationModal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassID { get; set; }
        public string Strand { get; set; }
        public string GradeLevel { get; set; }
        public string Section { get; set; }
        public string [] Teacher { get; set; }
        public string  [] Students  { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
