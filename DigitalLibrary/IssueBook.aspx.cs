using Antlr.Runtime;
using DigitalLibrary.Models;
using DigitalLibrary.Service;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.XPath;
using System.Configuration;

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
                GetAllBranch();
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

        protected void btnBookIssue_Click(object sender, EventArgs e)
        {
            IssueBookService issueBookService = new IssueBookService();
            try
            {
                if (string.IsNullOrEmpty(txtDay.Text))
                {
                    lblmsg.ForeColor=System.Drawing.Color.Red;
                    lblmsg.Text = "Enter Days";
                }
                else
                {
                    if(Convert.ToInt32(lblAvlQuantity.Text)==0)
                    {
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Text = "Book Stock not avilable";
                    }
                    else
                    {
                        int studentId = Convert.ToInt32(ddlStudent.SelectedValue);
                        string bookName = ddlBook.SelectedItem.Text;
                        List<IssueBookModel> lst = issueBookService.GetRentBookbyStudent(studentId,bookName);
                        if(lst!=null)
                        {
                            if (lst.Count >= 1)
                            {
                                lblmsg.Text = "Same book alredy issued to : " + ddlStudent.SelectedItem.Text;
                            }
                        }
                        else
                        {
                            int bookLimits = Convert.ToInt32(ConfigurationManager.AppSettings["BookLimits"]);
                            int studentid = Convert.ToInt32(ddlStudent.SelectedValue);
                            List<IssueBookModel> lstBookCount = issueBookService.GetIssuedBookCountbyStudent(studentid);
                            if(lstBookCount.Count>= bookLimits)
                            {
                                lblmsg.Text = "A student can issue maximum "+ bookLimits + " books !!";
                            }
                            else
                            {
                                int i = InsertIssueBookDetails();
                                int j = BookIssueToStudent();
                                if (j > 0)
                                {
                                    lblmsg.Text = "Book issued to " + ddlStudent.SelectedItem.Text;
                                }
                                int BookId = Convert.ToInt32(ddlBook.SelectedValue);
                                GetBookDetailById(BookId);
                                clearData();
                            }
                            
                        }
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private int InsertIssueBookDetails()
        {
            int result = 0;
            IssueBookModel model = new IssueBookModel();
            IssueBookService service = new IssueBookService();
            model.BookName = ddlBook.SelectedItem.Text;
            model.StudentId=Convert.ToInt32(ddlStudent.SelectedValue);
            model.Days=Convert.ToInt32(txtDay.Text);
            result = service.InsertIssueBook(model);


            return result;
        }

        private void clearData()
        {
            ddlBranch.SelectedIndex = 0;
            ddlStudent.SelectedIndex = 0;
            txtDay.Text= string.Empty;
        }

        private int BookIssueToStudent()
        {
            int result = 0;
            int BookId = Convert.ToInt32(ddlBook.SelectedValue);
            IssueBookService service= new IssueBookService();
            result= service.BookIssueToStudent(BookId);
            return result;
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
                dvIssueBook.Visible = true;
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
                ddlStudent.Items.Insert(0, new ListItem("--Select Book--", "0"));
            }
            catch (Exception ex)
            {

            }
        }
    }
}