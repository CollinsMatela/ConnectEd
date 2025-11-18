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
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ConnectEducation
{
    public partial class ViewSubmission : Form
    {
        private string submissionID;
        private string instructorId;
        private string studentID;
        private string subject;
        private string name;
        private string section;
        private string handout;
        private string type;
        private string text;
        private string[] files;
        private string time;
        public ViewSubmission(string submissionId, string instructorId, string studentId, string subject, string name, string section, string handout, string type, string text, string[] files, string time)
        {
            InitializeComponent();
            this.submissionID = submissionId;
            this.instructorId = instructorId;
            this.studentID = studentId;
            this.subject = subject;
            this.name = name;
            this.section = section;
            this.handout = handout;
            this.type = type;
            this.text = text;
            this.files = files;
            this.time = time;
        }
        private void DownloadFiles(string fileId)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("ConnectED");
                var gridFS = new GridFSBucket(database);

                var filesCollection = database.GetCollection<GridFSFileInfo>("fs.files");
                var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", new ObjectId(fileId));
                bool exists = filesCollection.Find(filter).Any();

                if (!exists)
                {
                    MessageBox.Show("File does not exist in the database.");
                    return;
                }


                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Save File";
                    sfd.Filter = "All Files|*.*";
                    sfd.FileName = fileId;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        byte[] fileBytes = gridFS.DownloadAsBytes(new ObjectId(fileId));
                        File.WriteAllBytes(sfd.FileName, fileBytes);

                        MessageBox.Show("File downloaded successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewSubmission_Load(object sender, EventArgs e)
        {
            SubmissionIDLabel.Text = submissionID;
            SubmissionStudentLabel.Text = name;
            SubmissionSubjectLabel.Text = subject;
            SubmissionDateLabel.Text = time;
            SubmissionHandoutLabel.Text = handout;
            SubmissionActivityLabel.Text = type;
            SubmissionSectionLabel.Text = section;
            SubmissionTextRTB.Text = text;
            foreach (var item in files)
            {
                FilesListBox.Items.Add(item);
            }

        }

        private void FilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedItem == null) return;

            string fileId = FilesListBox.SelectedItem.ToString();
            DownloadFiles(fileId);
        }

        private void ScoreUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ScoreTxt.Text))
            {
                MessageBox.Show("Please input score.");
                ScoreTxt.Focus();
                return;
            }
            if (!ScoreTxt.Text.All(char.IsDigit))
            {
                MessageBox.Show("Characters is not valid please enter numbers only.");
                ScoreTxt.Focus();
                return;
            }
            string[] HandoutNumber = { "Handout 1", "Handout 2", "Handout 3", "Handout 4", "Handout 5", "Handout 6", "Handout 7", "Handout 8" };
            string Worksheet = "Worksheet";
            string PerformanceTask = "Performance Task";

            foreach (var handouts in HandoutNumber)
            {
                if (SubmissionHandoutLabel.Text == handouts && SubmissionActivityLabel.Text == Worksheet)
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
            }
            foreach (var handouts in HandoutNumber)
            {
                if (SubmissionHandoutLabel.Text == handouts && SubmissionActivityLabel.Text == PerformanceTask)
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
            }

            string selectedTypeOfActivity = type;
            string scoreValue = ScoreTxt.Text;

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("ConnectED");
            var collection = database.GetCollection<TeachersStudentRecords>("TeachersStudentRecords");
            var filter = Builders<TeachersStudentRecords>.Filter.And(
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.TeacherId, instructorId),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.Subject, subject),
                   Builders<TeachersStudentRecords>.Filter.Eq(z => z.StudentId, studentID),
                   Builders<TeachersStudentRecords>.Filter.ElemMatch(z => z.ActivityRecord, a => a.ActivityType == selectedTypeOfActivity)
            );
            // Update
            var update = Builders<TeachersStudentRecords>.Update.Set("ActivityRecord.$.Score", scoreValue);
            collection.UpdateOne(filter, update);
            // Delete
            var collection2 = database.GetCollection<ActivitySubmission>("ActivitySubmission");
            var filter2 = Builders<ActivitySubmission>.Filter.Eq(z => z.SubmissionId, SubmissionIDLabel.Text);
            var delete = collection2.FindOneAndDelete(filter2);

            MessageBox.Show("Successfully added "+ scoreValue + " to " + selectedTypeOfActivity);

            this.Close();
        }




    }
}
