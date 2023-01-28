using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class BookReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllBooks();
            }
        }

        protected void gvBookRebort_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "view")
            {
                MultiView1.ActiveViewIndex = 1;
                int intBookId = Convert.ToInt32(e.CommandArgument);
                GetBookDetailById(intBookId);
            }
        }

        protected void gvBookRebort_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvBookRebort_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        private void GetAllBooks()
        {
            List<BookModel> lstbooks = new List<BookModel>();
            BookService bookService = new BookService();
            lstbooks = bookService.GetAllBooks();
            gvBookRebort.DataSource = lstbooks;
            gvBookRebort.DataBind();
            MultiView1.ActiveViewIndex = 0;
        }
        private void GetBookDetailById(int bookId)
        {
            BookModel book = new BookModel();   
            BookService bookService = new BookService();
            book = bookService.GetBookDetailsById(bookId);
            if(book!= null)
            {
                lblbname.Text = book.BookName;
                lblauthor.Text = book.Author;
                lblbran.Text = book.Branch;
                lblpub.Text = book.Publication;
                lblprice.Text = book.Price.ToString();
                lblqnt.Text= book.Quantities.ToString();
                lblaqnt.Text = book.AvlQuantity.ToString();
                lblrqnt.Text = book.RentQuantity.ToString();
                lbldetail.Text = book.Detail;
                Image2.ImageUrl = "../Images/"+book.Images;
            }
        }
    }
}