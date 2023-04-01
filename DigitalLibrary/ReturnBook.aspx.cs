using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class ReturnBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllStudents();
            }
        }

        protected void btnViewbook_Click(object sender, EventArgs e)
        {

        }

        private void GetAllStudents()
        {
            List<StudentModel> lststudentModel1 = new List<StudentModel>();
            StudentService studentService = new StudentService();

            try
            {
                lststudentModel1 = studentService.GetAllStudents();
                ddlStudent.DataSource = lststudentModel1;

                ddlStudent.DataTextField = "StudentName";
                ddlStudent.DataValueField = "StudentId";
                ddlStudent.DataBind();
                ddlStudent.Items.Insert(0, new ListItem("-- Select Student --", "0"));

            }
            catch (Exception ex)
            {

            }
        }

        private void GetBookDetailById(int studentId, int bookId)
        {
            ReturnBookModel returnBookModel = new ReturnBookModel();
            ReturnBookService returnBookService = new ReturnBookService();
            returnBookModel = returnBookService.GetReturnBookDetails(studentId, bookId);

            if(returnBookModel == null )
            {

            }


            //if (studentModel1 != null)
            //{
            //    lblbStudentName.Text = studentModel1.StudentName;
            //    lblphn.Text = studentModel1.Mobile;
            //    lblAddress.Text = studentModel1.Address;
            //    lblPinCode.Text = studentModel1.PinCode;
            //    lblDOB.Text = studentModel1.DOB.ToString("dd-MMM-yyyy");
            //    lblBranch.Text = studentModel1.BranchName;
            //    lblEmail.Text = studentModel1.Email;
            //    Image2.ImageUrl = "../Images/" + studentModel1.Images;
            //}
        }
    }
}