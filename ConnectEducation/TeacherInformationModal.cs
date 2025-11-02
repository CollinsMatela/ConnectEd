using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class TeacherInformationModal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TeacherID { get; set; }
        public string TeacherPassword { get; set; }
        public string Subject { get; set; }
        public string Section { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Fullname { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string HomeAddress { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string EducAttainment { get; set; }
        public string PrcID { get; set; }
        public string Course { get; set; }
        public string School { get; set; }
    }
}
