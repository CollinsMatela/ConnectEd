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
        private string nameOfStudent;
        private string gradeAndSection;

        public void StudentData(string teacher, string subject, string student, string gradeSection)
        {
            this.nameOfSubjectTeacher = teacher;
            this.nameOfSubject = subject;
            this.nameOfStudent = student;
            this.gradeAndSection = gradeSection;
        }
        public Submit()
        {
            InitializeComponent();
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
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("ConnectED");
                var gridFS = new GridFSBucket(database);
                var submissions = database.GetCollection<TeacherModal>("TeacherModal");

                var fileIds = new List<ObjectId>();

                foreach (string filePath in ListBoxFiles.Items)
                {
                    using (var fs = new FileStream(filePath, FileMode.Open))
                    {
                        var id = gridFS.UploadFromStream(Path.GetFileName(filePath), fs);
                        fileIds.Add(id);
                    }
                }

                var teacherTable = new TeacherModal
                {
                    Student = "Name of Student",
                    AnswerTextField = "Optional",
                    Files = fileIds,
                    Time = DateTime.UtcNow,
                };

                submissions.InsertOne(teacherTable);

                MessageBox.Show("Files submitted successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
