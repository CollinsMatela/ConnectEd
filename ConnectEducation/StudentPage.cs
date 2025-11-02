using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace ConnectEducation
{
    public partial class StudentPage : Form
    {

        private string FirstSubject, SecondSubject, ThirdSubject, FourthSubject, FifthSubject, SixthSubject, SeventhSubject, EightSubject;
        private string IdOfStudent, FullnameOfStudent, StrandOfStudent, GradeLevelOfStudent, SemesterOfStudent, SectionOfStudent;
        private string link;

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
            // Assign subjects to labels
            Sub1Label.Text = FirstSubject;
            Sub2Label.Text = SecondSubject;
            Sub3Label.Text = ThirdSubject;
            Sub4Label.Text = FourthSubject;
            Sub5Label.Text = FifthSubject;
            Sub6Label.Text = SixthSubject;
            Sub7Label.Text = SeventhSubject;
            Sub8Label.Text = EightSubject;

            // MongoDB setup
            //var connectionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connectionString);
            //var database = client.GetDatabase("ConnectED");
            //var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

            //Label[] SubjectLabels = { Sub1Label, Sub2Label, Sub3Label, Sub4Label, Sub5Label, Sub6Label, Sub7Label, Sub8Label };
            //Label[] TeacherLabels = { TeacherNameLabel1, TeacherNameLabel2, TeacherNameLabel3, TeacherNameLabel4, TeacherNameLabel5, TeacherNameLabel6, TeacherNameLabel7, TeacherNameLabel8 };

            //for (int i = 0; i < SubjectLabels.Length; i++)
            //{
            //    var subLabel = SubjectLabels[i];
            //    var teacherLabel = TeacherLabels[i];

            //    // Get text values (trim + ignore case)
            //    string subjectValue = subLabel.Text?.Trim();
            //    string sectionValue = SectionOfStudent?.Trim();

            //    if (string.IsNullOrEmpty(subjectValue))
            //    {
            //        teacherLabel.Text = "No subject.";
            //        continue;
            //    }

            //    // Use regex for more flexible matching
            //    var filter = Builders<TeacherInformationModal>.Filter.And(
            //        Builders<TeacherInformationModal>.Filter.Regex(z => z.Subject, new BsonRegularExpression($"^{subjectValue}$", "i")),
            //        Builders<TeacherInformationModal>.Filter.Regex(z => z.Section, new BsonRegularExpression($"^{sectionValue}$", "i"))
            //    );

            //    var instructor = collection.Find(filter).FirstOrDefault();

            //    if (instructor != null)
            //    {
            //        // Same logic: if subject matches, show teacher
            //        if (string.Equals(instructor.Subject?.Trim(), subjectValue, StringComparison.OrdinalIgnoreCase))
            //        {
            //            teacherLabel.Text = instructor.Fullname;
            //        }
            //        else
            //        {
            //            teacherLabel.Text = "No matching instructor.";
            //        }
            //    }
            //    else
            //    {
            //        teacherLabel.Text = "No registered instructor.";
            //    }
            //}
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
            Sub1Label.Text = FirstSubject;
            Sub2Label.Text = SecondSubject;
            Sub3Label.Text = ThirdSubject;
            Sub4Label.Text = FourthSubject;
            Sub5Label.Text = FifthSubject;
            Sub6Label.Text = SixthSubject;
            Sub7Label.Text = SeventhSubject;
            Sub8Label.Text = EightSubject;
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

        }
        private void StudentPage_Load(object sender, EventArgs e)
        {
            string StudentName = FullnameOfStudent;
            string Strand = StrandOfStudent;
            string Grade = GradeLevelOfStudent;
            string Semester = SemesterOfStudent;

            SubjectsPanel.Visible = false;
            GradingSystemPanel.Visible = false;

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

            displayGrades();

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
            displayNameOfSubjectsInGradesPanel();

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
            Submit submitForm = new Submit();
            submitForm.Show();
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
        }

        private void TeacherNameLabel1_Click(object sender, EventArgs e)
        {
            string subject = Sub1Label.Text.Trim();
            string section = SectionOfStudent.Trim();

            if (string.IsNullOrEmpty(subject))
            {
                MessageBox.Show("No subject assigned for this label.");
                return;
            }

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

            // Create filter to find the teacher
            var filter = Builders<TeacherInformationModal>.Filter.And(
                Builders<TeacherInformationModal>.Filter.Regex(z => z.Subject, new BsonRegularExpression($"^{subject}$", "i")),
                Builders<TeacherInformationModal>.Filter.Regex(z => z.Section, new BsonRegularExpression($"^{section}$", "i"))
            );

            var instructor = collection.Find(filter).FirstOrDefault();

            if (instructor != null)
            {
                // Display found teacher info
                MessageBox.Show(
                    $"Teacher found!\n\n" +
                    $"Name: {instructor.Fullname}\n" +
                    $"Subject: {instructor.Subject}\n" +
                    $"Section: {instructor.Section}",
                    "Instructor Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show("No instructor found for this subject and section.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
