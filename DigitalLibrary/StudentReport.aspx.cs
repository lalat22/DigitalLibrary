using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class StudentReport : System.Web.UI.Page
    {
        public int StudentId
        {
            get
            {
                return Convert.ToInt32(ViewState["StudentId"]);
            }
            set
            {
                ViewState["StudentId"] = value;
            }
        }
        public static string successMsg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllStudents();
            }
        }
        private void GetAllStudents()
        {
            List<StudentModel> lststudentModel1 = new List<StudentModel>();
            StudentService studentService = new StudentService();

            try
            {
                lststudentModel1 = studentService.GetAllStudents();
                gvStudentReport.DataSource = lststudentModel1;
                gvStudentReport.DataBind();
                MultiView1.ActiveViewIndex = 0;

            }
            catch (Exception ex)
            {

            }
        }
        private void GetBookDetailById(int studentId)
        {
            StudentModel studentModel1 = new StudentModel();
            StudentService studentService = new StudentService();
            studentModel1 = studentService.GetStudentsDetailsById(studentId);
            if (studentModel1 != null)
            {
                lblbStudentName.Text = studentModel1.StudentName;
                lblphn.Text = studentModel1.Mobile;
                lblAddress.Text = studentModel1.Address;
                lblPinCode.Text = studentModel1.PinCode;
                lblDOB.Text = studentModel1.DOB.ToString("dd-MMM-yyyy");
                lblBranch.Text = studentModel1.BranchName;
                lblEmail.Text = studentModel1.Email;
                Image2.ImageUrl = "../Images/" + studentModel1.Images;
            }
        }
        private void DeleteStudentById(int studentId)
        {
            int i = 0;
            StudentService studentService = new StudentService();
            i = studentService.DeleteStudentById(studentId);

            if (i > 0)
            {
                lblDelete.Text = "Student deleted successfully.";
                GetAllStudents();
                //successMsg = "Student deleted successfully.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showmodel(); });", true);

            }
            else
            {
                lblDelete.Text = "Error Occured.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showErrorpopup(); });", true);

            }
        }
        protected void gvStudentReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                MultiView1.ActiveViewIndex = 1;
                int intStudentId = Convert.ToInt32(e.CommandArgument);
                GetBookDetailById(intStudentId);
            }
            else if (e.CommandName == "delete")
            {
                lblDelete.Text = string.Empty;
                StudentId = 0;
                int intStudentId = Convert.ToInt32(e.CommandArgument);
                StudentId = intStudentId;
                DeleteStudentById(intStudentId);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showDeletepopup(); });", true);


            }
        }

        protected void gvStudentReport_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvStudentReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            StudentId = 0;
            GetAllStudents();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudentById(StudentId);
            StudentId = 0;
        }
    }
}