using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class IssueReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllBranch();
                ddlStudent.Items.Insert(0, new ListItem("--Select Student--", "0"));
                BindGrid();
            }
        }


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
                ddlBranch.Items.Insert(0, new ListItem("-- Select Branch --", "0"));
            }
            catch (Exception ex)
            {

            }
        }

      
        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedIndex > 0)
            {
                //dvIssueBook.Visible = true;
                string str = ddlBranch.SelectedItem.Text;
                GetStudentByBranch(str);

            }
        }

        private void GetStudentByBranch(string Publication)
        {
            List<StudentModel> lststudent = new List<StudentModel>();
            IssueBookService issueBookService = new IssueBookService();
            try
            {
                ddlStudent.Items.Clear();
                lststudent = issueBookService.GetStudentByBranch(Publication);
                ddlStudent.DataSource = lststudent;
                ddlStudent.DataTextField = "StudentName";
                ddlStudent.DataValueField = "StudentId";
                ddlStudent.DataBind();
                ddlStudent.Items.Insert(0, new ListItem("--Select Student--", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnViewIssueReport_Click(object sender, EventArgs e)
        {
            if(ddlStudent.SelectedIndex>0)
            {
                BindGrid();
            }
        }

        protected void gvIssueReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvIssueReport_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvIssueReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void BindGrid()
        {
            if(ddlStudent.SelectedIndex > 0)
            {
                IssueReportService issueReportService = new IssueReportService();
                int studentid = Convert.ToInt32(ddlStudent.SelectedValue);

                List<IssueBookModel> lstBookCount = issueReportService.GetIssuedBookCountbyStudent(studentid);
                gvIssueReport.DataSource = lstBookCount;
                gvIssueReport.DataBind();
            }
           
        }
    }
}