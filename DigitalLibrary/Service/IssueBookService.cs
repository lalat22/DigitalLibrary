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
    public class IssueBookService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public IssueBookService()
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

        #region GetBooksByPublication
        public List<BookModel> GetBooksByPublication(string publication)
        {
            List<BookModel> lstBook = null;
            BookModel objBookModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BOOK_SELECT_By_PUBLICATION";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@Publication", publication);
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
                        //objBookModel.Price = Convert.ToDecimal(_dtSet.Tables[0].Rows[i]["Price"].ToString());
                        //objBookModel.Quantities = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["Quantities"].ToString());
                        //objBookModel.AvlQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["AvlQuantity"].ToString());
                        //objBookModel.RentQuantity = Convert.ToInt32(_dtSet.Tables[0].Rows[i]["RentQuantity"].ToString());


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