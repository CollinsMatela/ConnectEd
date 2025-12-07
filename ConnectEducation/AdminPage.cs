using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConnectEducation
{
    public partial class AdminPage : Form
    {

        public AdminPage()
        {
            InitializeComponent();
        }

        private void MakeRoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void SetRoundedButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }
        private void SetTopRoundedButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(btn.Width, radius, btn.Width, btn.Height);
            path.AddLine(btn.Width, btn.Height, 0, btn.Height);
            path.AddLine(0, btn.Height, 0, radius);

            path.CloseAllFigures();

            btn.Region = new Region(path);
        }
        private void SetRoundedRichTextBox(RichTextBox rtb, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(rtb.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(rtb.Width, radius, rtb.Width, rtb.Height);
            path.AddLine(rtb.Width, rtb.Height, 0, rtb.Height);
            path.AddLine(0, rtb.Height, 0, radius);

            path.CloseAllFigures();

            rtb.Region = new Region(path);
        }
        private void SetRoundedTextBox(TextBox txt, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(txt.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(txt.Width - radius, txt.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, txt.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            txt.Region = new Region(path);
        }


        private void checkAvailabilityOfSubjectForInstructors()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");
            var filter = Builders<TeacherInformationModal>.Filter.And(
                         Builders<TeacherInformationModal>.Filter.Eq(z => z.Subject, SubjectCb.Text),
                         Builders<TeacherInformationModal>.Filter.Eq(z => z.Section, ClassSectionsCb.Text)
                );
            var existing = collection.Find(filter).FirstOrDefault();

            if (existing != null)
            {
                SubjectCb.Text = string.Empty;
                //SubjectCb.SelectedItem = null;   
                MessageBox.Show("The selected subject is already assigned to another instructor");
                SubjectCb.Focus();
                return;
            }

        }
        private void UpdateSectionComboBox()
        {
            SectionCb.Text = "";
            SectionCb.Items.Clear();

            if (GradeLevelCb.SelectedItem == null || StrandCb.SelectedItem == null)
                return;

            string grade = GradeLevelCb.SelectedItem.ToString();
            string strand = StrandCb.SelectedItem.ToString();

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");


            string collectionName = "";

            if (grade == "Grade 11" && strand == "STEM") { collectionName = "Grade11_STEM"; }
            else if (grade == "Grade 12" && strand == "STEM") { collectionName = "Grade12_STEM"; }
            else if (grade == "Grade 11" && strand == "ABM") { collectionName = "Grade11_ABM"; }
            else if (grade == "Grade 12" && strand == "ABM") { collectionName = "Grade12_ABM"; }
            else if (grade == "Grade 11" && strand == "HUMSS") { collectionName = "Grade11_HUMSS"; }
            else if (grade == "Grade 12" && strand == "HUMSS") { collectionName = "Grade12_HUMSS"; }
            else { return; }
            ;

            var collection = database.GetCollection<ClassInformationModal>(collectionName);
            var result = collection.Find(res => res.GradeLevel == grade && res.Strand == strand).ToList();


            foreach (var item in result)
            {
                SectionCb.Items.Add(item.Section);
            }
        }

        private void displayRegisteredInstructor()
        {

            InstructorCb.Items.Clear();

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");
            var result = collection.Find(_ => true).ToList();


            foreach (var item in result)
            {
                InstructorCb.Items.Add(item.Lastname + " " + item.Firstname + " " + item.Middlename);
            }
        }
        private void displaySubjects()
        {
            //SubjectCb.Items.Clear();

            //var connectionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connectionString);
            //var database = client.GetDatabase("ConnectED");
            //var collection = database.GetCollection<SubjectModal>("Subjects");
            //var result = collection.Find(_ => true).ToList(); // all subjects in database


            //foreach (var item in result)
            //{
            //    SubjectCb.Items.Add(item.Title);
            //}
            if (StrandAndGradeCb.SelectedItem == null || SelectSemesterCb.SelectedItem == null)
            {
                return;
            }
            SubjectCb.Items.Clear();
            // STEM - Grade 11
            if (StrandAndGradeCb.SelectedItem.ToString() == "STEM - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("Pre-Calculus");
                SubjectCb.Items.Add("General Biology 1");
                SubjectCb.Items.Add("General Chemistry 1");
                SubjectCb.Items.Add("General Physics 1");
                SubjectCb.Items.Add("Practical Research 1");
                SubjectCb.Items.Add("Filipino sa Piling Larang");
                SubjectCb.Items.Add("Earth and Life Science");
                SubjectCb.Items.Add("Personal Development");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "STEM - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Basic-Calculus");
                SubjectCb.Items.Add("General Biology 2");
                SubjectCb.Items.Add("General Chemistry 2");
                SubjectCb.Items.Add("General Physics 2");
                SubjectCb.Items.Add("Practical Research 2");
                SubjectCb.Items.Add("21st Century Literature");
                SubjectCb.Items.Add("Oral Communication");
                SubjectCb.Items.Add("Physical Education and Health");
            }
            // STEM - Grade 12
            if (StrandAndGradeCb.SelectedItem.ToString() == "STEM - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("English for Academic and Professional Purposes");
                SubjectCb.Items.Add("Entrepreneurship");
                SubjectCb.Items.Add("General Mathematics 1");
                SubjectCb.Items.Add("Media and Information Literacy");
                SubjectCb.Items.Add("Work Immersion 1");
                SubjectCb.Items.Add("Physical Education and Health 1");
                SubjectCb.Items.Add("Komunikasyon at Pananaliksik");
                SubjectCb.Items.Add("Empowerment Technologies");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "STEM - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Calculus");
                SubjectCb.Items.Add("Technopreneurship");
                SubjectCb.Items.Add("General Mathematics 2");
                SubjectCb.Items.Add("Inquiries, Investigations, and Immersion");
                SubjectCb.Items.Add("Work Immersion 2");
                SubjectCb.Items.Add("Physical Education and Health 2");
                SubjectCb.Items.Add("Understanding Culture, Society and Politics");
                SubjectCb.Items.Add("Physical Science");
            }

            // ABM - Grade 11
            if (StrandAndGradeCb.SelectedItem.ToString() == "ABM - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("Oral Communication");
                SubjectCb.Items.Add("General Mathematics");
                SubjectCb.Items.Add("Earth and Life Science");
                SubjectCb.Items.Add("Empowerment Technologies");
                SubjectCb.Items.Add("Business Mathematics");
                SubjectCb.Items.Add("Organization and Management");
                SubjectCb.Items.Add("21st Century Literature");
                SubjectCb.Items.Add("Physical Education and Health 1");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "ABM - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Komunikasyon at Pananaliksik");
                SubjectCb.Items.Add("Statistics and Probability");
                SubjectCb.Items.Add("Physical Science");
                SubjectCb.Items.Add("Filipino sa Piling Larang");
                SubjectCb.Items.Add("Principles of Marketing");
                SubjectCb.Items.Add("Business Ethics and Social Responsibility");
                SubjectCb.Items.Add("Understanding Culture, Society and Politics");
                SubjectCb.Items.Add("Physical Education and Health 2");
            }
            // ABM - Grade 12
            if (StrandAndGradeCb.SelectedItem.ToString() == "ABM - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("Applied Economics");
                SubjectCb.Items.Add("Business Finance");
                SubjectCb.Items.Add("Practical Research 1");
                SubjectCb.Items.Add("Inquiries, Investigations and Immersion");
                SubjectCb.Items.Add("English for Academic and Professional Purposes");
                SubjectCb.Items.Add("Philosophy of the Human Person");
                SubjectCb.Items.Add("Media and Information Literacy");
                SubjectCb.Items.Add("Physical Education and Health 3");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "ABM - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Fundamentals of Accounting 1");
                SubjectCb.Items.Add("Fundamentals of Accounting 2");
                SubjectCb.Items.Add("Business Enterprise Simulation");
                SubjectCb.Items.Add("Work Immersion");
                SubjectCb.Items.Add("Entrepreneurship");
                SubjectCb.Items.Add("Contemporary Philippine Arts from the Regions");
                SubjectCb.Items.Add("Introduction to World Religions");
                SubjectCb.Items.Add("Physical Education and Health 4");
            }

            // HUMSS - Grade 11
            if (StrandAndGradeCb.SelectedItem.ToString() == "HUMSS - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("Oral Communication");
                SubjectCb.Items.Add("Komunikasyon at Pananaliksik");
                SubjectCb.Items.Add("General Mathematics");
                SubjectCb.Items.Add("Earth and Life Science");
                SubjectCb.Items.Add("Creative Writing");
                SubjectCb.Items.Add("Introduction to World Religions and Belief Systems");
                SubjectCb.Items.Add("21st Century Literature");
                SubjectCb.Items.Add("Physical Education and Health 1");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "HUMSS - Grade 11" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Reading and Writing");
                SubjectCb.Items.Add("Statistics and Probability");
                SubjectCb.Items.Add("Physical Science");
                SubjectCb.Items.Add("Filipino sa Piling Larang");
                SubjectCb.Items.Add("Discipline and Ideas in the Social Sciences (DISS)");
                SubjectCb.Items.Add("Discipline and Ideas in the Applied Social Sciences (DIASS)");
                SubjectCb.Items.Add("Understanding Culture, Society and Politics");
                SubjectCb.Items.Add("Physical Education and Health 2");
            }
            // HUMSS - Grade 12
            if (StrandAndGradeCb.SelectedItem.ToString() == "HUMSS - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "First semester")
            {

                SubjectCb.Items.Add("Creative Nonfiction");
                SubjectCb.Items.Add("Trends, Networks, and Critical Thinking");
                SubjectCb.Items.Add("Philippine Politics and Governance");
                SubjectCb.Items.Add("Community Engagement, Solidarity and Citizenship");
                SubjectCb.Items.Add("Entrepreneurship / Applied Economics");
                SubjectCb.Items.Add("English for Academic and Professional Purposes");
                SubjectCb.Items.Add("Practical Research 1");
                SubjectCb.Items.Add("Physical Education and Health 3");
            }
            if (StrandAndGradeCb.SelectedItem.ToString() == "HUMSS - Grade 12" && SelectSemesterCb.SelectedItem.ToString() == "Second semester")
            {

                SubjectCb.Items.Add("Work Immersion / Culminating Activity");
                SubjectCb.Items.Add("Practical Research 2");
                SubjectCb.Items.Add("Inquiries, Investigations, and Immersion");
                SubjectCb.Items.Add("Contemporary Philippine Arts from the Regions");
                SubjectCb.Items.Add("Philosophy of the Human Person");
                SubjectCb.Items.Add("Media and Information Literacy");
                SubjectCb.Items.Add("Personal Development");
                SubjectCb.Items.Add("Physical Education and Health 4");

            }
        }

        private void StudentRegistrationBtn_Click(object sender, EventArgs e)
        {
            AdminBoardPanel.Visible = false;
            StudentRegistrationPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentRegistrationPanel.Visible = false;
            AdminBoardPanel.Visible = true;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(StudentLastnameTxt.Text))
            {
                MessageBox.Show("Lastname of student is required!");
                StudentLastnameTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(StudentFirstnameTxt.Text))
            {
                MessageBox.Show("Firstname of student is required!");
                StudentFirstnameTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(StudentMiddlenameTxt.Text))
            {
                MessageBox.Show("Middlename of student is required!");
                StudentMiddlenameTxt.Focus();
                return;
            }
            if (GenderCb.SelectedItem == null)
            {
                MessageBox.Show("Please select gender!");
                GenderCb.Focus();
                return;
            }

            if (DateOfBirthDtp.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Birth date cannot be in the future!");
                DateOfBirthDtp.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(AgeTxt.Text))
            {
                MessageBox.Show("Age of student is required!");
                AgeTxt.Focus();
                return;
            }

            if (!AgeTxt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter numbers only for age!");
                AgeTxt.Focus();
                return;
            }
            if (int.Parse(AgeTxt.Text) > 99)
            {
                MessageBox.Show("Student age is too high!");
                AgeTxt.Focus();
                return;
            }
            if (int.Parse(AgeTxt.Text) < 1)
            {
                MessageBox.Show("Age below 0 is invalid");
                AgeTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(HomeAddressTxt.Text))
            {
                MessageBox.Show("Home address is required!");
                HomeAddressTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ContactTxt.Text))
            {
                MessageBox.Show("Contact number is required!");
                ContactTxt.Focus();
                return;
            }
            if (!ContactTxt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter numbers only for contact no.!");
                ContactTxt.Focus();
                return;
            }
            if (!GuardianContactTxt.Text.StartsWith("09"))
            {
                MessageBox.Show("Contact number must start with '09'!");
                GuardianContactTxt.Focus();
                return;
            }

            if (ContactTxt.Text.Length != 11)
            {
                MessageBox.Show("Contact number must be at 11 digits!");
                ContactTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailAddressTxt.Text))
            {
                MessageBox.Show("Email address is required!");
                EmailAddressTxt.Focus();
                return;
            }

            if (!EmailAddressTxt.Text.Contains("@") || !EmailAddressTxt.Text.Contains(".com"))
            {
                MessageBox.Show("Please enter a valid email address!");
                EmailAddressTxt.Focus();
                return;
            }



            // --- ACADEMIC INFORMATION ---
            if (StrandCb.SelectedItem == null)
            {
                MessageBox.Show("Please select strand!");
                StrandCb.Focus();
                return;
            }

            if (GradeLevelCb.SelectedItem == null)
            {
                MessageBox.Show("Please select grade level!");
                GradeLevelCb.Focus();
                return;
            }

            if (SemesterCb.SelectedItem == null)
            {
                MessageBox.Show("Please select semester!");
                SemesterCb.Focus();
                return;
            }
            if (SectionCb.SelectedItem == null)
            {
                MessageBox.Show("Please select section!");
                SectionCb.Focus();
                return;
            }

            // --- GUARDIAN INFORMATION ---
            if (string.IsNullOrWhiteSpace(GuardianLastnameTxt.Text))
            {
                MessageBox.Show("Guardian lastname is required!");
                GuardianLastnameTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(GuardianFirstnameTxt.Text))
            {
                MessageBox.Show("Guardian firstname is required!");
                GuardianFirstnameTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(GuardianMiddleInitialTxt.Text))
            {
                MessageBox.Show("Guardian middle initial is required!");
                GuardianMiddleInitialTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(GuardianEmailTxt.Text))
            {
                MessageBox.Show("Email address is required!");
                GuardianEmailTxt.Focus();
                return;
            }

            if (!GuardianEmailTxt.Text.Contains("@") || !GuardianEmailTxt.Text.Contains(".com"))
            {
                MessageBox.Show("Please enter a valid email address!");
                GuardianEmailTxt.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(GuardianContactTxt.Text))
            {
                MessageBox.Show("Guardian contact number is required!");
                GuardianContactTxt.Focus();
                return;
            }

            if (!GuardianContactTxt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter numbers only for guardian contact no.!");
                GuardianContactTxt.Focus();
                return;
            }
            if (!GuardianContactTxt.Text.StartsWith("09"))
            {
                MessageBox.Show("Contact number must start with '09'!");
                GuardianContactTxt.Focus();
                return;
            }

            if (GuardianContactTxt.Text.Length != 11)
            {
                MessageBox.Show("Guardian contact number must be at 11 digits!");
                GuardianContactTxt.Focus();
                return;
            }
            if (RelationshipCb.SelectedItem == null)
            {
                MessageBox.Show("Please select guardian relationship!");
                RelationshipCb.Focus();
                return;
            }



            try
            {
                DialogResult mess = MessageBox.Show("Are you sure to resgister a student", "Confirm", MessageBoxButtons.YesNo);
                if (mess == DialogResult.Yes)
                {
                    Random random = new Random();
                    // Student information
                    string StudentID = "NO" + DateTime.Now.ToString("yy") + "-" + random.Next(10000, 99999);
                    string StudentPass = "password" + random.Next(10000, 99999);
                    string LastnameOfStudent = StudentLastnameTxt.Text.Trim();
                    string FirstnameOfStudent = StudentFirstnameTxt.Text;
                    string MiddlenameOfStudent = StudentMiddlenameTxt.Text;
                    string AgeOfStudent = AgeTxt.Text;
                    string HomeAddressOfStudent = HomeAddressTxt.Text;
                    string ContactOfStudent = ContactTxt.Text;
                    string EmailOfStudent = EmailAddressTxt.Text;
                    string GenderOfStudent = GenderCb.SelectedItem.ToString();
                    DateTime BirthOfStudent = DateOfBirthDtp.Value.Date;

                    // Academic Information
                    string StrandOfStudent = StrandCb.SelectedItem.ToString();
                    string GradeLevelOfStudent = GradeLevelCb.SelectedItem.ToString();
                    string SemesterOfStudent = SemesterCb.SelectedItem.ToString();
                    string SectionOfStudent = SectionCb.SelectedItem.ToString();

                    // Parents Information
                    string GuardianLastname = GuardianLastnameTxt.Text;
                    string GuardianFirstname = GuardianFirstnameTxt.Text;
                    string GuardianMiddleInitial = GuardianMiddleInitialTxt.Text;
                    string GuardianRelationship = RelationshipCb.SelectedItem.ToString();
                    string GuardianContact = ContactTxt.Text;
                    string GuardianEmail = GuardianEmailTxt.Text;

                    DateTime CreatedAt = DateTime.Now.Date;

                    //Insert to database
                    var connectionString = "mongodb://localhost:27017";
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("ConnectED");
                    var collection = database.GetCollection<StudentModal>("StudentModal");

                    var studentProperties = new StudentModal
                    {
                        StudentId = StudentID,
                        StudentPassword = StudentPass,
                        Lastname = LastnameOfStudent,
                        Firstname = FirstnameOfStudent,
                        Middlename = MiddlenameOfStudent,
                        Fullname = LastnameOfStudent + " " + FirstnameOfStudent + " " + MiddlenameOfStudent,
                        Age = AgeOfStudent,
                        HomeAddress = HomeAddressOfStudent,
                        Contact = ContactOfStudent,
                        Email = EmailOfStudent,
                        Gender = GenderOfStudent,
                        DateOfBirth = BirthOfStudent,

                        Strand = StrandOfStudent,
                        GradeLevel = GradeLevelOfStudent,
                        Semester = SemesterOfStudent,
                        Section = SectionOfStudent,

                        GuardianLastname = GuardianLastname,
                        GuardianFirstname = GuardianFirstname,
                        GuardianMiddleInitial = GuardianMiddleInitial,
                        GuardianRelationship = GuardianRelationship,
                        GuardianContact = GuardianContact,
                        GuardianEmail = GuardianEmail,

                        CreatedAt = CreatedAt
                    };

                    string StudentFullname = LastnameOfStudent + " " + FirstnameOfStudent + " " + MiddlenameOfStudent;

                    // Put the name of student to the list of students section
                    string nameOfTable = "";

                    if (GradeLevelOfStudent == "Grade 11" && StrandOfStudent == "STEM") { nameOfTable = "Grade11_STEM"; }
                    else if (GradeLevelOfStudent == "Grade 12" && StrandOfStudent == "STEM") { nameOfTable = "Grade12_STEM"; }
                    else if (GradeLevelOfStudent == "Grade 11" && StrandOfStudent == "ABM") { nameOfTable = "Grade11_ABM"; }
                    else if (GradeLevelOfStudent == "Grade 12" && StrandOfStudent == "ABM") { nameOfTable = "Grade12_ABM"; }
                    else if (GradeLevelOfStudent == "Grade 11" && StrandOfStudent == "HUMSS") { nameOfTable = "Grade11_HUMSS"; }
                    else if (GradeLevelOfStudent == "Grade 12" && StrandOfStudent == "HUMSS") { nameOfTable = "Grade12_HUMSS"; }
                    else { return; }
                ;

                    var collection2 = database.GetCollection<ClassInformationModal>(nameOfTable);
                    var sectionFilter = Builders<ClassInformationModal>.Filter.Eq(x => x.Section, SectionOfStudent); // find the object same as the section of student
                    var update = Builders<ClassInformationModal>.Update.AddToSet(x => x.Students, StudentFullname); // added name of student to the object
                    var result = collection2.UpdateOneAsync(sectionFilter, update);

                    var collection3 = database.GetCollection<StudentGrades>("StudentGrades");

                    var GradeRecordProperties = new StudentGrades
                    {
                        recordID = Guid.NewGuid().ToString(),
                        StudentID = StudentID,
                        StudentFullname = LastnameOfStudent + " " + FirstnameOfStudent + " " + MiddlenameOfStudent,
                        StudentSection = SectionOfStudent,
                        SubjectList = new List<GradeRecording> { }


                    };

                    // Insert student information to database
                    collection3.InsertOne(GradeRecordProperties);
                    collection.InsertOne(studentProperties);
                    MessageBox.Show("Auto - Generated Account for " + StudentFullname + "\n\n" + "Username: " + StudentID + "\n" + "Password: " + StudentPass);
                    MessageBox.Show("Successfully added a student");



                    StudentLastnameTxt.Clear();
                    StudentFirstnameTxt.Clear();
                    StudentMiddlenameTxt.Clear();
                    AgeTxt.Clear();
                    HomeAddressTxt.Clear();
                    ContactTxt.Clear();
                    EmailAddressTxt.Clear();
                    GuardianLastnameTxt.Clear();
                    GuardianFirstnameTxt.Clear();
                    GuardianMiddleInitialTxt.Clear();
                    GuardianEmailTxt.Clear();
                    GuardianContactTxt.Clear();
                    GenderCb.SelectedIndex = -1;
                    StrandCb.SelectedIndex = -1;
                    GradeLevelCb.SelectedIndex = -1;
                    SemesterCb.SelectedIndex = -1;
                    SectionCb.SelectedIndex = -1;
                    RelationshipCb.SelectedIndex = -1;
                    DateOfBirthDtp.Value = DateTime.Now;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SemesterCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BackTeacherPanel_Click(object sender, EventArgs e)
        {
            TeacherRegistrationPanel.Visible = false;
            AdminBoardPanel.Visible = true;
        }

        private void TeacherRegistrationBtn_Click(object sender, EventArgs e)
        {
            TeacherRegistrationPanel.Visible = true;
            AdminBoardPanel.Visible = false;
            StudentRegistrationPanel.Visible = false;
        }

        private void SubmitTeacherInformationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(LastnameOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's last name.");
                    LastnameOfTeacherTxt.Focus();
                    return;
                }

                // First Name
                if (string.IsNullOrEmpty(FirstnameOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's first name.");
                    FirstnameOfTeacherTxt.Focus();
                    return;
                }

                // Middle Name
                if (string.IsNullOrEmpty(MiddlenameOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's middle name.");
                    MiddlenameOfTeacherTxt.Focus();
                    return;
                }

                // Age
                if (string.IsNullOrWhiteSpace(AgeOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's age.");
                    AgeOfTeacherTxt.Focus();
                    return;
                }
                if (!AgeOfTeacherTxt.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Age only contains number.");
                    AgeOfTeacherTxt.Focus();
                    return;
                }
                if (int.Parse(AgeOfTeacherTxt.Text) < 18)
                {
                    MessageBox.Show("Age must not lower than 18.");
                    AgeOfTeacherTxt.Focus();
                    return;
                }
                if (int.Parse(AgeOfTeacherTxt.Text) > 100)
                {
                    MessageBox.Show("Age must not lower than 100.");
                    AgeOfTeacherTxt.Focus();
                    return;
                }


                // Gender
                if (GenderOfTeacherCb.SelectedItem == null)
                {
                    MessageBox.Show("Please select the teacher's gender.");
                    GenderOfTeacherCb.Focus();
                    return;
                }

                // Birth Date
                if (BirthOfTeacherDtp.Value.Date > DateTime.Today)
                {
                    MessageBox.Show("Birth date cannot be in the future.");
                    BirthOfTeacherDtp.Focus();
                    return;
                }

                // Home Address
                if (string.IsNullOrWhiteSpace(HomeAddressOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's home address.");
                    HomeAddressOfTeacherTxt.Focus();
                    return;
                }

                // Contact Number
                if (string.IsNullOrWhiteSpace(ContactOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's contact number.");
                    ContactOfTeacherTxt.Focus();
                    return;
                }
                if (!ContactOfTeacherTxt.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Contact number must contain digits only.");
                    ContactOfTeacherTxt.Focus();
                    return;
                }
                if (!ContactOfTeacherTxt.Text.Contains("09"))
                {
                    MessageBox.Show("Contact number starts in 09");
                    ContactOfTeacherTxt.Focus();
                    return;
                }
                if (ContactOfTeacherTxt.Text.Length != 11)
                {
                    MessageBox.Show("Contact number contains 11 numbers");
                    ContactOfTeacherTxt.Focus();
                    return;
                }

                // Email 
                if (string.IsNullOrWhiteSpace(EmailOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the email address.");
                    EmailOfTeacherTxt.Focus();
                    return;
                }
                if (!EmailOfTeacherTxt.Text.Contains("@") || !EmailOfTeacherTxt.Text.Contains(".com"))
                {
                    MessageBox.Show("Please enter a valid email address.");
                    EmailOfTeacherTxt.Focus();
                    return;
                }

                // Educational Attainment
                if (EducAttainmentCb.SelectedItem == null)
                {
                    MessageBox.Show("Please enter the teacher's educational attainment.");
                    EducAttainmentCb.Focus();
                    return;
                }

                // PRC ID
                if (string.IsNullOrWhiteSpace(PrcIDOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's PRC ID.");
                    PrcIDOfTeacherTxt.Focus();
                    return;
                }
                if (PrcIDOfTeacherTxt.Text.Length != 7)
                {
                    MessageBox.Show("PRC ID contains 7 characters.");
                    PrcIDOfTeacherTxt.Focus();
                    return;
                }

                // Course
                if (CourseOfTeacherCb.SelectedItem == null)
                {
                    MessageBox.Show("Please enter the course of the teacher.");
                    CourseOfTeacherCb.Focus();
                    return;
                }

                // School
                if (string.IsNullOrEmpty(SchoolOfTeacherTxt.Text))
                {
                    MessageBox.Show("Please enter the teacher's school.");
                    SchoolOfTeacherTxt.Focus();
                    return;
                }

                DialogResult mess2 = MessageBox.Show("Are you sure to register a instructor", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (mess2 == DialogResult.Yes)
                {
                    var connectionString = "mongodb://localhost:27017";
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("ConnectED");
                    var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

                    var PRCfilter = Builders<TeacherInformationModal>.Filter.Eq(z => z.PrcID, PrcIDOfTeacherTxt.Text);
                    var existingPRC = collection.Find(PRCfilter).FirstOrDefault();
                    if (existingPRC != null)
                    {
                        MessageBox.Show("The PRC Identifiction of instructor existing. Please validate the ID");
                        PrcIDOfTeacherTxt.Focus();
                        return;
                    }
                    Random random = new Random();
                    // Store muna
                    string TeacherID = "NO" + DateTime.Now.ToString("dd") + "-" + random.Next(10000, 99999);
                    string TeacherPass = "password" + random.Next(10000, 99999);
                    string lastnameOfTeacher = LastnameOfTeacherTxt.Text;
                    string firstnameOfTeacher = FirstnameOfTeacherTxt.Text;
                    string middlenameOfTeacher = MiddlenameOfTeacherTxt.Text;
                    string ageOfTeacher = AgeOfTeacherTxt.Text;
                    string genderOfTeacher = GenderOfTeacherCb.SelectedItem.ToString();
                    DateTime birthOfTeacher = BirthOfTeacherDtp.Value.Date;
                    string homeAddressOfTeacher = HomeAddressOfTeacherTxt.Text;
                    string contactOfTeacher = ContactOfTeacherTxt.Text;
                    string emailOfTeacher = EmailOfTeacherTxt.Text;

                    string educAttainmentOfTeacher = EducAttainmentCb.SelectedItem.ToString();
                    string prcIDOfTeacher = PrcIDOfTeacherTxt.Text;
                    string courseOfTeacher = CourseOfTeacherCb.SelectedItem.ToString();
                    string schoolOfTeacher = SchoolOfTeacherTxt.Text;



                    //Insert to database

                    TeacherInformationModal teacherProperties = new TeacherInformationModal()
                    {
                        TeacherID = TeacherID,
                        TeacherPassword = TeacherPass,
                        Subject = "",
                        Section = "",
                        Lastname = lastnameOfTeacher,
                        Firstname = firstnameOfTeacher,
                        Middlename = middlenameOfTeacher,
                        Fullname = lastnameOfTeacher + " " + firstnameOfTeacher + " " + middlenameOfTeacher,
                        Age = ageOfTeacher,
                        Gender = genderOfTeacher,
                        BirthDate = birthOfTeacher,
                        HomeAddress = homeAddressOfTeacher,
                        Contact = contactOfTeacher,
                        Email = emailOfTeacher,
                        EducAttainment = educAttainmentOfTeacher,
                        PrcID = prcIDOfTeacher,
                        Course = courseOfTeacher,
                        School = schoolOfTeacher
                    };

                    collection.InsertOne(teacherProperties);
                    MessageBox.Show("Auto - Generated Account" + "\n\n" + "Username: " + TeacherID + "\n" + "Password: " + TeacherPass);
                    MessageBox.Show("Teacher information saved successfully!");

                    LastnameOfTeacherTxt.Text = "";
                    FirstnameOfTeacherTxt.Text = "";
                    MiddlenameOfTeacherTxt.Text = "";
                    AgeOfTeacherTxt.Text = "";
                    HomeAddressOfTeacherTxt.Text = "";
                    ContactOfTeacherTxt.Text = "";
                    EmailOfTeacherTxt.Text = "";
                    PrcIDOfTeacherTxt.Text = "";
                    SchoolOfTeacherTxt.Text = "";

                    GenderOfTeacherCb.Text = "";
                    EducAttainmentCb.Text = "";
                    CourseOfTeacherCb.Text = "";

                    BirthOfTeacherDtp.Value = DateTime.Today;

                    displayRegisteredInstructor();
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateClassBtn_Click(object sender, EventArgs e)
        {
            CreateClassPanel.Visible = true;
            AdminBoardPanel.Visible = false;
            TeacherRegistrationPanel.Visible = false;
            StudentRegistrationPanel.Visible = false;
        }

        private void ClassBackBtn_Click(object sender, EventArgs e)
        {
            CreateClassPanel.Visible = false;
            AdminBoardPanel.Visible = true;
        }

        private void Class_SubjectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (StrandOfClassCb.SelectedItem == null)
                {
                    MessageBox.Show("Select strand of class.");
                    StrandOfClassCb.Focus();
                    return;
                }
                if (GradeLevelOfClassCb.SelectedItem == null)
                {
                    MessageBox.Show("Select grade level of class.");
                    GradeLevelCb.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(SectionOfClassTxt.Text))
                {
                    MessageBox.Show("Enter name of section of class.");
                    SectionOfClassTxt.Focus();
                    return;
                }

                DialogResult mess2 = MessageBox.Show("Are you sure to create a class", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mess2 == DialogResult.Yes)
                {
                    Random random = new Random();

                    string ClassID = Guid.NewGuid().ToString();
                    string Strand = StrandOfClassCb.SelectedItem.ToString();
                    string GradeLevelOfClass = GradeLevelOfClassCb.SelectedItem.ToString();
                    string SectionOfClass = SectionOfClassTxt.Text;
                    string[] Teachers = [];
                    string[] Students = [];
                    DateTime CreatedTime = DateTime.Now;

                    //Insert to database
                    var connectionString = "mongodb://localhost:27017";
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("ConnectED");

                    if (Strand.ToString() == "STEM" && GradeLevelOfClass.ToString() == "Grade 11") // Grade 11 STEM
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade11_STEM");
                        var filter = Builders<ClassInformationModal>.Filter.Eq(z => z.Section, SectionOfClass);
                        var result = collection.Find(filter).FirstOrDefault();
                        if (result != null)
                        {
                            MessageBox.Show("The section is already existing.");
                            SectionOfClassTxt.Text = "";
                            SectionOfClassTxt.Focus();
                            return;
                        }

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a Grade 11 STEM new class!.");
                    }
                    else if (Strand.ToString() == "STEM" && GradeLevelOfClass.ToString() == "Grade 12") // Grade 12 STEM
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade12_STEM");
                        var filter = Builders<ClassInformationModal>.Filter.Eq(z => z.Section, SectionOfClass);
                        var result = collection.Find(filter).FirstOrDefault();
                        if (result != null)
                        {
                            MessageBox.Show("The section is already existing.");
                            SectionOfClassTxt.Text = "";
                            SectionOfClassTxt.Focus();
                            return;
                        }

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a Grade 12 STEM new class!.");
                    }
                    else if (Strand.ToString() == "ABM" && GradeLevelOfClass.ToString() == "Grade 11") // Grade 11 ABM
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade11_ABM");
                        var filter = Builders<ClassInformationModal>.Filter.Eq(z => z.Section, SectionOfClass);
                        var result = collection.Find(filter).FirstOrDefault();
                        if (result != null)
                        {
                            MessageBox.Show("The section is already existing.");
                            SectionOfClassTxt.Text = "";
                            SectionOfClassTxt.Focus();
                            return;
                        }

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a Grade 11 ABM new class!.");
                    }
                    else if (Strand.ToString() == "ABM" && GradeLevelOfClass.ToString() == "Grade 12") // Grade 12 ABM
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade12_ABM");
                        var filter = Builders<ClassInformationModal>.Filter.Eq(z => z.Section, SectionOfClass);
                        var result = collection.Find(filter).FirstOrDefault();
                        if (result != null)
                        {
                            MessageBox.Show("The section is already existing.");
                            SectionOfClassTxt.Text = "";
                            SectionOfClassTxt.Focus();
                            return;
                        }

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a Grade 12 ABM new class!.");
                    }
                    else if (Strand.ToString() == "HUMSS" && GradeLevelOfClass.ToString() == "Grade 11") // Grade 11 HUMSS
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade11_HUMSS");

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a new Grade 11 HUMSS class!.");
                    }
                    else if (Strand.ToString() == "HUMSS" && GradeLevelOfClass.ToString() == "Grade 12") // Grade 12 HUMSS
                    {

                        var collection = database.GetCollection<ClassInformationModal>("Grade12_HUMSS");

                        ClassInformationModal classProperties = new ClassInformationModal()
                        {
                            ClassID = ClassID,
                            Strand = Strand,
                            GradeLevel = GradeLevelOfClass,
                            Section = SectionOfClass,
                            Teacher = Teachers,
                            Students = Students,
                            CreateAt = CreatedTime,
                        };

                        collection.InsertOne(classProperties);
                        MessageBox.Show("Successfully created a new Grade 12 HUMSS class!.");
                    }
                    else
                    {
                        MessageBox.Show("Not match strand or grade level!");
                        return;
                    }


                    StrandOfClassCb.SelectedIndex = -1;
                    GradeLevelOfClassCb.SelectedIndex = -1;
                    SectionOfClassTxt.Clear();

                    StrandAndGradeCb.Text = "";
                    ClassSectionsCb.Text = "";
                    ClassSectionsCb.Items.Clear();
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            LoginPage showLoginPage = new LoginPage();

            this.Hide();
            showLoginPage.ShowDialog();
            this.Close();
        }

        private void StrandCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSectionComboBox();
        }

        private void GradeLevelCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSectionComboBox();
        }

        private void StrandAndGradeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassSectionsCb.Text = "";
            ClassSectionsCb.Items.Clear();

            SubjectCb.Text = "";
            SubjectCb.Items.Clear();

            if (StrandAndGradeCb.SelectedItem == null)
                return;

            string strandAndGrade = StrandAndGradeCb.SelectedItem.ToString();


            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");


            string collectionName = "";

            if (strandAndGrade == "STEM - Grade 11") { collectionName = "Grade11_STEM"; }
            else if (strandAndGrade == "STEM - Grade 12") { collectionName = "Grade12_STEM"; }
            else if (strandAndGrade == "ABM - Grade 11") { collectionName = "Grade11_ABM"; }
            else if (strandAndGrade == "ABM - Grade 12") { collectionName = "Grade12_ABM"; }
            else if (strandAndGrade == "HUMSS - Grade 11") { collectionName = "Grade11_HUMSS"; }
            else if (strandAndGrade == "HUMSS - Grade 12") { collectionName = "Grade12_HUMSS"; }
            else { return; }
            ;

            var collection = database.GetCollection<ClassInformationModal>(collectionName);
            var result = collection.Find(_ => true).ToList();


            foreach (var item in result)
            {
                ClassSectionsCb.Items.Add(item.Section);
            }
            displaySubjects();

        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            displayRegisteredInstructor();

            // ADMIN CONTROL PANEL
            SetRoundedButton(StudentRegistrationBtn, 20);
            SetRoundedButton(TeacherRegistrationBtn, 20);
            SetRoundedButton(CreateClassBtn, 20);
            SetRoundedButton(LogoutBtn, 20);
            SetRoundedButton(SendAnnouncementBtn, 10);
            SetRoundedButton(CloseAnnouncementPanel, 10);
            SetTopRoundedButton(AnnouncementBtn, 20);
            SetRoundedRichTextBox(AnnouncementRTB, 10);
            // STUDENT REGISTRATION
            MakeRoundPanel(PersonalInformationPanel, 20);
            MakeRoundPanel(GuardianInformationPanel, 20);
            MakeRoundPanel(AcademinInformationPanel, 20);

            SetRoundedButton(SubmitBtn, 20);
            SetRoundedButton(button1, 20);

            SetRoundedTextBox(StudentLastnameTxt, 10);
            SetRoundedTextBox(StudentFirstnameTxt, 10);
            SetRoundedTextBox(StudentMiddlenameTxt, 10);
            SetRoundedTextBox(AgeTxt, 10);
            SetRoundedTextBox(HomeAddressTxt, 10);
            SetRoundedTextBox(ContactTxt, 10);
            SetRoundedTextBox(EmailAddressTxt, 10);

            SetRoundedTextBox(GuardianLastnameTxt, 10);
            SetRoundedTextBox(GuardianFirstnameTxt, 10);
            SetRoundedTextBox(GuardianMiddleInitialTxt, 10);
            SetRoundedTextBox(GuardianContactTxt, 10);
            SetRoundedTextBox(GuardianEmailTxt, 10);

        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            if (StrandAndGradeCb.SelectedItem == null)
            {
                MessageBox.Show("Please select strand and grade level.");
                return;
            }
            if (ClassSectionsCb.SelectedItem == null)
            {
                MessageBox.Show("Please select section to be assign.");
                return;
            }
            if (InstructorCb.SelectedItem == null)
            {
                MessageBox.Show("Please select instructor for the section.");
                return;
            }
            if (SubjectCb.SelectedItem == null)
            {
                MessageBox.Show("Please select subject for the instructor.");
                return;
            }

            DialogResult mess2 = MessageBox.Show("Are you sure to assign the instructor", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mess2 == DialogResult.Yes)
            {
                string strandAndGrade = StrandAndGradeCb.Text;
                string classSection = ClassSectionsCb.Text;
                string Instructor = InstructorCb.Text; // fullname
                string Subject = SubjectCb.Text;

                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");

                var teacherCollection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

                var filter = Builders<TeacherInformationModal>.Filter.And(
                    Builders<TeacherInformationModal>.Filter.Eq(z => z.Subject, Subject),
                    Builders<TeacherInformationModal>.Filter.Eq(z => z.Section, classSection)
                );

                bool exists = teacherCollection.Find(filter).Any();

                if (exists)
                {
                    MessageBox.Show("The selected subject is already assigned to another instructor.");
                    SubjectCb.Focus();
                    return;
                }

                string nameOfTable = "";

                if (strandAndGrade == "STEM - Grade 11") { nameOfTable = "Grade11_STEM"; }
                else if (strandAndGrade == "STEM - Grade 12") { nameOfTable = "Grade12_STEM"; }
                else if (strandAndGrade == "ABM - Grade 11") { nameOfTable = "Grade11_ABM"; }
                else if (strandAndGrade == "ABM - Grade 12") { nameOfTable = "Grade12_ABM"; }
                else if (strandAndGrade == "HUMSS - Grade 11") { nameOfTable = "Grade11_HUMSS"; }
                else if (strandAndGrade == "HUMSS - Grade 12") { nameOfTable = "Grade12_HUMSS"; }
                else { return; }
            ;

                var collection2 = database.GetCollection<ClassInformationModal>(nameOfTable);
                var sectionFilter = Builders<ClassInformationModal>.Filter.Eq(x => x.Section, classSection); // find the object same as the section of student
                var update = Builders<ClassInformationModal>.Update.AddToSet(x => x.Teacher, Instructor); // added name of student to the object
                var result = collection2.UpdateOneAsync(sectionFilter, update);

                var collection4 = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");
                var teacher_filter = Builders<TeacherInformationModal>.Filter.Eq(x => x.Fullname, Instructor);
                var teacherInformation = collection4.Find(teacher_filter).FirstOrDefault();

                if (teacherInformation != null)
                {
                    if (!string.IsNullOrEmpty(teacherInformation.Subject))
                    {

                        MessageBox.Show("Instructor " + teacherInformation.Fullname + " is already assigned to section: " + teacherInformation.Section + ".");
                        InstructorCb.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Instructor did not found in database.");
                    return;
                }
                var updateSection = Builders<TeacherInformationModal>.Update.Set(x => x.Section, classSection);
                var results = collection4.UpdateOneAsync(teacher_filter, updateSection);

                var collection3 = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");
                var teacherFilter = Builders<TeacherInformationModal>.Filter.Eq(x => x.Fullname, Instructor);
                var teacher = collection3.Find(teacherFilter).FirstOrDefault();

                if (teacher != null)
                {
                    if (!string.IsNullOrEmpty(teacher.Subject))
                    {

                        MessageBox.Show("Instructor " + teacher.Fullname + " is already assigned to subject: " + teacher.Subject + "\n" + "Please select other instructor.");
                        InstructorCb.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Instructor did not found in database.");
                    return;
                }
                var updateSubject = Builders<TeacherInformationModal>.Update.Set(x => x.Subject, Subject);
                var executeUpdateTeacherSubject = collection3.UpdateOneAsync(teacherFilter, updateSubject);

                MessageBox.Show("Instructor " + Instructor + " is successfully appointed as one of instructors of class " + classSection + " as " + Subject + " instructor.");

                StrandAndGradeCb.Text = "";
                ClassSectionsCb.Text = "";
                SelectSemesterCb.Text = "";
                ClassSectionsCb.Items.Clear();
                InstructorCb.Text = "";
                SubjectCb.Text = "";
            }
            
        }

        private void SubjectCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectSemesterCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySubjects();
        }

        private void ClassSectionsCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AnnouncementBtn_Click(object sender, EventArgs e)
        {
            AnnouncementPanel.Visible = !AnnouncementPanel.Visible;
            AnnouncementRTB.Text = string.Empty;

        }

        private void CloseAnnouncementPanel_Click(object sender, EventArgs e)
        {
            AnnouncementPanel.Visible = false;
        }

        private void SendAnnouncementBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AnnouncementRTB.Text))
            {
                MessageBox.Show("Please write your announcement.");
                AnnouncementRTB.Focus();
                return;
            }
            
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<AnnouncementModel>("AnnouncementModel");
            var insertAnnouncement = new AnnouncementModel()
            {
                Id = Guid.NewGuid().ToString(),
                Message = "ANNOUNCEMENT!: " + AnnouncementRTB.Text,
                Time = DateTime.Now.ToString("dd/MM/yyyy")
            };
            DialogResult result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                collection.InsertOne(insertAnnouncement);
                MessageBox.Show("Announcement sent!");
                AnnouncementRTB.Clear();
            }
        }
    }




    }
