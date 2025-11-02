using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class TeachersStudentRecords
    {
        public string Id { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public string Strand { get; set; }
        public string GradeLevel { get; set; }
        public string Section { get; set; }
        public List<Attendance> AttendanceRecord { get; set; } = new();
        public List<AcademicActivities> ActivityRecord { get; set; } = new();
        public List<Grades> GradeRecord { get; set; } = new();
        public string AverageGrade { get; set; }
    }
    public class Attendance
    {
        public string WeekNumber { get; set; }
        public string Status { get; set; }
    }
    public class AcademicActivities
    {
        public string WeekNumber { get; set; }
        public string ActivityType { get; set; }
        public string Score { get; set; }
    }
    public class Grades
    {
        public string Quarter { get; set; }
        public string Grade { get; set; }
    }
}
