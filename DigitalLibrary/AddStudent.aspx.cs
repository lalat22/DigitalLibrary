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
    public partial class AddStudent : System.Web.UI.Page
    {
        public static string successMsg = string .Empty;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllBranch();
            }
        }

        protected void rblGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        #region GetAllBranch
        private void GetAllBranch()
        {
            List<BranchModel> lstBranch = new List<BranchModel>();
            BranchService branchService = new BranchService();
            try
            {

                lstBranch = branchService.GetAllBranch();
                ddlBranch.DataSource = lstBranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
                ddlBranch.Items.Insert(0, new ListItem("--Select Branch--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region InsertStudent
        private void InsertStudent()
        {
            StudentModel student = new StudentModel();  
            StudentService studentService = new StudentService();
            int i = 0;
            try
            {

               student.StudentName = txtStudentName.Text;
                student.BranchName = ddlBranch.SelectedItem.Text;
                student.Mobile= txtMobile.Text;
                student.Address= txtAddress.Text;
                student.PinCode= txtPinCode.Text;
                student.Email= txtEmail.Text;
                student.Gender = rblGender.SelectedItem.Text;
                student.DOB= Convert.ToDateTime(txtDOB.Text);
                student.Images = fuStudent.FileName;

                i=studentService.InsertStudent(student);
                if (i > 0)
                {
                    ClearControl();
                    
                    successMsg = "Student Added SuccessFully.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showmodel(); });", true);

                }
                else
                {
                    successMsg = "Error Occured";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showErrorpopup(); });", true);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDOB.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void lnkDate_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (fuStudent.HasFile)
            {
                fuStudent.SaveAs(Server.MapPath("~/Images/") + fuStudent.FileName);
                InsertStudent();
            }
            
        }
        private void ClearControl()
        {
            txtStudentName.Text= string.Empty;
            txtPinCode.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rblGender.SelectedIndex = -1;
            fuStudent.Attributes.Clear();
        }
    }
}