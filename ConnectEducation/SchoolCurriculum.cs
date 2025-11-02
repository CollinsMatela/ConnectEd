using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectEducation
{
    internal class SchoolCurriculum()
    {
        
        private string _Grade11 = "Grade 11";
        private string _Grade12 = "Grade 12";

        private string _FirstSemester = "first semester";
        private string _SecondSemester = "second semester";

        public string _StudentName {  get; set; }
        public string _Subject1 { get; private set; }
        public string _Subject2 { get; private set; }
        public string _Subject3 { get; private set; }
        public string _Subject4 { get; private set; }
        public string _Subject5 { get; private set; }
        public string _Subject6 { get; private set; }
        public string _Subject7 { get; private set; }
        public string _Subject8 { get; private set; }

        public void StudentCurriculum(string studentName)
        {
            _StudentName = studentName;
        }
        public void STEM(string gradeLevel, string semester)
        {
            if(gradeLevel.ToLower() == _Grade11.ToLower() && semester.ToLower() == _FirstSemester)
            {
                _Subject1 = "Pre-Calculus";
                _Subject2 = "General Biology 1";
                _Subject3 = "General Chemistry 1";
                _Subject4 = "General Physics 1";
                _Subject5 = "Practical Research 1";
                _Subject6 = "Filipino sa Piling Larang";
                _Subject7 = "Earth and Life Science";
                _Subject8 = "Personal Development";
            }
            else if (gradeLevel.ToLower() == _Grade11.ToLower() && semester.ToLower() == _SecondSemester)
            {
                _Subject1 = "Basic-Calculus";
                _Subject2 = "General Biology 2";
                _Subject3 = "General Chemistry 2";
                _Subject4 = "General Physics 2";
                _Subject5 = "Practical Research 2";
                _Subject6 = "21st Century Literature";
                _Subject7 = "Oral Communication";
                _Subject8 = "Physical Education and Health";
            }
            else if (gradeLevel.ToLower() == _Grade12.ToLower() && semester.ToLower() == _FirstSemester)
            {
                _Subject1 = "English for Academic and Professional Purposes";
                _Subject2 = "Entrepreneurship";
                _Subject3 = "General Mathematics 1";
                _Subject4 = "Media and Information Literacy";
                _Subject5 = "Work Immersion 1";
                _Subject6 = "Physical Education and Health 1";
                _Subject7 = "Komunikasyon at Pananaliksik";
                _Subject8 = "Empowerment Technologies";
            }
            else if (gradeLevel.ToLower() == _Grade12.ToLower() && semester.ToLower() == _SecondSemester)
            {
                _Subject1 = "Calculus";
                _Subject2 = "Technopreneurship";
                _Subject3 = "General Mathematics 2";
                _Subject4 = "Inquiries, Investigations, and Immersion";
                _Subject5 = "Work Immersion 2";
                _Subject6 = "Physical Education and Health 2";
                _Subject7 = "Understanding Culture, Society and Politics";
                _Subject8 = "Physical Science";
            }
            else
            {
                MessageBox.Show("Invalid of Grade Level and Semester inputs");
            }
        }
        public void ABM(string gradeLevel, string semester)
        {
            if (gradeLevel.ToLower() == "grade 11" && semester.ToLower() == "first semester")
            {
                _Subject1 = "Oral Communication";
                _Subject2 = "General Mathematics";
                _Subject3 = "Earth and Life Science";
                _Subject4 = "Empowerment Technologies";
                _Subject5 = "Business Mathematics";
                _Subject6 = "Organization and Management";
                _Subject7 = "21st Century Literature";
                _Subject8 = "Physical Education and Health 1";
            }
            else if (gradeLevel.ToLower() == "grade 11" && semester.ToLower() == "second semester")
            {
                _Subject1 = "Komunikasyon at Pananaliksik";
                _Subject2 = "Statistics and Probability";
                _Subject3 = "Physical Science";
                _Subject4 = "Filipino sa Piling Larang";
                _Subject5 = "Principles of Marketing";
                _Subject6 = "Business Ethics and Social Responsibility";
                _Subject7 = "Understanding Culture, Society and Politics";
                _Subject8 = "Physical Education and Health 2";
            }
            else if (gradeLevel.ToLower() == "grade 12" && semester.ToLower() == "first semester")
            {
                _Subject1 = "Applied Economics";
                _Subject2 = "Business Finance";
                _Subject3 = "Practical Research";
                _Subject4 = "Inquiries, Investigations and Immersion";
                _Subject5 = "English for Academic and Professional Purposes";
                _Subject6 = "Philosophy of the Human Person";
                _Subject7 = "Media and Information Literacy";
                _Subject8 = "Physical Education and Health 3";
            }
            else if (gradeLevel.ToLower() == "grade 12" && semester.ToLower() == "second semester")
            {
                _Subject1 = "Fundamentals of Accounting 1";
                _Subject2 = "Fundamentals of Accounting 2";
                _Subject3 = "Business Enterprise Simulation";
                _Subject4 = "Work Immersion";
                _Subject5 = "Entrepreneurship";
                _Subject6 = "Contemporary Philippine Arts from the Regions";
                _Subject7 = "Introduction to World Religions";
                _Subject8 = "Physical Education and Health 4";
            }
            else
            {
                MessageBox.Show("Invalid Grade Level or Semester input");
            }
        }
        public void HUMSS(string gradeLevel, string semester)
        {
            if (gradeLevel.ToLower() == "grade 11" && semester.ToLower() == "first semester")
            {
                _Subject1 = "Oral Communication";
                _Subject2 = "Komunikasyon at Pananaliksik";
                _Subject3 = "General Mathematics";
                _Subject4 = "Earth and Life Science";
                _Subject5 = "Creative Writing";
                _Subject6 = "Introduction to World Religions and Belief Systems";
                _Subject7 = "21st Century Literature";
                _Subject8 = "Physical Education and Health 1";
            }
            else if (gradeLevel.ToLower() == "grade 11" && semester.ToLower() == "second semester")
            {
                _Subject1 = "Reading and Writing";
                _Subject2 = "Statistics and Probability";
                _Subject3 = "Physical Science";
                _Subject4 = "Filipino sa Piling Larang";
                _Subject5 = "Discipline and Ideas in the Social Sciences (DISS)";
                _Subject6 = "Discipline and Ideas in the Applied Social Sciences (DIASS)";
                _Subject7 = "Understanding Culture, Society and Politics";
                _Subject8 = "Physical Education and Health 2";
            }
            else if (gradeLevel.ToLower() == "grade 12" && semester.ToLower() == "first semester")
            {
                _Subject1 = "Creative Nonfiction";
                _Subject2 = "Trends, Networks, and Critical Thinking";
                _Subject3 = "Philippine Politics and Governance";
                _Subject4 = "Community Engagement, Solidarity and Citizenship";
                _Subject5 = "Entrepreneurship / Applied Economics";
                _Subject6 = "English for Academic and Professional Purposes";
                _Subject7 = "Practical Research 1";
                _Subject8 = "Physical Education and Health 3";
            }
            else if (gradeLevel.ToLower() == "grade 12" && semester.ToLower() == "second semester")
            {
                _Subject1 = "Work Immersion / Culminating Activity";
                _Subject2 = "Practical Research 2";
                _Subject3 = "Inquiries, Investigations, and Immersion";
                _Subject4 = "Contemporary Philippine Arts from the Regions";
                _Subject5 = "Philosophy of the Human Person";
                _Subject6 = "Media and Information Literacy";
                _Subject7 = "Personal Development";
                _Subject8 = "Physical Education and Health 4";
            }
            else
            {
                MessageBox.Show("Invalid Grade Level or Semester input");
            }
        }


    }
}
