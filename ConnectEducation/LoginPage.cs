using MongoDB.Bson;
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

namespace ConnectEducation
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (typeOfUserCb.SelectedItem == null)
            {
                MessageBox.Show("Select type of user.");
                typeOfUserCb.Focus();
                return;
            }
            if (string.IsNullOrEmpty(UsernameTxt.Text))
            {
                MessageBox.Show("Enter your username.");
                UsernameTxt.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PasswordTxt.Text))
            {
                MessageBox.Show("Enter your password.");
                PasswordTxt.Focus();
                return;
            }

            String Username = UsernameTxt.Text;
            String Password = PasswordTxt.Text;
            String User = typeOfUserCb.SelectedItem.ToString();

            // Admin condition
            if (User.ToString().Equals("Admin"))
            {
                if (Username.Equals("Admin", StringComparison.OrdinalIgnoreCase) &&
                    Password.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    this.Hide();
                    AdminPage showAdmin = new AdminPage();
                    showAdmin.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid admin identification or password!");
                    UsernameTxt.Text = null;
                    PasswordTxt.Text = null;
                    return;
                }
            }
            // Student account condtion
            if (User.ToString().Equals("Student"))
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<StudentModal>("StudentModal");

                var studentAccount = collection.Find(res => res.StudentId == Username).FirstOrDefaultAsync().Result;

                if (studentAccount != null)
                {
                    string studentPassword = studentAccount.StudentPassword.ToString();

                    if (studentPassword != Password)
                    {
                        MessageBox.Show("Password of student did not match to student Password");
                        return;
                    }
                    string student_ID = studentAccount.StudentId.ToString();
                    string student_fullname = studentAccount.Lastname.ToString() + " " +
                                              studentAccount.Firstname.ToString() + " " +
                                              studentAccount.Middlename.ToString();
                    string student_Strand = studentAccount.Strand.ToString();
                    string student_GradeLevel = studentAccount.GradeLevel.ToString();
                    string student_Semester = studentAccount.Semester.ToString();
                    string student_Section = studentAccount.Section.ToString();

                    MessageBox.Show("Welcome " + student_fullname + ".");
                    // pass info
                    // lipat sa student page
                    StudentPage showStudentPage = new StudentPage(student_ID, student_fullname, student_Strand, student_GradeLevel, student_Semester, student_Section);
                    this.Hide();
                    showStudentPage.ShowDialog();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Student's Identification (ID) did not recognize!");
                    return;
                }


            }
            // Teacher condintion
            if (User.ToString().Equals("Teacher"))
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("ConnectED");
                var collection = database.GetCollection<TeacherInformationModal>("TeacherInformationModal");

                var teacherAccount = collection.Find(res => res.TeacherID == Username).FirstOrDefaultAsync().Result;

                if (teacherAccount != null)
                {
                    string teacherPassword = teacherAccount.TeacherPassword.ToString();

                    if (teacherPassword != Password)
                    {
                        MessageBox.Show("Password of student did not match to teacher Password");
                        return;
                    }
                    string teacher_ID = teacherAccount.TeacherID.ToString();
                    string teacher_fullname = teacherAccount.Lastname.ToString() + " " +
                                              teacherAccount.Firstname.ToString() + " " +
                                              teacherAccount.Middlename.ToString();
                    string teacher_subject = teacherAccount.Subject.ToString();
                    string teacher_sectionHandle = teacherAccount.Section.ToString();


                    MessageBox.Show("Welcome " + teacher_fullname + ".");
                    TeacherPage showTeacherPage = new TeacherPage(teacher_ID, teacher_fullname, teacher_subject, teacher_sectionHandle);
                    this.Hide();
                    showTeacherPage.ShowDialog();
                    this.Close();


                }
                else
                {
                    MessageBox.Show("Teacher's Identification (ID) did not recognize!");
                    return;
                }
            }

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            PasswordTxt.UseSystemPasswordChar = true;
        }
    }
}
