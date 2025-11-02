using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConnectEducation
{
    internal class SubjectModal
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string NameHandout1 { get; set; }
        public string NameHandout2 { get; set; }
        public string NameHandout3 { get; set; }
        public string NameHandout4 { get; set; }
        public string NameHandout5 { get; set; }
        public string NameHandout6 { get; set; }
        public string NameHandout7 { get; set; }
        public string NameHandout8 { get; set; }
        public string LinkHandout1 { get; set; }
        public string LinkHandout2 { get; set; }
        public string LinkHandout3 { get; set; }
        public string LinkHandout4 { get; set; }
        public string LinkHandout5 { get; set; }
        public string LinkHandout6 { get; set; }
        public string LinkHandout7 { get; set; }
        public string LinkHandout8 { get; set; }
        public string Assignment1 { get; set; }
        public string Assignment2 { get; set; }
        public string Assignment3 { get; set; }
        public string Assignment4 { get; set; }
        public string Assignment5 { get; set; }
        public string Assignment6 { get; set; }
        public string Assignment7 { get; set; }
        public string Assignment8 { get; set; }
        public string PerformanceTask1 { get; set; }
        public string PerformanceTask2 { get; set; }
        public string PerformanceTask3 { get; set; }
        public string PerformanceTask4 { get; set; }
        public string PerformanceTask5 { get; set; }
        public string PerformanceTask6 { get; set; }
        public string PerformanceTask7 { get; set; }
        public string PerformanceTask8 { get; set; }
    }
}
