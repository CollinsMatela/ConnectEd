using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Globalization;

namespace ConnectEducation
{
    public partial class StudentPage : Form
    {

        private string FirstSubject, SecondSubject, ThirdSubject, FourthSubject, FifthSubject, SixthSubject, SeventhSubject, EightSubject;
        private string IdOfStudent, FullnameOfStudent, StrandOfStudent, GradeLevelOfStudent, SemesterOfStudent, SectionOfStudent;
        private string link;

        private void QuizListBoxProperties()
        {
            QuizListView.View = View.Details;      // table mode
            QuizListView.FullRowSelect = true;
            QuizListView.GridLines = true;

            QuizListView.Columns.Add("", 0);
            QuizListView.Columns.Add("Title", 50);
            QuizListView.Columns.Add("Subject", 250);
            QuizListView.Columns.Add("Instructor", 150);
            QuizListView.Columns.Add("Section", 100);
            QuizListView.Columns.Add("Deadline", 120);
        }
        private void LoadQuizzes()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<QuizModel>("QuizModel");
            var filter = Builders<QuizModel>.Filter.Eq(z => z.Section, SectionOfStudent);
            var quizzes = collection.Find(filter).ToList();

            QuizListView.Items.Clear();

            foreach (var quiz in quizzes)
            {
                // 1. Skip NULL or empty deadlines
                if (string.IsNullOrEmpty(quiz.Deadline))
                {
                    continue;
                }

                // 2. Try parse using exact format dd/MM/yyyy
                if (!DateTime.TryParseExact(
                        quiz.Deadline,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime quizDeadline))
                {
                    continue; // skip invalid formats
                }

                // 3. Skip if deadline already passed
                if (quizDeadline < DateTime.Today)
                {
                    continue;
                }


                ListViewItem item = new ListViewItem(quiz.QuizId);
                item.SubItems.Add(quiz.QuizTitle);
                item.SubItems.Add(quiz.SubjectName);
                item.SubItems.Add(quiz.Instructor);
                item.SubItems.Add(quiz.Section);
                item.SubItems.Add(quiz.Deadline);   // make sure string format

                QuizListView.Items.Add(item);
            }
        }

        private void displaySystemLog()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<AnnouncementModel>("AnnouncementModel");
            var result = collection.Find(_ => true).ToList();
            if (result.Count > 0)
            {
                foreach (var announcement in result)
                {
                    SystemLogListBox.Items.Add("ATTENTION! - " + announcement.Message);
                    SystemLogListBox.Items.Add("");
                }
            }
        }
        private void displayProfileInformation()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentModal>("StudentModal");
            var filter = Builders<StudentModal>.Filter.Eq(z => z.StudentId, IdOfStudent);
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                ProfileStudentName.Text = result.Fullname;
                ProfileAge.Text = result.Age;
                ProfileGender.Text = result.Gender;
                ProfileBirthday.Text = result.DateOfBirth.ToString("MMMM/dd/yyyy");
                ProfileHomeAddress.Text = result.HomeAddress;
                ProfileContactNumber.Text = result.Contact;
                ProfileStudentEmail.Text = result.Email;

                ProfileGuardianName.Text = result.GuardianLastname + " " + result.GuardianFirstname + " " + result.GuardianMiddleInitial;
                ProfileGuardianRelationship.Text = result.GuardianRelationship;
                ProfileGuardianContactNumber.Text = result.GuardianContact;
                ProfileGuardianEmail.Text = result.GuardianEmail;

                ProfileGradeLevel.Text = result.GradeLevel;
                ProfileStrand.Text = result.Strand;
                ProfileSemester.Text = result.Semester;
                ProfileSection.Text = result.Section;

                ProfileAccountIdentification.Text = result.StudentId;
                AccountPasswordTxt.Text = result.StudentPassword;
            }
        }
        private void submission()
        {
            if (subjectNameHeader.Text == "Select Subject")
            {
                MessageBox.Show("Please select a subject!");
                return;
            }

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");
            var filter = Builders<TeacherInformationModal>.Filter.And(
                         Builders<TeacherInformationModal>.Filter.Eq(z => z.Subject, subjectNameHeader.Text),
                         Builders<TeacherInformationModal>.Filter.Eq(z => z.Section, SectionOfStudent)
                         );
            var result = collection.Find(filter).FirstOrDefault();
            if (result != null)
            {
                string subject = subjectNameHeader.Text;
                string instructor = result.Fullname;
                string instructorId = result.TeacherID;
                string studentId = IdOfStudent;
                string student = FullnameOfStudent;
                string section = SectionOfStudent;

                if (SubmissionCb.Text == "Handout 1: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 1", "WorkSheet 1", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 1: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 1", "Performance Task 1", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 2: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 2", "WorkSheet 2", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 2: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 2", "Performance Task 2", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 3: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 3", "WorkSheet 3", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 3: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 3", "Performance Task 3", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 4: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 4", "WorkSheet 4", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 4: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 4", "Performance Task 4", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 5: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 5", "WorkSheet 5", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 5: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 5", "Performance Task 5", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 6: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 6", "WorkSheet 6", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 6: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 6", "Performance Task 6", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 7: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 7", "WorkSheet 7", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 7: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 7", "Performance Task 7", studentId, student, section);
                    submitForm.Show();
                }

                if (SubmissionCb.Text == "Handout 8: Worksheet")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 8", "WorkSheet 8", studentId, student, section);
                    submitForm.Show();
                }
                if (SubmissionCb.Text == "Handout 8: Performance Task")
                {
                    Submit submitForm = new Submit(subject, instructor, instructorId, "Handout 8", "Performance Task 8", studentId, student, section);
                    submitForm.Show();
                }


            }





        }


        //var connectionString = "mongodb://localhost:27017";
        //var client = new MongoClient(connectionString);
        //var database = client.GetDatabase("ConnectED");
        //var collection = database.GetCollection<SubjectModal>("Subjects");

        //var subjectProperties = new SubjectModal
        //{
        //    Title = "General Chemistry 1",

        //    NameHandout1 = "Introduction to Chemistry and Scientific Measurement",
        //    NameHandout2 = "The Structure of the Atom",
        //    NameHandout3 = "Electronic Structure and the Periodic Table",
        //    NameHandout4 = "Chemical Bonding and Molecular Geometry",
        //    NameHandout5 = "Stoichiometry: Chemical Formulas and Equations",
        //    NameHandout6 = "The States of Matter: Gases, Liquids, and Solids",
        //    NameHandout7 = "Solutions and Their Properties",
        //    NameHandout8 = "Thermochemistry and Energy Changes",

        //    LinkHandout1 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout2 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout3 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout4 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout5 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout6 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout7 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    LinkHandout8 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",

        //    Assignment1 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment2 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment3 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment4 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment5 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment6 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment7 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    Assignment8 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",

        //    PerformanceTask1 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask2 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask3 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask4 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask5 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask6 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask7 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",
        //    PerformanceTask8 = "https://www.w3.org/WAI/ER/tests/xhtml/testfiles/resources/pdf/dummy.pdf",

        //};
        //collection.InsertOne(subjectProperties);

        private void displayGrades()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentGrades>("StudentGrades");
            var filter = Builders<StudentGrades>.Filter.And(
                         Builders<StudentGrades>.Filter.Eq(z => z.StudentID, IdOfStudent),
                         Builders<StudentGrades>.Filter.Eq(z => z.StudentFullname, FullnameOfStudent),
                         Builders<StudentGrades>.Filter.Eq(z => z.StudentSection, SectionOfStudent)
                         );
            var gradeRecord = collection.Find(filter).FirstOrDefault();
            if (gradeRecord != null)
            {
                if (gradeRecord.SubjectList == null || gradeRecord.SubjectList.Count == 0)
                {
                    MessageBox.Show("Grades are not yet available. Please check back later.");
                    return;
                }


                Label[] nameOfSubjectLabels = { Sub1Label, Sub2Label, Sub3Label, Sub4Label, Sub5Label, Sub6Label, Sub7Label, Sub8Label };
                Label[] nameOfInstructorLabels = { TeacherNameLabel1, TeacherNameLabel2, TeacherNameLabel3, TeacherNameLabel4, TeacherNameLabel5, TeacherNameLabel6, TeacherNameLabel7, TeacherNameLabel8 };
                Label[] GradeLabels = { GradeLabel1, GradeLabel2, GradeLabel3, GradeLabel4, GradeLabel5, GradeLabel6, GradeLabel7, GradeLabel8 };

                if (QuarterSelectionCb.Text == "First Grade" || QuarterSelectionCb.Text == string.Empty)
                {
                    int i = 0;
                    foreach (var item in gradeRecord.SubjectList)
                    {
                        nameOfSubjectLabels[i].Text = item.Subject;
                        nameOfInstructorLabels[i].Text = item.TeacherFullname;
                        GradeLabels[i].Text = item.FinalGrade1;
                        i++;
                    }
                }
                if (QuarterSelectionCb.Text == "Second Grade")
                {
                    int i = 0;
                    foreach (var item in gradeRecord.SubjectList)
                    {
                        nameOfSubjectLabels[i].Text = item.Subject;
                        nameOfInstructorLabels[i].Text = item.TeacherFullname;
                        GradeLabels[i].Text = item.FinalGrade2;
                        i++;
                    }
                }

            }
            else
            {
                MessageBox.Show("Student record have not found in database");
            }
        }




        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(panel.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(panel.Width - radius, panel.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, panel.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }
        private void MakeLink(LinkLabel URLname)
        {
            if (URLname != null && !string.IsNullOrEmpty(URLname.Text))
            {
                URLname.Links.Clear();
                URLname.Links.Add(0, URLname.Text.Length, URLname.Text);
            }
        }
        private void displayNameOfSubjectsInGradesPanel()
        {
            string StudentName = FullnameOfStudent;
            string Strand = StrandOfStudent;
            string Grade = GradeLevelOfStudent;
            string Semester = SemesterOfStudent;

            SchoolCurriculum schoolCurriculum = new SchoolCurriculum();

            if (StudentName != "")
            {
                schoolCurriculum.StudentCurriculum(StudentName);

                if (Strand == "STEM")
                {
                    schoolCurriculum.STEM(Grade, Semester);
                }
                else if (Strand == "ABM")
                {
                    schoolCurriculum.ABM(Grade, Semester);
                }
                else if (Strand == "HUMSS")
                {
                    schoolCurriculum.HUMSS(Grade, Semester);
                }
                else
                {
                    MessageBox.Show("mali dito");
                }

            }
            else
            {
                MessageBox.Show("No Registered Student :(");
            }



            FirstSubject = schoolCurriculum._Subject1;
            SecondSubject = schoolCurriculum._Subject2;
            ThirdSubject = schoolCurriculum._Subject3;
            FourthSubject = schoolCurriculum._Subject4;
            FifthSubject = schoolCurriculum._Subject5;
            SixthSubject = schoolCurriculum._Subject6;
            SeventhSubject = schoolCurriculum._Subject7;
            EightSubject = schoolCurriculum._Subject8;

            // Grades panel
            //Sub1Label.Text = FirstSubject;
            //Sub2Label.Text = SecondSubject;
            //Sub3Label.Text = ThirdSubject;
            //Sub4Label.Text = FourthSubject;
            //Sub5Label.Text = FifthSubject;
            //Sub6Label.Text = SixthSubject;
            //Sub7Label.Text = SeventhSubject;
            //Sub8Label.Text = EightSubject;
        }

        public StudentPage(string studID, string studFullname, string studStrand, string studGradeLevel, string studSemester, string studSection)
        {
            InitializeComponent();

            SubjectsPanel.AutoScroll = true;

            this.IdOfStudent = studID;
            this.FullnameOfStudent = studFullname;
            this.StrandOfStudent = studStrand;
            this.GradeLevelOfStudent = studGradeLevel;
            this.SemesterOfStudent = studSemester;
            this.SectionOfStudent = studSection;

        }
        private void StudentPage_Load(object sender, EventArgs e)
        {
            string StudentName = FullnameOfStudent;
            string Strand = StrandOfStudent;
            string Grade = GradeLevelOfStudent;
            string Semester = SemesterOfStudent;

            QuizPanel.Visible = false;
            SubjectsPanel.Visible = false;
            GradingSystemPanel.Visible = false;
            StudentProfilePanel.Visible = false;

            SchoolCurriculum schoolCurriculum = new SchoolCurriculum();

            if (StudentName != "")
            {
                schoolCurriculum.StudentCurriculum(StudentName);

                if (Strand == "STEM")
                {
                    schoolCurriculum.STEM(Grade, Semester);
                }
                else if (Strand == "ABM")
                {
                    schoolCurriculum.ABM(Grade, Semester);
                }
                else if (Strand == "HUMSS")
                {
                    schoolCurriculum.HUMSS(Grade, Semester);
                }
                else
                {
                    MessageBox.Show("Invalid Strand");
                }

            }
            else
            {
                MessageBox.Show("No Registered Student :(");
            }

            AccountPasswordTxt.UseSystemPasswordChar = true;
            ConfirmPasswordTxt.UseSystemPasswordChar = true;
            NewPasswordTxt.UseSystemPasswordChar = true;
            displayProfileInformation();
            displaySystemLog();

            QuizListBoxProperties();
            LoadQuizzes();

            FirstSubject = schoolCurriculum._Subject1;
            SecondSubject = schoolCurriculum._Subject2;
            ThirdSubject = schoolCurriculum._Subject3;
            FourthSubject = schoolCurriculum._Subject4;
            FifthSubject = schoolCurriculum._Subject5;
            SixthSubject = schoolCurriculum._Subject6;
            SeventhSubject = schoolCurriculum._Subject7;
            EightSubject = schoolCurriculum._Subject8;

            // Pop-Up Panel
            subject1.Text = FirstSubject;
            subject2.Text = SecondSubject;
            subject3.Text = ThirdSubject;
            subject4.Text = FourthSubject;
            subject5.Text = FifthSubject;
            subject6.Text = SixthSubject;
            subject7.Text = SeventhSubject;
            subject8.Text = EightSubject;

            SubjectsPopUpPanel.Visible = false;
        }
        private void btnSubject_Click(object sender, EventArgs e)
        {
            if (SubjectsPopUpPanel.Visible)
            {
                SubjectsPopUpPanel.Visible = false;
            }
            else
            {
                SubjectsPopUpPanel.Visible = true;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void subject5_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject5.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            GradingSystemPanel.Visible = true;
            SubjectsPanel.Visible = false;
            StudentProfilePanel.Visible = false;
            //displayNameOfSubjectsInGradesPanel();
            displayGrades();

        }

        private void LinkOfHandout2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void LinkOfHandout8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void Assignment1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }
        private void PerformanceTask6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }


        private void PerformanceTask8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void PerformanceTask7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void Assignment8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            });
        }

        private void subject1_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject1.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject2_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject2.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject3_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject3.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject4_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject4.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject6_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject6.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject7_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject7.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void subject8_Click(object sender, EventArgs e)
        {
            SubmissionCb.Text = "";

            string nameOfText = subject8.Text;
            subjectNameHeader.Text = nameOfText;
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<SubjectModal>("Subjects");

                var filter = Builders<SubjectModal>.Filter.Eq(s => s.Title, nameOfText);
                var result = collection.Find(filter).FirstOrDefault();

                if (result != null)
                {
                    TitleOfHandout1.Text = result.NameHandout1;
                    TitleOfHandout2.Text = result.NameHandout2;
                    TitleOfHandout3.Text = result.NameHandout3;
                    TitleOfHandout4.Text = result.NameHandout4;
                    TitleOfHandout5.Text = result.NameHandout5;
                    TitleOfHandout6.Text = result.NameHandout6;
                    TitleOfHandout7.Text = result.NameHandout7;
                    TitleOfHandout8.Text = result.NameHandout8;

                    LinkOfHandout1.Text = result.LinkHandout1;
                    LinkOfHandout2.Text = result.LinkHandout2;
                    LinkOfHandout3.Text = result.LinkHandout3;
                    LinkOfHandout4.Text = result.LinkHandout4;
                    LinkOfHandout5.Text = result.LinkHandout5;
                    LinkOfHandout6.Text = result.LinkHandout6;
                    LinkOfHandout7.Text = result.LinkHandout7;
                    LinkOfHandout8.Text = result.LinkHandout8;

                    Assignment1.Text = result.Assignment1;
                    Assignment2.Text = result.Assignment2;
                    Assignment3.Text = result.Assignment3;
                    Assignment4.Text = result.Assignment4;
                    Assignment5.Text = result.Assignment5;
                    Assignment6.Text = result.Assignment6;
                    Assignment7.Text = result.Assignment7;
                    Assignment8.Text = result.Assignment8;

                    PerformanceTask1.Text = result.PerformanceTask1;
                    PerformanceTask2.Text = result.PerformanceTask2;
                    PerformanceTask3.Text = result.PerformanceTask3;
                    PerformanceTask4.Text = result.PerformanceTask4;
                    PerformanceTask5.Text = result.PerformanceTask5;
                    PerformanceTask6.Text = result.PerformanceTask6;
                    PerformanceTask7.Text = result.PerformanceTask7;
                    PerformanceTask8.Text = result.PerformanceTask8;



                }
                MakeLink(LinkOfHandout1);
                MakeLink(LinkOfHandout2);
                MakeLink(LinkOfHandout3);
                MakeLink(LinkOfHandout4);
                MakeLink(LinkOfHandout5);
                MakeLink(LinkOfHandout6);
                MakeLink(LinkOfHandout7);
                MakeLink(LinkOfHandout8);

                MakeLink(Assignment1);
                MakeLink(Assignment2);
                MakeLink(Assignment3);
                MakeLink(Assignment4);
                MakeLink(Assignment5);
                MakeLink(Assignment6);
                MakeLink(Assignment7);
                MakeLink(Assignment8);

                MakeLink(PerformanceTask1);
                MakeLink(PerformanceTask2);
                MakeLink(PerformanceTask3);
                MakeLink(PerformanceTask4);
                MakeLink(PerformanceTask5);
                MakeLink(PerformanceTask6);
                MakeLink(PerformanceTask7);
                MakeLink(PerformanceTask8);


                SubjectsPopUpPanel.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnSubmit1_Click(object sender, EventArgs e)
        {

        }

        private void StudentLogoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.ShowDialog();
            this.Close();
        }

        private void SubjectsBtn_Click(object sender, EventArgs e)
        {
            SubjectsPanel.Visible = true;
            GradingSystemPanel.Visible = false;
            StudentProfilePanel.Visible = false;
        }

        private void TeacherNameLabel1_Click(object sender, EventArgs e)
        {
            //string subject = Sub1Label.Text.Trim();
            //string section = SectionOfStudent.Trim();

            //if (string.IsNullOrEmpty(subject))
            //{
            //    MessageBox.Show("No subject assigned for this label.");
            //    return;
            //}

            //var connectionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connectionString);
            //var database = client.GetDatabase("ConnectED");
            //var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

            //// Create filter to find the teacher
            //var filter = Builders<TeacherInformationModal>.Filter.And(
            //    Builders<TeacherInformationModal>.Filter.Regex(z => z.Subject, new BsonRegularExpression($"^{subject}$", "i")),
            //    Builders<TeacherInformationModal>.Filter.Regex(z => z.Section, new BsonRegularExpression($"^{section}$", "i"))
            //);

            //var instructor = collection.Find(filter).FirstOrDefault();

            //if (instructor != null)
            //{
            //    // Display found teacher info
            //    MessageBox.Show(
            //        $"Teacher found!\n\n" +
            //        $"Name: {instructor.Fullname}\n" +
            //        $"Subject: {instructor.Subject}\n" +
            //        $"Section: {instructor.Section}",
            //        "Instructor Information",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information
            //    );
            //}
            //else
            //{
            //    MessageBox.Show("No instructor found for this subject and section.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void TeacherNameLabel2_Click(object sender, EventArgs e)
        {

        }

        private void QuarterSelectionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (QuarterSelectionCb.Text == "First Grade")
            {
                displayGrades();
            }
            if (QuarterSelectionCb.Text == "Second Grade")
            {
                displayGrades();
            }

        }

        private void SubmissionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            submission();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            StudentProfilePanel.Visible = true;
            SubjectsPanel.Visible = false;
            GradingSystemPanel.Visible = false;

        }

        private void PasswordUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConfirmPasswordTxt.Text))
            {
                MessageBox.Show("PLease enter your previous password.");
                return;
            }
            if (ConfirmPasswordTxt.Text != AccountPasswordTxt.Text)
            {
                MessageBox.Show("Confirmation password is incorrect.");
                return;
            }
            if (string.IsNullOrEmpty(NewPasswordTxt.Text))
            {
                MessageBox.Show("PLease enter your new password.");
                return;
            }
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<StudentModal>("StudentModal");
            var filter = Builders<StudentModal>.Filter.Eq(z => z.StudentId, IdOfStudent);
            var update = Builders<StudentModal>.Update.Set(z => z.StudentPassword, NewPasswordTxt.Text);

            collection.UpdateOne(filter, update);
            MessageBox.Show("Successfully updated a new password");
            displayProfileInformation();
            ConfirmPasswordTxt.Text = "";
            NewPasswordTxt.Text = "";
        }

        private void SidebarPanel_MouseEnter(object sender, EventArgs e)
        {
            SidebarPanel.Width = 787;

        }
        private void SidebarPanel_MouseLeave(object sender, EventArgs e)
        {
            Point cursorPos = SidebarPanel.PointToClient(Cursor.Position);
            if (!SidebarPanel.ClientRectangle.Contains(cursorPos))
            {
                SidebarPanel.Width = 60; // collapse
            }
        }

        private void SystemLogListBox_MouseEnter(object sender, EventArgs e)
        {
            SidebarPanel.Width = 787;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void QuizListView_Click(object sender, EventArgs e)
        {
            if (QuizListView.SelectedItems.Count == 0)
            {  return; }

            ListViewItem selectedItem = QuizListView.SelectedItems[0];

            // Ask for confirmation
            DialogResult result = MessageBox.Show("Do you want to open this quiz?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                QuizPanel.Visible = true;
                SubjectsPanel.Visible = false;
                GradingSystemPanel.Visible = false;
                StudentProfilePanel.Visible = false;
                SidebarPanel.Width = 60;

                
                string quizId = selectedItem.SubItems[0].Text; // assuming first column is the ID

                // Connect to MongoDB
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<QuizModel>("QuizModel");

                // Find the quiz by ID
                var filter = Builders<QuizModel>.Filter.Eq(z => z.QuizId, quizId);
                var quiz = collection.Find(filter).FirstOrDefault();

                if (quiz != null)
                {
                    QuizTitleLabel.Text = quiz.QuizTitle;
                    QuizIdLabel.Text = quiz.QuizId;
                    QuizDeadlineLabel.Text = quiz.Deadline;

                    string quizIdentification = quiz.QuizId;
                    string quizTitle = quiz.QuizTitle;
                    string [] questionsArr = quiz.Question;
                    string [] answers = quiz.AnswerKey;
                    string deadline = quiz.Deadline;

                    Label[] questionaire = { QuestionLabel1, QuestionLabel2, QuestionLabel3, QuestionLabel4, QuestionLabel5, QuestionLabel6, QuestionLabel7, QuestionLabel8, QuestionLabel9, QuestionLabel10 };

                    for (int i = 0; i < questionaire.Length && i < questionsArr.Length; i++)
                    {
                        questionaire[i].Text = questionsArr[i];
                    }
                }
                else
                {
                    MessageBox.Show("Quiz not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
