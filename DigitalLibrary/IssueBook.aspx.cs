using DigitalLibrary.Models;
using DigitalLibrary.Service;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class IssueBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetAllPublication();
                ddlBook.Items.Insert(0, new ListItem("--Select Book--", "0"));
            }
        }
        private void GetBooksByPubliction(string Publication)
        {
            List<BookModel> lstbook = new List<BookModel>();
            IssueBookService issueBookService = new IssueBookService();
            try
            {
                ddlBook.Items.Clear();
                lstbook = issueBookService.GetBooksByPublication(Publication);
                ddlBook.DataSource = lstbook;
                ddlBook.DataTextField = "BookName";
                ddlBook.DataValueField = "BookId";
                ddlBook.DataBind();
                ddlBook.Items.Insert(0, new ListItem("--Select Book--", "0"));
            }
            catch(Exception ex)
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
                ddlPublication.DataBind();
                ddlPublication.Items.Insert(0, new ListItem("--Select Publication--", "0"));
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlPublication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPublication.SelectedIndex >0)
            {
                dvIssueBook.Visible = false;
                string str = ddlPublication.SelectedItem.Text;
                GetBooksByPubliction(str);
                
            }
        }

        protected void btnViewbook_Click(object sender, EventArgs e)
        {
            if(ddlBook.SelectedIndex >0) 
            {
                dvIssueBook.Visible = true;
                int BookId = Convert.ToInt32(ddlBook.SelectedValue);
                GetBookDetailById(BookId);
            }
            
        }

        private void GetBookDetailById(int bookId)
        {
            BookModel book = new BookModel();
            BookService bookService = new BookService();
            book = bookService.GetBookDetailsById(bookId);
            if (book != null)
            {
                lblbname.Text = book.BookName;
                lblauthor.Text = book.Author;
                lblProfileAuthor.Text = book.Author;
                lblProfileBook.Text = book.BookName;
                lblbran.Text = book.Branch;
                lblpub.Text = book.Publication;
                lblprice.Text = book.Price.ToString();
                lblQuantities.Text = book.Quantities.ToString();
                lblAvlQuantity.Text = book.AvlQuantity.ToString();
                lblRentQuantity.Text = book.RentQuantity.ToString();
                
                Image2.ImageUrl = "../Images/" + book.Images;
            }
        }


    }
}