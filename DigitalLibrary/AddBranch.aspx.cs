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
    public partial class AddBranch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllBranch();
            }
        }
        
        protected void gvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName =="edit")
            {
                int branchId = Convert.ToInt32(e.CommandArgument);
                GetBranchById(branchId);
            }
            else if(e.CommandName == "delete")
            {
                int branchId = Convert.ToInt32(e.CommandArgument);
                DeleteBranchById(branchId);
            }
        }
        private void GetBranchById(int branchId)
        {
            BranchService branchService = new BranchService();
            BranchModel branchModel = new BranchModel();
            branchModel = branchService.GetBranchById(branchId);
            if(branchModel!= null)
            {
                txtBranchName.Text = branchModel.BranchName;
            }
        }
        private void GetAllBranch()
        {
            List<BranchModel> lstBranch = new List<BranchModel>();
            BranchService branchService = new BranchService();
            try
            {

                lstBranch = branchService.GetAllBranch();
                gvBranch.DataSource = lstBranch;
                gvBranch.DataBind();
            }
            catch(Exception ex)
            {

            }
        }
        private void InsertBranch(string branchName)
        {
            int i = 0;
            try
            {
                BranchService branchService = new BranchService();
               i =  branchService.InsertBranch(branchName);
                if(i>0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.GhostWhite;
                    lblMsg.Text = "Branch Added SuccessFully.";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                    lblMsg.Text = "Error Occured.";
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void DeleteBranchById(int branchId)
        {
            int i = 0;
            BranchService branchService = new BranchService();
            i = branchService.DeleteBranchById(branchId);

            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.GhostWhite;
                lblMsg.Text = "Branch Deleted SuccessFully.";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                lblMsg.Text = "Error Occured.";
            }
        }
        protected void gvBranch_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str = txtBranchName.Text.Trim();
            InsertBranch(str);
        }
    }
}