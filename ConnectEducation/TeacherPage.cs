using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ConnectEducation
{
    public partial class TeacherPage : Form
    {
        private string teacherID, teacherFullname, teacherSubject, teacherSection;

        private void sendEmailMessage()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentModal>("StudentModal");
            var filter = Builders<StudentModal>.Filter.Eq(z => z.StudentId, studentIDLabel.Text);
            var student = collection.Find(filter).FirstOrDefault();

            var guardianEmail = ""; 
            if (student != null)
            {
                guardianEmail = student.GuardianEmail.Trim();
            } 

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("connecteducation02@gmail.com");//your email
            mailMessage.To.Add(guardianEmail);// receiver of mail
            mailMessage.Subject = "ConnectEducation: Attendance update!";
            mailMessage.Body = "Your son/daughter named " + StudentsNameCb.Text.ToUpper() + " is currently " + SelectAttendanceCb.Text.ToUpper() + " in subject of " + teacherSubject + ". " + DateTime.Now.ToString("dddd, MMMM dd yyyy");

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // e.g., "smtp.gmail.com"
            smtpClient.Port = 587; // Common port for TLS/SSL
            smtpClient.Credentials = new NetworkCredential("connecteducation02@gmail.com", "dpseednerlscfeyi"); // Your email and generated app password
            smtpClient.EnableSsl = true; // Enable SSL/TLS encryption

            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("Email sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
            finally
            {
                mailMessage.Dispose(); // Release resources
                                       // smtpClient.Dispose(); // Optional, if you're done with the client
            }
        }
        private void updateDisplayValue()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection2 = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filterStudentRecord = Builders<TeachersStudentRecords>.Filter.And
                (
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, teacherID),
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, teacherSubject),
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentIDLabel.Text)
                );
            var studentRecord = collection2.Find(filterStudentRecord).FirstOrDefault();
            if (studentRecord != null)
            {
                List<string> Attendance = new List<string>();
                List<string> Activities = new List<string>();
                List<string> Grade = new List<string>();

                foreach (var attendanceObjectArray in studentRecord.AttendanceRecord)
                {
                    Attendance.Add(attendanceObjectArray.Status);
                }
                foreach (var activitiesObjectArray in studentRecord.ActivityRecord)
                {
                    Activities.Add(activitiesObjectArray.Score);
                }
                foreach (var gradesObjectArray in studentRecord.GradeRecord)
                {
                    Grade.Add(gradesObjectArray.Grade);
                }

                if (Activities.Count < 26)
                {
                    MessageBox.Show("The student does not have complete activity records yet.");
                    return;
                }
                if (Attendance.Count < 8)
                {
                    MessageBox.Show("The student does not have complete activity records yet.");
                    return;
                }
                // Display record to Student Record Panel (Worksheets)
                WorkSheet1Txt.Text = Activities[0] + "/50";
                WorkSheet2Txt.Text = Activities[1] + "/50";
                WorkSheet3Txt.Text = Activities[2] + "/50";
                WorkSheet4Txt.Text = Activities[3] + "/50";
                WorkSheet5Txt.Text = Activities[4] + "/50";
                WorkSheet6Txt.Text = Activities[5] + "/50";
                WorkSheet7Txt.Text = Activities[6] + "/50";
                WorkSheet8Txt.Text = Activities[7] + "/50";
                // Display record to Student Record Panel (Quizzes)
                Quiz1Txt.Text = Activities[8] + "/10";
                Quiz2Txt.Text = Activities[9] + "/10";
                Quiz3Txt.Text = Activities[10] + "/10";
                Quiz4Txt.Text = Activities[11] + "/10";
                Quiz5Txt.Text = Activities[12] + "/10";
                Quiz6Txt.Text = Activities[13] + "/10";
                Quiz7Txt.Text = Activities[14] + "/10";
                Quiz8Txt.Text = Activities[15] + "/10";
                // Display record to Student Record Panel (Performance Tasks)
                PT1Txt.Text = Activities[16] + "/100";
                PT2Txt.Text = Activities[17] + "/100";
                PT3Txt.Text = Activities[18] + "/100";
                PT4Txt.Text = Activities[19] + "/100";
                PT5Txt.Text = Activities[20] + "/100";
                PT6Txt.Text = Activities[21] + "/100";
                PT7Txt.Text = Activities[22] + "/100";
                PT8Txt.Text = Activities[23] + "/100";
                // Display record to Student Record Panel (Exams)
                Exam1Txt.Text = Activities[24] + "/50";
                Exam2Txt.Text = Activities[25] + "/50";
                // =================================================================
                // Display attendance record of student
                DisplayAttendance1.Text = Attendance[0];
                DisplayAttendance2.Text = Attendance[1];
                DisplayAttendance3.Text = Attendance[2];
                DisplayAttendance4.Text = Attendance[3];
                DisplayAttendance5.Text = Attendance[4];
                DisplayAttendance6.Text = Attendance[5];
                DisplayAttendance7.Text = Attendance[6];
                DisplayAttendance8.Text = Attendance[7];

            }
            else
            {
                MessageBox.Show("Student not found in the database.");
            }
        }
        private void displayRegisteredStudents()
        {

            StudentsNameCb.Items.Clear();

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentModal>("StudentModal");
            var filter = Builders<StudentModal>.Filter.Eq(x => x.Section, SectionHandleLabel.Text);
            var result = collection.Find(filter).ToList();


            foreach (var item in result)
            {
                StudentsNameCb.Items.Add(item.Lastname + " " + item.Firstname + " " + item.Middlename);
            }
        }
        private void autoGeneratedStudentsClassRecords()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            // Filter the students
            var collection = database.GetCollection<StudentModal>("StudentModal");
            var filter = Builders<StudentModal>.Filter.Eq(x => x.Section, SectionHandleLabel.Text);
            var AllStudents = collection.Find(filter).ToList();

            var recordCollection = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");

            int countOfStudent = 0;
            foreach (var student in AllStudents)
            {

                
                var existingRecord = recordCollection.Find(x => x.TeacherId == teacherID && x.StudentId == student.StudentId && x.Subject == teacherSubject).FirstOrDefault();

                
                if (existingRecord != null)
                {
                    continue;
                }
                
                
                var newStudentRecord = new TeachersStudentRecords
                {

                    Id = Guid.NewGuid().ToString(),
                    TeacherId = teacherID,
                    TeacherName = teacherFullname,
                    StudentId = student.StudentId,
                    StudentName = student.Fullname,
                    Subject = teacherSubject,
                    Strand = student.Strand,
                    GradeLevel = student.GradeLevel,
                    Section = student.Section,
                    AttendanceRecord = new List<Attendance> {
                                                                    new Attendance { WeekNumber = "1", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "2", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "3", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "4", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "5", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "6", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "7", Status = "No Record" },
                                                                    new Attendance { WeekNumber = "8", Status = "No Record" }
                                                                },
                    ActivityRecord = new List<AcademicActivities> {
                                                                    new AcademicActivities { WeekNumber = "1", ActivityType = "WorkSheet 1", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "2", ActivityType = "WorkSheet 2", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "3", ActivityType = "WorkSheet 3", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "4", ActivityType = "WorkSheet 4", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "5", ActivityType = "WorkSheet 5", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "6", ActivityType = "WorkSheet 6", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "7", ActivityType = "WorkSheet 7", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "8", ActivityType = "WorkSheet 8", Score = "0" },

                                                                    new AcademicActivities { WeekNumber = "1", ActivityType = "Quiz 1", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "2", ActivityType = "Quiz 2", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "3", ActivityType = "Quiz 3", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "4", ActivityType = "Quiz 4", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "5", ActivityType = "Quiz 5", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "6", ActivityType = "Quiz 6", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "7", ActivityType = "Quiz 7", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "8", ActivityType = "Quiz 8", Score = "0" },

                                                                    new AcademicActivities { WeekNumber = "1", ActivityType = "Performance Task 1", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "2", ActivityType = "Performance Task 2", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "3", ActivityType = "Performance Task 3", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "4", ActivityType = "Performance Task 4", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "5", ActivityType = "Performance Task 5", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "6", ActivityType = "Performance Task 6", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "7", ActivityType = "Performance Task 7", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = "8", ActivityType = "Performance Task 8", Score = "0" },

                                                                    new AcademicActivities { WeekNumber = null, ActivityType = "Exam 1", Score = "0" },
                                                                    new AcademicActivities { WeekNumber = null, ActivityType = "Exam 2", Score = "0" },
                                                                      },
                    GradeRecord = new List<Grades> {
                                                                    new Grades { Quarter = "First Quarter", Grade = "0"},
                                                                    new Grades { Quarter = "Second Quarter", Grade = "0"},
                                                        },
                    AverageGrade = "0"
                };
                recordCollection.InsertOne(newStudentRecord);
                countOfStudent++;
            }
            if(countOfStudent > 0)
            {
               MessageBox.Show("Successfully auto-generated " + countOfStudent + " records of registered student.");
            }
            
            

        }

        private void diplaySubjectsAndProperties()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<SubjectModal>("Subjects");

            var FilterSubjects = Builders<SubjectModal>.Filter.Eq(z => z.Title, teacherSubject);
            var Subject = collection.Find(FilterSubjects).FirstOrDefault();

            if (Subject != null)
            {
                SubjectLabel.Text = Subject.Title;

                NameOfHandout1.Text = Subject.NameHandout1;
                NameOfHandout2.Text = Subject.NameHandout2;
                NameOfHandout3.Text = Subject.NameHandout3;
                NameOfHandout4.Text = Subject.NameHandout4;
                NameOfHandout5.Text = Subject.NameHandout5;
                NameOfHandout6.Text = Subject.NameHandout6;
                NameOfHandout7.Text = Subject.NameHandout7;
                NameOfHandout8.Text = Subject.NameHandout8;

                FileOfHandout1.Text = Subject.LinkHandout1;
                FileOfHandout2.Text = Subject.LinkHandout2;
                FileOfHandout3.Text = Subject.LinkHandout3;
                FileOfHandout4.Text = Subject.LinkHandout4;
                FileOfHandout5.Text = Subject.LinkHandout5;
                FileOfHandout6.Text = Subject.LinkHandout6;
                FileOfHandout7.Text = Subject.LinkHandout7;
                FileOfHandout8.Text = Subject.LinkHandout8;
            }
            else
            {
                MessageBox.Show("No assigned subject!");
            }
            }
        public TeacherPage(string teacherID, string teacherFullname, string teacherSubject, string teacherSection)
        {
            InitializeComponent();
            this.teacherID = teacherID;
            this.teacherFullname = teacherFullname;
            this.teacherSubject = teacherSubject;
            this.teacherSection = teacherSection;

        }

        private void TeacherPage_Load(object sender, EventArgs e)
        {
            SubjectNameLabel.Text = teacherSubject;
            SectionHandleLabel.Text = teacherSection;
            TeachernameLabel.Text = teacherFullname;

            //
            HandoutsPanel.Visible = false;
            StudentManagePanel.Visible = false;

            ClassAttendancePanel.Visible = false;
            StudentRecordPanel.Visible = false;
            InputGradesPanel.Visible = false;

            UpdatePanel.Visible = false;
            AttendanceUpdatePanel.Visible = false;

            displayRegisteredStudents();
            diplaySubjectsAndProperties();
            autoGeneratedStudentsClassRecords();


        }

        private void ActionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionCb.SelectedItem == "Handouts")
            {
                HandoutsPanel.Visible = true;
                StudentManagePanel.Visible = false;
            }
            if (ActionCb.SelectedItem == "Manage Students")
            {

                HandoutsPanel.Visible = false;
                StudentManagePanel.Visible = true;
            }
            if (ActionCb.SelectedItem == "Logout")
            {
                this.Hide();
                LoginPage login = new LoginPage();
                login.ShowDialog();
                
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentsNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentModal>("StudentModal");


            var selectedName = StudentsNameCb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedName))
            {
                MessageBox.Show("Please select a student.");
                return;
            }

            var filter = Builders<StudentModal>.Filter.Eq(x => x.Fullname, selectedName);
            var student = collection.Find(filter).FirstOrDefault();

            if (student != null)
            {

                studentIDLabel.Text = student.StudentId;
                nameOfStudentLabel.Text = student.Fullname;
                strandOfStudentLabel.Text = student.Strand;
                gradeLevelOfStudentLabel.Text = student.GradeLevel;
                sectionOfStudentLabel.Text = student.Section;

            }
            else
            {
                MessageBox.Show("Student not found in the database.");
            }

            updateDisplayValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectQuarterCb.Text == "")
            {
                MessageBox.Show("Please choose a quarter");
                SelectQuarterCb.Focus();
                return;
            }
            TextBox[] worksheetScores = { WorksheetScore1, WorksheetScore2, WorksheetScore3, WorksheetScore4 };
            TextBox[] quizScores = { QuizScore1, QuizScore2, QuizScore3, QuizScore4 };
            TextBox[] PTScores = { PTScore1, PTScore2, PTScore3, PTScore4 };


            foreach (var scoreBox in worksheetScores)
            {
                if (string.IsNullOrEmpty(scoreBox.Text))
                {
                    MessageBox.Show("Please enter score.");
                    scoreBox.Focus();
                    scoreBox.Text = "";
                    return;
                }

                if (!scoreBox.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Invalid! Please enter numbers only.");
                    scoreBox.Focus();
                    scoreBox.Text = "";
                    return;
                }

                int score1 = int.Parse(scoreBox.Text);

                if (score1 > 50)
                {
                    MessageBox.Show("The maximum score for Worksheets is 50.");
                    scoreBox.Focus();
                    scoreBox.Text = "";
                    return;
                }

                if (score1 < 0)
                {
                    MessageBox.Show("The minimum score for Worksheets is 0.");
                    scoreBox.Focus();
                    scoreBox.Text = "";
                    return;
                }
            }
            // Quizzes validation
            foreach (var quizBox in quizScores)
            {
                if (string.IsNullOrEmpty(quizBox.Text))
                {
                    MessageBox.Show("Please enter score for quiz.");
                    quizBox.Focus();
                    quizBox.Text = "";
                    return;
                }

                if (!quizBox.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Invalid! Please enter numbers only.");
                    quizBox.Focus();
                    quizBox.Text = "";
                    return;
                }

                int score2 = int.Parse(quizBox.Text);

                if (score2 > 10)
                {
                    MessageBox.Show("The maximum score for quizzes is 10.");
                    quizBox.Focus();
                    quizBox.Text = "";
                    return;
                }

                if (score2 < 0)
                {
                    MessageBox.Show("The minimum score for quizzes is 0.");
                    quizBox.Focus();
                    quizBox.Text = "";
                    return;
                }
            }

            // Performance Tasks validation
            foreach (var ptBox in PTScores)
            {
                if (string.IsNullOrEmpty(ptBox.Text))
                {
                    MessageBox.Show("Please enter score for performance task.");
                    ptBox.Focus();
                    ptBox.Text = "";
                    return;
                }

                if (!ptBox.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Invalid! Please enter numbers only.");
                    ptBox.Focus();
                    ptBox.Text = "";
                    return;
                }

                int score3 = int.Parse(ptBox.Text);

                if (score3 > 100)
                {
                    MessageBox.Show("The maximum score for performance tasks is 100.");
                    ptBox.Focus();
                    ptBox.Text = "";
                    return;
                }

                if (score3 < 0)
                {
                    MessageBox.Show("The minimum score for performance tasks is 0.");
                    ptBox.Focus();
                    ptBox.Text = "";
                    return;
                }
            }
            if (string.IsNullOrEmpty(ExamScore.Text))
            {
                MessageBox.Show("Please enter score for Exam.");
                ExamScore.Focus();
                ExamScore.Text = "";
                return;
            }

            if (!ExamScore.Text.All(char.IsDigit))
            {
                MessageBox.Show("Invalid! Please enter numbers only.");
                ExamScore.Focus();
                ExamScore.Text = "";
                return;
            }

            int score = int.Parse(ExamScore.Text);

            if (score > 50)
            {
                MessageBox.Show("The maximum score for performance tasks is 50.");
                ExamScore.Focus();
                ExamScore.Text = "";
                return;
            }

            if (score < 0)
            {
                MessageBox.Show("The minimum score for performance tasks is 0.");
                ExamScore.Focus();
                ExamScore.Text = "";
                return;
            }


            // Formula to input grades (Percentage = Score/Total x 100)

            //Activities Solution
            double Worksheet1 = (double.Parse(WorksheetScore1.Text) / 50) * 100;
            double Worksheet2 = (double.Parse(WorksheetScore2.Text) / 50) * 100;
            double Worksheet3 = (double.Parse(WorksheetScore3.Text) / 50) * 100;
            double Worksheet4 = (double.Parse(WorksheetScore4.Text) / 50) * 100;
            // Quizzes Solution
            double Quiz1 = (double.Parse(QuizScore1.Text) / 10) * 100;
            double Quiz2 = (double.Parse(QuizScore2.Text) / 10) * 100;
            double Quiz3 = (double.Parse(QuizScore3.Text) / 10) * 100;
            double Quiz4 = (double.Parse(QuizScore4.Text) / 10) * 100;
            // Performance Task Solution
            double PerformanceTask1 = (double.Parse(PTScore1.Text) / 100) * 100;
            double PerformanceTask2 = (double.Parse(PTScore2.Text) / 100) * 100;
            double PerformanceTask3 = (double.Parse(PTScore3.Text) / 100) * 100;
            double PerformanceTask4 = (double.Parse(PTScore4.Text) / 100) * 100;
            // Exam Solution
            double ExamScore1 = (double.Parse(ExamScore.Text) / 50) * 100;
            // Divide with their percentage
            double AverageOfActivities = (Worksheet1 + Worksheet2 + Worksheet3 + Worksheet4) / 4;
            double AverageOfQuizzes = (Quiz1 + Quiz2 + Quiz3 + Quiz4) / 4;
            double AverageOfPerformanceTasks = (PerformanceTask1 + PerformanceTask2 + PerformanceTask3 + PerformanceTask4) / 4;

            double PercentageOfActivities = AverageOfActivities * 0.10;
            double PercentageOfQuizzes = AverageOfQuizzes * 0.10;
            double PercentageOfPerformanceTasks = AverageOfPerformanceTasks * 0.50;
            double PercentageOfExam = ExamScore1 * 0.30;

            double totalGrades = PercentageOfActivities + PercentageOfQuizzes + PercentageOfPerformanceTasks + PercentageOfExam;

            string status;
            if (totalGrades < 75) status = "(Failed)";
            else if (totalGrades < 80) { status = "(Fair)"; }
            else if (totalGrades < 85) { status = "(Good)"; }
            else if (totalGrades < 90) { status = "(Very Good)"; }
            else if (totalGrades < 95) { status = "(Excellent)"; }
            else status = "(Very Excellent)";

            ResultLabel.Text = totalGrades.ToString("F2");
            StatusLabel.Text = "% " + status;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void ClassAttendanceBtn_Click(object sender, EventArgs e)
        {
            ClassAttendancePanel.Visible = true;
            StudentRecordPanel.Visible = false;
            InputGradesPanel.Visible = false;
        }

        private void StudentRecordBtn_Click(object sender, EventArgs e)
        {
            ClassAttendancePanel.Visible = false;
            StudentRecordPanel.Visible = true;
            InputGradesPanel.Visible = false;
        }

        private void InputGradesBtn_Click(object sender, EventArgs e)
        {
            ClassAttendancePanel.Visible = false;
            StudentRecordPanel.Visible = false;
            InputGradesPanel.Visible = true;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StudentsNameCb.Text))
            {
                MessageBox.Show("Select student.");
                StudentsNameCb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TypeOfActivityCb.Text))
            {
                MessageBox.Show("Select type of activity to update.");
                TypeOfActivityCb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ScoreTxt.Text))
            {
                MessageBox.Show("Type score of activity.");
                ScoreTxt.Focus();
                return;
            }
            if (!ScoreTxt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Letters are invalid! please enter a numbers.");
                ScoreTxt.Focus();
                return;
            }
            if (TypeOfActivityCb.Text == "WorkSheet 1" || TypeOfActivityCb.Text == "WorkSheet 2" ||
                TypeOfActivityCb.Text == "WorkSheet 3" || TypeOfActivityCb.Text == "WorkSheet 4" ||
                TypeOfActivityCb.Text == "WorkSheet 5" || TypeOfActivityCb.Text == "WorkSheet 6" ||
                TypeOfActivityCb.Text == "WorkSheet 7" || TypeOfActivityCb.Text == "WorkSheet 8")
            {
                if (int.Parse(ScoreTxt.Text) > 50)
                {
                    MessageBox.Show("The score maximum limit for Worksheet is 50.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }
                else if (int.Parse(ScoreTxt.Text) < 1)
                {
                    MessageBox.Show("The score minimum limit for Worksheet is 1.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }

            }
            if (TypeOfActivityCb.Text == "Quiz 1" || TypeOfActivityCb.Text == "Quiz 2" ||
               TypeOfActivityCb.Text == "Quiz 3" || TypeOfActivityCb.Text == "Quiz 4" ||
               TypeOfActivityCb.Text == "Quiz 5" || TypeOfActivityCb.Text == "Quiz 6" ||
               TypeOfActivityCb.Text == "Quiz 7" || TypeOfActivityCb.Text == "Quiz 8")
            {
                if (int.Parse(ScoreTxt.Text) > 10)
                {
                    MessageBox.Show("The score maximum limit for Quiz is 10.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }
                else if (int.Parse(ScoreTxt.Text) < 1)
                {
                    MessageBox.Show("The score minimum limit for Quiz is 1.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }

            }
            if (TypeOfActivityCb.Text == "Performance Task 1" || TypeOfActivityCb.Text == "Performance Task 2" ||
               TypeOfActivityCb.Text == "Performance Task 3" || TypeOfActivityCb.Text == "Performance Task 4" ||
               TypeOfActivityCb.Text == "Performance Task 5" || TypeOfActivityCb.Text == "Performance Task 6" ||
               TypeOfActivityCb.Text == "Performance Task 7" || TypeOfActivityCb.Text == "Performance Task 8")
            {
                if (int.Parse(ScoreTxt.Text) > 100)
                {
                    MessageBox.Show("The score maximum limit for Performance Task is 100.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }
                else if (int.Parse(ScoreTxt.Text) < 1)
                {
                    MessageBox.Show("The score minimum limit for Performance Task is 1.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }

            }
            if (TypeOfActivityCb.Text == "Exam 1" || TypeOfActivityCb.Text == "Exam 2")
            {
                if (int.Parse(ScoreTxt.Text) > 50)
                {
                    MessageBox.Show("The score maximum limit for Exam is 50.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }
                else if (int.Parse(ScoreTxt.Text) < 1)
                {
                    MessageBox.Show("The score minimum limit for Exam is 1.");
                    ScoreTxt.Focus();
                    ScoreTxt.Text = "";
                    return;
                }

            }


            string selectedTypeOfActivity = TypeOfActivityCb.Text;
            string scoreValue = ScoreTxt.Text;

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filter = Builders<TeachersStudentRecords>.Filter.And(
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, teacherID),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, teacherSubject),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentIDLabel.Text),
                   Builders<TeachersStudentRecords>.Filter.ElemMatch(z => z.ActivityRecord, a => a.ActivityType == selectedTypeOfActivity)
            );

            var update = Builders<TeachersStudentRecords>.Update.Set("ActivityRecord.$.Score", scoreValue);
            collection.UpdateOne(filter, update);

            MessageBox.Show("Successfully update " + selectedTypeOfActivity);
            updateDisplayValue();
            TypeOfActivityCb.Text = "";
            ScoreTxt.Text = "";
            UpdatePanel.Visible = false;

        }

        private void SelectQuarterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_quarter = SelectQuarterCb.Text;

            if (string.IsNullOrEmpty(StudentsNameCb.Text))
            {
                MessageBox.Show("Please select student first.");
                StudentsNameCb.Focus();
                SelectQuarterCb.Text = "";
                return;
            }


            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");

            var collection2 = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filterStudentRecord = Builders<TeachersStudentRecords>.Filter.And
                (
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, teacherID),
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, teacherSubject),
                 Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentIDLabel.Text)
                );
            var studentRecord = collection2.Find(filterStudentRecord).FirstOrDefault();
            if (studentRecord != null)
            {
                List<string> Activities = new List<string>();

                foreach (var activitiesObjectArray in studentRecord.ActivityRecord)
                {
                    Activities.Add(activitiesObjectArray.Score);
                }


                if (Activities.Count < 26)
                {
                    MessageBox.Show("The student does not have complete activity records yet.");
                    return;
                }

                if (selected_quarter == "First Quarter")
                {
                    WorksheetScore1.Text = Activities[0];
                    WorksheetScore2.Text = Activities[1];
                    WorksheetScore3.Text = Activities[2];
                    WorksheetScore4.Text = Activities[3];

                    QuizScore1.Text = Activities[8];
                    QuizScore2.Text = Activities[9];
                    QuizScore3.Text = Activities[10];
                    QuizScore4.Text = Activities[11];

                    PTScore1.Text = Activities[16];
                    PTScore2.Text = Activities[17];
                    PTScore3.Text = Activities[18];
                    PTScore4.Text = Activities[19];
                }
                ;
                if (selected_quarter == "Second Quarter")
                {
                    WorksheetScore1.Text = Activities[4];
                    WorksheetScore2.Text = Activities[5];
                    WorksheetScore3.Text = Activities[6];
                    WorksheetScore4.Text = Activities[7];

                    QuizScore1.Text = Activities[12];
                    QuizScore2.Text = Activities[13];
                    QuizScore3.Text = Activities[14];
                    QuizScore4.Text = Activities[15];

                    PTScore1.Text = Activities[20];
                    PTScore2.Text = Activities[21];
                    PTScore3.Text = Activities[22];
                    PTScore4.Text = Activities[23];
                }
                ;




            }
            else
            {
                MessageBox.Show("Student not found in the database.");
            }
        }

        private void UpdatePanelBtn_Click(object sender, EventArgs e)
        {
            UpdatePanel.Visible = true;


        }

        private void CloseUpdatePanelBtn_Click(object sender, EventArgs e)
        {
            UpdatePanel.Visible = false;
        }

        private void ScoreTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void AttendanceUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StudentsNameCb.Text))
            {
                MessageBox.Show("Select student.");
                StudentsNameCb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(SelectWeeksCb.Text))
            {
                MessageBox.Show("Select weeks.");
                SelectWeeksCb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(SelectAttendanceCb.Text))
            {
                MessageBox.Show("Select attendance status.");
                SelectAttendanceCb.Focus();
                return;
            }
            string selectedWeeks = SelectWeeksCb.Text;
            string selectedAttendance = SelectAttendanceCb.Text;

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filter = Builders<TeachersStudentRecords>.Filter.And(
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, teacherID),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, teacherSubject),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentIDLabel.Text),
                   Builders<TeachersStudentRecords>.Filter.ElemMatch(z => z.AttendanceRecord, a => a.WeekNumber == selectedWeeks)
            );

            var update = Builders<TeachersStudentRecords>.Update.Set("AttendanceRecord.$.Status", selectedAttendance);
            collection.UpdateOne(filter, update);
            sendEmailMessage();

            MessageBox.Show("Successfully update week " + selectedWeeks);
            updateDisplayValue();
            SelectWeeksCb.Text = "";
            SelectAttendanceCb.Text = "";
            AttendanceUpdatePanel.Visible = false;
        }

        private void AttendanceUpdateDropDownBtn_Click(object sender, EventArgs e)
        {
            AttendanceUpdatePanel.Visible = true;
        }

        private void AttendanceCloseBtn_Click(object sender, EventArgs e)
        {
            AttendanceUpdatePanel.Visible = false;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(ResultLabel.Text == "00.00")
            {
                MessageBox.Show("Please compute the grade of student.");
                return;
            }

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filter = Builders<TeachersStudentRecords>.Filter.And(
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, teacherID),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, teacherSubject),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentIDLabel.Text),
                   Builders<TeachersStudentRecords>.Filter.ElemMatch(z => z.GradeRecord, a => a.Quarter == SelectQuarterCb.Text)
            );
            var update = Builders<TeachersStudentRecords>.Update.Set("GradeRecord.$.Grade", ResultLabel.Text);

            var collection2 = database.GetCollection<StudentGrades>("StudentGrades");
            var filter2 = Builders<StudentGrades>.Filter.Eq(z => z.StudentID, studentIDLabel.Text);

            GradeRecording fillGradeRecord = null;

            if (SelectQuarterCb.Text == "First Quarter")
            {
                fillGradeRecord = new GradeRecording
                {
                    Subject = teacherSubject,
                    TeacherID = teacherID,
                    TeacherFullname = teacherFullname,
                    FinalGrade1 = ResultLabel.Text
                };
                if (fillGradeRecord != null)
                {

                    var updateExam1 = Builders<StudentGrades>.Update.Push(z => z.SubjectList, fillGradeRecord);
                    collection2.UpdateOne(filter2, updateExam1);
                }
            }
            else if (SelectQuarterCb.Text == "Second Quarter")
            {
                
                var filterUpdate = Builders<StudentGrades>.Filter.And(
                    Builders<StudentGrades>.Filter.Eq(z => z.StudentID, studentIDLabel.Text),
                    Builders<StudentGrades>.Filter.ElemMatch(z => z.SubjectList, x => x.Subject == teacherSubject)
                );

                
                var updateExam2 = Builders<StudentGrades>.Update.Set("SubjectList.$.FinalGrade2", ResultLabel.Text);

                var result = collection2.UpdateOne(filterUpdate, updateExam2);

            }


            collection.UpdateOne(filter, update);
            MessageBox.Show("Successfully saved a grade for " + SelectQuarterCb.Text);
            ResultLabel.Text = "00.00";
        }
    }
    }
