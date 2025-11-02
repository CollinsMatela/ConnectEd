using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class StudentModal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        public string StudentId { get; set; }
        public string StudentPassword { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }

        public string Fullname { get; set; }
        public string Age { get; set; }
        public string HomeAddress { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }


        public DateTime DateOfBirth { get; set; }


        public string Strand { get; set; }
        public string GradeLevel { get; set; }
        public string Semester { get; set; }
        public string Section { get; set; }


        public string GuardianLastname { get; set; }
        public string GuardianFirstname { get; set; }
        public string GuardianMiddleInitial { get; set; }
        public string GuardianRelationship { get; set; }
        public string GuardianContact { get; set; }
        public string GuardianEmail { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class AcademicRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string StudentId { get; set; }

        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public double GeneralAverage { get; set; }
    }

    public class Subject
    {
        public string SubjectName { get; set; }

        public List<QuarterGrade> Quarters { get; set; } = new List<QuarterGrade>();

        public double FinalAverage { get; set; }
    }

    public class QuarterGrade
    {
        public int Quarter { get; set; } // 1, 2, 3, or 4

        public double Worksheet1 { get; set; }
        public double Worksheet2 { get; set; }
        public double Worksheet3 { get; set; }
        public double Worksheet4 { get; set; }

        public double Quiz1 { get; set; }
        public double Quiz2 { get; set; }
        public double Quiz3 { get; set; }
        public double Quiz4 { get; set; }

        public double Performance1 { get; set; }
        public double Performance2 { get; set; }
        public double Performance3 { get; set; }
        public double Performance4 { get; set; }

        public double Exam { get; set; }

        public double QuarterAverage { get; set; }
    }
    public class AttendanceRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string StudentId { get; set; }

        public string SubjectName { get; set; } // e.g., "Math"

        public List<AttendanceEntry> AttendanceList { get; set; } = new List<AttendanceEntry>();
    }

    public class AttendanceEntry
    {
        public DateTime Date { get; set; }
        public string Status { get; set; } // Present, Absent, Late
    }

    public class StudentGrades 
    {
        public string recordID { get; set; }
        public string StudentID { get; set; }
        public string StudentFullname { get; set; }
        public string StudentSection { get; set; }
        public List<GradeRecording> SubjectList { get; set; } = new List<GradeRecording>();

    }
    public class GradeRecording
    { 
        public string Subject {  get; set; }
        public string TeacherID { get; set; }
        public string TeacherFullname { get; set; }
        public string FinalGrade1 { get; set; }
        public string FinalGrade2 { get; set; }

    }

}
