using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class AnnouncementModel
    {
        [BsonId]                       // tells Mongo this is the primary key
        [BsonRepresentation(BsonType.String)] // store Guid as a string in Mongo
        public string Id { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
    }
}
