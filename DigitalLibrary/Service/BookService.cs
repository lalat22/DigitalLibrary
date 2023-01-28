using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DigitalLibrary.Models;

namespace DigitalLibrary.Service
{
    public class BookService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public BookService()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        }
        public void CreateConnection()
        {
            SqlConnection _sqlConnection = new SqlConnection(ConnectionString);
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }
        public void OpenConnection()
        {
            _sqlCommand.Connection.Open();
        }
        public void CloseConnection()
        {
            _sqlCommand.Connection.Close();
        }
        public void DisposeConnection()
        {
            _sqlCommand.Connection.Dispose();
        }

        #region GetAllBranch
        public List<BranchModel> GetAllBranch()
        {
            List<BranchModel> lstBranch = null;
            BranchModel branchModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "[dbo].[BRANCH_SELECT]";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstBranch = new List<BranchModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BranchModel obj = new BranchModel();
                        obj.BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]);
                        obj.BranchName = dt.Rows[i]["BranchName"].ToString();

                        lstBranch.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                CloseConnection();
                DisposeConnection();
                branchModel = null;
            }
            return lstBranch;
        }
        #endregion

        #region GetAllPublication
        public List<PublicationModel> GetAllPublication()
        {
            List<PublicationModel> lstPublication = null;
            PublicationModel obj = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_SELECT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstPublication = new List<PublicationModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new PublicationModel();
                        obj.PublicationId = Convert.ToInt32(dt.Rows[i]["PublicationId"]);
                        obj.PublicationName = dt.Rows[i]["PublicationName"].ToString();

                        lstPublication.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                CloseConnection();
                DisposeConnection();
                obj = null;
            }
            return lstPublication;
        }
        #endregion

        #region InsertBook
        public int InsertBook(BookModel bookModel)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BOOK_INSERT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@BookName", bookModel.BookName);
                _sqlCommand.Parameters.AddWithValue("@Author", bookModel.Author);
                _sqlCommand.Parameters.AddWithValue("@Detail", bookModel.Detail);
                _sqlCommand.Parameters.AddWithValue("@Price", bookModel.Price);
                _sqlCommand.Parameters.AddWithValue("@Publication", bookModel.Publication);
                _sqlCommand.Parameters.AddWithValue("@Branch", bookModel.Branch);
                _sqlCommand.Parameters.AddWithValue("@Quantities", bookModel.Quantities);
                _sqlCommand.Parameters.AddWithValue("@AvlQuantity", bookModel.AvlQuantity);
                _sqlCommand.Parameters.AddWithValue("@RentQuantity", bookModel.RentQuantity);
                _sqlCommand.Parameters.AddWithValue("@Images", bookModel.Images);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        #endregion

        #region GetBookDetailsById
        public BookModel GetBookDetailsById(int bookId)
        {
            BookModel objBookModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BOOK_SELECT_By_BID";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@BookId", bookId);

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                if ((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    objBookModel = new BookModel();
                    objBookModel.BookName = _dtSet.Tables[0].Rows[0]["BookName"].ToString();
                    objBookModel.BookId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["BookId"].ToString());
                    objBookModel.Author = _dtSet.Tables[0].Rows[0]["Author"].ToString();
                    objBookModel.Detail = _dtSet.Tables[0].Rows[0]["Detail"].ToString();
                    objBookModel.Price = Convert.ToDecimal(_dtSet.Tables[0].Rows[0]["Price"].ToString());
                    objBookModel.Publication = _dtSet.Tables[0].Rows[0]["Publication"].ToString();
                    objBookModel.Branch = _dtSet.Tables[0].Rows[0]["Branch"].ToString();
                    objBookModel.Quantities = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["Quantities"].ToString());
                    objBookModel.AvlQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["AvlQuantity"].ToString());
                    objBookModel.RentQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["RentQuantity"].ToString());
                    objBookModel.Images = _dtSet.Tables[0].Rows[0]["Images"].ToString();


                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return objBookModel;
        }
        #endregion

        #region GetAllBooks
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> lstBook = null;
            BookModel objBookModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BOOK_SELECT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstBook = new List<BookModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objBookModel = new BookModel();
                        objBookModel.BookName = _dtSet.Tables[0].Rows[i]["BookName"].ToString();
                        objBookModel.BookId = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["BookId"].ToString());
                        objBookModel.Price = Convert.ToDecimal(_dtSet.Tables[0].Rows[i]["Price"].ToString());
                        objBookModel.Quantities = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["Quantities"].ToString());
                        objBookModel.AvlQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["AvlQuantity"].ToString());
                        objBookModel.RentQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["RentQuantity"].ToString());
                       

                        lstBook.Add(objBookModel);
                    }
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                CloseConnection();
                DisposeConnection();
                objBookModel = null;
            }
            return lstBook;
        }
        #endregion
    }
}