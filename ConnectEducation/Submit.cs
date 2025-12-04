using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
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
    public partial class Submit : Form
    {
        private string nameOfSubjectTeacher;
        private string nameOfSubject;
        private string IdOfStudent;
        private string IdOfInstructor;
        private string nameOfStudent;
        private string sectionOfStudent;
        private string selectedHandout;
        private string selectedActivity;

        //public void StudentData(string teacher, string subject, string student, string gradeSection)
        //{
        //    this.nameOfSubjectTeacher = teacher;
        //    this.nameOfSubject = subject;
        //    this.nameOfStudent = student;
        //    this.gradeAndSection = gradeSection;
        //}
        public Submit(string subject, string instructor, string instructorId, string handout, string typeOfActivity, string studentId, string student, string section)
        {
            InitializeComponent();
            this.nameOfSubjectTeacher = instructor;
            this.IdOfInstructor = instructorId;
            this.nameOfSubject = subject;
            this.IdOfStudent = studentId;
            this.nameOfStudent = student;
            this.sectionOfStudent = section;
            this.selectedHandout = handout;
            this.selectedActivity = typeOfActivity;

            InstructorLabel.Text = nameOfSubjectTeacher;
            HandoutNoLabel.Text = selectedHandout + " " + selectedActivity;
           
            //MessageBox.Show(
            //    $"Instructor: {instructor}\n" +
            //    $"Subject: {subject}\n" +
            //    $"Student: {student}\n" +
            //    $"Section: {section}\n" +
            //    $"Handout: {handout}\n" +
            //    $"Activity Type: {typeOfActivity}",
            //    "Submission Details"
            //);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileExplorer = new OpenFileDialog();
            fileExplorer.Filter = "All Files (*.*)|*.*";

            if (fileExplorer.ShowDialog() == DialogResult.OK)
            {
                ListBoxFiles.Items.Add(fileExplorer.FileName);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnswerTxt.Text) && ListBoxFiles.Items.Count == 0)
            {
                MessageBox.Show("Please provide text or file.");
                return;
            }
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<ActivitySubmission>("ActivitySubmission");

            var existingSubmissionFilter = Builders<ActivitySubmission>.Filter.And(
                                        Builders<ActivitySubmission>.Filter.Eq(z => z.Subject, nameOfSubject),
                                        Builders<ActivitySubmission>.Filter.Eq(z => z.Section, sectionOfStudent),
                                        Builders<ActivitySubmission>.Filter.Eq(z => z.Handout, selectedHandout),
                                        Builders<ActivitySubmission>.Filter.Eq(z => z.TypeOfActivity, selectedActivity),
                                        Builders<ActivitySubmission>.Filter.Eq(z => z.StudentId, IdOfStudent)
                                    );
            var existingResult = collection.Find(existingSubmissionFilter).FirstOrDefault();
            if (existingResult != null)
            {
                if (existingResult.IsChecked)
                {
                    MessageBox.Show("This activity has already been graded. You cannot resubmit.");
                }
                else
                {
                    MessageBox.Show("You have already submitted this activity.");
                }
                return;
            }


            try
            {
                DialogResult res = MessageBox.Show("Are you sure to submit your work?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {


                    
                    
                    var filter = Builders<ActivitySubmission>.Filter.And(
                                 Builders<ActivitySubmission>.Filter.Eq(z => z.Subject, nameOfSubject),
                                 Builders<ActivitySubmission>.Filter.Eq(z => z.Section, sectionOfStudent),
                                 Builders<ActivitySubmission>.Filter.Eq(z => z.Handout, selectedHandout),
                                 Builders<ActivitySubmission>.Filter.Eq(z => z.TypeOfActivity, selectedActivity)

                    );

                    var result = collection.Find(filter).FirstOrDefault();

                    if (result != null)
                    {
                        MessageBox.Show("The " + selectedHandout + " " + selectedActivity + " is already provided!");
                        this.Close();
                        return;
                    }
                    else
                    {
                        var gridFS = new GridFSBucket(database);
                        var submissions = database.GetCollection<ActivitySubmission>("ActivitySubmission");
                        var fileIds = new List<ObjectId>();

                        foreach (string filePath in ListBoxFiles.Items)
                        {
                            using (var fs = new FileStream(filePath, FileMode.Open))
                            {
                                var id = gridFS.UploadFromStream(Path.GetFileName(filePath), fs);
                                fileIds.Add(id);
                            }
                        }

                        var submissionCollection = new ActivitySubmission
                        {
                            SubmissionId = Guid.NewGuid().ToString(),
                            Subject = nameOfSubject,
                            Instructor = nameOfSubjectTeacher,
                            InstructorId = IdOfInstructor,
                            StudentId = IdOfStudent,
                            Student = nameOfStudent,
                            Section = sectionOfStudent,
                            Handout = selectedHandout,
                            TypeOfActivity = selectedActivity,
                            AnswerTextField = AnswerTxt.Text,
                            Files = fileIds,
                            Time = DateTime.Now,
                            IsChecked = false,
                        };

                        submissions.InsertOne(submissionCollection);
                        MessageBox.Show("Files submitted successfully!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            this.Close();
        }
    }
}
