using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class AddBook : System.Web.UI.Page
    {
        public static string successMsg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllPublication();
                GetAllBranch();

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
                ddlBranch.Items.Insert(0, "--Select Branch--");
                ddlBranch.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private void GetAllPublication()
        {
            List<PublicationModel> lstPublication = new List<PublicationModel>();
            PublicationService objPublicationService = new PublicationService();
            try
            {

                lstPublication = objPublicationService.GetAllPublication();
                ddlPublication.DataSource = lstPublication;
                ddlPublication.DataTextField = "PublicationName";
                ddlPublication.DataValueField = "PublicationId";
                ddlPublication.Items.Insert(0, "--Select Publication--");
                ddlPublication.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            if(fuBook.HasFile)
            {
                fuBook.SaveAs(Server.MapPath("~/Images/") + fuBook.FileName);
                InsertBook();
            }

        }

        private void InsertBook()
        {
            BookModel bookModel = new   BookModel();
            BookService bookService = new BookService();
            int i = 0;
            try
            {
               
                bookModel.BookName = txtBookName.Text;
                bookModel.Author = txtAuthor.Text;
                bookModel.Detail=txtDetails.Text;
                bookModel.Price= Convert.ToDecimal(txtPrice.Text);
                bookModel.Publication = ddlPublication.SelectedItem.Text;
                bookModel.Branch= ddlBranch.SelectedItem.Text;  
                bookModel.Quantities= Convert.ToInt32( txtQuantity.Text);
                bookModel.AvlQuantity= Convert.ToInt32( txtQuantity.Text);
                bookModel.RentQuantity= Convert.ToInt32( txtQuantity.Text); 
                bookModel.Images=   fuBook.FileName;



                i = bookService.InsertBook(bookModel);
                if (i > 0)
                {
                    successMsg = "Book Added SuccessFully.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { showmodel(); });", true);
                    
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                    lblMsg.Text = "Error Occured.";
                }
            }
            catch (Exception ex)
            {
            }


        }
    }
}