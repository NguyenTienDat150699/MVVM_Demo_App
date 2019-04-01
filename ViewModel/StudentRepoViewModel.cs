using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Model;
using DataAccessLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data;

namespace ViewModel
{
    public class StudentRepoViewModel
    {
        private ObservableCollection<StudentModel> students;
        private StudentDAL studentDAL;
        public StudentRepoViewModel()
        {
            studentDAL = new StudentDAL();
            LoadStudentRepo();
        }
        public ObservableCollection<StudentModel> Students
        {
            get { return students; }
            set { students = value; }
        }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        private void CreateNewStudent (StudentModel student)
        {
            studentDAL.CreateItem(student);
            LoadStudentRepo();
        }
        private void DeleteCurStudent(StudentModel student)
        {
            studentDAL.DeleteItem(student);
            LoadStudentRepo();
        }
        private void UpdateCurStudent(StudentModel student)
        {
            studentDAL.UpdateItem(student);
            LoadStudentRepo();
        }
        private void LoadStudentRepo()
        {
            students.Clear();
            DataTable dataTable = studentDAL.ReadItems();
            foreach(DataRow row in dataTable.Rows)
            {
                StudentModel student = new StudentModel();
                student.Identity = int.Parse(row["Identity"].ToString());
                student.FullName = row["FullName"].ToString();
                student.BirthDate = row["BirthDate"].ToString();
                students.Add(student);
            }
        }
    }
}
